namespace QCSim
{
    partial class GateForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Hadamard Gate", "hadamard");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("X (NOT) Gate", "x");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Y Gate", "y");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Z Gate", "z");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GateForm));
            this.typeList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.controlQbitPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeList
            // 
            this.typeList.HideSelection = false;
            this.typeList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.typeList.LargeImageList = this.imageList1;
            this.typeList.Location = new System.Drawing.Point(12, 27);
            this.typeList.Name = "typeList";
            this.typeList.Size = new System.Drawing.Size(308, 226);
            this.typeList.TabIndex = 0;
            this.typeList.UseCompatibleStateImageBehavior = false;
            this.typeList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.typeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hadamard");
            this.imageList1.Images.SetKeyName(1, "x");
            this.imageList1.Images.SetKeyName(2, "y");
            this.imageList1.Images.SetKeyName(3, "z");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gate Types";
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(12, 259);
            this.descBox.Name = "descBox";
            this.descBox.ReadOnly = true;
            this.descBox.Size = new System.Drawing.Size(308, 20);
            this.descBox.TabIndex = 2;
            this.descBox.WordWrap = false;
            // 
            // controlQbitPanel
            // 
            this.controlQbitPanel.AutoScroll = true;
            this.controlQbitPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.controlQbitPanel.Location = new System.Drawing.Point(6, 19);
            this.controlQbitPanel.Name = "controlQbitPanel";
            this.controlQbitPanel.Size = new System.Drawing.Size(83, 227);
            this.controlQbitPanel.TabIndex = 3;
            this.controlQbitPanel.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.controlQbitPanel);
            this.groupBox1.Location = new System.Drawing.Point(326, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 252);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control QBits";
            // 
            // GateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GateForm";
            this.Text = "QCSim - Insert Gate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GateForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView typeList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.FlowLayoutPanel controlQbitPanel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}