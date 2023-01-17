namespace D92A_Automation_Function_V7
{
    partial class Actions
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
            this.btnSaveAction = new System.Windows.Forms.Button();
            this.btnSelectedIOFunction = new System.Windows.Forms.RadioButton();
            this.btnSelectedImageFunction = new System.Windows.Forms.RadioButton();
            this.groupBoxIO = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbButtom = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTimeOutS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTimeOut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.NumericUpDown();
            this.txtTimeOut = new System.Windows.Forms.NumericUpDown();
            this.txtAutoDelay = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOFF = new System.Windows.Forms.CheckBox();
            this.checkBocON = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIOPort = new System.Windows.Forms.ComboBox();
            this.btnIO_TypeWaitJudgment = new System.Windows.Forms.RadioButton();
            this.btnIO_TypeAuto = new System.Windows.Forms.RadioButton();
            this.btnIO_TypeManual = new System.Windows.Forms.RadioButton();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.txtPercent = new System.Windows.Forms.NumericUpDown();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDriveCamera = new System.Windows.Forms.ComboBox();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBoxIO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).BeginInit();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAction
            // 
            this.btnSaveAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAction.Location = new System.Drawing.Point(736, 532);
            this.btnSaveAction.Name = "btnSaveAction";
            this.btnSaveAction.Size = new System.Drawing.Size(93, 23);
            this.btnSaveAction.TabIndex = 3;
            this.btnSaveAction.Text = "Save";
            this.btnSaveAction.UseVisualStyleBackColor = true;
            this.btnSaveAction.Click += new System.EventHandler(this.btnSaveAction_Click);
            // 
            // btnSelectedIOFunction
            // 
            this.btnSelectedIOFunction.AutoSize = true;
            this.btnSelectedIOFunction.Location = new System.Drawing.Point(12, 26);
            this.btnSelectedIOFunction.Name = "btnSelectedIOFunction";
            this.btnSelectedIOFunction.Size = new System.Drawing.Size(74, 17);
            this.btnSelectedIOFunction.TabIndex = 4;
            this.btnSelectedIOFunction.TabStop = true;
            this.btnSelectedIOFunction.Text = "IO Fuction";
            this.btnSelectedIOFunction.UseVisualStyleBackColor = true;
            // 
            // btnSelectedImageFunction
            // 
            this.btnSelectedImageFunction.AutoSize = true;
            this.btnSelectedImageFunction.Location = new System.Drawing.Point(231, 26);
            this.btnSelectedImageFunction.Name = "btnSelectedImageFunction";
            this.btnSelectedImageFunction.Size = new System.Drawing.Size(98, 17);
            this.btnSelectedImageFunction.TabIndex = 4;
            this.btnSelectedImageFunction.TabStop = true;
            this.btnSelectedImageFunction.Text = "Image Function";
            this.btnSelectedImageFunction.UseVisualStyleBackColor = true;
            // 
            // groupBoxIO
            // 
            this.groupBoxIO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxIO.Controls.Add(this.label12);
            this.groupBoxIO.Controls.Add(this.label8);
            this.groupBoxIO.Controls.Add(this.lbButtom);
            this.groupBoxIO.Controls.Add(this.label7);
            this.groupBoxIO.Controls.Add(this.label3);
            this.groupBoxIO.Controls.Add(this.label5);
            this.groupBoxIO.Controls.Add(this.lbTimeOutS);
            this.groupBoxIO.Controls.Add(this.label4);
            this.groupBoxIO.Controls.Add(this.label6);
            this.groupBoxIO.Controls.Add(this.lbTimeOut);
            this.groupBoxIO.Controls.Add(this.label2);
            this.groupBoxIO.Controls.Add(this.txtDelay);
            this.groupBoxIO.Controls.Add(this.txtTimeOut);
            this.groupBoxIO.Controls.Add(this.txtAutoDelay);
            this.groupBoxIO.Controls.Add(this.checkBoxOFF);
            this.groupBoxIO.Controls.Add(this.checkBocON);
            this.groupBoxIO.Controls.Add(this.label1);
            this.groupBoxIO.Controls.Add(this.comboBoxIOPort);
            this.groupBoxIO.Controls.Add(this.btnIO_TypeWaitJudgment);
            this.groupBoxIO.Controls.Add(this.btnIO_TypeAuto);
            this.groupBoxIO.Controls.Add(this.btnIO_TypeManual);
            this.groupBoxIO.Location = new System.Drawing.Point(12, 49);
            this.groupBoxIO.Name = "groupBoxIO";
            this.groupBoxIO.Size = new System.Drawing.Size(205, 461);
            this.groupBoxIO.TabIndex = 5;
            this.groupBoxIO.TabStop = false;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(8, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 10);
            this.label12.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(8, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 10);
            this.label8.TabIndex = 7;
            // 
            // lbButtom
            // 
            this.lbButtom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbButtom.Location = new System.Drawing.Point(8, 345);
            this.lbButtom.Name = "lbButtom";
            this.lbButtom.Size = new System.Drawing.Size(190, 10);
            this.lbButtom.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(8, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 10);
            this.label7.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Parameter";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(166, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "ms";
            // 
            // lbTimeOutS
            // 
            this.lbTimeOutS.AutoSize = true;
            this.lbTimeOutS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeOutS.Location = new System.Drawing.Point(166, 311);
            this.lbTimeOutS.Name = "lbTimeOutS";
            this.lbTimeOutS.Size = new System.Drawing.Size(13, 15);
            this.lbTimeOutS.TabIndex = 5;
            this.lbTimeOutS.Text = "s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "ms";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Delay Next Fuction :";
            // 
            // lbTimeOut
            // 
            this.lbTimeOut.AutoSize = true;
            this.lbTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeOut.Location = new System.Drawing.Point(2, 311);
            this.lbTimeOut.Name = "lbTimeOut";
            this.lbTimeOut.Size = new System.Drawing.Size(63, 15);
            this.lbTimeOut.TabIndex = 5;
            this.lbTimeOut.Text = "Time Out :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Delay";
            // 
            // txtDelay
            // 
            this.txtDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelay.Location = new System.Drawing.Point(71, 431);
            this.txtDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(91, 21);
            this.txtDelay.TabIndex = 4;
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelay.ThousandsSeparator = true;
            this.txtDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeOut.Location = new System.Drawing.Point(71, 309);
            this.txtTimeOut.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(91, 21);
            this.txtTimeOut.TabIndex = 4;
            this.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeOut.ThousandsSeparator = true;
            this.txtTimeOut.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtAutoDelay
            // 
            this.txtAutoDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoDelay.Location = new System.Drawing.Point(71, 237);
            this.txtAutoDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAutoDelay.Name = "txtAutoDelay";
            this.txtAutoDelay.Size = new System.Drawing.Size(91, 21);
            this.txtAutoDelay.TabIndex = 4;
            this.txtAutoDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutoDelay.ThousandsSeparator = true;
            this.txtAutoDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // checkBoxOFF
            // 
            this.checkBoxOFF.AutoSize = true;
            this.checkBoxOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOFF.Location = new System.Drawing.Point(30, 164);
            this.checkBoxOFF.Name = "checkBoxOFF";
            this.checkBoxOFF.Size = new System.Drawing.Size(49, 19);
            this.checkBoxOFF.TabIndex = 3;
            this.checkBoxOFF.Text = "OFF";
            this.checkBoxOFF.UseVisualStyleBackColor = true;
            this.checkBoxOFF.CheckedChanged += new System.EventHandler(this.CheckBoxOFF_CheckedChanged);
            // 
            // checkBocON
            // 
            this.checkBocON.AutoSize = true;
            this.checkBocON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBocON.Location = new System.Drawing.Point(30, 141);
            this.checkBocON.Name = "checkBocON";
            this.checkBocON.Size = new System.Drawing.Size(44, 19);
            this.checkBocON.TabIndex = 3;
            this.checkBocON.Text = "ON";
            this.checkBocON.UseVisualStyleBackColor = true;
            this.checkBocON.CheckedChanged += new System.EventHandler(this.checkBocON_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "IO Port :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxIOPort
            // 
            this.comboBoxIOPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxIOPort.FormattingEnabled = true;
            this.comboBoxIOPort.Location = new System.Drawing.Point(67, 59);
            this.comboBoxIOPort.Name = "comboBoxIOPort";
            this.comboBoxIOPort.Size = new System.Drawing.Size(95, 23);
            this.comboBoxIOPort.TabIndex = 1;
            // 
            // btnIO_TypeWaitJudgment
            // 
            this.btnIO_TypeWaitJudgment.AutoSize = true;
            this.btnIO_TypeWaitJudgment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO_TypeWaitJudgment.Location = new System.Drawing.Point(9, 284);
            this.btnIO_TypeWaitJudgment.Name = "btnIO_TypeWaitJudgment";
            this.btnIO_TypeWaitJudgment.Size = new System.Drawing.Size(107, 19);
            this.btnIO_TypeWaitJudgment.TabIndex = 0;
            this.btnIO_TypeWaitJudgment.TabStop = true;
            this.btnIO_TypeWaitJudgment.Text = "Wait Judgment";
            this.btnIO_TypeWaitJudgment.UseVisualStyleBackColor = true;
            // 
            // btnIO_TypeAuto
            // 
            this.btnIO_TypeAuto.AutoSize = true;
            this.btnIO_TypeAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO_TypeAuto.Location = new System.Drawing.Point(9, 207);
            this.btnIO_TypeAuto.Name = "btnIO_TypeAuto";
            this.btnIO_TypeAuto.Size = new System.Drawing.Size(96, 19);
            this.btnIO_TypeAuto.TabIndex = 0;
            this.btnIO_TypeAuto.TabStop = true;
            this.btnIO_TypeAuto.Text = "Auto ON/OFF";
            this.btnIO_TypeAuto.UseVisualStyleBackColor = true;
            // 
            // btnIO_TypeManual
            // 
            this.btnIO_TypeManual.AutoSize = true;
            this.btnIO_TypeManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO_TypeManual.Location = new System.Drawing.Point(7, 116);
            this.btnIO_TypeManual.Name = "btnIO_TypeManual";
            this.btnIO_TypeManual.Size = new System.Drawing.Size(67, 19);
            this.btnIO_TypeManual.TabIndex = 0;
            this.btnIO_TypeManual.TabStop = true;
            this.btnIO_TypeManual.Text = "Manual";
            this.btnIO_TypeManual.UseVisualStyleBackColor = true;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadImage.Location = new System.Drawing.Point(498, 431);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(93, 23);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // txtPercent
            // 
            this.txtPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPercent.Location = new System.Drawing.Point(88, 408);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(106, 20);
            this.txtPercent.TabIndex = 4;
            this.txtPercent.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImage.Controls.Add(this.label11);
            this.groupBoxImage.Controls.Add(this.label10);
            this.groupBoxImage.Controls.Add(this.comboBoxDriveCamera);
            this.groupBoxImage.Controls.Add(this.pictureBoxCamera);
            this.groupBoxImage.Controls.Add(this.txtPercent);
            this.groupBoxImage.Controls.Add(this.label9);
            this.groupBoxImage.Controls.Add(this.btnLoadImage);
            this.groupBoxImage.Location = new System.Drawing.Point(231, 49);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(604, 460);
            this.groupBoxImage.TabIndex = 5;
            this.groupBoxImage.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Percent % :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(415, 411);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Drive Camera :";
            // 
            // comboBoxDriveCamera
            // 
            this.comboBoxDriveCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDriveCamera.FormattingEnabled = true;
            this.comboBoxDriveCamera.Location = new System.Drawing.Point(498, 408);
            this.comboBoxDriveCamera.Name = "comboBoxDriveCamera";
            this.comboBoxDriveCamera.Size = new System.Drawing.Size(93, 21);
            this.comboBoxDriveCamera.TabIndex = 7;
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCamera.Location = new System.Drawing.Point(20, 59);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(571, 343);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCamera.TabIndex = 5;
            this.pictureBoxCamera.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(574, 30);
            this.label9.TabIndex = 6;
            this.label9.Text = "Master Image";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(847, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 580);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxIO);
            this.Controls.Add(this.btnSelectedImageFunction);
            this.Controls.Add(this.btnSelectedIOFunction);
            this.Controls.Add(this.btnSaveAction);
            this.Name = "Actions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actions";
            this.Load += new System.EventHandler(this.Actions_Load);
            this.groupBoxIO.ResumeLayout(false);
            this.groupBoxIO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).EndInit();
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSaveAction;
        private System.Windows.Forms.RadioButton btnSelectedIOFunction;
        private System.Windows.Forms.RadioButton btnSelectedImageFunction;
        private System.Windows.Forms.GroupBox groupBoxIO;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.NumericUpDown txtPercent;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.RadioButton btnIO_TypeAuto;
        private System.Windows.Forms.RadioButton btnIO_TypeManual;
        private System.Windows.Forms.CheckBox checkBoxOFF;
        private System.Windows.Forms.CheckBox checkBocON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIOPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtDelay;
        private System.Windows.Forms.NumericUpDown txtAutoDelay;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.ComboBox comboBoxDriveCamera;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbButtom;
        private System.Windows.Forms.Label lbTimeOutS;
        private System.Windows.Forms.Label lbTimeOut;
        private System.Windows.Forms.NumericUpDown txtTimeOut;
        private System.Windows.Forms.RadioButton btnIO_TypeWaitJudgment;
    }
}