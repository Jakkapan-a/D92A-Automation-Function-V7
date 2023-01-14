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
            try
            {
                if (Process.isModelsExist(txtName.Text))
                {
                    MessageBox.Show("Model has been added");
                    return;
                }
                Models model = new Models();
                model.name = txtName.Text.Trim();
                model.description = txtDescription.Text.Trim();
                model.Save();
                this.home.loadModel();

                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;

                // Message Box
                MessageBox.Show("Model has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddModel_Load(object sender, EventArgs e)
        {

        }
    }
}
