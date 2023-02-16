namespace D92A_Automation_Function_V7
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.contextMenuStripHome = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnStartStop = new System.Windows.Forms.Button();
            this.comboBoxDriveCamera = new System.Windows.Forms.ComboBox();
            this.menuStripHome = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelHomeHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lbModelName = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelHome = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHome2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProcessDetails = new System.Windows.Forms.RichTextBox();
            this.pictureBoxDetect = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheckBoxAuto = new System.Windows.Forms.RadioButton();
            this.btnCheckBoxManual = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerialProduct = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditModel = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.dataGridViewModelList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripModel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectionSave = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudList = new System.Windows.Forms.ComboBox();
            this.statusStripHome = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusConection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSerialPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSerialDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelModelID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusProcessTesting = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressTesting = new System.Windows.Forms.ToolStripProgressBar();
            this.timerNG = new System.Windows.Forms.Timer(this.components);
            this.timerCounter = new System.Windows.Forms.Timer(this.components);
            this.menuStripHome.SuspendLayout();
            this.tableLayoutPanelHomeHeader.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelHome.SuspendLayout();
            this.tableLayoutPanelHome2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetect)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelList)).BeginInit();
            this.contextMenuStripModel.SuspendLayout();
            this.groupBoxConnection.SuspendLayout();
            this.statusStripHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripHome
            // 
            this.contextMenuStripHome.Name = "contextMenuStripHome";
            this.contextMenuStripHome.Size = new System.Drawing.Size(61, 4);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(20, 20);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(20);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(68, 44);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "START";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // comboBoxDriveCamera
            // 
            this.comboBoxDriveCamera.FormattingEnabled = true;
            this.comboBoxDriveCamera.Location = new System.Drawing.Point(73, 36);
            this.comboBoxDriveCamera.Name = "comboBoxDriveCamera";
            this.comboBoxDriveCamera.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDriveCamera.TabIndex = 3;
            // 
            // menuStripHome
            // 
            this.menuStripHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.menuStripHome.Location = new System.Drawing.Point(0, 0);
            this.menuStripHome.Name = "menuStripHome";
            this.menuStripHome.Size = new System.Drawing.Size(834, 24);
            this.menuStripHome.TabIndex = 4;
            this.menuStripHome.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportHistoryToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportHistoryToolStripMenuItem
            // 
            this.exportHistoryToolStripMenuItem.Name = "exportHistoryToolStripMenuItem";
            this.exportHistoryToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exportHistoryToolStripMenuItem.Text = "Export CSV";
            this.exportHistoryToolStripMenuItem.Visible = false;
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iOTestingToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.TestingToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // iOTestingToolStripMenuItem
            // 
            this.iOTestingToolStripMenuItem.Name = "iOTestingToolStripMenuItem";
            this.iOTestingToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.iOTestingToolStripMenuItem.Text = "IO Testing";
            this.iOTestingToolStripMenuItem.Click += new System.EventHandler(this.iOTestingToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuIteam_Click);
            // 
            // TestingToolStripMenuItem
            // 
            this.TestingToolStripMenuItem.Name = "TestingToolStripMenuItem";
            this.TestingToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.TestingToolStripMenuItem.Text = "Testing";
            this.TestingToolStripMenuItem.Click += new System.EventHandler(this.TestingToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // tableLayoutPanelHomeHeader
            // 
            this.tableLayoutPanelHomeHeader.ColumnCount = 3;
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06954F));
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.26379F));
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelHomeHeader.Controls.Add(this.btnStartStop, 0, 0);
            this.tableLayoutPanelHomeHeader.Controls.Add(this.lbModelName, 1, 0);
            this.tableLayoutPanelHomeHeader.Controls.Add(this.lbResult, 2, 0);
            this.tableLayoutPanelHomeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHomeHeader.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelHomeHeader.Name = "tableLayoutPanelHomeHeader";
            this.tableLayoutPanelHomeHeader.RowCount = 1;
            this.tableLayoutPanelHomeHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHomeHeader.Size = new System.Drawing.Size(834, 86);
            this.tableLayoutPanelHomeHeader.TabIndex = 5;
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelName.Location = new System.Drawing.Point(116, 8);
            this.lbModelName.Margin = new System.Windows.Forms.Padding(8);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(569, 70);
            this.lbModelName.TabIndex = 3;
            this.lbModelName.Text = "-----------------------";
            this.lbModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.BackColor = System.Drawing.Color.Yellow;
            this.lbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(703, 10);
            this.lbResult.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(121, 76);
            this.lbResult.TabIndex = 4;
            this.lbResult.Text = "Wait...";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHome
            // 
            this.panelHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHome.BackColor = System.Drawing.Color.Transparent;
            this.panelHome.Controls.Add(this.tabControl);
            this.panelHome.Location = new System.Drawing.Point(3, 113);
            this.panelHome.Margin = new System.Windows.Forms.Padding(5);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(831, 423);
            this.panelHome.TabIndex = 6;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(825, 417);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelHome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "INSPECTION";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelHome
            // 
            this.tableLayoutPanelHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelHome.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelHome.ColumnCount = 2;
            this.tableLayoutPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 511F));
            this.tableLayoutPanelHome.Controls.Add(this.tableLayoutPanelHome2, 1, 0);
            this.tableLayoutPanelHome.Controls.Add(this.pictureBoxCamera, 0, 0);
            this.tableLayoutPanelHome.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanelHome.Name = "tableLayoutPanelHome";
            this.tableLayoutPanelHome.RowCount = 1;
            this.tableLayoutPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHome.Size = new System.Drawing.Size(805, 382);
            this.tableLayoutPanelHome.TabIndex = 0;
            // 
            // tableLayoutPanelHome2
            // 
            this.tableLayoutPanelHome2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelHome2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelHome2.ColumnCount = 2;
            this.tableLayoutPanelHome2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.Controls.Add(this.txtProcessDetails, 1, 1);
            this.tableLayoutPanelHome2.Controls.Add(this.pictureBoxDetect, 0, 1);
            this.tableLayoutPanelHome2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelHome2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanelHome2.Location = new System.Drawing.Point(296, 4);
            this.tableLayoutPanelHome2.Name = "tableLayoutPanelHome2";
            this.tableLayoutPanelHome2.RowCount = 2;
            this.tableLayoutPanelHome2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.Size = new System.Drawing.Size(505, 374);
            this.tableLayoutPanelHome2.TabIndex = 2;
            // 
            // txtProcessDetails
            // 
            this.txtProcessDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessDetails.Location = new System.Drawing.Point(256, 190);
            this.txtProcessDetails.Name = "txtProcessDetails";
            this.txtProcessDetails.Size = new System.Drawing.Size(245, 180);
            this.txtProcessDetails.TabIndex = 1;
            this.txtProcessDetails.Text = "";
            // 
            // pictureBoxDetect
            // 
            this.pictureBoxDetect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDetect.Location = new System.Drawing.Point(4, 190);
            this.pictureBoxDetect.Name = "pictureBoxDetect";
            this.pictureBoxDetect.Size = new System.Drawing.Size(245, 180);
            this.pictureBoxDetect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDetect.TabIndex = 0;
            this.pictureBoxDetect.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnCheckBoxAuto);
            this.panel1.Controls.Add(this.btnCheckBoxManual);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSerialProduct);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 179);
            this.panel1.TabIndex = 3;
            // 
            // btnCheckBoxAuto
            // 
            this.btnCheckBoxAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckBoxAuto.AutoSize = true;
            this.btnCheckBoxAuto.Location = new System.Drawing.Point(194, 149);
            this.btnCheckBoxAuto.Name = "btnCheckBoxAuto";
            this.btnCheckBoxAuto.Size = new System.Drawing.Size(47, 17);
            this.btnCheckBoxAuto.TabIndex = 3;
            this.btnCheckBoxAuto.TabStop = true;
            this.btnCheckBoxAuto.Text = "Auto";
            this.btnCheckBoxAuto.UseVisualStyleBackColor = true;
            // 
            // btnCheckBoxManual
            // 
            this.btnCheckBoxManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckBoxManual.AutoSize = true;
            this.btnCheckBoxManual.Location = new System.Drawing.Point(128, 149);
            this.btnCheckBoxManual.Name = "btnCheckBoxManual";
            this.btnCheckBoxManual.Size = new System.Drawing.Size(60, 17);
            this.btnCheckBoxManual.TabIndex = 3;
            this.btnCheckBoxManual.TabStop = true;
            this.btnCheckBoxManual.Text = "Manual";
            this.btnCheckBoxManual.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "S/N :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 52);
            this.label4.TabIndex = 1;
            this.label4.Text = "INSPECTION";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerialProduct
            // 
            this.txtSerialProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialProduct.Location = new System.Drawing.Point(79, 116);
            this.txtSerialProduct.Name = "txtSerialProduct";
            this.txtSerialProduct.Size = new System.Drawing.Size(162, 20);
            this.txtSerialProduct.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(79, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 20);
            this.txtName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridViewHistory);
            this.panel2.Location = new System.Drawing.Point(256, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 179);
            this.panel2.TabIndex = 4;
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.Size = new System.Drawing.Size(239, 173);
            this.dataGridViewHistory.TabIndex = 2;
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(285, 374);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCamera.TabIndex = 1;
            this.pictureBoxCamera.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditModel);
            this.tabPage3.Controls.Add(this.btnAddModel);
            this.tabPage3.Controls.Add(this.dataGridViewModelList);
            this.tabPage3.Controls.Add(this.groupBoxConnection);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(817, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SETTING";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEditModel
            // 
            this.btnEditModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditModel.Location = new System.Drawing.Point(611, 359);
            this.btnEditModel.Name = "btnEditModel";
            this.btnEditModel.Size = new System.Drawing.Size(75, 23);
            this.btnEditModel.TabIndex = 2;
            this.btnEditModel.Text = "Edit";
            this.btnEditModel.UseVisualStyleBackColor = true;
            this.btnEditModel.Click += new System.EventHandler(this.btnEditModel_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddModel.Location = new System.Drawing.Point(736, 359);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(75, 23);
            this.btnAddModel.TabIndex = 2;
            this.btnAddModel.Text = "Add";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // dataGridViewModelList
            // 
            this.dataGridViewModelList.AllowUserToAddRows = false;
            this.dataGridViewModelList.AllowUserToDeleteRows = false;
            this.dataGridViewModelList.AllowUserToResizeColumns = false;
            this.dataGridViewModelList.AllowUserToResizeRows = false;
            this.dataGridViewModelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewModelList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModelList.ContextMenuStrip = this.contextMenuStripModel;
            this.dataGridViewModelList.Location = new System.Drawing.Point(7, 7);
            this.dataGridViewModelList.Name = "dataGridViewModelList";
            this.dataGridViewModelList.ReadOnly = true;
            this.dataGridViewModelList.RowHeadersVisible = false;
            this.dataGridViewModelList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewModelList.Size = new System.Drawing.Size(598, 376);
            this.dataGridViewModelList.TabIndex = 1;
            this.dataGridViewModelList.SelectionChanged += new System.EventHandler(this.dataGridViewModelList_SelectionChanged);
            // 
            // contextMenuStripModel
            // 
            this.contextMenuStripModel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModelToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStripModel.Name = "contextMenuStripModel";
            this.contextMenuStripModel.Size = new System.Drawing.Size(134, 70);
            // 
            // addModelToolStripMenuItem
            // 
            this.addModelToolStripMenuItem.Image = global::D92A_Automation_Function_V7.Properties.Resources.add_list_32;
            this.addModelToolStripMenuItem.Name = "addModelToolStripMenuItem";
            this.addModelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addModelToolStripMenuItem.Text = "Add Model";
            this.addModelToolStripMenuItem.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::D92A_Automation_Function_V7.Properties.Resources.edit_property_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.btnEditModel_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::D92A_Automation_Function_V7.Properties.Resources.trash_can_16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxConnection.Controls.Add(this.label3);
            this.groupBoxConnection.Controls.Add(this.label2);
            this.groupBoxConnection.Controls.Add(this.label1);
            this.groupBoxConnection.Controls.Add(this.btnConnectionSave);
            this.groupBoxConnection.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxConnection.Controls.Add(this.comboBoxBaudList);
            this.groupBoxConnection.Controls.Add(this.comboBoxDriveCamera);
            this.groupBoxConnection.Location = new System.Drawing.Point(611, 6);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(200, 168);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "CONNECTION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Serial Port :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Drive :";
            // 
            // btnConnectionSave
            // 
            this.btnConnectionSave.Location = new System.Drawing.Point(107, 133);
            this.btnConnectionSave.Name = "btnConnectionSave";
            this.btnConnectionSave.Size = new System.Drawing.Size(87, 23);
            this.btnConnectionSave.TabIndex = 4;
            this.btnConnectionSave.Text = "Save";
            this.btnConnectionSave.UseVisualStyleBackColor = true;
            this.btnConnectionSave.Click += new System.EventHandler(this.btnConnectionSave_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(73, 106);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialPort.TabIndex = 3;
            // 
            // comboBoxBaudList
            // 
            this.comboBoxBaudList.FormattingEnabled = true;
            this.comboBoxBaudList.Location = new System.Drawing.Point(73, 79);
            this.comboBoxBaudList.Name = "comboBoxBaudList";
            this.comboBoxBaudList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudList.TabIndex = 3;
            // 
            // statusStripHome
            // 
            this.statusStripHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusConection,
            this.toolStripStatusSerialPort,
            this.toolStripStatusSerialDetails,
            this.toolStripStatusLabelModelID,
            this.toolStripStatusProcessTesting,
            this.toolStripStatusCurrent,
            this.toolStripProgressTesting});
            this.statusStripHome.Location = new System.Drawing.Point(0, 537);
            this.statusStripHome.Name = "statusStripHome";
            this.statusStripHome.Size = new System.Drawing.Size(834, 24);
            this.statusStripHome.TabIndex = 7;
            this.statusStripHome.Text = "statusStrip1";
            // 
            // toolStripStatusConection
            // 
            this.toolStripStatusConection.Name = "toolStripStatusConection";
            this.toolStripStatusConection.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusConection.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusSerialPort
            // 
            this.toolStripStatusSerialPort.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSerialPort.Name = "toolStripStatusSerialPort";
            this.toolStripStatusSerialPort.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusSerialPort.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusSerialDetails
            // 
            this.toolStripStatusSerialDetails.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSerialDetails.Name = "toolStripStatusSerialDetails";
            this.toolStripStatusSerialDetails.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusSerialDetails.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelModelID
            // 
            this.toolStripStatusLabelModelID.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelModelID.Name = "toolStripStatusLabelModelID";
            this.toolStripStatusLabelModelID.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusLabelModelID.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusProcessTesting
            // 
            this.toolStripStatusProcessTesting.Name = "toolStripStatusProcessTesting";
            this.toolStripStatusProcessTesting.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusProcessTesting.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusCurrent
            // 
            this.toolStripStatusCurrent.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusCurrent.Name = "toolStripStatusCurrent";
            this.toolStripStatusCurrent.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusCurrent.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressTesting
            // 
            this.toolStripProgressTesting.Name = "toolStripProgressTesting";
            this.toolStripProgressTesting.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressTesting.Visible = false;
            // 
            // timerNG
            // 
            this.timerNG.Interval = 1000;
            this.timerNG.Tick += new System.EventHandler(this.timerNG_Tick);
            // 
            // timerCounter
            // 
            this.timerCounter.Interval = 900;
            this.timerCounter.Tick += new System.EventHandler(this.timerCounter_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.statusStripHome);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.tableLayoutPanelHomeHeader);
            this.Controls.Add(this.menuStripHome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripHome;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D92A Automation Function V7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.menuStripHome.ResumeLayout(false);
            this.menuStripHome.PerformLayout();
            this.tableLayoutPanelHomeHeader.ResumeLayout(false);
            this.tableLayoutPanelHomeHeader.PerformLayout();
            this.panelHome.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelHome.ResumeLayout(false);
            this.tableLayoutPanelHome2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetect)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelList)).EndInit();
            this.contextMenuStripModel.ResumeLayout(false);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.statusStripHome.ResumeLayout(false);
            this.statusStripHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripHome;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ComboBox comboBoxDriveCamera;
        private System.Windows.Forms.MenuStrip menuStripHome;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHomeHeader;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip statusStripHome;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectionSave;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.ComboBox comboBoxBaudList;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusConection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHome;
        private System.Windows.Forms.DataGridView dataGridViewModelList;
        private System.Windows.Forms.Label lbModelName;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnEditModel;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHome2;
        private System.Windows.Forms.PictureBox pictureBoxDetect;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialDetails;
        private System.Windows.Forms.ToolStripMenuItem iOTestingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripModel;
        private System.Windows.Forms.ToolStripMenuItem addModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelModelID;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem TestingToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtProcessDetails;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialProduct;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton btnCheckBoxAuto;
        private System.Windows.Forms.RadioButton btnCheckBoxManual;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusProcessTesting;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressTesting;
        private System.Windows.Forms.Timer timerNG;
        private System.Windows.Forms.Timer timerCounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCurrent;
        private System.Windows.Forms.ToolStripMenuItem exportHistoryToolStripMenuItem;
    }
}

