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
    public partial class IO_Testing : Form
    {

        Home home;
        Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
        public IO_Testing(Home home)
        {
            InitializeComponent();
            this.home = home;
        }        
        private void IO_Testingcs_Load(object sender, EventArgs e)
        {
            toolStripStatusSerialData.Text = string.Empty;
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

        private void btn_click(object sender, EventArgs e)
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
                updateLight(name);
            }
        }

        private void updateLight(string _name)
        {
            string name = _name.Replace("R", "L");
            var groupBox = this.Controls.OfType<GroupBox>();
            //.where(c => c.name.startswith("lbl10"))
            //.tolist();
            foreach (var g in groupBox)
            {
                var labels = g.Controls.OfType<Label>();
                foreach (var label in labels)
                {
                    if (label.Name == name)
                    {
                        if (this.stateBtn[_name])
                        {
                            label.Image = Properties.Resources.Light_32;
                        }
                        else
                        {
                            label.Image = Properties.Resources.Light_Off_32;
                        }
                        break;
                    }
                }
            }
        }

    }
}
