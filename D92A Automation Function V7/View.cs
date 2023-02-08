using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7
{
    public partial class View : Form
    {
        private string pathImage;

        public View(string pathImage)
        {
            InitializeComponent();
            this.pathImage = pathImage;
        }

        private void View_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Image = Image.FromFile(pathImage);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            Image m = pictureBox.Image;
            pictureBox.Image = null;
            m?.Dispose();
        }
    }
}
