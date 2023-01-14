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
            this.contextMenuStripHome = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnStartStop = new System.Windows.Forms.Button();
            this.comboBoxDriveCamera = new System.Windows.Forms.ComboBox();
            this.menuStripHome = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelHomeHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lbModelName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelHome = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHome2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditModel = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.dataGridViewModelList = new System.Windows.Forms.DataGridView();
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
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.pictureBoxDetect = new System.Windows.Forms.PictureBox();
            this.menuStripHome.SuspendLayout();
            this.tableLayoutPanelHomeHeader.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelHome.SuspendLayout();
            this.tableLayoutPanelHome2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelList)).BeginInit();
            this.groupBoxConnection.SuspendLayout();
            this.statusStripHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetect)).BeginInit();
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iOTestingToolStripMenuItem});
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
            // tableLayoutPanelHomeHeader
            // 
            this.tableLayoutPanelHomeHeader.ColumnCount = 3;
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06954F));
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.26379F));
            this.tableLayoutPanelHomeHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelHomeHeader.Controls.Add(this.btnStartStop, 0, 0);
            this.tableLayoutPanelHomeHeader.Controls.Add(this.lbModelName, 1, 0);
            this.tableLayoutPanelHomeHeader.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanelHomeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHomeHeader.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelHomeHeader.Name = "tableLayoutPanelHomeHeader";
            this.tableLayoutPanelHomeHeader.RowCount = 1;
            this.tableLayoutPanelHomeHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHomeHeader.Size = new System.Drawing.Size(834, 84);
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
            this.lbModelName.Size = new System.Drawing.Size(569, 68);
            this.lbModelName.TabIndex = 3;
            this.lbModelName.Text = "-----------------------";
            this.lbModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(703, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 64);
            this.label5.TabIndex = 4;
            this.label5.Text = "Wait...";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHome
            // 
            this.panelHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHome.BackColor = System.Drawing.Color.Transparent;
            this.panelHome.Controls.Add(this.tabControl1);
            this.panelHome.Location = new System.Drawing.Point(3, 116);
            this.panelHome.Margin = new System.Windows.Forms.Padding(5);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(831, 420);
            this.panelHome.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 414);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelHome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HOME";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelHome
            // 
            this.tableLayoutPanelHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelHome.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelHome.ColumnCount = 2;
            this.tableLayoutPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome.Controls.Add(this.pictureBoxCamera, 0, 0);
            this.tableLayoutPanelHome.Controls.Add(this.tableLayoutPanelHome2, 1, 0);
            this.tableLayoutPanelHome.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanelHome.Name = "tableLayoutPanelHome";
            this.tableLayoutPanelHome.RowCount = 1;
            this.tableLayoutPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome.Size = new System.Drawing.Size(805, 379);
            this.tableLayoutPanelHome.TabIndex = 0;
            // 
            // tableLayoutPanelHome2
            // 
            this.tableLayoutPanelHome2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelHome2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelHome2.ColumnCount = 1;
            this.tableLayoutPanelHome2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.Controls.Add(this.pictureBoxDetect, 0, 0);
            this.tableLayoutPanelHome2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanelHome2.Location = new System.Drawing.Point(406, 4);
            this.tableLayoutPanelHome2.Name = "tableLayoutPanelHome2";
            this.tableLayoutPanelHome2.RowCount = 2;
            this.tableLayoutPanelHome2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHome2.Size = new System.Drawing.Size(395, 371);
            this.tableLayoutPanelHome2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 189);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(387, 178);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "STATUS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.82759F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.17241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 329);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.tabPage3.Size = new System.Drawing.Size(817, 388);
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
            this.dataGridViewModelList.Location = new System.Drawing.Point(7, 7);
            this.dataGridViewModelList.Name = "dataGridViewModelList";
            this.dataGridViewModelList.ReadOnly = true;
            this.dataGridViewModelList.RowHeadersVisible = false;
            this.dataGridViewModelList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewModelList.Size = new System.Drawing.Size(598, 376);
            this.dataGridViewModelList.TabIndex = 1;
            this.dataGridViewModelList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModelList_CellContentClick);
            this.dataGridViewModelList.SelectionChanged += new System.EventHandler(this.dataGridViewModelList_SelectionChanged);
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
            this.toolStripStatusSerialDetails});
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
            this.toolStripStatusSerialDetails.Name = "toolStripStatusSerialDetails";
            this.toolStripStatusSerialDetails.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusSerialDetails.Text = "toolStripStatusLabel1";
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(395, 371);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCamera.TabIndex = 1;
            this.pictureBoxCamera.TabStop = false;
            // 
            // pictureBoxDetect
            // 
            this.pictureBoxDetect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDetect.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxDetect.Name = "pictureBoxDetect";
            this.pictureBoxDetect.Size = new System.Drawing.Size(387, 178);
            this.pictureBoxDetect.TabIndex = 0;
            this.pictureBoxDetect.TabStop = false;
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
            this.MainMenuStrip = this.menuStripHome;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStripHome.ResumeLayout(false);
            this.menuStripHome.PerformLayout();
            this.tableLayoutPanelHomeHeader.ResumeLayout(false);
            this.tableLayoutPanelHomeHeader.PerformLayout();
            this.panelHome.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelHome.ResumeLayout(false);
            this.tableLayoutPanelHome2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelList)).EndInit();
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.statusStripHome.ResumeLayout(false);
            this.statusStripHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetect)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditModel;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHome2;
        private System.Windows.Forms.PictureBox pictureBoxDetect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialDetails;
        private System.Windows.Forms.ToolStripMenuItem iOTestingToolStripMenuItem;
    }
}

