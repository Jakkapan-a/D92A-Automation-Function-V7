﻿using D92A_Automation_Function_V7.modules;
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
//using VideoTCapture;
using D92A_Automation_Function_V7.VideoTCapture;

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
        int modelId = -1;
        public Dictionary<string, string[,]> keysSLD = new Dictionary<string, string[,]>();

        private OpenCvSharp.VideoCapture capture;

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


        private Bitmap bitmapCamera;
        private string ReadDataSerial;
        private string dataSerialReceived;
        private bool stateReceivedData = false;
        private string btnReceivedData = string.Empty;

        private VideoTCapture.Capture _Tcapture;

        #endregion

        #region Form Home Load
        private void Home_Load(object sender, EventArgs e)
        {
            this.timerVideo = new System.Windows.Forms.Timer();
            this.timerVideo.Interval = 1000 / 20;
            this.timerVideo.Tick += new System.EventHandler(this.timerVideo_Trick);

            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            this._Tcapture = new VideoTCapture.Capture();
            this._Tcapture.OnFrameHeadler += _Tcapture_OnFrameHeadler;
            this._Tcapture.OnVideoStarted += _Tcapture_OnVideoStarted;
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

            btnCheckBoxManual.Checked = true;
            timerVideo.Stop();
        }

        private void _Tcapture_OnVideoStarted()
        {

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
                pictureBoxCamera.Image = new Bitmap(bitmap);
                pictureBoxCamera.ResumeLayout();
            }
        }
        #endregion


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
                            bitmapCamera = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
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
            try
            {
                isCapturing = !isCapturing;
                if (isCapturing)
                {
                    if (_indexDriverCamera == -1)
                        throw new Exception("Please select a camera drive!");
                    if (_Tcapture != null && _Tcapture.IsOpened)
                    {
                        _Tcapture.Stop();
                    }
                    Task.Factory.StartNew(() => _Tcapture.Start(_indexDriverCamera));
                    //_Tcapture.Start(_indexDriverCamera);

                    _SerialPort = new SerialPort(_serialPortName, int.Parse(_baudRate));
                    _SerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                    _SerialPort.Open();
                    toolStripStatusSerialPort.Text = "Serial Port : Connected";
                    toolStripStatusSerialPort.ForeColor = Color.Green;
                    sendSerialCommand("conn");
                    Task.Delay(10);
                    sendSerialCommand("conn");
                    btnStartStop.Text = "Stop";
                }
                else
                {
                    if (_Tcapture != null && _Tcapture.IsOpened)
                    {
                        _Tcapture.Stop();
                    }

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
                    btnStartStop.Text = "Start";
                }
            }catch(Exception ex)
            {
               MessageBox.Show(ex.Message, "Exclamation 01", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            /*
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
            */
        }

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
                    Console.WriteLine("Received : "+data);
                    data = data.Replace(">", string.Empty).Replace("<", string.Empty);
                    if (data == "start")
                    {
                        TestingToolStripMenuItem.PerformClick();
                    }
                    else if(data == "end")
                    {

                    }

                    string[] findKeyValue = data.Split(':');
                    if (findKeyValue.Length == 2)
                    {
                        switch (findKeyValue[0])
                        {
                            case "C1":
                                break;
                            case "C2":
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
                toolStripStatusConection.Text = $"Camera : {_indexDriverCamera} | Baud Rate : {_baudRate} | Serial Port : {_serialPortName}";

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
            if(modelId == -1)
            {
                MessageBox.Show("Please select a model!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (items != null)
            {
                items.Dispose();
            }
            items = new Items(modelId);
            items.ShowDialog();
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            AddModel model = new AddModel(this);
            model.ShowDialog();
        }
        IO_Testing io;
        private void iOTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SerialPort != null && _SerialPort.IsOpen)
            {               
                if (io != null)
                {
                    io.Dispose();
                }
                io = new IO_Testing(this);
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
                dataGridViewModelList.Columns[0].Visible = false;
                dataGridViewModelList.Columns[1].Width = (int)(dataGridViewModelList.Width * 0.1);

                // Add buuton to datagridview

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                loadModel();
            }
        }

        private void dataGridViewModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modelId == -1)
            {
                MessageBox.Show("Please select a model!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (items != null)
            {
                items.Dispose();
            }
            // Column index of button edit
            items = new Items(modelId);
            items.ShowDialog();
            
        }

        private void dataGridViewModelList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewModelList.SelectedRows.Count > 0)
                {
                    dynamic row = dataGridViewModelList.SelectedRows[0].DataBoundItem;
                    this.modelId =int.Parse(row.id.ToString());
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

        private void ProcessTesting()
        {
            if(modelId == -1)
            {
                MessageBox.Show("Please select model!");
                return;
                throw new Exception("Please select model!");
            }

            for (int i = 0; i < 16; i++)
            {
                sendSerialCommand("0R" + (i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString()));
                Thread.Sleep(50);
            }

            _Items = null;
            _Items = _ItemsList.LoadItems(modelId);
            if (txtProcessDetails.InvokeRequired)
                txtProcessDetails.Invoke((MethodInvoker)delegate { txtProcessDetails.Text = string.Empty; });
            
            foreach (_ItemsList item in _Items)
            {
                txtProcessDetailsAppendText($"Item : {item.name} ");
                toolStripStatusProcessTesting.Text = $"Type : {type_items[item._type]}";
                if (btnCheckBoxAuto.Checked && item._type == 1)
                {
                    continue;
                }else if (btnCheckBoxManual.Checked && item._type == 2)
                {
                    continue;
                }
                actions = null;
                actions = modules.Actions.LoadActions(item.id);
                foreach(modules.Actions action in actions)
                {
                    //Console.WriteLine(action._type);
                    if(action._type == 0)
                    {
                        // Mode IO Function
                        if(action.io_type == 0)
                        {
                            //Console.WriteLine($"{action.io_state}{action.io_port}");
                            sendSerialCommand($"{action.io_state}{action.io_port}");
                            txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : {action.io_state}{action.io_port} ");                        }
                        else if(action.io_type == 1)
                        {
                            sendSerialCommand($"1{action.io_port}");
                            txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 1{action.io_port} ");
                            Thread.Sleep(action.auto_delay);
                            sendSerialCommand($"0{action.io_port}");
                            txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> io data : 0{action.io_port} ");
                        }
                        
                    }
                    else if(action._type == 1)
                    {
                        int ngCount = 0;
                        process_compare:
                        var result = ProcessCompare(action.image_path);
                        txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Image Comapre result : {result}%, config :{action.image_percent} ");
                        if (result < action.image_percent)
                        {
                            // Test Again
                            ngCount++;
                            if(ngCount < 10)
                            {
                                txtProcessDetailsAppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> Test again : ---{ngCount}--- ");
                                Thread.Sleep(100);
                                goto process_compare;
                            }
                            // Test 
                            txtProcessDetailsAppendText("Judement NG");
                            //Console.WriteLine("Judement NG");
                            // End process
                        }
                        else
                        {
                            txtProcessDetailsAppendText("Judement OK");
                            //Console.WriteLine("Judement OK");
                        }                      
                    }
                    else if (action._type == 2)
                    {
                        stateReceivedData = false;
                        btnReceivedData = string.Empty;
                        // 1 se
                        int timeOut = action.io_timeout * 1000;
                        int counter = 0;
                        int countTime = 0;
                        while (counter<=timeOut)
                        {
                            if (stateReceivedData == true)
                            {
                                break;
                            }
                            Thread.Sleep(50);
                            counter++;
                            countTime ++;
                            if(countTime > 10)
                            {
                                txtProcessDetailsAppendText(".",true);
                            }
                        }
                        if(stateReceivedData && btnReceivedData != string.Empty)
                        {
                            txtProcessDetailsAppendText("Pressed button OK");
                        }
                        else if(stateReceivedData && btnReceivedData != string.Empty)
                        {
                            txtProcessDetailsAppendText("Pressed button NG");
                        }
                        else
                        {
                            txtProcessDetailsAppendText("Time Out!!");
                        }
                    }

                    Thread.Sleep(action.delay);
                }
            }
            txtProcessDetailsAppendText("End Process");
            Console.WriteLine("End Process");
            sendSerialCommand("end");
        }

        public void txtProcessDetailsAppendText(string data,bool noNewLine = false)
        {
            if (txtProcessDetails.InvokeRequired)
            {
                txtProcessDetails.Invoke((MethodInvoker)delegate
                {
                    string newLine = noNewLine ? "" : Environment.NewLine;
                txtProcessDetails.AppendText($"{data} {newLine}");
                    txtProcessDetails.ScrollToCaret();
                });
            }
        }

        public double ProcessCompare(string path_master)
        {
            if (!File.Exists(path_master))
                throw new Exception("File master not found!!");

            Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> image_master = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(path_master).Clone();

            Bitmap match = Matching(image_master.ToBitmap(), imageSlave: bitmapCamera);
            pictureBoxDetect.Image = (Image)match.Clone();

            string path_temp = _path + "/temp/" + Guid.NewGuid().ToString() + ".jpg";

            if (!Directory.Exists(_path + "/temp/"))
                Directory.CreateDirectory(_path + "/temp/");
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
                //this.pictureBox2.Image = imgScene.ToBitmap();

                if (path_save != null)
                {
                    imgScene.Save(path_save);
                }
                //this.pictureBox1.Hide();
                return imgCrop.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("E007 " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(login != null)
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

            if(txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSerialProduct.Text == "")
            {
                MessageBox.Show("Please enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 
            sendSerialCommand("run");
            //ProcessTesting();
            if (thread != null)
            {
                thread.Abort();
                thread.DisableComObjectEagerCleanup();
                thread= null;
            }
            thread = new Thread(new ThreadStart(ProcessTesting));
            thread.Start();
            
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            //Console.WriteLine("Resize");
            //// Size of Home
            //int width = this.Width;
            //int height = this.Height;
            //Console.WriteLine("Width: " + width + " Height: " + height);
            if(this.Width > 1390)
            {
                tableLayoutPanelHome.ColumnStyles[1].Width = 700;
            }else if (this.Width > 1500)
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
    }
}
