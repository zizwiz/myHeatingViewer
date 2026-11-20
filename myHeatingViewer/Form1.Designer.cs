
namespace myHeatingViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_chart = new System.Windows.Forms.TabPage();
            this.lblCrossHair = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab_settings = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbl_FileToModify = new System.Windows.Forms.Label();
            this.btnOpenFileToModify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnElectricityColour = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGalleryColour = new System.Windows.Forms.Button();
            this.btnThermostatColour = new System.Windows.Forms.Button();
            this.btnMiddleColour = new System.Windows.Forms.Button();
            this.btnSanctuaryColour = new System.Windows.Forms.Button();
            this.btnOutsideColour = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHeatmiserStateColour = new System.Windows.Forms.Button();
            this.btnHeatmiserChurchSensorColour = new System.Windows.Forms.Button();
            this.btnHeatmiserActualTempColour = new System.Windows.Forms.Button();
            this.btnHeatmisetSetTempColour = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbx_YAxis_max = new System.Windows.Forms.TextBox();
            this.txtbx_YAxis_min = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_clear_crosshairs = new System.Windows.Forms.Button();
            this.chkbx_zoom_Y_Axis = new System.Windows.Forms.CheckBox();
            this.btn_resetZoom = new System.Windows.Forms.Button();
            this.btn_saveChart = new System.Windows.Forms.Button();
            this.lstDays = new System.Windows.Forms.ListBox();
            this.lstMonths = new System.Windows.Forms.ListBox();
            this.lstYears = new System.Windows.Forms.ListBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnDrawChart = new System.Windows.Forms.Button();
            this.clbData = new System.Windows.Forms.CheckedListBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.tab_settings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1452, 690);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1446, 484);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_chart);
            this.tabControl1.Controls.Add(this.tab_settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1446, 484);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_chart
            // 
            this.tab_chart.Controls.Add(this.lblCrossHair);
            this.tab_chart.Controls.Add(this.chartMain);
            this.tab_chart.Location = new System.Drawing.Point(4, 29);
            this.tab_chart.Name = "tab_chart";
            this.tab_chart.Padding = new System.Windows.Forms.Padding(3);
            this.tab_chart.Size = new System.Drawing.Size(1438, 451);
            this.tab_chart.TabIndex = 0;
            this.tab_chart.Text = "Chart";
            this.tab_chart.UseVisualStyleBackColor = true;
            // 
            // lblCrossHair
            // 
            this.lblCrossHair.AutoSize = true;
            this.lblCrossHair.Location = new System.Drawing.Point(6, 418);
            this.lblCrossHair.Name = "lblCrossHair";
            this.lblCrossHair.Size = new System.Drawing.Size(45, 20);
            this.lblCrossHair.TabIndex = 1;
            this.lblCrossHair.Text = ".........";
            // 
            // chartMain
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(3, 3);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartMain.Series.Add(series1);
            this.chartMain.Size = new System.Drawing.Size(1432, 445);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "chart1";
            this.chartMain.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartMain_GetToolTipText);
            this.chartMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartMain_MouseDown);
            this.chartMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartMain_MouseMove);
            this.chartMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartMain_MouseUp);
            // 
            // tab_settings
            // 
            this.tab_settings.Controls.Add(this.panel2);
            this.tab_settings.Location = new System.Drawing.Point(4, 29);
            this.tab_settings.Name = "tab_settings";
            this.tab_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_settings.Size = new System.Drawing.Size(1438, 451);
            this.tab_settings.TabIndex = 1;
            this.tab_settings.Text = "Settings";
            this.tab_settings.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1432, 445);
            this.panel2.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbl_FileToModify);
            this.groupBox6.Controls.Add(this.btnOpenFileToModify);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(614, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(510, 133);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configure CSV File";
            // 
            // lbl_FileToModify
            // 
            this.lbl_FileToModify.AutoSize = true;
            this.lbl_FileToModify.Location = new System.Drawing.Point(161, 102);
            this.lbl_FileToModify.Name = "lbl_FileToModify";
            this.lbl_FileToModify.Size = new System.Drawing.Size(45, 20);
            this.lbl_FileToModify.TabIndex = 36;
            this.lbl_FileToModify.Text = "none";
            // 
            // btnOpenFileToModify
            // 
            this.btnOpenFileToModify.Location = new System.Drawing.Point(10, 40);
            this.btnOpenFileToModify.Name = "btnOpenFileToModify";
            this.btnOpenFileToModify.Size = new System.Drawing.Size(98, 42);
            this.btnOpenFileToModify.TabIndex = 35;
            this.btnOpenFileToModify.Text = "Open File";
            this.btnOpenFileToModify.UseVisualStyleBackColor = true;
            this.btnOpenFileToModify.Click += new System.EventHandler(this.btnOpenFileToModify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "File being modified: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(12, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(596, 297);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chart Line Colours";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnElectricityColour);
            this.groupBox4.Location = new System.Drawing.Point(21, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 86);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Smart Meter";
            // 
            // btnElectricityColour
            // 
            this.btnElectricityColour.Location = new System.Drawing.Point(30, 26);
            this.btnElectricityColour.Name = "btnElectricityColour";
            this.btnElectricityColour.Size = new System.Drawing.Size(118, 41);
            this.btnElectricityColour.TabIndex = 16;
            this.btnElectricityColour.Text = "Electricity";
            this.btnElectricityColour.UseVisualStyleBackColor = true;
            this.btnElectricityColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGalleryColour);
            this.groupBox3.Controls.Add(this.btnThermostatColour);
            this.groupBox3.Controls.Add(this.btnMiddleColour);
            this.groupBox3.Controls.Add(this.btnSanctuaryColour);
            this.groupBox3.Controls.Add(this.btnOutsideColour);
            this.groupBox3.Location = new System.Drawing.Point(204, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 259);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensors";
            // 
            // btnGalleryColour
            // 
            this.btnGalleryColour.Location = new System.Drawing.Point(16, 66);
            this.btnGalleryColour.Name = "btnGalleryColour";
            this.btnGalleryColour.Size = new System.Drawing.Size(118, 41);
            this.btnGalleryColour.TabIndex = 17;
            this.btnGalleryColour.Text = "Gallery";
            this.btnGalleryColour.UseVisualStyleBackColor = true;
            this.btnGalleryColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnThermostatColour
            // 
            this.btnThermostatColour.Location = new System.Drawing.Point(16, 19);
            this.btnThermostatColour.Name = "btnThermostatColour";
            this.btnThermostatColour.Size = new System.Drawing.Size(118, 41);
            this.btnThermostatColour.TabIndex = 21;
            this.btnThermostatColour.Text = "Thermostat";
            this.btnThermostatColour.UseVisualStyleBackColor = true;
            this.btnThermostatColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnMiddleColour
            // 
            this.btnMiddleColour.Location = new System.Drawing.Point(16, 113);
            this.btnMiddleColour.Name = "btnMiddleColour";
            this.btnMiddleColour.Size = new System.Drawing.Size(118, 41);
            this.btnMiddleColour.TabIndex = 18;
            this.btnMiddleColour.Text = "Middle";
            this.btnMiddleColour.UseVisualStyleBackColor = true;
            this.btnMiddleColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnSanctuaryColour
            // 
            this.btnSanctuaryColour.Location = new System.Drawing.Point(16, 207);
            this.btnSanctuaryColour.Name = "btnSanctuaryColour";
            this.btnSanctuaryColour.Size = new System.Drawing.Size(118, 41);
            this.btnSanctuaryColour.TabIndex = 20;
            this.btnSanctuaryColour.Text = "Sanctuary";
            this.btnSanctuaryColour.UseVisualStyleBackColor = true;
            this.btnSanctuaryColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnOutsideColour
            // 
            this.btnOutsideColour.Location = new System.Drawing.Point(16, 160);
            this.btnOutsideColour.Name = "btnOutsideColour";
            this.btnOutsideColour.Size = new System.Drawing.Size(118, 41);
            this.btnOutsideColour.TabIndex = 19;
            this.btnOutsideColour.Text = "Outside";
            this.btnOutsideColour.UseVisualStyleBackColor = true;
            this.btnOutsideColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHeatmiserStateColour);
            this.groupBox2.Controls.Add(this.btnHeatmiserChurchSensorColour);
            this.groupBox2.Controls.Add(this.btnHeatmiserActualTempColour);
            this.groupBox2.Controls.Add(this.btnHeatmisetSetTempColour);
            this.groupBox2.Location = new System.Drawing.Point(365, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 215);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heatmiser";
            // 
            // btnHeatmiserStateColour
            // 
            this.btnHeatmiserStateColour.Location = new System.Drawing.Point(22, 164);
            this.btnHeatmiserStateColour.Name = "btnHeatmiserStateColour";
            this.btnHeatmiserStateColour.Size = new System.Drawing.Size(168, 41);
            this.btnHeatmiserStateColour.TabIndex = 25;
            this.btnHeatmiserStateColour.Text = "Heating State";
            this.btnHeatmiserStateColour.UseVisualStyleBackColor = true;
            this.btnHeatmiserStateColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnHeatmiserChurchSensorColour
            // 
            this.btnHeatmiserChurchSensorColour.Location = new System.Drawing.Point(22, 117);
            this.btnHeatmiserChurchSensorColour.Name = "btnHeatmiserChurchSensorColour";
            this.btnHeatmiserChurchSensorColour.Size = new System.Drawing.Size(168, 41);
            this.btnHeatmiserChurchSensorColour.TabIndex = 24;
            this.btnHeatmiserChurchSensorColour.Text = "Church Sensor";
            this.btnHeatmiserChurchSensorColour.UseVisualStyleBackColor = true;
            this.btnHeatmiserChurchSensorColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnHeatmiserActualTempColour
            // 
            this.btnHeatmiserActualTempColour.Location = new System.Drawing.Point(22, 70);
            this.btnHeatmiserActualTempColour.Name = "btnHeatmiserActualTempColour";
            this.btnHeatmiserActualTempColour.Size = new System.Drawing.Size(168, 41);
            this.btnHeatmiserActualTempColour.TabIndex = 23;
            this.btnHeatmiserActualTempColour.Text = "Actual Temperature";
            this.btnHeatmiserActualTempColour.UseVisualStyleBackColor = true;
            this.btnHeatmiserActualTempColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // btnHeatmisetSetTempColour
            // 
            this.btnHeatmisetSetTempColour.Location = new System.Drawing.Point(22, 23);
            this.btnHeatmisetSetTempColour.Name = "btnHeatmisetSetTempColour";
            this.btnHeatmisetSetTempColour.Size = new System.Drawing.Size(168, 41);
            this.btnHeatmisetSetTempColour.TabIndex = 22;
            this.btnHeatmisetSetTempColour.Text = "Set Temperature";
            this.btnHeatmisetSetTempColour.UseVisualStyleBackColor = true;
            this.btnHeatmisetSetTempColour.Click += new System.EventHandler(this.ChangeChartLineColour_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbx_YAxis_max);
            this.groupBox1.Controls.Add(this.txtbx_YAxis_min);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chart Y-Axis";
            // 
            // txtbx_YAxis_max
            // 
            this.txtbx_YAxis_max.Location = new System.Drawing.Point(75, 68);
            this.txtbx_YAxis_max.Name = "txtbx_YAxis_max";
            this.txtbx_YAxis_max.Size = new System.Drawing.Size(68, 26);
            this.txtbx_YAxis_max.TabIndex = 3;
            this.txtbx_YAxis_max.Text = "60";
            this.txtbx_YAxis_max.Leave += new System.EventHandler(this.YAxis_Leave);
            // 
            // txtbx_YAxis_min
            // 
            this.txtbx_YAxis_min.Location = new System.Drawing.Point(75, 33);
            this.txtbx_YAxis_min.Name = "txtbx_YAxis_min";
            this.txtbx_YAxis_min.Size = new System.Drawing.Size(68, 26);
            this.txtbx_YAxis_min.TabIndex = 2;
            this.txtbx_YAxis_min.Text = "0";
            this.txtbx_YAxis_min.Leave += new System.EventHandler(this.YAxis_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_clear_crosshairs);
            this.panel3.Controls.Add(this.chkbx_zoom_Y_Axis);
            this.panel3.Controls.Add(this.btn_resetZoom);
            this.panel3.Controls.Add(this.btn_saveChart);
            this.panel3.Controls.Add(this.lstDays);
            this.panel3.Controls.Add(this.lstMonths);
            this.panel3.Controls.Add(this.lstYears);
            this.panel3.Controls.Add(this.btnLoadData);
            this.panel3.Controls.Add(this.btnDrawChart);
            this.panel3.Controls.Add(this.clbData);
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1446, 194);
            this.panel3.TabIndex = 2;
            // 
            // btn_clear_crosshairs
            // 
            this.btn_clear_crosshairs.Location = new System.Drawing.Point(1091, 10);
            this.btn_clear_crosshairs.Name = "btn_clear_crosshairs";
            this.btn_clear_crosshairs.Size = new System.Drawing.Size(135, 56);
            this.btn_clear_crosshairs.TabIndex = 22;
            this.btn_clear_crosshairs.Text = "Clear Crosshairs";
            this.btn_clear_crosshairs.UseVisualStyleBackColor = true;
            this.btn_clear_crosshairs.Click += new System.EventHandler(this.btn_clear_crosshairs_Click);
            // 
            // chkbx_zoom_Y_Axis
            // 
            this.chkbx_zoom_Y_Axis.AutoSize = true;
            this.chkbx_zoom_Y_Axis.Location = new System.Drawing.Point(1091, 88);
            this.chkbx_zoom_Y_Axis.Name = "chkbx_zoom_Y_Axis";
            this.chkbx_zoom_Y_Axis.Size = new System.Drawing.Size(125, 24);
            this.chkbx_zoom_Y_Axis.TabIndex = 21;
            this.chkbx_zoom_Y_Axis.Text = "Zoom Y-Axis";
            this.chkbx_zoom_Y_Axis.UseVisualStyleBackColor = true;
            this.chkbx_zoom_Y_Axis.CheckedChanged += new System.EventHandler(this.chkbx_zoom_Y_Axis_CheckedChanged);
            // 
            // btn_resetZoom
            // 
            this.btn_resetZoom.Location = new System.Drawing.Point(1091, 118);
            this.btn_resetZoom.Name = "btn_resetZoom";
            this.btn_resetZoom.Size = new System.Drawing.Size(135, 56);
            this.btn_resetZoom.TabIndex = 20;
            this.btn_resetZoom.Text = "Reset Zoom";
            this.btn_resetZoom.UseVisualStyleBackColor = true;
            this.btn_resetZoom.Click += new System.EventHandler(this.btn_resetZoom_Click);
            // 
            // btn_saveChart
            // 
            this.btn_saveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveChart.Location = new System.Drawing.Point(1306, 9);
            this.btn_saveChart.Name = "btn_saveChart";
            this.btn_saveChart.Size = new System.Drawing.Size(131, 59);
            this.btn_saveChart.TabIndex = 19;
            this.btn_saveChart.Text = "Save Chart";
            this.btn_saveChart.UseVisualStyleBackColor = true;
            this.btn_saveChart.Click += new System.EventHandler(this.btn_saveChart_Click);
            // 
            // lstDays
            // 
            this.lstDays.FormattingEnabled = true;
            this.lstDays.ItemHeight = 20;
            this.lstDays.Location = new System.Drawing.Point(433, 9);
            this.lstDays.Name = "lstDays";
            this.lstDays.Size = new System.Drawing.Size(182, 164);
            this.lstDays.TabIndex = 18;
            this.lstDays.SelectedIndexChanged += new System.EventHandler(this.lstDays_SelectedIndexChanged);
            // 
            // lstMonths
            // 
            this.lstMonths.FormattingEnabled = true;
            this.lstMonths.ItemHeight = 20;
            this.lstMonths.Location = new System.Drawing.Point(214, 9);
            this.lstMonths.Name = "lstMonths";
            this.lstMonths.Size = new System.Drawing.Size(180, 164);
            this.lstMonths.TabIndex = 17;
            this.lstMonths.SelectedIndexChanged += new System.EventHandler(this.lstMonths_SelectedIndexChanged);
            // 
            // lstYears
            // 
            this.lstYears.FormattingEnabled = true;
            this.lstYears.ItemHeight = 20;
            this.lstYears.Location = new System.Drawing.Point(13, 9);
            this.lstYears.Name = "lstYears";
            this.lstYears.Size = new System.Drawing.Size(177, 164);
            this.lstYears.TabIndex = 16;
            this.lstYears.SelectedIndexChanged += new System.EventHandler(this.lstYears_SelectedIndexChanged);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(874, 9);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(135, 56);
            this.btnLoadData.TabIndex = 15;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnDrawChart
            // 
            this.btnDrawChart.Location = new System.Drawing.Point(874, 118);
            this.btnDrawChart.Name = "btnDrawChart";
            this.btnDrawChart.Size = new System.Drawing.Size(135, 56);
            this.btnDrawChart.TabIndex = 14;
            this.btnDrawChart.Text = "Draw Chart";
            this.btnDrawChart.UseVisualStyleBackColor = true;
            this.btnDrawChart.Click += new System.EventHandler(this.btnDrawChart_Click);
            // 
            // clbData
            // 
            this.clbData.CheckOnClick = true;
            this.clbData.FormattingEnabled = true;
            this.clbData.Location = new System.Drawing.Point(654, 9);
            this.clbData.Name = "clbData";
            this.clbData.Size = new System.Drawing.Size(173, 165);
            this.clbData.TabIndex = 13;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(1306, 126);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(131, 59);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 690);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "myHeatingViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_chart.ResumeLayout(false);
            this.tab_chart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.tab_settings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.TabPage tab_settings;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnDrawChart;
        private System.Windows.Forms.CheckedListBox clbData;
        private System.Windows.Forms.ListBox lstYears;
        private System.Windows.Forms.ListBox lstMonths;
        private System.Windows.Forms.ListBox lstDays;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbx_YAxis_max;
        private System.Windows.Forms.TextBox txtbx_YAxis_min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnElectricityColour;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGalleryColour;
        private System.Windows.Forms.Button btnThermostatColour;
        private System.Windows.Forms.Button btnMiddleColour;
        private System.Windows.Forms.Button btnSanctuaryColour;
        private System.Windows.Forms.Button btnOutsideColour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHeatmiserStateColour;
        private System.Windows.Forms.Button btnHeatmiserChurchSensorColour;
        private System.Windows.Forms.Button btnHeatmiserActualTempColour;
        private System.Windows.Forms.Button btnHeatmisetSetTempColour;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnOpenFileToModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_FileToModify;
        private System.Windows.Forms.Button btn_saveChart;
        private System.Windows.Forms.Button btn_resetZoom;
        private System.Windows.Forms.CheckBox chkbx_zoom_Y_Axis;
        private System.Windows.Forms.Label lblCrossHair;
        private System.Windows.Forms.Button btn_clear_crosshairs;
    }
}

