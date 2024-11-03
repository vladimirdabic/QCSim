namespace QCSim
{
    partial class CircuitControl
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.circuitWindow = new QCSim.CircuitWindow();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.circuitWindow)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Enabled = false;
            this.vScrollBar1.Location = new System.Drawing.Point(811, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 427);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Enabled = false;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 410);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(811, 17);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // circuitWindow
            // 
            this.circuitWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitWindow.Location = new System.Drawing.Point(0, 0);
            this.circuitWindow.Name = "circuitWindow";
            this.circuitWindow.Size = new System.Drawing.Size(811, 410);
            this.circuitWindow.TabIndex = 0;
            this.circuitWindow.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.circuitWindow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 410);
            this.panel1.TabIndex = 3;
            // 
            // CircuitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "CircuitControl";
            this.Size = new System.Drawing.Size(828, 427);
            ((System.ComponentModel.ISupportInitialize)(this.circuitWindow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        public CircuitWindow circuitWindow;
        private System.Windows.Forms.Panel panel1;
    }
}
