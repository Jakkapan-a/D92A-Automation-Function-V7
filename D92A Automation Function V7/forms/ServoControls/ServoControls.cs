using D92A_Automation_Function_V7.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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

        private modules.Actions action;
        private void ServoControls_Load(object sender, EventArgs e)
        {
            if(this.action_id != -1)
            {
                this.action = modules.Actions.LoadActionsByID(action_id).First();
                
                if(this.action.io_type == 0)
                {
                    btnIO_TypeManual.Checked = true;
                    txtAngleManual.Value = this.action.servo_val;
                }
                else if(this.action.io_type == 1)
                {
                    btnIO_TypeAuto.Checked = true;
                    txtAngleAuto.Value = this.action.servo_val;
                }
                txtAutoDelay.Value = this.action.auto_delay;
                txtDelay.Value = this.action.delay;
            }
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
                actions._type = 0; // 0 = IO, 1 = Image, 2 = servo
                actions.servo = 1;
                actions.image_status = 1;
                actions.name = "Servo Control";
                actions.io_port = "S" + getServoValue().ToString();
                actions.io_name = "Servo";
                actions.io_type = getActionType() != -1? getActionType(): throw new Exception("Please select parameter!");
                actions.servo_val = getServoValue() != 0 ? getServoValue() : throw new Exception("Value of servo is empty!");
                actions.auto_delay = (int)txtAutoDelay.Value;
                actions.delay = (int)txtDelay.Value;
                actions.item_id = this.items.item_id;

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
            if (getActionType() == -1)
                return 0;
            if (getActionType() == 0)
                return trackBarAngleManual.Value;            

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
