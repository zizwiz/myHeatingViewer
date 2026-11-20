using System.Collections.Generic;
using myHeatingViewer.Models;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace myHeatingViewer.Services
{
    public class ChartService
    {
        private readonly CsvDataService _csvService;
        private readonly DataContext _context;

        public ChartService(
            CsvDataService csvService,
            DataContext context)
        {
            _csvService = csvService;
            _context = context;
        }

        #region Configuration

        public void ConfigureChart(Chart chart)
        {
            ChartArea area;

            if (chart.ChartAreas.Count == 0)
            {
                area = new ChartArea("Main");
                chart.ChartAreas.Add(area);
            }
            else
            {
                area = chart.ChartAreas[0];
            }

            area.AxisX.LabelStyle.Format = "HH:mm";

            area.AxisX.IsMarginVisible = false;

            area.AxisX.MajorGrid.LineColor =
                Color.LightGray;

            area.AxisY.Minimum =
                _context.YAxisMinimum;

            area.AxisY.Maximum =
                _context.YAxisMaximum;

            area.AxisY.MajorGrid.LineColor =
                Color.LightGray;

            //// Zoom section
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = true;

            area.CursorX.Interval = 0;

            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.IsPositionedInside = true;

            area.AxisX.ScaleView.SizeType = DateTimeIntervalType.Hours;

            //// Cross hairs section
            area.CursorX.LineColor = Color.Red;
            area.CursorX.LineWidth = 1;
            area.CursorX.LineDashStyle =
                ChartDashStyle.Dash;

            area.CursorY.LineColor = Color.Red;
            area.CursorY.LineWidth = 1;
            area.CursorY.LineDashStyle =
                ChartDashStyle.Dash;

            //Now hide cross hairs until they are needed
            area.CursorX.SetCursorPosition(double.NaN);
            area.CursorY.SetCursorPosition(double.NaN);
        }

        public static void EnableYAxisZoom(Chart chart, CheckBox myCheckBox)
        {
            bool flag = myCheckBox.Checked;  //used for zooming Y-Axis

            ChartArea area;

            if (chart.ChartAreas.Count == 0)
            {
                area = new ChartArea("Main");
                chart.ChartAreas.Add(area);
            }
            else
            {
                area = chart.ChartAreas[0];
            }

            area.CursorY.IsUserEnabled = flag;
            area.CursorY.IsUserSelectionEnabled = flag;
            area.AxisY.ScaleView.Zoomable = flag;
        }

        #endregion

        #region Clear

        public void Clear(
            Chart chart)
        {
            chart.Series.Clear();
        }

        #endregion

        #region Draw


        public void DrawSeries(
            Chart chart,
            string dataset)
        {
            switch (dataset)
            {
                case "Electricity":

                    DrawElectricity(chart);

                    break;

                case "Gallery":
                case "Middle":
                case "Outside":
                case "Sanctuary":
                case "Thermostat":

                    DrawTemperature(
                        chart,
                        dataset);

                    break;

                case "Heatmiser":

                    DrawHeatmiser(chart);

                    break;
            }
        }

        #endregion

        #region Electricity


        private void DrawElectricity(
            Chart chart)
        {
            var records =
                _csvService.GetElectricityForDay(
                    _context.DataRoot,
                    _context.SelectedDate);

            Series series =
                CreateSeries(
                    "Electricity",
                    _context.ElectricityColour);

            foreach (ElectricityRecord record in records)
            {
                series.Points.AddXY(
                    record.Timestamp.ToOADate(),
                    record.KW);
            }

            chart.Series.Add(series);
        }

        #endregion

        #region Temperature


        private void DrawTemperature(Chart chart, string sensor)
        {
            Color myColor = Color.Empty;

            var records =
                _csvService.GetTemperatureForDay(
                    _context.DataRoot,
                    _context.SelectedDate,
                    sensor);

            switch (sensor)
            {
                case "Gallery":
                    myColor = _context.GalleryColour;
                    break;
                case "Middle":
                    myColor = _context.MiddleColour;
                    break;
                case "Outside":
                    myColor = _context.OutsideColour;
                    break;
                case "Sanctuary":
                    myColor = _context.SanctuaryColour;
                    break;
                case "Thermostat":
                    myColor = _context.ThermostatColour;
                    break;
                default:
                    myColor = Color.Black;
                    break;
            }

            Series series =
                    CreateSeries(
                        sensor,
                        myColor);

            foreach (TemperatureRecord record in records)
            {
                series.Points.AddXY(
                    record.Timestamp.ToOADate(),
                    record.Temperature);
            }

            chart.Series.Add(series);
        }

        #endregion

        #region Heatmiser


        private void DrawHeatmiser(
            Chart chart)
        {
            List<HeatmiserRecord> records =
                _csvService.GetHeatmiserForDay(
                    _context.DataRoot,
                    _context.SelectedDate);

            Series setTemp =
                CreateSeries(
                    "H_Set Temp",
                    _context.SetTempColour);

            Series actualTemp =
                CreateSeries(
                    "H_Actual Temp",
                    _context.ActualTempColour);

            Series churchSensor =
                CreateSeries(
                    "H_Church Sensor",
                    _context.ChurchSensorColour);

            Series state =
                CreateSeries(
                    "H_State",
                    _context.StateColour);

            state.BorderWidth = 1;

            foreach (HeatmiserRecord record in records)
            {
                double x =
                    record.Timestamp.ToOADate();

                setTemp.Points.AddXY(
                    x,
                    record.SetTemperature);

                actualTemp.Points.AddXY(
                    x,
                    record.ActualTemperature);

                churchSensor.Points.AddXY(
                    x,
                    record.ChurchSensor);

                state.Points.AddXY(
                    x,
                    record.State);
            }

            chart.Series.Add(setTemp);

            chart.Series.Add(actualTemp);

            chart.Series.Add(churchSensor);

            chart.Series.Add(state);
        }


        #endregion

        #region Helpers

        private Series CreateSeries(
            string name,
            Color colour)
        {
            Series s =
                new Series(name);

            s.ChartType =
                SeriesChartType.Line;

            s.BorderWidth = 2;

            s.Color = colour;

            s.XValueType =
                ChartValueType.DateTime;

            return s;
        }

        public void ResetZoom(Chart chart)
        {
            ChartArea area = chart.ChartAreas[0];

            area.AxisX.ScaleView.ZoomReset(0);

            area.AxisY.ScaleView.ZoomReset(0);
        }

        #endregion
    }
}