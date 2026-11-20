using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CenteredMessagebox;
using myHeatingViewer.Helpers;
using myHeatingViewer.Services;

namespace myHeatingViewer
{
    public partial class Form1 : Form
    {
        private FolderService _folderService = new FolderService();
        private CsvDataService _csvService = new CsvDataService();
        private ChartService _chartService;

        private bool _isRightDragging; //For Cross hairs starts as false
        private ToolTip tooltip;

        private readonly DataContext _context = new DataContext();

        //used to store data to use in sunrise and sunset tooltips
        private List<DateTime> sunriseMarkers = new List<DateTime>();
        private List<DateTime> sunsetMarkers = new List<DateTime>();

        public Form1()
        {
            InitializeComponent();

            _chartService = new ChartService(_csvService, _context);

            _chartService.ConfigureChart(chartMain);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number

            _context.LoadUserSettings(); //get all teh stored settings from last run

            btnElectricityColour.BackColor = _context.ElectricityColour;
            btnGalleryColour.BackColor = _context.GalleryColour;
            btnThermostatColour.BackColor = _context.ThermostatColour;
            btnGalleryColour.BackColor = _context.GalleryColour;
            btnMiddleColour.BackColor = _context.MiddleColour;
            btnSanctuaryColour.BackColor = _context.SanctuaryColour;
            btnOutsideColour.BackColor = _context.OutsideColour;
            btnHeatmiserActualTempColour.BackColor = _context.ActualTempColour;
            btnHeatmiserChurchSensorColour.BackColor = _context.ChurchSensorColour;
            btnHeatmiserStateColour.BackColor = _context.StateColour;
            btnHeatmisetSetTempColour.BackColor = _context.SetTempColour;

            txtbx_YAxis_min.Text = _context.YAxisMinimum.ToString();
            txtbx_YAxis_max.Text = _context.YAxisMaximum.ToString();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Load Data Button

        private void btnLoadData_Click(
            object sender,
            EventArgs e)
        {
            using (FolderBrowserDialog dlg =
                   new FolderBrowserDialog())
            {
                dlg.Description =
                    "Select Data Folder";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                _context.DataRoot = dlg.SelectedPath;

                _csvService.ClearCache();

            }

            LoadYears();
        }

        private void LoadYears()
        {
            lstYears.Items.Clear();

            lstMonths.Items.Clear();
            lstDays.Items.Clear();

            clbData.Items.Clear();

            var years =
                _folderService.GetYears(_context.DataRoot);

            lstYears.Items.AddRange(
                years.ToArray());
        }

        #endregion



        #region Years

        private void LoadMonths()
        {
            lstMonths.Items.Clear();
            lstDays.Items.Clear();

            clbData.Items.Clear();

            string year =
                lstYears.SelectedItem.ToString();

            var months =
                _folderService.GetMonths(
                    _context.DataRoot,
                    year);

            lstMonths.Items.AddRange(
                months.ToArray());
        }

        #endregion

        #region Months

        private void LoadDays()
        {
            lstDays.Items.Clear();

            clbData.Items.Clear();

            string year =
                lstYears.SelectedItem.ToString();

            string month =
                lstMonths.SelectedItem.ToString();

            List<int> days =
                _csvService.GetAvailableDays(
                    _context.DataRoot,
                    year,
                    month);

            foreach (int day in days)
            {
                lstDays.Items.Add(day);
            }
        }

        #endregion


        #region Draw Chart

        private void btnDrawChart_Click(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            UpdateChartSettings();

            _chartService.Clear(chartMain);

            _chartService.ConfigureChart(chartMain);

            foreach (string dataset in clbData.CheckedItems)
            {
                _chartService.DrawSeries(
                    chartMain,
                    dataset);
            }

            // ---------------------------------------------------------
            // SUNRISE / SUNSET shading
            // ---------------------------------------------------------
            DateTime? sunrise;
            DateTime? sunset;
            var myDay = GetSelectedDate();


            sunrise = DayNightShading.GetSunEventLocal(myDay, true);
            sunset = DayNightShading.GetSunEventLocal(myDay, false);

            // Vertical markers
            if (sunrise.HasValue)
            {
                DayNightShading.AddVerticalLine(sunrise.Value, Color.Red, chartMain);
                sunriseMarkers.Add(sunrise.Value);
            }

            if (sunset.HasValue)
            {
                DayNightShading.AddVerticalLine(sunset.Value, Color.Orange, chartMain);
                sunsetMarkers.Add(sunset.Value);
            }

            // ---------------------------------------------------------
            // NIGHT BEFORE SUNRISE (00:00 → sunrise)
            // ---------------------------------------------------------
            DayNightShading.AddNightBeforeSunrise(myDay, sunrise.Value, chartMain);

            // ---------------------------------------------------------
            // DAYLIGHT SHADING (sunrise → sunset)
            // ---------------------------------------------------------
            DayNightShading.AddDaylightShading(sunrise.Value, sunset.Value, chartMain);

            // ---------------------------------------------------------
            // NIGHT AFTER SUNSET (sunset → next sunrise)
            // ---------------------------------------------------------
            DateTime nextDay = myDay.AddDays(1);
            DateTime? nextSunrise = DayNightShading.GetSunEventLocal(nextDay, true);

            if (nextSunrise.HasValue)
                DayNightShading.AddNightShading(sunset.Value, nextSunrise.Value, chartMain);








        }

        #endregion

        private DateTime GetSelectedDate()
        {
            int year =
                Convert.ToInt32(
                    lstYears.SelectedItem);

            int month =
                DateTime.ParseExact(
                        lstMonths.SelectedItem.ToString(),
                        "MMMM",
                        CultureInfo.InvariantCulture)
                    .Month;

            int day =
                Convert.ToInt32(
                    lstDays.SelectedItem);

            return new DateTime(
                year,
                month,
                day);
        }

        private void lstYears_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstYears.SelectedItem == null)
                return;

            _context.CurrentYear =
                lstYears.SelectedItem.ToString();

            LoadMonths();
        }

        private void lstMonths_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstMonths.SelectedItem == null)
                return;

            _context.CurrentMonth =
                lstMonths.SelectedItem.ToString();

            LoadDays();
        }

        private void lstDays_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstDays.SelectedItem == null)
                return;

            _context.CurrentDay =
                Convert.ToInt32(
                    lstDays.SelectedItem);

            LoadDatasets();
        }

        private void LoadDatasets()
        {
            clbData.Items.Clear();

            DateTime selectedDate =
                GetSelectedDate();

            List<string> datasets =
                _csvService.GetAvailableDataSets(
                    _context.DataRoot,
                    _context.SelectedDate);

            foreach (string dataset in datasets)
            {
                clbData.Items.Add(dataset);
            }
        }

        private void UpdateChartSettings()
        {
            double min;
            double max;

            if (!double.TryParse(
                    txtbx_YAxis_min.Text,
                    out min))
            {
                min = 0;
            }

            if (!double.TryParse(
                    txtbx_YAxis_max.Text,
                    out max))
            {
                max = 60;
            }

            if (max <= min)
            {
                max = min + 1;
            }

            _context.YAxisMinimum = min;
            _context.YAxisMaximum = max;
        }

        //If we update Y-Axis limits then update immediately so they can be used
        private void YAxis_Leave(object sender, EventArgs e)
        {
            UpdateChartSettings();

            _chartService.ConfigureChart(chartMain);

            _context.SaveSettings();
        }

        private Color PickColour(Color currentColour)
        {
            using (ColorDialog dlg =
                   new ColorDialog())
            {
                dlg.Color = currentColour;

                if (dlg.ShowDialog() ==
                    DialogResult.OK)
                {
                    return dlg.Color;
                }
            }

            return currentColour;
        }

        private void ChangeChartLineColour_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Electricity":
                    btnElectricityColour.BackColor = _context.ElectricityColour = PickColour(_context.ElectricityColour);
                    break;
                case "Gallery":
                    btnGalleryColour.BackColor = _context.GalleryColour = PickColour(_context.GalleryColour);
                    break;
                case "Middle":
                    btnMiddleColour.BackColor = _context.MiddleColour = PickColour(_context.MiddleColour);
                    break;
                case "Thermostat":
                    btnThermostatColour.BackColor = _context.ThermostatColour = PickColour(_context.ThermostatColour);
                    break;
                case "Outside":
                    btnOutsideColour.BackColor = _context.OutsideColour = PickColour(_context.OutsideColour);
                    break;
                case "Sanctuary":
                    btnSanctuaryColour.BackColor = _context.SanctuaryColour = PickColour(_context.SanctuaryColour);
                    break;
                case "Set Temperature":
                    btnHeatmisetSetTempColour.BackColor = _context.SetTempColour = PickColour(_context.SetTempColour);
                    break;
                case "Actual Temperature":
                    btnHeatmiserActualTempColour.BackColor = _context.ActualTempColour = PickColour(_context.ActualTempColour);
                    break;
                case "Church Sensor":
                    btnHeatmiserChurchSensorColour.BackColor = _context.ChurchSensorColour = PickColour(_context.ChurchSensorColour);
                    break;
                case "Heating State":
                    btnHeatmiserStateColour.BackColor = _context.StateColour = PickColour(_context.StateColour);
                    break;
                default:
                    MessageBox.Show("Errror: Unknown button pressed", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
            UpdateUI();

        }

        private void UpdateUI()
        {
            DrawChart();
            _context.SaveSettings();
        }

        private void btnOpenFileToModify_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    ofd.Title = "Select CSV File";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        lbl_FileToModify.Text = ofd.FileName;
                        string filePath = ofd.FileName;
                        string backupPath = filePath + ".bak";

                        // Backup original file
                        File.Copy(filePath, backupPath, true);

                        // Process file with buffered streaming
                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("0D0A2C"),
                            ConversionTools.HexStringToByteArray("2C"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("2C4368757263682073656E736F7220202C"),
                         ConversionTools.HexStringToByteArray("2C"), 4096);


                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("5374617465"),
                         ConversionTools.HexStringToByteArray("53746174652C4368757263682073656E736F72"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("2C526F6F6D2C"),
                         ConversionTools.HexStringToByteArray("2C"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("2C4368757263682068656174696E672C"),
                         ConversionTools.HexStringToByteArray("2C"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("4F6666"),
                         ConversionTools.HexStringToByteArray("30"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("5072652D48656174696E67"),
                         ConversionTools.HexStringToByteArray("32"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("48656174696E67"),
                         ConversionTools.HexStringToByteArray("34"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("2C2C"),
                         ConversionTools.HexStringToByteArray("2C302C"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("4461746520616E642054696D65"),
                         ConversionTools.HexStringToByteArray("446174652C54696D65"), 4096);

                        CSVTools.ReplaceBytes(filePath, ConversionTools.HexStringToByteArray("3230323620"),
                         ConversionTools.HexStringToByteArray("323032362C"), 4096);

                        CSVTools.ProcessCsv(filePath); //Reconfigure the columns etc
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_saveChart_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Title = "Save Chart As Image";
                    dialog.Filter =
                        "JPEG Image (*.jpg)|*.jpg|PNG Image (*.png)|*.png|Bitmap Image (*.bmp)|*.bmp";
                    dialog.DefaultExt = "png";
                    dialog.AddExtension = true;

                    // Show dialog and validate selection
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        // Determine chosen format
                        ChartImageFormat format;
                        string ext = Path.GetExtension(dialog.FileName).ToLower();

                        switch (ext)
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = ChartImageFormat.Jpeg;
                                break;
                            case ".png":
                                format = ChartImageFormat.Png;
                                break;
                            case ".bmp":
                                format = ChartImageFormat.Bmp;
                                break;
                            default:
                                MessageBox.Show("Unsupported file format.", "Error");
                                return;
                        }

                        chartMain.SaveImage(dialog.FileName, format);

                        MsgBox.Show("Chart saved successfully", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show($"An error occurred while saving the chart:\n{ex.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chartMain_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Only show tooltips for data points
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];

                // Extract the DateTime from the X value
                DateTime dt = DateTime.FromOADate(point.XValue);

                // Extract Y-axis value
                double yAxisValue = point.YValues[0];


                // Build tooltip text
                e.Text =
                    "Date: " + dt.ToString("dd-MMM-yyyy") + Environment.NewLine +
                    "Time: " + dt.ToString("HH:mm") + Environment.NewLine +
                    "Value: " + yAxisValue.ToString("F3");
            }
        }

        private void btn_resetZoom_Click(object sender, EventArgs e)
        {
            _chartService.ResetZoom(chartMain);
        }

        private void chkbx_zoom_Y_Axis_CheckedChanged(object sender, EventArgs e)
        {
            ChartService.EnableYAxisZoom(chartMain, chkbx_zoom_Y_Axis);
        }

        private void chartMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            _isRightDragging = true;

            MoveCrossHair(e.Location);
        }

        private void chartMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isRightDragging)
                return;
            
            MoveCrossHair(e.Location);
        }

        private void chartMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            _isRightDragging = false;
        }

        private void MoveCrossHair(Point location)
        {
            ChartArea area = chartMain.ChartAreas[0];

            try
            {
                double x = area.AxisX.PixelPositionToValue(location.X);
                double y = area.AxisY.PixelPositionToValue(location.Y);

                area.CursorX.SetCursorPosition(x);
                area.CursorY.SetCursorPosition(y);

                DateTime dt = DateTime.FromOADate(x);

                lblCrossHair.Text =
                    dt.ToString("dd/MM/yyyy HH:mm:ss")
                    + "  "
                    + y.ToString("F2");
            }
            catch
            {
            }
        }

        private void btn_clear_crosshairs_Click(object sender, EventArgs e)
        {
            ChartArea area = chartMain.ChartAreas[0];

            area.CursorX.SetCursorPosition(double.NaN);
            area.CursorY.SetCursorPosition(double.NaN);

            chartMain.Invalidate();
        }
    }
}
