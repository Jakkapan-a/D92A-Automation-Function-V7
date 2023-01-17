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

namespace D92A_Automation_Function_V7.forms.ItemList
{
    public partial class Add_Item : Form
    {
        private Items _item;
        private string[] type_items = { "Normal", "Manual","Auto" };
        public Add_Item(Items _item)
        {
            InitializeComponent();
            this._item = _item;
        }
        private void Add_Item_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(type_items);
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (_item != null)
                    throw new Exception("Component is invalid");
                if (txtItemName.Text.Trim() == string.Empty)
                    throw new Exception("Name is Empty!");
                if (txtDescription.Text.Trim() == string.Empty)
                    throw new Exception("Description is Empty!");
                if (comboBoxType.SelectedIndex == -1)
                    throw new Exception("Type not select!");
                // Save to database
                _ItemsList _ItemsList = new _ItemsList();
                _ItemsList.name= txtItemName.Text.Trim();
                _ItemsList.description = txtDescription.Text.Trim();
                _ItemsList._type = comboBoxType.SelectedIndex;
                _ItemsList.model_id = _item.model_id;
                _ItemsList.Save();
                // Refresh item list
                this._item.LoadItemList();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

       
    }
}
