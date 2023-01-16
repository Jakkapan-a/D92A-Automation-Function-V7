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
    public partial class Login : Form
    {
        Home home;
        public Login(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == "asdfghjkl")
            {
                this.home.TestingToolStripMenuItem.Visible = true;
                this.Close();
            }
        }
    }
}
