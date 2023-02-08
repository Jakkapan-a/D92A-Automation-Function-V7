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
    public partial class ActionImage : Form
    {
        private Items Items;
        private string oldfileName = string.Empty;
        public ActionImage()
        {
            InitializeComponent();
        }
        LoadImage_2 loadImage;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (loadImage != null)
            {
                pictureBoxCamera.Image = null;
                loadImage.Dispose();
            }
            loadImage = new LoadImage_2(this.Items.home, this);
            loadImage.Show(this);
        }

        internal void SetImage(string filename)
        {
            Image m = pictureBoxCamera.Image;
            pictureBoxCamera.Image = null;
            m?.Dispose();
            try
            {
                pictureBoxCamera.Image = Image.FromFile(filename);
                if (oldfileName != string.Empty)
                {
                    if (File.Exists(oldfileName))
                    {
                        File.Delete(oldfileName);
                    }
                }
                oldfileName = filename;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
