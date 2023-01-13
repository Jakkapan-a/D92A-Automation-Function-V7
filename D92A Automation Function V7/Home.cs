using DirectShowLib;
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

namespace D92A_Automation_Function_V7
{
    public partial class Home : Form
    {
        public Home() => InitializeComponent();

        //public string[,] keys = {
        //    { "0R01", "1R01" }, // BAT + ON OFF
        //    { "0R02", "1R02" }, // ACC + ON OFF
        //    { "0R03", "1R03" }, // V+ REAR CAMERA
        //    { "0R04", "1R04" }, // V- REAR CAMERA
        //    { "0R05", "1R05" }, // ALRAM RED
        //    { "0R06", "1R06" }, // ALRAM YOLLOW
        //    { "0R07", "1R07" }, // ALRAM GREEN
        //    { "0R08", "1R08" }, // ALRAM SOUND
        //};

        //public string[,] keysSLD = {
        //    { "0R09", "1R09" }, // SLD 45° 1
        //    { "0R10", "1R10" }, // SLD 45° 2
        //    { "0R11", "1R11" }, // SLD 45° 3
        //    { "0R12", "1R12" }, // SLD 45° 4
        //    { "0R13", "1R13" }, // SLD 90° 1
        //    { "0R14", "1R14" }, // SLD 90° 2
        //    { "0R15", "1R15" }, // SLD 90° 3
        //    { "0R16", "1R16" }, // SLD 90° 4
        //};

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

        public Dictionary<string, string[,]> keysSLD = new Dictionary<string, string[,]>();

        private OpenCvSharp.VideoCapture capture;

        private bool isCapturing = false;
        private System.Windows.Forms.Timer timerVideo;
        private string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private string _path = @"./system";

        private string _baudRate = string.Empty;
        private string _serialPortName = string.Empty;

        private SerialPort _SerialPort;

        private int _indexDriverCamera = -1;

        private void Home_Load(object sender, EventArgs e)
        {
            this.timerVideo = new System.Windows.Forms.Timer();
            this.timerVideo.Interval = 1000 / 20;
            this.timerVideo.Tick += new System.EventHandler(this.timerVideo_Trick);
            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

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
        }

        private void timerVideo_Trick(object sender, EventArgs e)
        {
            try
            {
                if(capture != null && capture.IsOpened())
                {
                    using(OpenCvSharp.Mat frame = new OpenCvSharp.Mat())
                    {
                        
                        capture.Read(frame);
                        if(frame != null)
                        {
                            pictureBoxCamera.SuspendLayout();
                            pictureBoxCamera.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                            pictureBoxCamera.ResumeLayout();
                        }                       
                    }
                }
            }catch(Exception ex)
            {
                timerVideo.Stop();
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            isCapturing = !isCapturing;
            try
            {
                if (isCapturing)
                {
                    if (_indexDriverCamera == -1)
                        throw new Exception("Please select a camera drive!");

                    capture = new OpenCvSharp.VideoCapture(_indexDriverCamera);
                    capture.Open(_indexDriverCamera);
                    btnStartStop.Text = "STOP";
                    timerVideo.Start();

                    _SerialPort = new SerialPort(_serialPortName, int.Parse(_baudRate));
                    _SerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                    _SerialPort.Open();
                    toolStripStatusSerialPort.Text = "Serial Port : Connected";
                    toolStripStatusSerialPort.ForeColor = Color.Green;
                    sendSerialCommand("conn");
                        Task.Delay(500); 
                    sendSerialCommand("conn");

                }
                else
                {
                    capture.Dispose();
                    timerVideo.Stop();
                    btnStartStop.Text = "START";

                    if (_SerialPort != null || _SerialPort.IsOpen)
                    {
                        _SerialPort.DataReceived -= serialPort_DataReceived;
                        sendSerialCommand("close");
                        _SerialPort.Close();
                        _SerialPort.Dispose();
                    }
                    _SerialPort = null;

                    toolStripStatusSerialPort.Text = "Serial Port : Disconnected";
                    toolStripStatusSerialPort.ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation 01", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        string ReadDataSerial;
        string dataSerialReceived;

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

        private void dataReceived(object sender, EventArgs e)
        {
            try
            {
                dataSerialReceived += ReadDataSerial;
                

                if (dataSerialReceived.Contains(">") && dataSerialReceived.Contains("<"))
                {
                    // Remove \r\n
                    string data = dataSerialReceived.Replace("\r\n", string.Empty);
                    dataSerialReceived = string.Empty;
                    // [1][2][3][4][5][6][7]
                    //  >  1  1  1  1  1  < 
                    int indexStart = data.IndexOf(">") + ">".Length;
                    int indexEnd = data.IndexOf("<");
                    data = data.Substring(indexStart, indexEnd - indexStart);
                    Console.WriteLine(data);
                    string[] findKeyValue = data.Split(':');
                    if (findKeyValue.Length == 2)
                    {
                        switch (findKeyValue[0])
                        {
                            case "P":
                                break;
                            case "set":
                              
                                break;
                            case "clear":
                              
                                break;
                            case "reset":
                              
                            case "conn":
                                break;
                        }
                    }
                    ReadDataSerial = "";
                }
                else if(!dataSerialReceived.Contains(">"))
                {
                    dataSerialReceived = string.Empty;
                }
            }
            catch(Exception ex)
            {

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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                toolStripStatusConection.Text = $"Camera: {_indexDriverCamera} | Baud Rate: {_baudRate} | Serial Port: {_serialPortName}";

                MessageBox.Show("Save connection success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnEditModel_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.ShowDialog();
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            AddModel model = new AddModel(this);
            model.ShowDialog();
        }

        private void iOTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SerialPort != null && _SerialPort.IsOpen)
            {               
                for(int i = 0; i <16; i++)
                {
                    sendSerialCommand("0R"+(i+1<10? "0"+(i+1).ToString():(i+1).ToString()));
                    Thread.Sleep(100);
                }           
                IO_Testing io = new IO_Testing(this);
                io.ShowDialog();
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
        }
    }
}
