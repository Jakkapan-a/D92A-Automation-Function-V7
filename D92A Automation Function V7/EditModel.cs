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
    public partial class EditModel : Form
    {
        private int model_id = -1;
        private Items Items;
        public EditModel(Items items ,int model_id)
        {
            InitializeComponent();
            this.model_id = model_id;
            Items = items;
        }

        private void EditModel_Load(object sender, EventArgs e)
        {
            var data = Models.GetModelById(model_id);
            // Add to txt   
            txtName.Text = data.name; 
            txtDescription.Text = data.description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models models = new Models();
            models.id= model_id;
            models.name = txtName.Text.Trim();
            models.description = txtDescription.Text.Trim();
            models.Update();
            this.Items.lbModelName.Text = models.name;
        }
    }
}
