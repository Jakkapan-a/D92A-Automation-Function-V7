using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace D92A_Automation_Function_V7
{
    public partial class ActionImage : Form
    {
        private Items Items;
        private string oldfileName = string.Empty;
        private int item_id = -1;
        private int action_id = -1;
        public ActionImage(Items items)
        {
            InitializeComponent();
            Items = items;
            item_id = items.item_id;
        }
        public ActionImage(Items items,int action_id)
        {
            InitializeComponent();
            Items = items;
            item_id = items.item_id;
            this.action_id = action_id;
        }

        LoadImage_2 loadImage;

        private void ActionImage_Load(object sender, EventArgs e)
        {
            if(action_id != -1)
            {
                var action = modules.Actions.LoadActionsByID(action_id).First();
                txtDelay.Value = action.delay;
                txtPercent.Value = action.image_percent;
                string path = action.image_path;
                SetImage(path);
                lbTitle.Text = "Update Image";
                btnSave.Text = "Update";
            }
        }

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
            try
            {
                modules.Actions action = new modules.Actions();
                action.item_id = item_id;
                action.name = "Image Fuction";
                action._type = 1;  // 0 = IO, 1 = Image

                action.io_type = 0;     // 0 = Manual, 1 = Auto, 2 = Wait judgment
                action.io_state = 1;          // 0 = OFF,1 = ON
                action.io_port = "";
                action.io_name = "";
                action.io_timeout = 0;
                action.delay = (int)txtDelay.Value;
                action.auto_delay = 0;
                action.image_path = saveFileImage();
                action.image_percent = (int)txtPercent.Value;
                action.image_status = 1;
                if (action_id != -1)
                {
                    action.id = action_id;
                    action.Update();
                }
                else
                {
                    action.Save();
                }

                Items.LoadActionsList();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private string saveFileImage()
        {
            string filename = Properties.Resources.path_image;
            if (!Directory.Exists(filename))
            {
                Directory.CreateDirectory(filename);
            }
            filename += "/"+Guid.NewGuid().ToString() + ".jpg";
            pictureBoxCamera.Image.Save(filename, ImageFormat.Jpeg);
            Thread.Sleep(1000);
            Image m = pictureBoxCamera.Image;
            pictureBoxCamera.Image = null;
            m?.Dispose();

            if (oldfileName != string.Empty)
            {
                if (File.Exists(oldfileName))
                {
                    //File.Delete(oldfileName);
                }
            }
            oldfileName = string.Empty;

            return filename;
        }

    }
}
