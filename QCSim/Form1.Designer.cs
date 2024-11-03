namespace QCSim
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.ToolStrip();
            this.newCircuit = new System.Windows.Forms.ToolStripButton();
            this.calculateCircuit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.probabilityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.circuitControl1 = new QCSim.CircuitControl();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.initialState = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityChart)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCircuit,
            this.toolStripSeparator1,
            this.calculateCircuit,
            this.toolStripLabel1,
            this.initialState});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(768, 25);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "toolStrip1";
            // 
            // newCircuit
            // 
            this.newCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newCircuit.Image = global::QCSim.Properties.Resources.new_icon;
            this.newCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newCircuit.Name = "newCircuit";
            this.newCircuit.Size = new System.Drawing.Size(23, 22);
            this.newCircuit.Text = "toolStripButton1";
            this.newCircuit.ToolTipText = "New Circuit";
            this.newCircuit.Click += new System.EventHandler(this.newCircuit_Click);
            // 
            // calculateCircuit
            // 
            this.calculateCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.calculateCircuit.Image = global::QCSim.Properties.Resources.cog_go;
            this.calculateCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calculateCircuit.Name = "calculateCircuit";
            this.calculateCircuit.Size = new System.Drawing.Size(23, 22);
            this.calculateCircuit.Text = "toolStripButton2";
            this.calculateCircuit.ToolTipText = "Calculate probabilities";
            this.calculateCircuit.Click += new System.EventHandler(this.calculateCircuit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.probabilityChart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 258);
            this.panel1.TabIndex = 7;
            // 
            // probabilityChart
            // 
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisX.TitleFont = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea5.AxisY.Maximum = 100D;
            chartArea5.AxisY.Minimum = 0D;
            chartArea5.AxisY.TitleFont = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.IsSameFontSizeForAllAxes = true;
            chartArea5.Name = "ChartArea1";
            this.probabilityChart.ChartAreas.Add(chartArea5);
            this.probabilityChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.IsTextAutoFit = false;
            legend5.Name = "Legend1";
            this.probabilityChart.Legends.Add(legend5);
            this.probabilityChart.Location = new System.Drawing.Point(0, 0);
            this.probabilityChart.Name = "probabilityChart";
            series5.BorderColor = System.Drawing.Color.White;
            series5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Blue;
            series5.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Probability";
            series5.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom)));
            this.probabilityChart.Series.Add(series5);
            this.probabilityChart.Size = new System.Drawing.Size(768, 258);
            this.probabilityChart.TabIndex = 0;
            this.probabilityChart.Text = "chart1";
            title5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.Name = "probState";
            title5.Text = "Probability per state";
            this.probabilityChart.Titles.Add(title5);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.circuitControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 343);
            this.panel2.TabIndex = 8;
            // 
            // circuitControl1
            // 
            this.circuitControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitControl1.Location = new System.Drawing.Point(0, 0);
            this.circuitControl1.Name = "circuitControl1";
            this.circuitControl1.Size = new System.Drawing.Size(768, 343);
            this.circuitControl1.TabIndex = 6;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // initialState
            // 
            this.initialState.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialState.Name = "initialState";
            this.initialState.Size = new System.Drawing.Size(50, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "Initial State:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "QCSim";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.probabilityChart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip menuStrip;
        private System.Windows.Forms.ToolStripButton newCircuit;
        private System.Windows.Forms.ToolStripButton calculateCircuit;
        private CircuitControl circuitControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart probabilityChart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox initialState;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

