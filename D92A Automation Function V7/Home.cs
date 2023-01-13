using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7
{
    public partial class Home : Form
    {
        public Home() => InitializeComponent();

        public string[,] keys = {
            { "0R01", "1R01" }, // BAT + ON OFF
            { "0R02", "1R02" }, // ACC + ON OFF
            { "0R03", "1R03" }, // V+ REAR CAMERA
            { "0R04", "1R04" }, // V- REAR CAMERA
            { "0R05", "1R05" }, // ALRAM RED
            { "0R06", "1R06" }, // ALRAM YOLLOW
            { "0R07", "1R07" }, // ALRAM GREEN
            { "0R08", "1R08" }, // ALRAM SOUND
        };

        public string[,] keysSLD = {
            { "0R09", "1R09" }, // SLD 45° 1
            { "0R10", "1R10" }, // SLD 45° 2
            { "0R11", "1R11" }, // SLD 45° 3
            { "0R12", "1R12" }, // SLD 45° 4
            { "0R13", "1R13" }, // SLD 90° 1
            { "0R14", "1R14" }, // SLD 90° 2
            { "0R15", "1R15" }, // SLD 90° 3
            { "0R16", "1R16" }, // SLD 90° 4
        };


        private OpenCvSharp.VideoCapture capture;

        private bool isCapturing = false;
        private System.Windows.Forms.Timer timerVideo;
        private string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private string _path = @"./system";

        private string _baudRate = string.Empty;
        private string _serialPortName = string.Empty;
        private int _deviceCamera = -1;

        private SerialPort _SerialPort;

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

            toolStripStatusConection.Text = string.Empty;
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
                    if(comboBoxDriveCamera.SelectedIndex == -1)
                        throw new Exception("Please select a camera drive!");

                    capture = new OpenCvSharp.VideoCapture(comboBoxDriveCamera.SelectedIndex);
                    capture.Open(comboBoxDriveCamera.SelectedIndex);
                    btnStartStop.Text = "STOP";
                    timerVideo.Start();
                }
                else
                {
                    capture.Dispose();
                    timerVideo.Stop();
                    btnStartStop.Text = "START";
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnConnectionSave_Click(object sender, EventArgs e)
        {

            try
            {
                toolStripStatusConection.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
