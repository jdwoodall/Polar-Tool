namespace Polar_Tool
{
    partial class formMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.polarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.polarGrid = new System.Windows.Forms.DataGridView();
            this.polarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStripPolarGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStripPolarTable = new System.Windows.Forms.ToolStripMenuItem();
            this.polarGridGroup = new System.Windows.Forms.GroupBox();
            this.chartColGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtGraphCol = new System.Windows.Forms.TextBox();
            this.btnGraphLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.polarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polarGrid)).BeginInit();
            this.polarMenuStrip.SuspendLayout();
            this.polarGridGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // polarChart
            // 
            this.polarChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.polarChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.polarChart.Legends.Add(legend1);
            this.polarChart.Location = new System.Drawing.Point(28, 27);
            this.polarChart.Name = "polarChart";
            this.polarChart.Size = new System.Drawing.Size(1002, 510);
            this.polarChart.TabIndex = 3;
            title1.Name = "Polar Graph";
            this.polarChart.Titles.Add(title1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // polarGrid
            // 
            this.polarGrid.AllowUserToAddRows = false;
            this.polarGrid.AllowUserToDeleteRows = false;
            this.polarGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.polarGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.polarGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.polarGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.polarGrid.Location = new System.Drawing.Point(0, 19);
            this.polarGrid.Name = "polarGrid";
            this.polarGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.polarGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.polarGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.polarGrid.RowTemplate.DefaultCellStyle.Format = "N1";
            this.polarGrid.RowTemplate.DefaultCellStyle.NullValue = "0";
            this.polarGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.polarGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.polarGrid.Size = new System.Drawing.Size(821, 449);
            this.polarGrid.TabIndex = 4;
            this.polarGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            this.polarGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            this.polarGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            // 
            // polarMenuStrip
            // 
            this.polarMenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.polarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStrip,
            this.editToolStrip,
            this.viewToolStrip});
            this.polarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.polarMenuStrip.Name = "polarMenuStrip";
            this.polarMenuStrip.Size = new System.Drawing.Size(1059, 24);
            this.polarMenuStrip.TabIndex = 2;
            this.polarMenuStrip.Text = "polarMenuStrip";
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripOpen,
            this.fileStripSave,
            this.fileStripExit});
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(37, 20);
            this.fileToolStrip.Text = "File";
            this.fileToolStrip.Click += new System.EventHandler(this.fileToolStrip_Click);
            // 
            // fileStripOpen
            // 
            this.fileStripOpen.Name = "fileStripOpen";
            this.fileStripOpen.Size = new System.Drawing.Size(103, 22);
            this.fileStripOpen.Text = "Open";
            this.fileStripOpen.Click += new System.EventHandler(this.fileStripOpen_Click);
            // 
            // fileStripSave
            // 
            this.fileStripSave.Name = "fileStripSave";
            this.fileStripSave.Size = new System.Drawing.Size(103, 22);
            this.fileStripSave.Text = "Save";
            // 
            // fileStripExit
            // 
            this.fileStripExit.Name = "fileStripExit";
            this.fileStripExit.Size = new System.Drawing.Size(103, 22);
            this.fileStripExit.Text = "Exit";
            this.fileStripExit.Click += new System.EventHandler(this.fileStripExit_Click);
            // 
            // editToolStrip
            // 
            this.editToolStrip.Name = "editToolStrip";
            this.editToolStrip.Size = new System.Drawing.Size(39, 20);
            this.editToolStrip.Text = "Edit";
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStripPolarGraph,
            this.viewStripPolarTable});
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Size = new System.Drawing.Size(44, 20);
            this.viewToolStrip.Text = "View";
            // 
            // viewStripPolarGraph
            // 
            this.viewStripPolarGraph.Name = "viewStripPolarGraph";
            this.viewStripPolarGraph.Size = new System.Drawing.Size(103, 22);
            this.viewStripPolarGraph.Text = "Chart";
            this.viewStripPolarGraph.Click += new System.EventHandler(this.viewStripPolarChart_Click);
            // 
            // viewStripPolarTable
            // 
            this.viewStripPolarTable.Name = "viewStripPolarTable";
            this.viewStripPolarTable.Size = new System.Drawing.Size(103, 22);
            this.viewStripPolarTable.Text = "Table";
            this.viewStripPolarTable.Click += new System.EventHandler(this.viewStripPolarTable_Click);
            // 
            // polarGridGroup
            // 
            this.polarGridGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.polarGridGroup.Controls.Add(this.chartColGraph);
            this.polarGridGroup.Controls.Add(this.txtGraphCol);
            this.polarGridGroup.Controls.Add(this.btnGraphLine);
            this.polarGridGroup.Controls.Add(this.polarGrid);
            this.polarGridGroup.Location = new System.Drawing.Point(0, 27);
            this.polarGridGroup.Name = "polarGridGroup";
            this.polarGridGroup.Size = new System.Drawing.Size(1059, 510);
            this.polarGridGroup.TabIndex = 5;
            this.polarGridGroup.TabStop = false;
            this.polarGridGroup.Text = "Polar TWA/TWS";
            // 
            // chartColGraph
            // 
            this.chartColGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chartColGraph.BorderlineColor = System.Drawing.Color.Black;
            this.chartColGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartColGraph.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartColGraph.BorderSkin.BorderWidth = 2;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.IsReversed = true;
            chartArea2.AxisY.Maximum = 180D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartColGraph.ChartAreas.Add(chartArea2);
            this.chartColGraph.Location = new System.Drawing.Point(827, 19);
            this.chartColGraph.Name = "chartColGraph";
            this.chartColGraph.Size = new System.Drawing.Size(232, 449);
            this.chartColGraph.TabIndex = 7;
            this.chartColGraph.Text = "chart1";
            // 
            // txtGraphCol
            // 
            this.txtGraphCol.Location = new System.Drawing.Point(890, 477);
            this.txtGraphCol.Name = "txtGraphCol";
            this.txtGraphCol.Size = new System.Drawing.Size(100, 20);
            this.txtGraphCol.TabIndex = 6;
            // 
            // btnGraphLine
            // 
            this.btnGraphLine.Location = new System.Drawing.Point(770, 474);
            this.btnGraphLine.Name = "btnGraphLine";
            this.btnGraphLine.Size = new System.Drawing.Size(94, 25);
            this.btnGraphLine.TabIndex = 5;
            this.btnGraphLine.Text = "Graph Column";
            this.btnGraphLine.UseVisualStyleBackColor = true;
            this.btnGraphLine.Click += new System.EventHandler(this.btnGraphLine_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 537);
            this.Controls.Add(this.polarGridGroup);
            this.Controls.Add(this.polarMenuStrip);
            this.Controls.Add(this.polarChart);
            this.MainMenuStrip = this.polarMenuStrip;
            this.Name = "formMain";
            this.Text = "Polar Tool";
            ((System.ComponentModel.ISupportInitialize)(this.polarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polarGrid)).EndInit();
            this.polarMenuStrip.ResumeLayout(false);
            this.polarMenuStrip.PerformLayout();
            this.polarGridGroup.ResumeLayout(false);
            this.polarGridGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //
        // Dialogs and Graphs
        //
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView polarGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart polarChart;

        //
        // Menu bar
        //
        private System.Windows.Forms.MenuStrip polarMenuStrip;
        //
        // File Menu
        //
        private System.Windows.Forms.ToolStripMenuItem fileToolStrip;
        private System.Windows.Forms.ToolStripMenuItem fileStripOpen;
        private System.Windows.Forms.ToolStripMenuItem fileStripSave;
        private System.Windows.Forms.ToolStripMenuItem fileStripExit;
        //
        // View menu
        //
        private System.Windows.Forms.ToolStripMenuItem viewToolStrip;
        private System.Windows.Forms.ToolStripMenuItem viewStripPolarGraph;
        private System.Windows.Forms.ToolStripMenuItem viewStripPolarTable;
        //
        //Edit menu
        //
        private System.Windows.Forms.ToolStripMenuItem editToolStrip;
        //
        // polar grid group box
        //
        private System.Windows.Forms.GroupBox polarGridGroup;
        private System.Windows.Forms.Button btnGraphLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColGraph;
        private System.Windows.Forms.TextBox txtGraphCol;
    }
}

