using D92A_Automation_Function_V7.forms.ItemList;
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
        public int model_id = -1;
        private int item_id = -1;
        Models model;
        Actions actions;
        private string path_image = string.Empty;
        public Items(int model_id)
        {
            InitializeComponent();
            this.model_id = model_id;
            model = new Models();
            model = Models.GetModelById(model_id);
            lbModelName.Text = model.name;
        }
       
        private void btnAddActions_Click(object sender, EventArgs e)
        {
            if (actions != null)
            {
                actions.Close();
            }
            actions = new Actions(this,item_id);
            actions.Show(this);
        }

        private void Items_Load(object sender, EventArgs e)
        {
            LoadItemList();
            // Loop set default text are empty of statusStripHome
            foreach (ToolStripItem item in statusStrip.Items)
            {
                item.Text = string.Empty;
            }
        }

        public void LoadItemList()
        {
            if (model_id == -1)
                return;
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
        public void LoadActionsList()
        {
            dataGridViewActionList.DataSource = null;
            if (item_id == -1)
                return;
            List<modules.Actions> actions = modules.Actions.LoadActions(item_id);
            int i = 0;
            var data = (from x in actions
                        select new
                        {
                            id = x.id,
                            No = ++i,
                            Type = x.name,
                            IO_Name = (x._type == 0) ? x.io_name : "-",
                            IO_PORT = (x._type == 0) ? x.io_port : "-",
                            Image = (x._type == 1) ? x.image_path : "-",
                            Delay = x.delay,
                            Date = x.created_at                           
                        }).ToList();
            dataGridViewActionList.DataSource = data;
            dataGridViewActionList.Columns[0].Visible = false;
            dataGridViewActionList.Columns[1].Width = (int)(dataGridViewActionList.Width * 0.1);
        }
        
        private Add_Item add_item;

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(add_item != null)
                {
                    add_item?.Dispose();
                    add_item = null;
                    
                }
                add_item = new Add_Item(this);
                add_item.Name = "Add Item ";
                add_item.Show(this);
                
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
                    dynamic row = dataGridViewItemList.SelectedRows[0].DataBoundItem;
                    item_id = int.Parse(row.id.ToString());

                    toolStripStatusItemId.Text = "Item ID : " + item_id.ToString();
                    //
                    if (item_id != -1)
                    {
                        LoadActionsList();
                    }
                  
                    Console.WriteLine(item_id);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private int action_id = -1;
        private void dataGridViewActionList_SelectionChanged(object sender, EventArgs e)
        {

            // Get value columns 0
            if (dataGridViewActionList.SelectedRows.Count > 0)
            {
                dynamic row = dataGridViewActionList.SelectedRows[0].DataBoundItem;
                action_id = int.Parse(row.id.ToString());
                path_image = (row.Image != string.Empty)? row.Image : string.Empty; 
                toolStripStatusActionId.Text = "Action ID : " + action_id.ToString() + " Path : " + path_image;
                Console.WriteLine(action_id);
            }
        }


        private void deleteItemList_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?", "Confirm Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                modules.Actions.byItemToTemp(item_id);
                _ItemsList.Delete(item_id);
                LoadItemList();
            }
        }


        private void deleteActinList_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to delete this action?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                modules.Actions.ToTemp(action_id);
                LoadActionsList();
            }         
        }
        View view;
        private void viewActionList_Click(object sender, EventArgs e)
        {
            if (path_image != string.Empty)
            {
                if(view != null)
                {
                    view.Dispose();
                }
                view = new View(path_image);
                view.Show(this);
            }
        }
        EditModel editModel;
        private void editModelNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editModel != null)
            {
                editModel.Dispose();
                editModel = null;
            }
            editModel = new EditModel(this,model_id);
            editModel.Show(this);
        }

        Edit_Item edit_Item;
        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edit_Item != null)
            {
                edit_Item.Dispose();
                edit_Item = null;
            }
            edit_Item = new Edit_Item(this,item_id);
            edit_Item.Show(this);
        }
    }
}
