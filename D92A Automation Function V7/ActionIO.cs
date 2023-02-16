using D92A_Automation_Function_V7.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;

namespace D92A_Automation_Function_V7
{
    public partial class ActionIO : Form
    {
        //private Home home;
        private Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
        private List<stateBtn> stateBtns;

        private Items Items;
        private int item_id = -1;
        public ActionIO(Items Items)
        {
            InitializeComponent();
            this.Items = Items;
            this.item_id = Items.item_id;
        }
        private int action_id = -1;
        public ActionIO(Items Items, int action_id)
        {
            InitializeComponent();
            this.Items = Items;
            this.item_id = Items.item_id;
            this.action_id = action_id;
        }
        private modules.Actions ActionUpdate;
        private void ActionIO_Load(object sender, EventArgs e)
        {
            stateBtns = new List<stateBtn>();            
            for (int i = 1; i <= 16; i++)
            {
                if (i < 10)
                {
                    stateBtns.Add(new stateBtn { name = "R0" + i.ToString(), state = false });
                     this.stateBtn.Add("R0" + i.ToString(), false);
                }
                else
                {
                    stateBtns.Add(new stateBtn { name = "R" + i.ToString(), state = false });
                     this.stateBtn.Add("R" + i.ToString(), false);
                }
            }
            checkBoxON.Checked = true;

            if(action_id != -1)
            {
                btnSaveIO.Text = "Update";
                lbTitle.Text = "Update Action IO";
                ActionUpdate = modules.Actions.LoadActionsByID(action_id).First();
                // Set default patameter
                switch (ActionUpdate.io_type)
                {
                    case 0:
                        btnIO_TypeManual.Checked = true;
                        if (ActionUpdate.io_state == 1)
                            checkBoxON.Checked = true;
                        else
                            checkBoxOFF.Checked = true;
                        break;
                    case 1:
                        btnIO_TypeAuto.Checked = true;
                        txtAutoDelay.Value = ActionUpdate.auto_delay;
                        break;
                    case 2:
                        btnIO_TypeWaitJudgment.Checked = true;
                        break;
                }

                txtDelay.Value = ActionUpdate.delay;
                // Set default IO
                string IO = ActionUpdate.io_port;
                this.stateBtns.Where(x => x.name == IO).ToList().ForEach(x => x.state = true);
                this.stateBtns.Where(x => x.name != IO).ToList().ForEach(x => x.state = false);
                cancelOldState();
            }
        }


        private void IO_click(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Click");
            Button btn = (Button)sender;
            string name = btn.Name;
            this.stateBtn[name] = true;
            // If name is not same as key, set value to false 
            this.stateBtns.Where(x => x.name == name).ToList().ForEach(x => x.state = true);
            this.stateBtns.Where(x => x.name != name).ToList().ForEach(x => x.state = false);
            cancelOldState();
        }

        private void cancelOldState()
        {
            foreach (Panel panel in tableLayoutPanelAction.Controls)
            {
                foreach(Button btn in panel.Controls)
                {
                    updateColorBtn(btn);
                }
            }
        }
        private void updateColorBtn(Button button)
        {
            string name = button.Name;

            if(this.stateBtns.Where(x => x.name == name).ToList().First().state == true)
            {
                button.BackColor = Color.Green;
            }
            else
            {
                button.BackColor = Color.White;
            }            
        }
        private string getTxtBtn(string name)
        {
            foreach (Panel panel in tableLayoutPanelAction.Controls)
            {
                foreach (Button btn in panel.Controls)
                {
                    if(btn.Name == name)
                        return btn.Text;
                }
            }
            return string.Empty;
        }
        private bool isChecked()
        {
            if (btnIO_TypeAuto.Checked || btnIO_TypeManual.Checked || btnIO_TypeWaitJudgment.Checked)
            {
                return true;
            }
            return false;
        }
        private int TypeActionOfIO()
        {
            if(btnIO_TypeManual.Checked)
                return 0;
            else if(btnIO_TypeAuto.Checked)
                return 1;
            else if(btnIO_TypeWaitJudgment.Checked)
                return 2;

            return -1;
        }
        private void btnSaveIO_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string IOname = string.Empty;
                string IOPort = string.Empty;
                if (TypeActionOfIO() !=2)
                {

                    IOPort= this.stateBtns.Where(x => x.state == true).ToList().First().name;
                    // get text of tableLayoutPanelAction -> Panel -> button name is getStateBtnName
                    IOname = getTxtBtn(IOPort);         

                     // Validate 
                    if (IOname == string.Empty)
                    {
                        throw new Exception("Please select IO port!");
                    }
                }
                // get name of state button color green
                if (!isChecked())                    
                {
                  throw new Exception("Please select IO type!");
                }

                if(this.item_id == -1)
                {
                    throw new Exception("Please select item!");
                }

                modules.Actions actions = new modules.Actions();
                actions.item_id = item_id;
                actions.name = "IO Fuction";
                actions._type = 0;  // 0 = IO, 1 = Image

                actions.io_type = TypeActionOfIO();     // 0 = Manual, 1 = Auto, 2 = Wait judgment
                actions.io_state = checkBoxON.Checked ? 1 : 0;          // 0 = OFF,1 = ON
                actions.io_port = IOPort;
                actions.io_name = IOname;
                actions.io_timeout = (int)txtTimeOut.Value;
                actions.delay = (int)txtDelay.Value;
                actions.auto_delay = (int)txtAutoDelay.Value;
                actions.image_path = "-";
                actions.image_percent = 50;
                actions.image_status = 1;
                
                if(action_id != -1)
                {
                    actions.id = action_id;
                    actions.Update();
                }else{
                    actions.Save();
                }
               
                this.Items.LoadActionsList();
                stopwatch.Stop();
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation 007", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void checkBoxON_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxON.Checked)
            {
                checkBoxOFF.Checked = false;
            }
        }

        private void checkBoxOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOFF.Checked)
            {
                checkBoxON.Checked = false;
            }
        }
    }
    public class stateBtn
    {
        public string name { get; set; }
        public bool state { get; set; }
    }
}
