namespace D92A_Automation_Function_V7.Controls
{
    partial class ScrollablePictureBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new Netdev.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 96);
            this.listBox1.TabIndex = 0;
            // 
            // ScrollablePictureBox
            // 
            this.GotFocus += new System.EventHandler(this.ScrollablePictureBox_GotFocus);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScrollablePictureBox_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScrollablePictureBox_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ScrollablePictureBox_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScrollablePictureBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrollablePictureBox_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private Netdev.Windows.Forms.ListBox listBox1;
    }
}
