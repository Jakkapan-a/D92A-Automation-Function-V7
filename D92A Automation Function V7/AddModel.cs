using D92A_Automation_Function_V7.modules;
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
    public partial class AddModel : Form
    {
        private Home home;
        public AddModel(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models model = new Models();
            model.name = txtName.Text;
            model.description = txtDescription.Text;
            model.Save();
        }

        private void AddModel_Load(object sender, EventArgs e)
        {

        }
    }
}
