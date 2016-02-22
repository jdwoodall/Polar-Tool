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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.polarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.polarGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInsRow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInsCol = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelCol = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.insDelGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioBtnIns = new System.Windows.Forms.RadioButton();
            this.radioBtnDel = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioBtnCol = new System.Windows.Forms.RadioButton();
            this.radioBtnRow = new System.Windows.Forms.RadioButton();
            this.insDelHeadingValue = new System.Windows.Forms.TextBox();
            this.colRowHeading = new System.Windows.Forms.Label();
            this.insDelBtnCancel = new System.Windows.Forms.Button();
            this.insDelBtnOK = new System.Windows.Forms.Button();
            this.chartRowGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartColGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.polarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polarGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.polarMenuStrip.SuspendLayout();
            this.polarGridGroup.SuspendLayout();
            this.insDelGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRowGraph)).BeginInit();
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
            this.polarChart.Location = new System.Drawing.Point(31, 94);
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
            this.polarGrid.AllowUserToResizeColumns = false;
            this.polarGrid.AllowUserToResizeRows = false;
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
            this.polarGrid.ContextMenuStrip = this.contextMenuStrip1;
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
            this.polarGrid.Size = new System.Drawing.Size(826, 449);
            this.polarGrid.TabIndex = 4;
            this.polarGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            this.polarGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            this.polarGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.polarGrid_CellContentClick);
            this.polarGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.polarGrid_ColumnHeader);
            this.polarGrid.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.polarGrid_ColumnHeader);
            this.polarGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.polarGrid_RowHeader);
            this.polarGrid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.polarGrid_RowHeader);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.fitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 70);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemInsRow,
            this.ToolStripMenuItemInsCol});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.insertToolStripMenuItem.Text = "Insert...";
            // 
            // ToolStripMenuItemInsRow
            // 
            this.ToolStripMenuItemInsRow.Name = "ToolStripMenuItemInsRow";
            this.ToolStripMenuItemInsRow.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemInsRow.Text = "Row";
            this.ToolStripMenuItemInsRow.Click += new System.EventHandler(this.ToolStripMenuItemInsRow_Click);
            // 
            // ToolStripMenuItemInsCol
            // 
            this.ToolStripMenuItemInsCol.Name = "ToolStripMenuItemInsCol";
            this.ToolStripMenuItemInsCol.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemInsCol.Text = "Column";
            this.ToolStripMenuItemInsCol.Click += new System.EventHandler(this.ToolStripMenuItemInsCol_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDelRow,
            this.ToolStripMenuItemDelCol});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "Delete...";
            // 
            // ToolStripMenuItemDelRow
            // 
            this.ToolStripMenuItemDelRow.Name = "ToolStripMenuItemDelRow";
            this.ToolStripMenuItemDelRow.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemDelRow.Text = "Row";
            this.ToolStripMenuItemDelRow.Click += new System.EventHandler(this.ToolStripMenuItemDelRow_Click);
            // 
            // ToolStripMenuItemDelCol
            // 
            this.ToolStripMenuItemDelCol.Name = "ToolStripMenuItemDelCol";
            this.ToolStripMenuItemDelCol.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemDelCol.Text = "Column";
            this.ToolStripMenuItemDelCol.Click += new System.EventHandler(this.ToolStripMenuItemDelCol_Click);
            // 
            // fitToolStripMenuItem
            // 
            this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            this.fitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.fitToolStripMenuItem.Text = "Fit...";
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
            this.polarMenuStrip.Size = new System.Drawing.Size(1064, 24);
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
            this.polarGridGroup.Controls.Add(this.insDelGroupBox);
            this.polarGridGroup.Controls.Add(this.chartRowGraph);
            this.polarGridGroup.Controls.Add(this.chartColGraph);
            this.polarGridGroup.Controls.Add(this.polarGrid);
            this.polarGridGroup.Location = new System.Drawing.Point(0, 27);
            this.polarGridGroup.Name = "polarGridGroup";
            this.polarGridGroup.Size = new System.Drawing.Size(1064, 641);
            this.polarGridGroup.TabIndex = 5;
            this.polarGridGroup.TabStop = false;
            this.polarGridGroup.Text = "Polar TWA/TWS";
            // 
            // insDelGroupBox
            // 
            this.insDelGroupBox.Controls.Add(this.panel2);
            this.insDelGroupBox.Controls.Add(this.panel1);
            this.insDelGroupBox.Controls.Add(this.insDelHeadingValue);
            this.insDelGroupBox.Controls.Add(this.colRowHeading);
            this.insDelGroupBox.Controls.Add(this.insDelBtnCancel);
            this.insDelGroupBox.Controls.Add(this.insDelBtnOK);
            this.insDelGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insDelGroupBox.Location = new System.Drawing.Point(317, 105);
            this.insDelGroupBox.Name = "insDelGroupBox";
            this.insDelGroupBox.Size = new System.Drawing.Size(266, 166);
            this.insDelGroupBox.TabIndex = 2;
            this.insDelGroupBox.TabStop = false;
            this.insDelGroupBox.Text = "insDelGroupBox";
            this.insDelGroupBox.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioBtnIns);
            this.panel2.Controls.Add(this.radioBtnDel);
            this.panel2.Location = new System.Drawing.Point(9, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 26);
            this.panel2.TabIndex = 9;
            // 
            // radioBtnIns
            // 
            this.radioBtnIns.AutoSize = true;
            this.radioBtnIns.Location = new System.Drawing.Point(10, 6);
            this.radioBtnIns.Name = "radioBtnIns";
            this.radioBtnIns.Size = new System.Drawing.Size(58, 20);
            this.radioBtnIns.TabIndex = 6;
            this.radioBtnIns.TabStop = true;
            this.radioBtnIns.Text = "Insert";
            this.radioBtnIns.UseVisualStyleBackColor = true;
            // 
            // radioBtnDel
            // 
            this.radioBtnDel.AutoSize = true;
            this.radioBtnDel.Location = new System.Drawing.Point(157, 6);
            this.radioBtnDel.Name = "radioBtnDel";
            this.radioBtnDel.Size = new System.Drawing.Size(66, 20);
            this.radioBtnDel.TabIndex = 7;
            this.radioBtnDel.TabStop = true;
            this.radioBtnDel.Text = "Delete";
            this.radioBtnDel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnCol);
            this.panel1.Controls.Add(this.radioBtnRow);
            this.panel1.Location = new System.Drawing.Point(9, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 23);
            this.panel1.TabIndex = 8;
            // 
            // radioBtnCol
            // 
            this.radioBtnCol.AutoSize = true;
            this.radioBtnCol.Location = new System.Drawing.Point(157, 1);
            this.radioBtnCol.Name = "radioBtnCol";
            this.radioBtnCol.Size = new System.Drawing.Size(71, 20);
            this.radioBtnCol.TabIndex = 5;
            this.radioBtnCol.TabStop = true;
            this.radioBtnCol.Text = "Column";
            this.radioBtnCol.UseVisualStyleBackColor = true;
            // 
            // radioBtnRow
            // 
            this.radioBtnRow.AutoSize = true;
            this.radioBtnRow.Location = new System.Drawing.Point(10, 1);
            this.radioBtnRow.Name = "radioBtnRow";
            this.radioBtnRow.Size = new System.Drawing.Size(53, 20);
            this.radioBtnRow.TabIndex = 4;
            this.radioBtnRow.TabStop = true;
            this.radioBtnRow.Text = "Row";
            this.radioBtnRow.UseVisualStyleBackColor = true;
            // 
            // insDelHeadingValue
            // 
            this.insDelHeadingValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.insDelHeadingValue.Location = new System.Drawing.Point(185, 99);
            this.insDelHeadingValue.Name = "insDelHeadingValue";
            this.insDelHeadingValue.Size = new System.Drawing.Size(75, 22);
            this.insDelHeadingValue.TabIndex = 1;
            this.insDelHeadingValue.Text = "0.0";
            this.insDelHeadingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colRowHeading
            // 
            this.colRowHeading.AutoSize = true;
            this.colRowHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRowHeading.Location = new System.Drawing.Point(3, 105);
            this.colRowHeading.Name = "colRowHeading";
            this.colRowHeading.Size = new System.Drawing.Size(121, 16);
            this.colRowHeading.TabIndex = 3;
            this.colRowHeading.Text = "Col/Row Heading?";
            // 
            // insDelBtnCancel
            // 
            this.insDelBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.insDelBtnCancel.Location = new System.Drawing.Point(185, 137);
            this.insDelBtnCancel.Name = "insDelBtnCancel";
            this.insDelBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.insDelBtnCancel.TabIndex = 1;
            this.insDelBtnCancel.Text = "Cancel";
            this.insDelBtnCancel.UseVisualStyleBackColor = true;
            this.insDelBtnCancel.Click += new System.EventHandler(this.insDelBtnCancel_Click);
            // 
            // insDelBtnOK
            // 
            this.insDelBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.insDelBtnOK.Location = new System.Drawing.Point(6, 137);
            this.insDelBtnOK.Name = "insDelBtnOK";
            this.insDelBtnOK.Size = new System.Drawing.Size(75, 23);
            this.insDelBtnOK.TabIndex = 2;
            this.insDelBtnOK.Text = "OK";
            this.insDelBtnOK.UseVisualStyleBackColor = true;
            this.insDelBtnOK.Click += new System.EventHandler(this.insDelBtnOK_Click);
            // 
            // chartRowGraph
            // 
            this.chartRowGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRowGraph.BorderlineColor = System.Drawing.Color.Black;
            this.chartRowGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartRowGraph.ChartAreas.Add(chartArea2);
            this.chartRowGraph.Location = new System.Drawing.Point(0, 474);
            this.chartRowGraph.Name = "chartRowGraph";
            this.chartRowGraph.Size = new System.Drawing.Size(1064, 167);
            this.chartRowGraph.TabIndex = 8;
            this.chartRowGraph.Text = "chart1";
            // 
            // chartColGraph
            // 
            this.chartColGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartColGraph.BorderlineColor = System.Drawing.Color.Black;
            this.chartColGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartColGraph.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartColGraph.BorderSkin.BorderWidth = 2;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea3.AxisY.IsReversed = true;
            chartArea3.AxisY.Maximum = 180D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chartColGraph.ChartAreas.Add(chartArea3);
            this.chartColGraph.Location = new System.Drawing.Point(832, 19);
            this.chartColGraph.Name = "chartColGraph";
            this.chartColGraph.Size = new System.Drawing.Size(232, 449);
            this.chartColGraph.TabIndex = 1;
            this.chartColGraph.Text = "chart1";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 671);
            this.Controls.Add(this.polarGridGroup);
            this.Controls.Add(this.polarMenuStrip);
            this.Controls.Add(this.polarChart);
            this.MainMenuStrip = this.polarMenuStrip;
            this.Name = "formMain";
            this.Text = "Polar Tool";
            ((System.ComponentModel.ISupportInitialize)(this.polarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polarGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.polarMenuStrip.ResumeLayout(false);
            this.polarMenuStrip.PerformLayout();
            this.polarGridGroup.ResumeLayout(false);
            this.insDelGroupBox.ResumeLayout(false);
            this.insDelGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRowGraph)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRowGraph;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInsRow;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInsCol;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToolStripMenuItem;
        private System.Windows.Forms.GroupBox insDelGroupBox;
        private System.Windows.Forms.TextBox insDelHeadingValue;
        private System.Windows.Forms.Label colRowHeading;
        private System.Windows.Forms.Button insDelBtnCancel;
        private System.Windows.Forms.Button insDelBtnOK;
        private System.Windows.Forms.RadioButton radioBtnDel;
        private System.Windows.Forms.RadioButton radioBtnIns;
        private System.Windows.Forms.RadioButton radioBtnCol;
        private System.Windows.Forms.RadioButton radioBtnRow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelRow;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelCol;
    }
}

