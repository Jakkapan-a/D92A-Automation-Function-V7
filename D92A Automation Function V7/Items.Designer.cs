﻿namespace D92A_Automation_Function_V7
{
    partial class Items
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxItem = new System.Windows.Forms.GroupBox();
            this.dataGridViewItemList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripItenList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.dataGridViewActionList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripActionList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewActionList = new System.Windows.Forms.ToolStripMenuItem();
            this.addAction = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActionList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddActions = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusItemId = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusActionId = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editModelNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbModelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).BeginInit();
            this.contextMenuStripItenList.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActionList)).BeginInit();
            this.contextMenuStripActionList.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxItem);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxActions);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(800, 353);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxItem
            // 
            this.groupBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxItem.Controls.Add(this.dataGridViewItemList);
            this.groupBoxItem.Controls.Add(this.btnAddItem);
            this.groupBoxItem.Location = new System.Drawing.Point(3, 3);
            this.groupBoxItem.Name = "groupBoxItem";
            this.groupBoxItem.Size = new System.Drawing.Size(260, 340);
            this.groupBoxItem.TabIndex = 2;
            this.groupBoxItem.TabStop = false;
            this.groupBoxItem.Text = "Item List";
            // 
            // dataGridViewItemList
            // 
            this.dataGridViewItemList.AllowUserToAddRows = false;
            this.dataGridViewItemList.AllowUserToDeleteRows = false;
            this.dataGridViewItemList.AllowUserToResizeColumns = false;
            this.dataGridViewItemList.AllowUserToResizeRows = false;
            this.dataGridViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemList.ContextMenuStrip = this.contextMenuStripItenList;
            this.dataGridViewItemList.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewItemList.Name = "dataGridViewItemList";
            this.dataGridViewItemList.RowHeadersVisible = false;
            this.dataGridViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemList.Size = new System.Drawing.Size(245, 271);
            this.dataGridViewItemList.TabIndex = 2;
            this.dataGridViewItemList.SelectionChanged += new System.EventHandler(this.dataGridViewItemList_SelectionChanged);
            // 
            // contextMenuStripItenList
            // 
            this.contextMenuStripItenList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemList});
            this.contextMenuStripItenList.Name = "contextMenuStripItenList";
            this.contextMenuStripItenList.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteItemList
            // 
            this.deleteItemList.Name = "deleteItemList";
            this.deleteItemList.Size = new System.Drawing.Size(107, 22);
            this.deleteItemList.Text = "Delete";
            this.deleteItemList.Click += new System.EventHandler(this.deleteItemList_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(179, 311);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.dataGridViewActionList);
            this.groupBoxActions.Controls.Add(this.btnAddActions);
            this.groupBoxActions.Location = new System.Drawing.Point(3, 3);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(515, 340);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions List";
            // 
            // dataGridViewActionList
            // 
            this.dataGridViewActionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewActionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActionList.ContextMenuStrip = this.contextMenuStripActionList;
            this.dataGridViewActionList.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewActionList.Name = "dataGridViewActionList";
            this.dataGridViewActionList.RowHeadersVisible = false;
            this.dataGridViewActionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActionList.Size = new System.Drawing.Size(503, 271);
            this.dataGridViewActionList.TabIndex = 1;
            this.dataGridViewActionList.SelectionChanged += new System.EventHandler(this.dataGridViewActionList_SelectionChanged);
            // 
            // contextMenuStripActionList
            // 
            this.contextMenuStripActionList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewActionList,
            this.addAction,
            this.deleteActionList});
            this.contextMenuStripActionList.Name = "contextMenuStripActionList";
            this.contextMenuStripActionList.Size = new System.Drawing.Size(135, 70);
            // 
            // viewActionList
            // 
            this.viewActionList.Name = "viewActionList";
            this.viewActionList.Size = new System.Drawing.Size(134, 22);
            this.viewActionList.Text = "View";
            this.viewActionList.Click += new System.EventHandler(this.viewActionList_Click);
            // 
            // addAction
            // 
            this.addAction.Name = "addAction";
            this.addAction.Size = new System.Drawing.Size(134, 22);
            this.addAction.Text = "Add Action";
            this.addAction.Click += new System.EventHandler(this.btnAddActions_Click);
            // 
            // deleteActionList
            // 
            this.deleteActionList.Name = "deleteActionList";
            this.deleteActionList.Size = new System.Drawing.Size(134, 22);
            this.deleteActionList.Text = "Delete";
            this.deleteActionList.Click += new System.EventHandler(this.deleteActinList_Click);
            // 
            // btnAddActions
            // 
            this.btnAddActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddActions.Location = new System.Drawing.Point(434, 312);
            this.btnAddActions.Name = "btnAddActions";
            this.btnAddActions.Size = new System.Drawing.Size(75, 23);
            this.btnAddActions.TabIndex = 0;
            this.btnAddActions.Text = "Add Action";
            this.btnAddActions.UseVisualStyleBackColor = true;
            this.btnAddActions.Click += new System.EventHandler(this.btnAddActions_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusItemId,
            this.toolStripStatusActionId});
            this.statusStrip.Location = new System.Drawing.Point(0, 426);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 24);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusItemId
            // 
            this.toolStripStatusItemId.Name = "toolStripStatusItemId";
            this.toolStripStatusItemId.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusItemId.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusActionId
            // 
            this.toolStripStatusActionId.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusActionId.Name = "toolStripStatusActionId";
            this.toolStripStatusActionId.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusActionId.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maToolStripMenuItem
            // 
            this.maToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editModelNameToolStripMenuItem,
            this.deleteModelToolStripMenuItem});
            this.maToolStripMenuItem.Name = "maToolStripMenuItem";
            this.maToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.maToolStripMenuItem.Text = "File";
            // 
            // editModelNameToolStripMenuItem
            // 
            this.editModelNameToolStripMenuItem.Name = "editModelNameToolStripMenuItem";
            this.editModelNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editModelNameToolStripMenuItem.Text = "Edit Model Name";
            this.editModelNameToolStripMenuItem.Click += new System.EventHandler(this.editModelNameToolStripMenuItem_Click);
            // 
            // deleteModelToolStripMenuItem
            // 
            this.deleteModelToolStripMenuItem.Name = "deleteModelToolStripMenuItem";
            this.deleteModelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteModelToolStripMenuItem.Text = "Delete Model";
            // 
            // lbModelName
            // 
            this.lbModelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelName.Location = new System.Drawing.Point(3, 24);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(785, 45);
            this.lbModelName.TabIndex = 4;
            this.lbModelName.Text = "-------------------";
            this.lbModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbModelName);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Items";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items";
            this.Load += new System.EventHandler(this.Items_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).EndInit();
            this.contextMenuStripItenList.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActionList)).EndInit();
            this.contextMenuStripActionList.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnAddActions;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusItemId;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxItem;
        private System.Windows.Forms.DataGridView dataGridViewItemList;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.DataGridView dataGridViewActionList;
        private System.Windows.Forms.ToolStripMenuItem editModelNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteModelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripItenList;
        private System.Windows.Forms.ToolStripMenuItem deleteItemList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripActionList;
        private System.Windows.Forms.ToolStripMenuItem deleteActionList;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusActionId;
        private System.Windows.Forms.ToolStripMenuItem viewActionList;
        private System.Windows.Forms.ToolStripMenuItem addAction;
        public System.Windows.Forms.Label lbModelName;
    }
}