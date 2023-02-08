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

namespace D92A_Automation_Function_V7
{
    public partial class LoadImage_2 : Form
    {
        Home home;
        Rectangle Rect;
        private Actions actions;
        private ActionImage actionImage;
        public LoadImage_2(Home home, Actions actions)
        {
            InitializeComponent();
            this.home = home;
            this.actions= actions;
        }
        public LoadImage_2(Home home, ActionImage action)
        {
            InitializeComponent();
            this.home = home;
            this.actionImage = action;
        }
        private void LoadImage_2_Load(object sender, EventArgs e)
        {
            timerVideo.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Rect = pictureBoxCamera.GetRect();
            if(Rect.Width == 0 || Rect.Height == 0)
            {
                MessageBox.Show("Please select an area to save");
                return;
            }
            using (Bitmap bitmap = new Bitmap(pictureBoxCamera.Image))
            {
                using (Bitmap bmp = new Bitmap(Rect.Width, Rect.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(bitmap, 0, 0, Rect, GraphicsUnit.Pixel);
                    }
                    // Set path
                    string path = Properties.Resources.path_temp;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = $"{path}{Guid.NewGuid()}.jpg";
                    // Save image
                    bmp.Save(filename, ImageFormat.Jpeg);
                    if(this.actions != null)
                    {
                        this.actions.SetImage(filename);

                    }else if(this.actionImage != null)
                    {
                        this.actionImage.SetImage(filename);
                    }

                }
            }

            timerVideo.Stop();
            this.Close();
        }

        private void timerVideo_Tick(object sender, EventArgs e)
        {
            if(home != null && home.bitmapCamera != null)
            {
                pictureBoxCamera.Image = home.bitmapCamera;
            }
        }
    }
}
