namespace D92A_Automation_Function_V7.forms.ServoControls
{
    partial class ServoControls
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarAngleAuto = new System.Windows.Forms.TrackBar();
            this.trackBarAngleManual = new System.Windows.Forms.TrackBar();
            this.btnSaveIO = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAngleAuto = new System.Windows.Forms.NumericUpDown();
            this.txtAngleManual = new System.Windows.Forms.NumericUpDown();
            this.txtAutoDelay = new System.Windows.Forms.NumericUpDown();
            this.btnIO_TypeAuto = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIO_TypeManual = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngleAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngleManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(13, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 457);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBarAngleAuto);
            this.groupBox1.Controls.Add(this.trackBarAngleManual);
            this.groupBox1.Controls.Add(this.btnSaveIO);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDelay);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAngleAuto);
            this.groupBox1.Controls.Add(this.txtAngleManual);
            this.groupBox1.Controls.Add(this.txtAutoDelay);
            this.groupBox1.Controls.Add(this.btnIO_TypeAuto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnIO_TypeManual);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(372, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 450);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter";
            // 
            // trackBarAngleAuto
            // 
            this.trackBarAngleAuto.Location = new System.Drawing.Point(6, 218);
            this.trackBarAngleAuto.Maximum = 180;
            this.trackBarAngleAuto.Name = "trackBarAngleAuto";
            this.trackBarAngleAuto.Size = new System.Drawing.Size(250, 45);
            this.trackBarAngleAuto.TabIndex = 25;
            this.trackBarAngleAuto.ValueChanged += new System.EventHandler(this.trackBarAngleManual_ValueChanged);
            // 
            // trackBarAngleManual
            // 
            this.trackBarAngleManual.Location = new System.Drawing.Point(6, 77);
            this.trackBarAngleManual.Maximum = 180;
            this.trackBarAngleManual.Name = "trackBarAngleManual";
            this.trackBarAngleManual.Size = new System.Drawing.Size(250, 45);
            this.trackBarAngleManual.TabIndex = 25;
            this.trackBarAngleManual.ValueChanged += new System.EventHandler(this.trackBarAngleManual_ValueChanged);
            // 
            // btnSaveIO
            // 
            this.btnSaveIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveIO.Location = new System.Drawing.Point(191, 421);
            this.btnSaveIO.Name = "btnSaveIO";
            this.btnSaveIO.Size = new System.Drawing.Size(75, 23);
            this.btnSaveIO.TabIndex = 24;
            this.btnSaveIO.Text = "Save";
            this.btnSaveIO.UseVisualStyleBackColor = true;
            this.btnSaveIO.Click += new System.EventHandler(this.btnSaveIO_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "ms";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Delay Next Fuction :";
            // 
            // txtDelay
            // 
            this.txtDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelay.Location = new System.Drawing.Point(52, 422);
            this.txtDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(91, 21);
            this.txtDelay.TabIndex = 21;
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelay.ThousandsSeparator = true;
            this.txtDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(208, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "Degree";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Degree";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "ms";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(48, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Delay";
            // 
            // txtAngleAuto
            // 
            this.txtAngleAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngleAuto.Location = new System.Drawing.Point(92, 191);
            this.txtAngleAuto.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.txtAngleAuto.Name = "txtAngleAuto";
            this.txtAngleAuto.Size = new System.Drawing.Size(111, 21);
            this.txtAngleAuto.TabIndex = 14;
            this.txtAngleAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAngleAuto.ThousandsSeparator = true;
            this.txtAngleAuto.ValueChanged += new System.EventHandler(this.txtAngleManual_ValueChanged);
            // 
            // txtAngleManual
            // 
            this.txtAngleManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngleManual.Location = new System.Drawing.Point(92, 57);
            this.txtAngleManual.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.txtAngleManual.Name = "txtAngleManual";
            this.txtAngleManual.Size = new System.Drawing.Size(111, 21);
            this.txtAngleManual.TabIndex = 14;
            this.txtAngleManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAngleManual.ThousandsSeparator = true;
            this.txtAngleManual.ValueChanged += new System.EventHandler(this.txtAngleManual_ValueChanged);
            // 
            // txtAutoDelay
            // 
            this.txtAutoDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoDelay.Location = new System.Drawing.Point(91, 264);
            this.txtAutoDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAutoDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtAutoDelay.Name = "txtAutoDelay";
            this.txtAutoDelay.Size = new System.Drawing.Size(111, 21);
            this.txtAutoDelay.TabIndex = 14;
            this.txtAutoDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutoDelay.ThousandsSeparator = true;
            this.txtAutoDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnIO_TypeAuto
            // 
            this.btnIO_TypeAuto.AutoSize = true;
            this.btnIO_TypeAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO_TypeAuto.Location = new System.Drawing.Point(19, 166);
            this.btnIO_TypeAuto.Name = "btnIO_TypeAuto";
            this.btnIO_TypeAuto.Size = new System.Drawing.Size(96, 19);
            this.btnIO_TypeAuto.TabIndex = 13;
            this.btnIO_TypeAuto.TabStop = true;
            this.btnIO_TypeAuto.Text = "Auto ON/OFF";
            this.btnIO_TypeAuto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(6, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 10);
            this.label3.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(6, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 10);
            this.label8.TabIndex = 12;
            // 
            // btnIO_TypeManual
            // 
            this.btnIO_TypeManual.AutoSize = true;
            this.btnIO_TypeManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIO_TypeManual.Location = new System.Drawing.Point(20, 19);
            this.btnIO_TypeManual.Name = "btnIO_TypeManual";
            this.btnIO_TypeManual.Size = new System.Drawing.Size(67, 19);
            this.btnIO_TypeManual.TabIndex = 8;
            this.btnIO_TypeManual.TabStop = true;
            this.btnIO_TypeManual.Text = "Manual";
            this.btnIO_TypeManual.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Image = global::D92A_Automation_Function_V7.Properties.Resources.degree_02;
            this.pictureBox.Location = new System.Drawing.Point(4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(362, 450);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // ServoControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ServoControls";
            this.Text = "ServoControls";
            this.Load += new System.EventHandler(this.ServoControls_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngleAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngleManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveIO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtAutoDelay;
        private System.Windows.Forms.RadioButton btnIO_TypeAuto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton btnIO_TypeManual;
        private System.Windows.Forms.TrackBar trackBarAngleManual;
        private System.Windows.Forms.NumericUpDown txtAngleManual;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarAngleAuto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtAngleAuto;
    }
}