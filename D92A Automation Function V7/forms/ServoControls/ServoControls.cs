using D92A_Automation_Function_V7.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7.forms.ServoControls
{
    public partial class ServoControls : Form
    {
        private int action_id = -1;
        private Items items;
        private int item_id = -1;
        public ServoControls()
        {
            InitializeComponent();
        }
        public ServoControls(Items items)
        {
            InitializeComponent();
            this.items = items;
        }

        public ServoControls(Items items, int action_id)
        {
            InitializeComponent();
            this.items = items;
            this.action_id = action_id;
        }

        private int WIDTH = 900, HEIGHT = 900;
        private int cx, cy;
        private Bitmap bitmap;
        private int[] handDegree;

        private void ServoControls_Load(object sender, EventArgs e)
        {

        }

        private void txtAngleManual_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            if(num.Name == "txtAngleManual")
            {
                if (trackBarAngleManual.Value != txtAngleManual.Value)
                    trackBarAngleManual.Value = (int)txtAngleManual.Value;
            }else if(num.Name == "txtAngleAuto")
            {
                if(trackBarAngleAuto.Value != txtAngleAuto.Value)
                    trackBarAngleAuto.Value = (int)txtAngleAuto.Value;
            }
        }

        private void btnSaveIO_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.items ==  null) 
                {
                    throw new Exception("This item is not selected!");
                }
                if (!isChecked())
                {
                    throw new Exception("Please select parameter!");
                }

                if (this.items.item_id == -1)
                {
                    throw new Exception("Please select item!");
                }

                modules.Actions actions = new modules.Actions();
                actions._type = 2; // 0 = IO, 1 = Image, 2 = servo
                actions.servo = 0;
                actions.servo_val = getServoValue() != 0 ? getServoValue() : throw new Exception("Value of servo is empty!");
                actions.auto_delay = trackBarAngleAuto.Value;
                actions.delay = (int)txtDelay.Value;
                actions._type = this.items.item_id;

                if (action_id != -1)
                {
                    actions.id = action_id;
                    actions.Update();
                }
                else
                {
                    actions.Save();
                }
                this.items.LoadActionsList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation 007", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private bool isChecked()
        {
            if (btnIO_TypeAuto.Checked || btnIO_TypeManual.Checked)
            {
                return true;
            }
            return false;
        }

        private int getServoValue()
        {
            if(getActionType()== 0)
            {
                return trackBarAngleManual.Value;
            }

            return trackBarAngleAuto.Value;
        }
        private int getActionType()
        {
            if (btnIO_TypeManual.Checked)
                return 0;
            else if (btnIO_TypeAuto.Checked)
                return 1;

            return -1;
        }
        private void trackBarAngleManual_ValueChanged(object sender, EventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            if(track.Name == "trackBarAngleManual")
            {
                if (txtAngleManual.Value != trackBarAngleManual.Value)
                    txtAngleManual.Value = trackBarAngleManual.Value;
            }else if(track.Name == "trackBarAngleAuto")
            {
                if (txtAngleAuto.Value != trackBarAngleAuto.Value)
                    txtAngleAuto.Value = trackBarAngleAuto.Value;
            }
        }

        private int[] AngleDegree(int val,int helen)
        {
            int[] deg = new int[2];

            deg[0] = cx - (int)(helen * Math.Cos(val * Math.PI / 180));
            deg[1] = cy - (int)(helen * Math.Sin(val * Math.PI / 180));

            return deg;
        }
    }
}
