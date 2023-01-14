using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7
{
    public partial class Actions : Form
    {
        private int item_id = -1;
        private string oldfileName = string.Empty;
        public Actions(int item_id)
        {
            InitializeComponent();
            this.item_id = item_id;
        }
        private void Actions_Load(object sender, EventArgs e)
        {
            var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            foreach (var device in videoDevices)
            {
                comboBoxDriveCamera.Items.Add(device.Name);
            }
            if (comboBoxDriveCamera.Items.Count > 0)
                comboBoxDriveCamera.SelectedIndex = 0;
        }

        LoadImage loadImage;
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if(loadImage != null)
            {
                pictureBoxCamera.Image = null;
                loadImage.Dispose();                
            }
            loadImage = new LoadImage(this,comboBoxDriveCamera.SelectedIndex);
            loadImage.Show(this);
        }
        
        internal void SetImage(string fileName)
        {
            Image m = pictureBoxCamera.Image;
            pictureBoxCamera.Image = null;
            m?.Dispose();

            pictureBoxCamera.Image = Image.FromFile(fileName);
            if(oldfileName != string.Empty)
            {
                if (File.Exists(oldfileName))
                {
                    File.Delete(oldfileName);
                }               
            }
            oldfileName = fileName;
        }

       
    }
}
