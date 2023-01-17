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
    public partial class Edit_Item : Form
    {
        Items items;
        private int item_id;
        public Edit_Item(Items items,int item_id)
        {
            InitializeComponent();
            this.items = items;
            this.item_id = item_id;
        }

        _ItemsList _ItemsList;           
        private void Edit_Item_Load(object sender, EventArgs e)
        {
           _ItemsList = _ItemsList.LoadItemById(item_id);
            txtItemName.Text = _ItemsList.name;
            txtDescription.Text = _ItemsList.description;
            comboBoxType.SelectedIndex = _ItemsList._type;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to update this item?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Validate
                    if (txtItemName.Text.Trim() == string.Empty)
                        throw new Exception("Name is Empty!");
                    if (txtDescription.Text.Trim() == string.Empty)
                        throw new Exception("Description is Empty!");
                    if (comboBoxType.SelectedIndex == -1)
                        throw new Exception("Type not select!");
                    // Save to database
                    _ItemsList.name = txtItemName.Text.Trim();
                    _ItemsList.description = txtDescription.Text.Trim();
                    _ItemsList._type = comboBoxType.SelectedIndex;
                    _ItemsList.Update();
                    // Refresh item list
                    this.items.LoadItemList();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


    }
}
