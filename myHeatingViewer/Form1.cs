using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using myHeatingViewer.Services;

namespace myHeatingViewer
{
    public partial class Form1 : Form
    {
        private FolderService _folderService;
        private CsvDataService _csvService;
        private ChartService _chartService;

        private string _dataRoot = "";

        public Form1()
        {
            InitializeComponent();

            _folderService = new FolderService();
            _csvService = new CsvDataService();
            _chartService = new ChartService();

            // _chartService.ConfigureChart(chartMain);
            SetupChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number

           // SetupChart();
        }
        
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Setup

        private void SetupChart()
        {
            chartMain.Series.Clear();

            ChartArea area = chartMain.ChartAreas[0];

            area.AxisX.LabelStyle.Format = "HH:mm";
            area.AxisX.IntervalType = DateTimeIntervalType.Hours;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 40;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        #endregion

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

                _dataRoot = dlg.SelectedPath;
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
                _folderService.GetYears(_dataRoot);

            lstYears.Items.AddRange(
                years.ToArray());
        }

        #endregion



        #region Years

        //private void clbYears_SelectedIndexChanged(
        //    object sender,
        //    EventArgs e)
        //{
        //    LoadMonths();
        //}

        private void LoadMonths()
        {
            lstMonths.Items.Clear();
            lstDays.Items.Clear();

            clbData.Items.Clear();

            string year =
                lstYears.SelectedItem.ToString();

            var months =
                _folderService.GetMonths(
                    _dataRoot,
                    year);

            lstMonths.Items.AddRange(
                months.ToArray());
        }

        #endregion

        #region Months

        //private void clbMonths_SelectedIndexChanged(
        //    object sender,
        //    EventArgs e)
        //{
        //    LoadDays();
        //}

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
                    _dataRoot,
                    year,
                    month);

            foreach (int day in days)
            {
                lstDays.Items.Add(day);
            }
        }

        #endregion

        #region Days

        //private void clbDays_SelectedIndexChanged(
        //    object sender,
        //    EventArgs e)
        //{
        //    DetectAvailableData();
        //}

        //private void DetectAvailableData()
        //{
        //    clbData.Items.Clear();

        //    if (lstDays.SelectedItem == null)
        //        return;

        //    DateTime selectedDate =
        //        GetSelectedDate();

        //    string folder =
        //        GetCurrentFolder();

        //    string[] files =
        //    {
        //        "ChurchE.csv",
        //        "Gallery.csv",
        //        "Middle.csv",
        //        "Outside.csv",
        //        "Sanctuary.csv",
        //        "Thermostat.csv",
        //        "heatmiser.csv"
        //    };

        //    foreach (string file in files)
        //    {
        //        string fullPath =
        //            Path.Combine(folder, file);

        //        if (!File.Exists(fullPath))
        //            continue;

        //        if (ContainsDataForDate(
        //            fullPath,
        //            selectedDate))
        //        {
        //            clbData.Items.Add(
        //                GetDisplayName(file));
        //        }
        //    }
        //}

        #endregion

        #region Draw Chart

        private void btnDrawChart_Click(
            object sender,
            EventArgs e)
        {
            if (clbData.CheckedItems.Count == 0)
                return;

            DateTime selectedDate =
                GetSelectedDate();

            _chartService.Clear(chartMain);

            foreach (string dataset in clbData.CheckedItems)
            {
                _chartService.DrawSeries(
                    chartMain,
                    _dataRoot,
                    selectedDate,
                    dataset);
            }
        }

        #endregion

        #region Electricity

        //private void DrawElectricity(
        //    string file,
        //    DateTime selectedDate)
        //{
        //    Series s =
        //        new Series("Electricity");

        //    s.ChartType =
        //        SeriesChartType.Line;

        //    s.Color = Color.Red;
        //    s.BorderWidth = 2;

        //    var lines =
        //        File.ReadAllLines(file)
        //            .Skip(1);

        //    foreach (string line in lines)
        //    {
        //        string[] p =
        //            line.Split(',');

        //        if (p.Length < 3)
        //            continue;

        //        DateTime utc;

        //        if (!DateTime.TryParse(
        //            p[2],
        //            null,
        //            DateTimeStyles.RoundtripKind,
        //            out utc))
        //            continue;

        //        DateTime local =
        //            TimeZoneInfo.ConvertTimeFromUtc(
        //                utc,
        //                TimeZoneInfo.FindSystemTimeZoneById(
        //                    "GMT Standard Time"));

        //        if (local.Date != selectedDate.Date)
        //            continue;

        //        double kWh;

        //        if (!double.TryParse(
        //            p[1],
        //            out kWh))
        //            continue;

        //        double kW =
        //            kWh * 2.0;

        //        s.Points.AddXY(
        //            local.ToOADate(),
        //            kW);
        //    }

        //    chartMain.Series.Add(s);
        //}

        #endregion

        #region Temperature

        //private void DrawTemperatureFile(
        //    string file,
        //    DateTime selectedDate,
        //    string name)
        //{
        //    Color colour = Color.Black;

        //    switch (name)
        //    {
        //        case "Gallery":
        //            colour = Color.Green;
        //            break;

        //        case "Middle":
        //            colour = Color.Orange;
        //            break;

        //        case "Outside":
        //            colour = Color.Blue;
        //            break;

        //        case "Sanctuary":
        //            colour = Color.Purple;
        //            break;

        //        case "Thermostat":
        //            colour = Color.Brown;
        //            break;
        //    }

        //    Series s =
        //        new Series(name);

        //    s.ChartType =
        //        SeriesChartType.Line;

        //    s.Color = colour;
        //    s.BorderWidth = 2;

        //    var lines =
        //        File.ReadAllLines(file)
        //            .Skip(1);

        //    foreach (string line in lines)
        //    {
        //        string[] p =
        //            line.Split(',');

        //        if (p.Length < 4)
        //            continue;

        //        DateTime dt;

        //        if (!DateTime.TryParseExact(
        //            p[0] + " " + p[1],
        //            "dd/MM/yyyy HH:mm:ss",
        //            CultureInfo.InvariantCulture,
        //            DateTimeStyles.None,
        //            out dt))
        //            continue;

        //        if (dt.Date != selectedDate.Date)
        //            continue;

        //        double temp;

        //        if (!double.TryParse(
        //            p[2],
        //            out temp))
        //            continue;

        //        s.Points.AddXY(
        //            dt.ToOADate(),
        //            temp);
        //    }

        //    chartMain.Series.Add(s);
        //}

        #endregion

        #region Heatmiser

        //private void DrawHeatmiser(
        //    string file,
        //    DateTime selectedDate)
        //{
        //    Series setSeries =
        //        new Series("SetTemp");

        //    setSeries.ChartType =
        //        SeriesChartType.Line;

        //    setSeries.Color = Color.Black;

        //    Series actSeries =
        //        new Series("ActualTemp");

        //    actSeries.ChartType =
        //        SeriesChartType.Line;

        //    actSeries.Color =
        //        Color.DarkGreen;

        //    var lines =
        //        File.ReadAllLines(file)
        //            .Skip(1);

        //    foreach (string line in lines)
        //    {
        //        string[] p =
        //            line.Split(',');

        //        if (p.Length < 6)
        //            continue;

        //        DateTime dt;

        //        if (!DateTime.TryParseExact(
        //            p[0] + " " + p[1],
        //            "dd/MM/yyyy HH:mm",
        //            CultureInfo.InvariantCulture,
        //            DateTimeStyles.None,
        //            out dt))
        //            continue;

        //        if (dt.Date != selectedDate.Date)
        //            continue;

        //        double setTemp;
        //        double actualTemp;

        //        if (!double.TryParse(
        //            p[2],
        //            out setTemp))
        //            continue;

        //        if (!double.TryParse(
        //            p[3],
        //            out actualTemp))
        //            continue;

        //        setSeries.Points.AddXY(
        //            dt.ToOADate(),
        //            setTemp);

        //        actSeries.Points.AddXY(
        //            dt.ToOADate(),
        //            actualTemp);
        //    }

        //    chartMain.Series.Add(setSeries);
        //    chartMain.Series.Add(actSeries);
        //}

        #endregion

        #region Helpers

        //private string GetCurrentFolder()
        //{
        //    return Path.Combine(
        //        _dataRoot,
        //        lstYears.SelectedItem.ToString(),
        //        lstMonths.SelectedItem.ToString());
        //}

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

        //private bool ContainsDataForDate(
        //    string file,
        //    DateTime date)
        //{
        //    return File.ReadLines(file)
        //        .Skip(1)
        //        .Any(x => x.Contains(
        //            date.ToString("dd/MM/yyyy")) ||
        //            x.Contains(
        //            date.ToString("yyyy-MM-dd")));
        //}

        //private string GetDisplayName(
        //    string file)
        //{
        //    if (file.Equals(
        //        "ChurchE.csv",
        //        StringComparison.OrdinalIgnoreCase))
        //    {
        //        return "Electricity";
        //    }

        //    return Path.GetFileNameWithoutExtension(
        //        file);
        //}

        #endregion

        private void lstYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstYears.SelectedItem == null)
                return;

            LoadMonths();
        }

        private void lstMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMonths.SelectedItem == null)
                return;

            LoadDays();
        }

        private void lstDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDays.SelectedItem == null)
                return;

            LoadDatasets();
        }

        private void LoadDatasets()
        {
            clbData.Items.Clear();

            DateTime selectedDate =
                GetSelectedDate();

            List<string> datasets =
                _csvService.GetAvailableDataSets(
                    _dataRoot,
                    selectedDate);

            foreach (string dataset in datasets)
            {
                clbData.Items.Add(dataset);
            }
        }


    }
}
