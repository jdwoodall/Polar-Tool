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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
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
            this.btnGraphLine = new System.Windows.Forms.Button();
            this.txtGraphCol = new System.Windows.Forms.TextBox();
            this.chartColGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            chartArea3.Name = "ChartArea1";
            this.polarChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.polarChart.Legends.Add(legend3);
            this.polarChart.Location = new System.Drawing.Point(0, 27);
            this.polarChart.Name = "polarChart";
            this.polarChart.Size = new System.Drawing.Size(1002, 510);
            this.polarChart.TabIndex = 3;
            title2.Name = "Polar Graph";
            this.polarChart.Titles.Add(title2);
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
            this.polarGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.polarGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "N1";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.polarGrid.Location = new System.Drawing.Point(0, 19);
            this.polarGrid.Name = "polarGrid";
            this.polarGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.polarGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle8.Format = "N1";
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.polarGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.polarGrid.RowTemplate.DefaultCellStyle.Format = "N1";
            this.polarGrid.RowTemplate.DefaultCellStyle.NullValue = "0";
            this.polarGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.polarGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.polarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.polarGrid.Size = new System.Drawing.Size(1002, 449);
            this.polarGrid.TabIndex = 4;
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
            this.polarMenuStrip.Size = new System.Drawing.Size(1002, 24);
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
            this.polarGridGroup.Size = new System.Drawing.Size(1002, 510);
            this.polarGridGroup.TabIndex = 5;
            this.polarGridGroup.TabStop = false;
            this.polarGridGroup.Text = "Polar TWA/TWS";
            // 
            // btnGraphLine
            // 
            this.btnGraphLine.Location = new System.Drawing.Point(36, 479);
            this.btnGraphLine.Name = "btnGraphLine";
            this.btnGraphLine.Size = new System.Drawing.Size(94, 25);
            this.btnGraphLine.TabIndex = 5;
            this.btnGraphLine.Text = "Graph Column";
            this.btnGraphLine.UseVisualStyleBackColor = true;
            this.btnGraphLine.Click += new System.EventHandler(this.btnGraphLine_Click);
            // 
            // txtGraphCol
            // 
            this.txtGraphCol.Location = new System.Drawing.Point(136, 482);
            this.txtGraphCol.Name = "txtGraphCol";
            this.txtGraphCol.Size = new System.Drawing.Size(100, 20);
            this.txtGraphCol.TabIndex = 6;
            // 
            // chartColGraph
            // 
            chartArea4.Name = "ChartArea1";
            this.chartColGraph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartColGraph.Legends.Add(legend4);
            this.chartColGraph.Location = new System.Drawing.Point(677, 264);
            this.chartColGraph.Name = "chartColGraph";
            this.chartColGraph.Size = new System.Drawing.Size(325, 204);
            this.chartColGraph.TabIndex = 7;
            this.chartColGraph.Text = "chart1";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 537);
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
        private System.Windows.Forms.GroupBox polarGridGroup;
        private System.Windows.Forms.Button btnGraphLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColGraph;
        private System.Windows.Forms.TextBox txtGraphCol;
    }
}

