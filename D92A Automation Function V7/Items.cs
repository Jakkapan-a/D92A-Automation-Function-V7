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
    public partial class Items : Form
    {
        private int model_id = -1;
        private int item_id = -1;
        Models model;
        public Items(int model_id)
        {
            InitializeComponent();
            this.model_id = model_id;
            model = new Models();
            model = Models.GetModelById(model_id);
            lbModelName.Text = model.name;
        }
        Actions actions;
        private void btnAddActions_Click(object sender, EventArgs e)
        {
            if (actions != null)
            {
                actions.Close();
            }
            actions = new Actions(item_id);
            actions.Show(this);
        }

        private void Items_Load(object sender, EventArgs e)
        {
            LoadItemList();
        }

        private void LoadItemList()
        {
            dataGridViewItemList.DataSource = null;
            List<_ItemsList> items = _ItemsList.LoadItems(model_id);
            int i = 0;
            var data = (from x in items
                        select new
                        {
                            x.id,
                            No = ++i,
                            Name = x.name
                        }).ToList();
            dataGridViewItemList.DataSource = data;
            dataGridViewItemList.Columns[0].Visible = false;
            dataGridViewItemList.Columns[1].Width = (int)(dataGridViewItemList.Width * 0.1);

           
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Add new item
                _ItemsList item = new _ItemsList();
                item.name = txtItemName.Text;
                item.model_id = model_id;
                item.Save();
                // Load Items from database
                LoadItemList();
                item = null;
                // Clear text
                txtItemName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void dataGridViewItemList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewItemList.SelectedRows.Count > 0)
                {
                    item_id = (int)dataGridViewItemList.SelectedRows[0].Cells[0].Value;
                    /*
                        Load actions
                     */
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
