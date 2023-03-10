using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7.forms.ServoControls
{
    public partial class ServoControls : Form
    {
        public ServoControls()
        {
            InitializeComponent();
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
