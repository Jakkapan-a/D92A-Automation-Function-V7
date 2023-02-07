using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace D92A_Automation_Function_V7
{
    public partial class ActionIO : Form
    {
        //private Home home;
        private Dictionary<string, bool> stateBtn = new Dictionary<string, bool>();
        private List<stateBtn> stateBtns;

        private Items Items;
        public ActionIO(Items Items)
        {
            InitializeComponent();
            this.Items = Items;
        }

        private void ActionIO_Load(object sender, EventArgs e)
        {
            stateBtns = new List<stateBtn>();            
            for (int i = 1; i <= 16; i++)
            {
                if (i < 10)
                {
                    stateBtns.Add(new stateBtn { name = "R0" + i.ToString(), state = false });
                     this.stateBtn.Add("R0" + i.ToString(), false);
                }
                else
                {
                    stateBtns.Add(new stateBtn { name = "R" + i.ToString(), state = false });
                     this.stateBtn.Add("R" + i.ToString(), false);
                }
            }
        }


        private void IO_click(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Click");
            Button btn = (Button)sender;
            string name = btn.Name;
            this.stateBtn[name] = true;
            // If name is not same as key, set value to false 

            this.stateBtns.Where(x => x.name == name).ToList().ForEach(x => x.state = true);
            this.stateBtns.Where(x => x.name != name).ToList().ForEach(x => x.state = false);

            cancelOldState();
        }

        private void cancelOldState()
        {
            foreach (Panel panel in tableLayoutPanelAction.Controls)
            {
                foreach(Button btn in panel.Controls)
                {
                    updateColorBtn(btn);
                }
            }
        }
        private void updateColorBtn(Button button)
        {
            string name = button.Name;

            if(this.stateBtns.Where(x => x.name == name).ToList().First().state == true)
            {
                button.BackColor = Color.Green;
            }
            else
            {
                button.BackColor = Color.White;
            }            
        }

        private void btnSaveIO_Click(object sender, EventArgs e)
        {
            try
            {

                //modules.Actions actions = new modules.Actions();
                //actions.item_id = item_id;
                //actions.name = "IO Fuction";
                //actions._type = 0;  // 0 = IO, 1 = Image

                //if (TypeActionOfIO() == -1 && btnSelectedIOFunction.Checked)
                //    throw new Exception("Type of IO is invalid!.");

                //actions.io_type = TypeActionOfIO();     // 0 = Manual, 1 = Auto, 2 = Wait judment
                //actions.io_state = checkBocON.Checked ? 1 : 0;          // 0 = OFF,1 = ON
                //actions.io_port = (comboBoxIOPort.SelectedIndex + 1 < 10) ? "R0" + (comboBoxIOPort.SelectedIndex + 1).ToString() : "R" + (comboBoxIOPort.SelectedIndex + 1).ToString();
                //actions.io_name = getStateBtnName;
                //actions.io_timeout = (int)txtTimeOut.Value;
                //actions.delay = (int)txtDelay.Value;
                //actions.auto_delay = (int)txtAutoDelay.Value;
                //string filename = !btnSelectedIOFunction.Checked ? saveFileImage() : "";
                //actions.image_path = filename;
                //actions.image_percent = (int)txtPercent.Value;
                //actions.image_status = 1;
                //actions.Save();

                //this.Items.LoadActionsList();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    public class stateBtn
    {
        public string name { get; set; }
        public bool state { get; set; }
    }
}
