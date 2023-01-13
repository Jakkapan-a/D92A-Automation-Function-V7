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
        public IO_Testing(Home home)
        {
            InitializeComponent();
            this.home = home;
        }        
        private void IO_Testingcs_Load(object sender, EventArgs e)
        {
            toolStripStatusSerialData.Text = string.Empty;
            // keysSLD Add to combo
            foreach (var item in home.keysSLD)
            {
                comboBoxSerialPort.Items.Add(item.Key);
            }
            if (comboBoxSerialPort.Items.Count > 0)
            {
                comboBoxSerialPort.SelectedIndex = 0;
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            if (comboBoxSerialPort.SelectedIndex >= 0)
            {
                var key = home.keysSLD[comboBoxSerialPort.SelectedItem.ToString()][0, 1];
                //Console.WriteLine(key[0,1]);
                home.sendSerialCommand(key);
                toolStripStatusSerialData.Text = "Data : "+key;
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            if (comboBoxSerialPort.SelectedIndex >= 0)
            {
                var key = home.keysSLD[comboBoxSerialPort.SelectedItem.ToString()][0, 0];
                //Console.WriteLine(key[0,1]);
                home.sendSerialCommand(key);
                toolStripStatusSerialData.Text = "Data : " + key;
            }
        }
    }
}
