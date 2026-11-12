using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using myHeatingViewer.Services;

namespace myHeatingViewer
{
    public partial class Form1 : Form
    {
        private FolderService _folderService;
        private CsvDataService _csvService;
        private ChartService _chartService;

        private readonly DataContext _context;

        public Form1()
        {
            InitializeComponent();

            _context = new DataContext();

            _folderService = new FolderService();

            _csvService = new CsvDataService();

            _chartService =
                new ChartService(
                    _csvService,
                    _context);

            _chartService.ConfigureChart(chartMain);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number

            btnElectricityColour.BackColor = _context.ElectricityColour;
            btnThermostatColour.BackColor = _context.ThermostatColour;
            btnGalleryColour.BackColor = _context.GalleryColour;
            btnMiddleColour.BackColor = _context.MiddleColour;
            btnSanctuaryColour.BackColor = _context.SanctuaryColour;
            btnOutsideColour.BackColor = _context.OutsideColour;
            btnHeatmiserActualTempColour.BackColor = _context.ActualTempColour;
            btnHeatmiserChurchSensorColour.BackColor = _context.ChurchSensorColour;
            btnHeatmiserStateColour.BackColor = _context.StateColour;
            btnHeatmisetSetTempColour.BackColor = _context.SetTempColour;
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

            //MessageBox.Show(
            //    string.Join(", ", datasets));

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

            _chartService.ConfigureChart(
                chartMain);
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
                    DrawChart(); 
                    break;
                case "Gallery":
                    btnGalleryColour.BackColor = _context.GalleryColour = PickColour(_context.GalleryColour);
                    DrawChart();
                    break;
                case "Middle":
                    btnMiddleColour.BackColor = _context.MiddleColour = PickColour(_context.MiddleColour);
                    DrawChart();
                    break;
                case "Thermostat":
                    btnThermostatColour.BackColor = _context.ThermostatColour = PickColour(_context.ThermostatColour);
                    DrawChart();
                    break;
                case "Outside":
                    btnOutsideColour.BackColor = _context.OutsideColour = PickColour(_context.OutsideColour);
                    DrawChart();
                    break;
                case "Sanctuary":
                    btnSanctuaryColour.BackColor = _context.SanctuaryColour = PickColour(_context.SanctuaryColour);
                    DrawChart();
                    break;
                case "Set Temperature":
                    btnHeatmisetSetTempColour.BackColor = _context.SetTempColour = PickColour(_context.SetTempColour);
                    DrawChart();
                    break;
                case "Actual Temperature":
                    btnHeatmiserActualTempColour.BackColor = _context.ActualTempColour = PickColour(_context.ActualTempColour);
                    DrawChart();
                    break;
                case "Church Sensor":
                    btnHeatmiserChurchSensorColour.BackColor = _context.ChurchSensorColour = PickColour(_context.ChurchSensorColour);
                    DrawChart();
                    break;
                case "Heating State":
                    btnHeatmiserStateColour.BackColor = _context.StateColour = PickColour(_context.StateColour);
                    DrawChart();
                    break;
                default:
                    MessageBox.Show("Errror: Unknown button pressed", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;

                

            }
        }

        //public Color GetColour(string seriesName)
        //{
        //    switch (seriesName)
        //    {
        //        case "Electricity":
        //            return _context.ElectricityColour;

        //        case "Gallery":
        //            return _context.GalleryColour;

        //        case "Middle":
        //            return _context.MiddleColour;

        //        case "Outside":
        //            return _context.OutsideColour;

        //        case "Sanctuary":
        //            return _context.SanctuaryColour;

        //        case "Thermostat":
        //            return _context.ThermostatColour;

        //        case "Set Temp":
        //            return _context.SetTempColour;

        //        case "Actual Temp":
        //            return _context.ActualTempColour;

        //        case "Church Sensor":
        //            return _context.ChurchSensorColour;

        //        case "State":
        //            return _context.StateColour;

        //        default:
        //            return Color.Black;
        //    }
        //}
    }
}
