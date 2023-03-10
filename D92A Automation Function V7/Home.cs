using D92A_Automation_Function_V7.modules;
using DirectShowLib;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using OpenCvSharp.Extensions;
using System.Runtime.InteropServices;
using D92A_Automation_Function_V7.VideoTCapture;
using D92A_Automation_Function_V7.Class;
using System.Timers;
using System.Reflection;
using static Emgu.CV.DISOpticalFlow;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace D92A_Automation_Function_V7
{
    public partial class Home : Form
    {
        public Home() => InitializeComponent();

        #region Global Variable
        private string[] type_items = { "Normal", "Manual", "Auto" };
        public string[] masterNameKeys =
        {
            "BAT+",
            "ACC+",
            "V+ REAR CAMERA",
            "V- REAR CAMERA",
            "ALRAM RED",
            "ALRAM YOLLOW",
            "ALRAM GREEN",
            "ALRAM SOUND",
            "SLD 45° 1",
            "SLD 45° 2",
            "SLD 45° 3",
            "SLD 45° 4",
            "SLD 90° 1",
            "SLD 90° 2",
            "SLD 90° 3",
            "SLD 90° 4",
        };
        public int modelId = -1;
        public Dictionary<string, string[,]> keysSLD = new Dictionary<string, string[,]>();

        private bool isCapturing = false;
        private System.Windows.Forms.Timer timerVideo;
        private string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        public string _path = @"./system";

        private string _baudRate = string.Empty;
        private string _serialPortName = string.Empty;

        private SerialPort _SerialPort;
        private Login login;
        private Thread thread;
        private int _indexDriverCamera = -1;

        private BackgroundWorker _worker;

        public Bitmap bitmapCamera;
        public string ReadDataSerial;
        public string dataSerialReceived;
        public bool stateReceivedData = false;
        public string btnReceivedData = string.Empty;

        private TCapture.Capture _Tcapture;

        private LogWriter log;

        private bool blink = false;
        private bool blinkRuning = false;
        private delegate void ProcessUpdate(int value);
        private ProcessUpdate onProcessUpdate;
        private ProcessUpdate onProcessClose;
        private ProcessUpdate onProcessStart;

        private bool isTesting = false;
        private bool lockImage = false;
        private int oldSelectModel = -1;
        #endregion

        #region Form Home Load

        private void Home_Load(object sender, EventArgs e)
        {
            log = new LogWriter(Properties.Resources.path_log);
            log.Save("From loading");

            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            this._Tcapture = new TCapture.Capture();
            this._Tcapture.OnFrameHeadler += _Tcapture_OnFrameHeadler;
            this._Tcapture.OnVideoStarted += _Tcapture_OnVideoStarted;
            this._Tcapture.OnVideoStop += _Tcapture_OnVideoStop;
            foreach (DsDevice device in drive)
            {
                comboBoxDriveCamera.Items.Add(device.Name);
            }
            if (comboBoxDriveCamera.Items.Count > 0)
                comboBoxDriveCamera.SelectedIndex = 0;

            comboBoxBaudList.Items.AddRange(baudList);
            if (comboBoxBaudList.Items.Count > 0)
                comboBoxBaudList.SelectedIndex = comboBoxBaudList.Items.Count - 1;

            comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxSerialPort.Items.Count > 0)
                comboBoxSerialPort.SelectedIndex = comboBoxSerialPort.Items.Count - 1;

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            // Loop set default text are empty of statusStripHome
            foreach (ToolStripItem item in statusStripHome.Items)
            {
                item.Text = string.Empty;
            }

            // Add key to dictionary
            for (int i = 0; i < masterNameKeys.Length; i++)
            {
                keysSLD.Add(masterNameKeys[i], new string[,] { { "0R" + (i + 1).ToString("00"), "1R" + (i + 1).ToString("00") } });
            };
            // Delete file
            modules.Actions.DeleteTemp();

            btnCheckBoxAuto.Checked = true;

            onProcessUpdate += _ProcessUpdate;

            loadhistoty();
        }

        private void _Tcapture_OnVideoStop()
        {
            log.Save("Camera Stop");
        }
        #endregion
        private void _Tcapture_OnVideoStarted()
        {
            log.Save("Camera Started");
        }

        private delegate void FrameVideo(Bitmap bitmap);

        private void _Tcapture_OnFrameHeadler(Bitmap bitmap)
        {
            // If invoke is required, invoke it
            if (pictureBoxCamera.InvokeRequired)
            {
                pictureBoxCamera.Invoke(new FrameVideo(_Tcapture_OnFrameHeadler), bitmap);
                return;
            }

            else
            {
                pictureBoxCamera.SuspendLayout();
                pictureBoxCamera.Image = (Image)bitmap.Clone();
                bitmapCamera = (Bitmap)pictureBoxCamera.Image.Clone();                
                pictureBoxCamera.ResumeLayout();
            }
        }

        #region Serial port
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReadDataSerial = _SerialPort.ReadExisting();
                this.Invoke(new EventHandler(dataReceived));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private double _currnet_mA = 0;
        private double _dc_Voltage = 0;
        private void dataReceived(object sender, EventArgs e)
        {
            try
            {
                dataSerialReceived += ReadDataSerial;
                if (dataSerialReceived.Contains(">") && dataSerialReceived.Contains("<"))
                {
                    string data = dataSerialReceived.Replace("\r\n", string.Empty);
                    dataSerialReceived = string.Empty;
                    // [1][2][3][4][5][6][7]
                    //  >  1  1  1  1  1  < 
                    int indexStart = data.IndexOf(">") + ">".Length;
                    int indexEnd = data.IndexOf("<");
                    data = data.Substring(indexStart, indexEnd - indexStart);
                    Console.WriteLine("Received : " + data);
                    data = data.Replace(">", string.Empty).Replace("<", string.Empty);
                    log.Save("Serial Received :" + data);
                    if (data == "start")
                    {
                        blinkRuning = false;
                        pictureBoxDetect.Visible = true;
                        TestingToolStripMenuItem.PerformClick();
                    }
                    else if (data == "end")
                    {

                    }else if(data == "OK" || data == "NG")
                    {
                        if (data == "OK")
                            btnReceivedData = "OK";
                        if (data == "NG")
                            btnReceivedData = "NG";
                        stateReceivedData = true;
                        
                    }

                    string[] findKeyValue = data.Split(':');

                    if (findKeyValue.Length == 2)
                    {
                        switch (findKeyValue[0])
                        {
                            case "C1":
                                _currnet_mA = Double.Parse(findKeyValue[1]);
                                toolStripStatusCurrent.Text = _currnet_mA.ToString() + "mA.";
                                break;
                            case "C2":
                                _dc_Voltage = int.Parse(findKeyValue[1]) / 10;
                                Console.WriteLine($"C2 : {_dc_Voltage.ToString()}");
                                break;

                        }
                    }
                    ReadDataSerial = "";
                }
                else if (!dataSerialReceived.Contains(">"))
                {
                    dataSerialReceived = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void sendSerialCommand(string command)
        {
            try
            {
                if (_SerialPort != null && _SerialPort.IsOpen)
                {

                    _SerialPort.Write(">" + command + "<#");
                    toolStripStatusSerialDetails.Text = "Send : " + command;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                log.Save("bt Start camera!");
                isCapturing = !isCapturing;

                if (isCapturing)
                {
                    if (_indexDriverCamera == -1)
                        throw new Exception("Please select a camera drive!");

                    if (_Tcapture != null && _Tcapture.IsOpened)
                    {
                        _Tcapture.Stop();
                    }
                    if (comboBoxDriveCamera.SelectedIndex == -1)
                        throw new Exception("Please select a camera drive!");

                    
                    //Task.Factory.StartNew(() => _Tcapture.Start(comboBoxDriveCamera.SelectedIndex));
                    int index = comboBoxDriveCamera.SelectedIndex;
                    _Tcapture.Start(index);
                    //Task.Factory.StartNew(()=> _Tcapture.Start(index));



                    _SerialPort = new SerialPort(_serialPortName, int.Parse(_baudRate));
                    _SerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                    _SerialPort.Open();

                    isTesting = false;

                    sendSerialCommand("conn");
                    Thread.Sleep(50);
                    sendSerialCommand("conn");
                    btnStartStop.Text = "STOP";
                }
                else
                {
                    if (_Tcapture != null && _Tcapture.IsOpened)
                    {
                        _Tcapture.Stop();
                    }

                    if (_SerialPort != null || _SerialPort.IsOpen)
                    {
                        sendSerialCommand("close");
                        _SerialPort.Close();
                        _SerialPort.Dispose();
                        _SerialPort.DataReceived -= serialPort_DataReceived;
                    }

                    //_SerialPort = null;

                    btnStartStop.Text = "START";
                    //pictureBoxCamera.Image = null;
                }
                update_status();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation 01", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isCapturing = false;
                if (_Tcapture.IsOpened)
                    _Tcapture.Stop();

                if (_SerialPort != null && _SerialPort.IsOpen)
                    _SerialPort.Close();

                update_status();
            }
        }

        private void update_status()
        {
            // Update Serial Port Sataus
            if (_SerialPort != null && _SerialPort.IsOpen)
            {
                toolStripStatusSerialPort.Text = "Serial Port : connected";
                toolStripStatusSerialPort.ForeColor = Color.Green;
            }
            else if (_SerialPort == null || !_SerialPort.IsOpen)
            {
                toolStripStatusSerialPort.Text = "Serial Port : Disconnected";
                toolStripStatusSerialPort.ForeColor = Color.Red;
            }
        }

        private void btnConnectionSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBoxDriveCamera.SelectedIndex == -1)
                    throw new Exception("Please select a camera drive!");

                _indexDriverCamera = comboBoxDriveCamera.SelectedIndex;

                if (comboBoxBaudList.SelectedIndex == -1)
                    throw new Exception("Please select a baud rate!");

                _baudRate = comboBoxBaudList.SelectedItem.ToString();

                if (comboBoxSerialPort.SelectedIndex == -1)
                    throw new Exception("Please select a serial port!");
                _serialPortName = comboBoxSerialPort.SelectedItem.ToString();

                // Update to toolStripStatusConection status
                toolStripStatusConection.Text = $"Camera : {_indexDriverCamera} | Baud Rate : {_baudRate} | Serial Port : {_serialPortName}";
                btnStartStop.PerformClick();
                MessageBox.Show("Save connection success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        Items items;
        private void btnEditModel_Click(object sender, EventArgs e)
        {
            if (modelId == -1)
            {
                MessageBox.Show("Please select a model!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (items != null)
            {
                items.Close();
                items.Dispose();
            }
            items = new Items(this);
            items.Show();
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            AddModel model = new AddModel(this);
            model.ShowDialog();
        }
        Test_IO io;
        private void iOTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (io != null)
            //{
            //    io.Close();
            //    io.Dispose();
            //}
            //io = new Test_IO(this);
            //io.Show();


            if (_SerialPort != null && _SerialPort.IsOpen)
            {
                if (io != null)
                {
                    io.Close();
                    io.Dispose();
                }
                io = new Test_IO(this);
                io.Show();
            }
            else
            {
                MessageBox.Show("Please connect to serial port!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_SerialPort != null && _SerialPort.IsOpen)
            {
                sendSerialCommand("close");
                _SerialPort.Close();
                _SerialPort.Dispose();
            }
            if (_Tcapture != null)
            {
                _Tcapture.Stop();
                _Tcapture.Dispose();
            }
        }

        internal void loadModel()
        {
            try
            {
                dataGridViewModelList.DataSource = null;
                List<Models> models = Models.GetModelsAll();
                int num = 1;
                var data = (from x in models
                            select new
                            {
                                x.id,
                                No = num++,
                                Models_Name = x.name,
                                Description = x.description,
                                Date = x.created_at,
                            }).ToList();

                dataGridViewModelList.DataSource = data;
            
                dataGridViewModelList.Columns["No"].Width = (int)(dataGridViewModelList.Width * 0.1);
                if (modelId != -1)
                {
                    // Select row by modelId 
                    foreach (DataGridViewRow row in dataGridViewModelList.Rows)
                    {
                        dataGridViewModelList.Rows[row.Index].Selected = false;
                        if (row.Cells["id"].Value.ToString() == modelId.ToString())
                        {
                            dataGridViewModelList.Rows[row.Index].Selected = true;
                            break;
                        }
                    }
                }
                onloadModel = false;
                    dataGridViewModelList.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool onloadModel =false;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                onloadModel = true;
                loadModel();
            }
        }

        private void dataGridViewModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditModel.PerformClick();
        }

        private void dataGridViewModelList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {               
                if (dataGridViewModelList.SelectedRows.Count > 0)
                {
                    dynamic row = dataGridViewModelList.SelectedRows[0].DataBoundItem;
                    this.modelId = int.Parse(row.id.ToString());
                    lbModelName.Text = row.Models_Name;
                    toolStripStatusLabelModelID.Text = "Model ID :" + this.modelId.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation 02", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modules.Models.Delete(this.modelId);
            loadModel();
        }
        List<_ItemsList> _Items;
        List<modules.Actions> actions;

        private void _ProcessUpdate(int value)
        {
            if(toolStripProgressTesting.GetCurrentParent().InvokeRequired) {
                toolStripProgressTesting.GetCurrentParent().Invoke(new ProcessUpdate(_ProcessUpdate),value);
                return;
            }
            else
            {
                toolStripProgressTesting.Value = value;
            }
        }

        private void setLBResult(string _input)
        {
            Color colBG = Color.White;
            Color colTxt = Color.White;

            switch (_input.ToUpper())
            {
                case "OK":
                    colBG = Color.Green;
                    colTxt = Color.Black;
                    break;

                case "NG":
                    colBG = Color.Red;
                    colTxt = Color.White;
                    break;
                case "ERROR":
                    colBG = Color.Red;
                    colTxt = Color.White;
                    break;
                default:
                    colBG = Color.Yellow;
                    colTxt =Color.Black;
                    break;
            }

            if (lbResult.InvokeRequired)
            {
                lbResult.Invoke((MethodInvoker)delegate {
                    lbResult.Text = _input;
                    lbResult.BackColor = colBG;
                    lbResult.ForeColor = colTxt;
                });
            }
            else
            {
                lbResult.Text = _input;
                lbResult.BackColor = colBG;
                lbResult.ForeColor = colTxt;
            }
        }
        private void ProcessTesting()
        {
            if (modelId == -1)
            {
                MessageBox.Show("Please select model!");
                return;
                throw new Exception("Please select model!");
            }

            for (int i = 0; i < 16; i++)
            {
                sendSerialCommand("0R" + (i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString()));
                Thread.Sleep(50);
                int persent = (Int32)Math.Round((double)(i * 100) / 16); // 
                onProcessUpdate.Invoke(persent);
            }

            onProcessUpdate.Invoke(0);
            _Items = null;
            _Items = _ItemsList.LoadItems(modelId);
            if (txtProcessDetails.InvokeRequired)
                txtProcessDetails.Invoke((MethodInvoker)delegate { txtProcessDetails.Text = string.Empty; });
            bool toggle = false;
            int _counter = 0;
            int _counter_process = 0;
            bool found_NG = false;
            string found_NG_details = string.Empty;
            int countallActions = Process.getCountAllProcess(modelId);
            txtProcessDetailsAppendText($"Actions total :{countallActions}");
            foreach (_ItemsList item in _Items)
            {
                txtProcessDetailsAppendText($"Item : {item.name} ");
                if (btnCheckBoxAuto.Checked && item._type == 1)
                {
                    continue;
                }
                else if (btnCheckBoxManual.Checked && item._type == 2)
                {
                    continue;
                }
                actions = null;
                actions = modules.Actions.LoadActionsID(item.id);
                foreach (modules.Actions action in actions)
                {
                    toggle = !toggle;             
                    if (toggle)
                        setLBResult("Testing..");
                    else
                        setLBResult("Testing....");                    

                    _counter++;
                    int persent = (Int32)Math.Round((double)(_counter * 100) / countallActions); // 
                    onProcessUpdate.Invoke(persent);

                    _counter_process++;
                    if (_counter_process > 2 && _counter_process < countallActions -10 && _currnet_mA < 2.00)
                    {
                        // Checking current 
                        found_NG = true;
                        found_NG_details = "Current is too low";
                        break;
                    }


                    if (action._type == 0)
                    {
                        
                        // Mode IO Function
                        if (action.io_type == 0)
                        {
                            // Console.WriteLine($"{action.io_state}{action.io_port}");
                            sendSerialCommand($"{action.io_state}{action.io_port}");
                            txtProcessDetailsAppendText($"IO data : {action.io_state}{action.io_port} ");
                        }
                        else if (action.io_type == 1)
                        {
                            // Auto
                            sendSerialCommand($"1{action.io_port}");
                            txtProcessDetailsAppendText($"IO data : 1{action.io_port} ");
                            Thread.Sleep(action.auto_delay);
                            sendSerialCommand($"0{action.io_port}");
                            txtProcessDetailsAppendText($"IO data : 0{action.io_port} ");
                        }
                        else if (action.io_type == 2)
                        {
                            // Wait Judgement OK or NG
                            setLBResult("Please Judgement");
                            stateReceivedData = false;
                            btnReceivedData = string.Empty;
                            // 1 se
                            int timeOut = action.io_timeout * 1000;
                            int counter = 0;
                            int countTime = 0;
                            while (counter <= timeOut)
                            {
                                if (stateReceivedData == true)
                                {
                                    break;
                                }
                                Thread.Sleep(50);
                                counter+=50;
                                countTime++;
                                if (countTime > 10)
                                {
                                    txtProcessDetailsAppendText(".", true);
                                    countTime = 0;
                                }

                            }
                            if (stateReceivedData && btnReceivedData != string.Empty && btnReceivedData == "OK")
                            {
                                txtProcessDetailsAppendText("Pressed button OK");
                            }
                            else if (stateReceivedData && btnReceivedData != string.Empty && btnReceivedData == "NG")
                            {
                                found_NG = true;
                                found_NG_details = "Pressed button NG";
                            }
                            else
                            {
                                found_NG = true;
                                found_NG_details = "Time Out!!";
                            }
                        }

                        // End type
                    }
                    else if (action._type == 1)
                    {
                        // Start type 1 compare image
                        int ngCount = 0;
                        process_compare:
                        var result = ProcessCompare(action.image_path);
                        txtProcessDetailsAppendText($"Image Comapre result : {result}%, config :{action.image_percent} ");
                        if (result < action.image_percent)
                        {
                            // Test Again
                            ngCount++;
                            if (ngCount < 15)
                            {
                                txtProcessDetailsAppendText($"Test again : ---{ngCount}--- ");
                                Thread.Sleep(150);
                                goto process_compare;
                            }
                            txtProcessDetailsAppendText("Judement NG");
                            // End process
                            found_NG = true;
                        }
                        else
                        {
                            txtProcessDetailsAppendText("Judement OK");
                        }
                        // End type 1 
                    }
                   
                    if (found_NG)
                    {
                        break;
                    }

                    Thread.Sleep(action.delay);
                }
                if (found_NG)
                {
                    break;
                }
            }
            isTesting = false;

            if (found_NG)
            {
                setLBResult("NG");
                txtProcessDetailsAppendText($"NG : {found_NG_details}");
            }
            else
            {
                setLBResult("OK");
            }
            /*
            sendSerialCommand("0R03");
            Thread.Sleep(30);
            sendSerialCommand("0R04");
            Thread.Sleep(30);
            sendSerialCommand("0R02");
            Thread.Sleep(1000);
            sendSerialCommand("0R01");
            */
            // End Process
            try
            {
                var history = new History();
                history.employee_id = txtName.Text;
                history.serial_no = txtSerialProduct.Text;
                history.result = found_NG ? "NG" : "OK";
                // Get txtProcessDetails
                history.details = found_NG_details;
                history.Save();
                //// Load history
                loadhistoty();
                Invoke(new Action(() =>
                {
                    pictureBoxDetect.Image = null;
                    txtSerialProduct.Text = "";
                    this.ActiveControl = txtSerialProduct;
                    txtSerialProduct.Focus();

                }));


            }
            catch(Exception ex)
            {
                log.SaveLog("Error h001" + ex.Message);
            }
            txtProcessDetailsAppendText("End Process");
            Console.WriteLine("End Process");
            sendSerialCommand("end");

        }

        private delegate string getTxtProcessDetails();

        private string getTxtProcessDetailsText()
        {
            if (this.InvokeRequired)
            {                
                return (string)this.Invoke(new getTxtProcessDetails(getTxtProcessDetailsText));
            }
            return txtProcessDetails.Text;
        }

        private delegate void loadhoistory();

        private void loadhistoty()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new loadhoistory(loadhistoty));
                return;
            }
            var list = History.LoadHistory();
            dataGridViewHistory.DataSource = null;
            int i = 0;
            var data = (from item in list
                        select new
                        {
                            id = item.id,
                            No = ++i,
                            employee_id = item.employee_id,
                            serial_no = item.serial_no,
                            result = item.result,
                            details = item.details,
                            created_at = item.created_at
                        }).ToList();

            dataGridViewHistory.DataSource = data;
            dataGridViewHistory.Columns["id"].Visible = false;            
            
        }

        public void txtProcessDetailsAppendText(string data, bool noNewLine = false)
        {
            if (txtProcessDetails.InvokeRequired)
            {
                txtProcessDetails.Invoke((MethodInvoker)delegate
                {
                    string newLine = noNewLine ? "" : Environment.NewLine;
                    string date = DateTime.Now.ToString("HH:mm:ss");
                    string txt = $"{date} ->{data} {newLine}";
                    if (noNewLine) txt = data;
                    txtProcessDetails.AppendText(txt);
                    txtProcessDetails.ScrollToCaret();
                });
            }
            else
            {
                string newLine = noNewLine ? "" : Environment.NewLine;
                string date = DateTime.Now.ToString("HH:mm:ss");
                string txt = $"{date} ->{data} {newLine}";
                if (noNewLine) txt = data;
                txtProcessDetails.AppendText(txt);
                txtProcessDetails.ScrollToCaret();
            }
        }

        public double ProcessCompare(string path_master)
        {
            if (!File.Exists(path_master))
                throw new Exception("File master not found!!");

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> image_master = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(path_master).Clone();
            // LockImage = true;
            string path_temp = Properties.Resources.path_temp+"/" + Guid.NewGuid().ToString() + ".jpg";

            Bitmap match = Matching(image_master.ToBitmap(), imageSlave: bitmapCamera);
            pictureBoxDetect.Image = new Bitmap(match);

            path_temp = Properties.Resources.path_temp + "/" + Guid.NewGuid().ToString() + ".jpg";

            if (!Directory.Exists(Properties.Resources.path_temp))
                Directory.CreateDirectory(Properties.Resources.path_temp);
            match.Save(path_temp, System.Drawing.Imaging.ImageFormat.Jpeg);
            double result = Compare(image_master, new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(path_temp));

            image_master.Dispose();
            match.Dispose();

            if (File.Exists(path_temp))
                File.Delete(path_temp);

            return result;
        }

        public double Compare(Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> imageMaster, Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> imageSlave, string path = null, string stepname = null)
        {
            try
            {
                if (imageMaster.Width != imageSlave.Width || imageMaster.Height != imageSlave.Height)
                {
                    return 0;
                }
                var diffImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(imageMaster.Width, imageMaster.Height);
                // Get the image of different pixels.
                Emgu.CV.CvInvoke.AbsDiff(imageMaster, imageSlave, diffImage);

                var threadholdImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(imageMaster.Width, imageMaster.Height);
                // Check the pixies difference.
                // For instance, if difference between the same pixel on both image are less then 20,
                // we can say that this pixel is the same on both images.
                // After threadholding we would have matrix on which we would have 0 for pixels which are "nearly" the same and 1 for pixes which are different.
                Emgu.CV.CvInvoke.Threshold(diffImage, threadholdImage, 20, 1, Emgu.CV.CvEnum.ThresholdType.Binary);
                int diff = Emgu.CV.CvInvoke.CountNonZero(threadholdImage);

                // Take the percentage of the pixels which are different.
                var deffPrecentage = diff / (double)(imageMaster.Width * imageMaster.Height);
                if (path != null)
                {
                    string name = "D-";
                    if (stepname != null)
                    {
                        name += stepname;
                    }
                    var fileName = $@"{name}{DateTime.Now.Ticks}_DIF.jpg";
                    string pathDiffImage = System.IO.Path.Combine(path, fileName);
                    diffImage.Save(pathDiffImage);
                }

                diffImage.Dispose();
                threadholdImage.Dispose();
                // If the amount of different pixeles more then 15% then we can say that those immages are different.
                var percent = deffPrecentage * 100;
                // round off
                return Math.Round(100 - percent, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E006" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private Bitmap Matching(Bitmap imageMaster, Bitmap imageSlave, string path_save = null)
        {
            try
            {
                var imgScene = imageSlave.ToImage<Bgr, byte>();// new Bitmap(@"D:\CPush\Image\008.JPG").ToImage<Bgr, byte>(); // Image imput
                var template = imageMaster.ToImage<Bgr, byte>(); // new Bitmap(@"D:\CPush\Image\007.JPG").ToImage<Bgr, byte>(); // Master 
                string pathCurrent = Directory.GetCurrentDirectory();

                Emgu.CV.Mat imgout = new Emgu.CV.Mat();

                CvInvoke.MatchTemplate(imgScene, template, imgout, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);

                double minVal = 0.0;
                double maxVal = 0.0;
                Point minLoc = new Point();
                Point maxLoc = new Point();

                CvInvoke.MinMaxLoc(imgout, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                Rectangle r = new Rectangle(maxLoc, template.Size);
                var imgCrop = imgScene.Copy(r);
                CvInvoke.Rectangle(imgScene, r, new MCvScalar(0, 0, 255), 2);

                if (path_save != null)
                {
                    imgScene.Save(path_save);
                }
                return imgCrop.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("E007 " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void loginToolStripMenuIteam_Click(object sender, EventArgs e)
        {
            if (login != null)
            {
                login.Dispose();
            }

            login = new Login(this);
            login.Show(this);
        }

        private void TestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Vavidate
            if (string.IsNullOrEmpty(_path))
            {
                MessageBox.Show("Please select path to save image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSerialProduct.Text == "")
            {
                MessageBox.Show("Please enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (isTesting)
            {
                MessageBox.Show(Properties.Resources.process_is_runing, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 
            sendSerialCommand("run");
            //ProcessTesting();
          
            if (thread != null)
            {
                thread.Abort();
                thread.DisableComObjectEagerCleanup();
                thread = null;
            }
            toolStripProgressTesting.Visible = true;
            toolStripProgressTesting.Value = 0;
            isTesting = true;
            pictureBoxDetect.Image = null;
            thread = new Thread(new ThreadStart(ProcessTesting));
            thread.Start();           
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            // Size of Home
            // int width = this.Width;
            // int height = this.Height;
            // Console.WriteLine("Width: " + width + " Height: " + height);

            if (this.Width > 1390)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 700;
            }
            else if (this.Width > 1500)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 800;
            }
            else if (this.Width > 1600)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 900;
            }
            else if (this.Width > 1700)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 1100;
            }
            else if (this.Width > 1900)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 1300;
            }
            else
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 505;
            }
        }

        public string resultTesting = "NG";

        private void timerNG_Tick(object sender, EventArgs e)
        {
            if (blinkRuning)
            {
                blink = !blink;
                if (blink)
                {
                    lbResult.BackColor = Color.White;
                    lbResult.ForeColor = Color.Red;
                }
                else
                {
                    lbResult.BackColor = Color.Red;
                    lbResult.ForeColor = Color.White;
                }
            }
            else
            {
                blinkRuning = false;

                if (lbResult.Text == "NG" || lbResult.Text == "ERROR")
                {
                    lbResult.BackColor = Color.Red;
                    lbResult.ForeColor = Color.White;
                }
                else
                {
                    lbResult.BackColor = Color.Green;
                    lbResult.ForeColor = Color.White;
                }
                timerNG.Stop();
            }
        }

        private void timerCounter_Tick(object sender, EventArgs e)
        {

        }
       
    }

}