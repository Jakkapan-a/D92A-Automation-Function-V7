using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7
{
    public partial class Test_IO : Form
    {
        private Home home;
        Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
        public Test_IO(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void Test_IO_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                this.home.sendSerialCommand("0R" + (i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString()));
                Thread.Sleep(60);
            }

            // toolStripStatusSerialData.Text = string.Empty;
            for (int i = 1; i <= 16; i++)
            {
                if (i < 10)
                {
                    this.stateBtn.Add("R0" + i.ToString(), false);
                }
                else
                {
                    this.stateBtn.Add("R" + i.ToString(), false);
                }
            }
        }

        private void btn_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Test kd");
            if (home != null)
            {
                Button btn = (Button)sender;
                string name = btn.Name;
                if (this.stateBtn[name])
                {
                    this.stateBtn[name] = false;
                }
                else
                {
                    this.stateBtn[name] = true;
                }
                this.home.sendSerialCommand((this.stateBtn[name] ? 1 : 0) + name);
            }
        }

        private void updateLight(Button button,string name)
        {
            if (this.stateBtn[name] == true)
            {
                button.BackColor = Color.Green;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }

        private void btnSLN_MouseDown(object sender, MouseEventArgs e)
        {

            if (home != null)
            {
                Button btn = (Button)sender;
                string name = btn.Name;
                if (this.stateBtn[name])
                {
                    this.stateBtn[name] = false;
                }
                else
                {
                    this.stateBtn[name] = true;
                }
                this.home.sendSerialCommand((this.stateBtn[name] ? 1 : 0) + name);
                updateLight(btn, name);
            }
        }

        private void btnSLN_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbMode.Checked)
            {
                Button btn = (Button)sender;
                string name = btn.Name;

                if (this.stateBtn[name])
                {
                    this.stateBtn[name] = false;
                }
                else
                {
                    this.stateBtn[name] = true;
                }
                this.home.sendSerialCommand((this.stateBtn[name] ? 1 : 0) + name);
                updateLight(btn, name);
            }
        }
    }
}
