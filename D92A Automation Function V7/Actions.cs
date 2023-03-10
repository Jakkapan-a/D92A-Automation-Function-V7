using D92A_Automation_Function_V7.modules;
using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace D92A_Automation_Function_V7
{
    public partial class Actions : Form
    {
        private int item_id = -1;
        private string oldfileName = string.Empty;
        Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
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
            "SLD 45° 4",
            "SLD 45° 3",
            "SLD 45° 2",
            "SLD 45° 1",
            "SLD 90° 4",
            "SLD 90° 3",
            "SLD 90° 2",
            "SLD 90° 1",
        };

        private Items Items;
        private _ItemsList _itemsList;
        public Actions(Items Items, int item_id)
        {
            InitializeComponent();
            this.item_id = item_id;
            this.Items = Items;
            _itemsList = _ItemsList.LoadItemById(item_id);
            if(_itemsList._type == 2)
            {
                btnIO_TypeWaitJudgment.Visible = false;
                lbTimeOut.Visible = false;
                txtTimeOut.Visible = false;
                lbTimeOutS.Visible = false;
                lbButtom.Visible = false;
            }
        }
        private void Actions_Load(object sender, EventArgs e)
        {
            //var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            //foreach (var device in videoDevices)
            //{
            //    comboBoxDriveCamera.Items.Add(device.Name);
            //}
            //if (comboBoxDriveCamera.Items.Count > 0)
            //    comboBoxDriveCamera.SelectedIndex = 0;

            comboBoxIOPort.Items.AddRange(masterNameKeys);
            comboBoxIOPort.SelectedIndex = 0;

            btnSelectedIOFunction.Select();
        }

        LoadImage_2 loadImage;
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (loadImage != null)
            {
                pictureBoxCamera.Image = null;
                loadImage.Dispose();
            }
            loadImage = new LoadImage_2(this.Items.home,this);
            loadImage.Show(this);
        }
        
        internal void SetImage(string fileName)
        {
            Image m = pictureBoxCamera.Image;
            pictureBoxCamera.Image = null;
            m?.Dispose();
            try
            {
                pictureBoxCamera.Image = Image.FromFile(fileName);
                if(oldfileName != string.Empty)
                {
                    if (File.Exists(oldfileName))
                    {
                        File.Delete(oldfileName);
                    }               
                }
                oldfileName = fileName;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSaveAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnSelectedIOFunction.Checked && !btnSelectedImageFunction.Checked)
                    throw new Exception("Functions not select!!");

                modules.Actions actions = new modules.Actions();
                actions.item_id = item_id;
                actions.name = btnSelectedIOFunction.Checked ? "IO Fuction" : "Image Fuction";
                actions._type = btnSelectedIOFunction.Checked ? 0 : 1;  // 0 = IO, 1 = Image

                if (TypeActionOfIO() == -1 && btnSelectedIOFunction.Checked)
                    throw new Exception("Type of IO is invalid!.");

                actions.io_type = TypeActionOfIO();     // 0 = Manual, 1 = Auto, 2 = Wait judment
                actions.io_state = checkBocON.Checked ? 1 : 0;          // 0 = OFF,1 = ON
                actions.io_port = (comboBoxIOPort.SelectedIndex+1 < 10) ? "R0" + (comboBoxIOPort.SelectedIndex + 1).ToString() : "R" + (comboBoxIOPort.SelectedIndex + 1).ToString();
                actions.io_name = comboBoxIOPort.SelectedItem.ToString();
                actions.io_timeout = (int)txtTimeOut.Value;
                actions.delay = (int)txtDelay.Value;
                actions.auto_delay = (int)txtAutoDelay.Value;
                string filename = !btnSelectedIOFunction.Checked ? saveFileImage() : "";
                actions.image_path = filename;
                actions.image_percent = (int)txtPercent.Value;
                actions.image_status = 1;
                actions.Save();

                this.Items.LoadActionsList();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        private string saveFileImage()
        {
            string filename = @"./system/images/";
            if (!Directory.Exists(filename))
            {
                Directory.CreateDirectory(filename);
            }
            filename += Guid.NewGuid().ToString() + ".jpg";
            pictureBoxCamera.Image.Save(filename, ImageFormat.Jpeg);
            return filename;
        }
        

        private void checkBocON_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBocON.Checked)
            {
                checkBoxOFF.Checked = false;
            }
            Console.WriteLine("AA "+ checkBocON.Checked);
        }

        private void CheckBoxOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOFF.Checked)
            {
                checkBocON.Checked = false;
            }
        }

    }
}
