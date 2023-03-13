using D92A_Automation_Function_V7.Class;
using D92A_Automation_Function_V7.forms.ItemList;
using D92A_Automation_Function_V7.forms.ServoControls;
using D92A_Automation_Function_V7.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Emgu.CV.DISOpticalFlow;

namespace D92A_Automation_Function_V7
{
    public partial class Items : Form
    {
        public int model_id = -1;
        public int item_id = -1;
        private string[] type_items = { "Normal", "Manual", "Auto" };
        Models model;

        private string path_image = string.Empty;
        public Home home;
        private Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
        private LogWriter log;
        private bool stateTesting = false;
        private Thread thread;
        private BackgroundWorker _worker;
        public Items(int model_id)
        {
            InitializeComponent();
            this.model_id = model_id;
            model = new Models();
            model = Models.GetModelById(model_id);
            lbModelName.Text = model.name;
        }
        public Items(Home home)
        {
            InitializeComponent();
            this.model_id = home.modelId;
            this.home = home;
            model = new Models();
            model = Models.GetModelById(model_id);
            lbModelName.Text = model.name;
        }
        ActionImage actions;


        private void Items_Load(object sender, EventArgs e)
        {
            log = new LogWriter(Properties.Resources.path_log);
            log.Save("Items Starting....");
            LoadItemList();
            // Loop set default text are empty of statusStripHome
            foreach (ToolStripItem item in statusStrip.Items)
            {
                item.Text = string.Empty;
            }

            ProgressLoader();
        }
        int _total;
        public async void ProgressLoader()
        {
            log.Save("Close all IO");
            this.toolStripProgressLoader.Visible = true;
            int total = 16;
            for (int i = 0; i < total; i++)
            {
                int persent = (Int32)Math.Round((double)(i * 100) / total); // 

                toolStripProgressLoader.Value = persent;
                this.home.sendSerialCommand("0R" + (i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString()));
                await Task.Delay(100);
                this._total = i + 1;
            }
            await Task.Delay(100);
            this.home.sendSerialCommand("1S0");
            this.toolStripProgressLoader.Visible = false;
        }
        public void LoadItemList()
        {
            if (model_id == -1)
                return;
            dataGridViewItemList.DataSource = null;
            List<_ItemsList> items = _ItemsList.LoadItems(model_id);
            int i = 0;
            var data = (from x in items
                        select new
                        {
                            x.id,
                            No = ++i,
                            Name = x.name,
                            Type = type_items[x._type]
                        }).ToList();
            dataGridViewItemList.DataSource = data;
            dataGridViewItemList.Columns[0].Visible = false;
            dataGridViewItemList.Columns[1].Width = (int)(dataGridViewItemList.Width * 0.1);
        }
        public void LoadActionsList()
        {
            dataGridViewActionList.DataSource = null;
            if (item_id == -1)
                return;
            List<modules.Actions> actions = modules.Actions.LoadActionsID(item_id);
            int i = 0;
            var data = (from x in actions
                        select new
                        {
                            id = x.id,
                            No = ++i,
                            Type = x.name,
                            IO_Name = (x._type == 0) ? x.io_name : "-",
                            Action = getIOAction(x), 
                            IO_PORT = (x._type == 0) ? x.io_port : "-",
                            Image = (x._type == 1) ? x.image_path : "-",
                            Percent = (x._type == 1)? x.image_percent.ToString() :"-",
                            Delay = x.delay,
                            Date = x.created_at                           
                        }).ToList();
            dataGridViewActionList.DataSource = data;
            dataGridViewActionList.Columns[0].Visible = false;
            dataGridViewActionList.Columns[1].Width = (int)(dataGridViewActionList.Width * 0.1);
        }
        private string getIOAction(modules.Actions actions)
        {
            // Number Type --> 0 = Manual, 1 = Auto, 2 = Wait judment
            string str = string.Empty;
            if (actions._type == 0)
            {
                switch (actions.io_type)
                {
                    case 0:
                        // Manual
                        // 0 = OFF,1 = ON
                        if (actions.io_state == 1)
                        {
                            str = "On";
                        }
                        else
                        {
                            str = "Off";
                        }
                        break;
                    case 1:
                        str = "Auto";
                        break;
                    case 2:
                        str = "Wait judment";
                        break;
                }
                return str;
            }
            return "-";
        }
        private Add_Item add_item;

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(add_item != null)
                {
                    add_item?.Dispose();
                    add_item = null;
                    
                }
                add_item = new Add_Item(this);
                add_item.Name = "Add Item ";
                add_item.Show(this);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridViewItemList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewItemList.SelectedRows.Count > 0)
                {
                    dynamic row = dataGridViewItemList.SelectedRows[0].DataBoundItem;
                    item_id = int.Parse(row.id.ToString());

                    toolStripStatusItemId.Text = "Item ID : " + item_id.ToString();
                    //
                    if (item_id != -1)
                    {
                        LoadActionsList();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private int action_id = -1;
        private void dataGridViewActionList_SelectionChanged(object sender, EventArgs e)
        {

            // Get value columns 0
            if (dataGridViewActionList.SelectedRows.Count > 0)
            {
                dynamic row = dataGridViewActionList.SelectedRows[0].DataBoundItem;
                action_id = int.Parse(row.id.ToString());
                path_image = (row.Image != string.Empty)? row.Image : string.Empty; 
                toolStripStatusActionId.Text = "Action ID : " + action_id.ToString() + " Path : " + path_image;
                Console.WriteLine(action_id);
            }
        }


        private void deleteItemList_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?", "Confirm Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                modules.Actions.byItemToTemp(item_id);
                _ItemsList.Delete(item_id);
                LoadItemList();
            }
        }


        private void deleteActinList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to delete this action?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                modules.Actions.ToTemp(action_id);
                LoadActionsList();
            }         
        }
        View view;
        private void viewActionList_Click(object sender, EventArgs e)
        {
            if (path_image == string.Empty || path_image == "-")
            {
                return;
            }
            if (view != null)
            {
                view.Dispose();
            }
            view = new View(path_image);
            view.Show(this);
        }
        EditModel editModel;
        private void editModelNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editModel != null)
            {
                editModel.Dispose();
                editModel = null;
            }
            editModel = new EditModel(this,model_id);
            editModel.Show(this);
        }

        Edit_Item edit_Item;

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edit_Item != null)
            {
                edit_Item.Dispose();
                edit_Item = null;
            }
            edit_Item = new Edit_Item(this,item_id);
            edit_Item.Show(this);
        }

        
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (item_id != -1)
            {
                if(thread != null && thread.ThreadState == ThreadState.Running)
                {
                    thread.Abort();
                }
                if(_worker == null)
                {
                    _worker = new BackgroundWorker();
                    _worker.WorkerReportsProgress= true;
                    _worker.WorkerSupportsCancellation= true;
                    _worker.DoWork += _worker_DoWork;
                    _worker.ProgressChanged += _worker_ProgressChanged;
                    _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
                }  

                toolStripStatusTestting.Text = string.Empty;
                toolStripStatusTestting.Visible = true;
                toolStripProgressLoader.Visible = true;
                toolStripProgressLoader.Value = 0;

                stateTesting = !stateTesting;
                if (stateTesting == true)
                {
                    if (_worker.IsBusy == true && _worker.WorkerSupportsCancellation == true)
                    {
                        _worker.CancelAsync();
                    }
                    if (_worker.IsBusy != true)
                    {
                        // Start the asynchronous operation.
                        _worker.RunWorkerAsync(this);
                    }
                    btnTest.Text = "Stop";
                }
                else
                {
                    if (_worker.IsBusy == true && _worker.WorkerSupportsCancellation == true)
                    {
                        _worker.CancelAsync();
                    }
                    btnTest.Text = "Test";
                }
            }
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            log.Save("Testing Start");
            List<modules.Actions> actions = modules.Actions.LoadActionsID(item_id);
            Int32 counter = 0;
            foreach (modules.Actions action in actions)
            {
                string str = string.Empty;
                counter += 1;
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //// Perform a time consuming operation and report progress.
                    if (action._type == 0)
                    {
                        // Mode IO Function
                        if (action.io_type == 0)
                        {
                            //Console.WriteLine($"{action.io_state}{action.io_port}");

                            if (action.servo >0)
                            {
                                str = $"{action.servo}{action.io_port}";
                                this.home.sendSerialCommand(str);

                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {action.io_state}{action.io_port} ";
                            }
                            else
                            {
                                str = $"{action.io_state}{action.io_port}";
                                this.home.sendSerialCommand(str);

                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {action.io_state}{action.io_port} ";

                            }
                        }
                        else if (action.io_type == 1)
                        {
                            if(action.servo > 0)
                            {
                                str = $"{action.servo}{action.io_port}";
                                //str = $"1{action.io_port}";
                                this.home.sendSerialCommand(str);
                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {str} ";
                                Thread.Sleep(action.auto_delay);
                                str = $"{action.servo}S0";
                                this.home.sendSerialCommand(str);
                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {str} ";
                            }
                            else
                            {
                                str = $"1{action.io_port}";
                                this.home.sendSerialCommand(str);
                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 1{action.io_port} ";
                                Thread.Sleep(action.auto_delay);
                                str = $"0{action.io_port}";
                                this.home.sendSerialCommand(str);
                                toolStripStatusTestting.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 0{action.io_port} ";
                            }
                        }
                    }
                    else if (action._type == 1)
                    {
                        int ngCount = 0;
                        process_compare:
                        var result = this.home.ProcessCompare(action.image_path);
                        //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Image Comapre result : {result}%, config :{action.image_percent} ");
                        toolStripStatusTestting.Text = result.ToString();
                        if (result < action.image_percent)
                        {
                            // Test Again
                            ngCount++;
                            if (ngCount < 10)
                            {
                                //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Test again : ---{ngCount}--- ");
                                Thread.Sleep(100);
                                goto process_compare;
                            }
                            // Test 
                            //txtProcessDetailsAppendText("Judement NG");
                            //Console.WriteLine("Judement NG");
                            // End process
                        }
                        else
                        {
                            //txtProcessDetailsAppendText("Judement OK");
                            //Console.WriteLine("Judement OK");
                            toolStripStatusTestting.Text = "Judement OK";
                        }
                    }
                    else if (action._type == 2)
                    {
                        // Wait test 

                        this.home.stateReceivedData = false;
                        this.home.btnReceivedData = string.Empty;
                        // 1 se
                        int timeOut = action.io_timeout * 1000;
                        int _counter = 0;
                        int _countTime = 0;
                        while (counter <= timeOut)
                        {
                            if (this.home.stateReceivedData == true)
                            {
                                break;
                            }
                            Thread.Sleep(50);
                            _counter++;
                            _countTime++;
                            if (_countTime > 10)
                            {
                                //txtProcessDetailsAppendText(".", true);
                                log.Save(".",false);
                            }
                        }
                        if (this.home.stateReceivedData && this.home.btnReceivedData != string.Empty)
                        {
                            toolStripStatusTestting.Text = "Pressed button OK";
                            log.Save("Pressed button OK");
                        }
                        else if (this.home.stateReceivedData && this.home.btnReceivedData != string.Empty)
                        {
                            //txtProcessDetailsAppendText("Pressed button NG");
                            toolStripStatusTestting.Text = "Pressed button NG";
                            log.Save("Pressed button NG");
                        }
                        else
                        {
                            //txtProcessDetailsAppendText("Time Out!!");
                            toolStripStatusTestting.Text = "Time Out!!";
                            log.Save("Time Out!!");
                            break;
                        }
                    }

                    Thread.Sleep(action.delay);

                    int persent = (Int32)Math.Round((double)(counter * 100) / actions.Count); // 
                    worker.ReportProgress(persent);
                }
                stateTesting = false;
            }
         }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressLoader.Value = e.ProgressPercentage;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusTestting.Text = string.Empty;
            toolStripStatusTestting.Visible = false;
            toolStripProgressLoader.Visible = false;
            log.Save("Testing End");
            btnTest.Text = "Test";
        }
        private void processTesting()
        {
            List<modules.Actions> actions = modules.Actions.LoadActionsID(item_id);
            Int32 counter = 0;
            toolStripStatusTestting.Text = string.Empty;
            toolStripStatusTestting.Visible = true;
            foreach (modules.Actions action in actions)
            {
                counter+=1;
                //Console.WriteLine(action._type);
                if (action._type == 0)
                {
                    // Mode IO Function
                    if (action.io_type == 0)
                    {
                        //Console.WriteLine($"{action.io_state}{action.io_port}");
                        this.home.sendSerialCommand($"{action.io_state}{action.io_port}");
                        //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {action.io_state}{action.io_port} ");
                    }
                    else if (action.io_type == 1)
                    {
                        this.home.sendSerialCommand($"1{action.io_port}");
                        //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 1{action.io_port} ");
                        Thread.Sleep(action.auto_delay);
                        this.home.sendSerialCommand($"0{action.io_port}");
                        //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 0{action.io_port} ");
                    }

                }

                else if (action._type == 1)
                {
                     int ngCount = 0;
                      process_compare:
                    var result = this.home.ProcessCompare(action.image_path);
                    //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Image Comapre result : {result}%, config :{action.image_percent} ");
                    if (result < action.image_percent)
                    {
                        // Test Again
                        ngCount++;
                        if (ngCount < 10)
                        {
                            //txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Test again : ---{ngCount}--- ");
                            Thread.Sleep(100);
                            goto process_compare;
                        }
                        // Test 
                        //txtProcessDetailsAppendText("Judement NG");
                        //Console.WriteLine("Judement NG");
                        // End process
                    }
                    else
                    {
                        //txtProcessDetailsAppendText("Judement OK");
                        //Console.WriteLine("Judement OK");
                    }
                }
                else if (action._type == 2)
                {
                    // Wait test 

                    this.home.stateReceivedData = false;
                    this.home.btnReceivedData = string.Empty;
                    // 1 se
                    int timeOut = action.io_timeout * 1000;
                    int _counter = 0;
                    int _countTime = 0;
                    while (counter <= timeOut)
                    {
                        if (this.home.stateReceivedData == true)
                        {
                            break;
                        }
                        Thread.Sleep(50);
                        _counter++;
                        _countTime++;
                        if (_countTime > 10)
                        {
                            //txtProcessDetailsAppendText(".", true);
                        }
                    }
                    if (this.home.stateReceivedData && this.home.btnReceivedData != string.Empty)
                    {
                        //txtProcessDetailsAppendText("Pressed button OK");
                    }
                    else if (this.home.stateReceivedData && this.home.btnReceivedData != string.Empty)
                    {
                        //txtProcessDetailsAppendText("Pressed button NG");
                    }
                    else
                    {
                        //txtProcessDetailsAppendText("Time Out!!");
                    }
                }

                Thread.Sleep(action.delay);
            }
            stateTesting = false;
        }

        private void Items_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_total <= 15)
            {
                e.Cancel = true;
                MessageBox.Show(Properties.Resources.process_is_runing, "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        ActionIO actionIO;
        private void btnAdd_IO_Click(object sender, EventArgs e)
        {
            if(item_id == -1)
            {
                MessageBox.Show(Properties.Resources.please_select_item, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(actionIO != null)
            {
                actionIO.Close();
                actionIO.Dispose();
            }

            actionIO = new ActionIO(this);
            actionIO.Show();
        }

        private void btnAddActionImage_Click(object sender, EventArgs e)
        {
            if (item_id == -1)
            {
                MessageBox.Show(Properties.Resources.please_select_item, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (actions != null)
            {
                actions.Close();
            }
            actions = new ActionImage(this);
            actions.Show(this);
        }


        private ServoControls servo;
        private void editDelayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (action_id == -1)
            {
                MessageBox.Show(Properties.Resources.please_select_action, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var action = modules.Actions.LoadActionsByID(action_id).First();
            if (action._type == 1)
            {
                if (actions != null)
                {
                    actions.Close();
                }
                actions = new ActionImage(this, action.id);
                actions.Show(this);
            }
            else
            {
                if (action.servo > 0)
                {
                    if (servo != null)
                    {
                        servo.Close();

                    }

                    servo = new ServoControls(this, action.id);
                    servo.Show();
                }
                else
                {
                    if (actionIO != null)
                    {
                        actionIO.Close();
                        actionIO.Dispose();
                    }

                    actionIO = new ActionIO(this, action.id);
                    actionIO.Show();
                }
              
            }
        }

        private void btAddServo_Click(object sender, EventArgs e)
        {
         
        }
    }
}
