using System.Collections.Generic;
using myHeatingViewer.Models;
using System.Drawing;
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

        public void ConfigureChart(
            Chart chart)
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
                    Color.Red);

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

        
        private void DrawTemperature(
            Chart chart,
            string sensor)
        {
            var records =
                _csvService.GetTemperatureForDay(
                    _context.DataRoot,
                    _context.SelectedDate,
                    sensor);

        Series series =
                CreateSeries(
                    sensor,
                    GetColour(sensor));

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
                    Color.Black);

            Series actualTemp =
                CreateSeries(
                    "H_Actual Temp",
                    Color.DarkGreen);

            Series churchSensor =
                CreateSeries(
                    "H_Church Sensor",
                    Color.DarkOrange);

            Series state =
                CreateSeries(
                    "H_State",
                    Color.Blue);

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

        private Color GetColour(
            string sensor)
        {
            switch (sensor)
            {
                case "Gallery":
                    return Color.Green;

                case "Middle":
                    return Color.Orange;

                case "Outside":
                    return Color.Blue;

                case "Sanctuary":
                    return Color.Purple;

                case "Thermostat":
                    return Color.Brown;

                default:
                    return Color.Black;
            }
        }

        #endregion
    }
}