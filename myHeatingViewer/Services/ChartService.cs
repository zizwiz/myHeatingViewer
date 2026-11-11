using myHeatingViewer.Models;
using System;
using System.Collections.Generic;
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
            chart.Series.Clear();

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

            area.AxisX.IntervalAutoMode =
                IntervalAutoMode.VariableCount;

            area.AxisX.MajorGrid.LineColor =
                Color.LightGray;

            area.AxisX.IsMarginVisible = false;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 60;

            area.AxisY.MajorGrid.LineColor =
                Color.LightGray;

            chart.Legends.Clear();

            chart.Legends.Add(
                new Legend("Default"));
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

        //public void DrawSeries(
        //    Chart chart,
        //    string dataRoot,
        //    DateTime selectedDate,
        //    string dataset)
        //{
        //    switch (dataset)
        //    {
        //        case "Electricity":
        //            DrawElectricity(
        //                chart,
        //                dataRoot,
        //                selectedDate);
        //            break;

        //        case "Gallery":
        //        case "Middle":
        //        case "Outside":
        //        case "Sanctuary":
        //        case "Thermostat":
        //            DrawTemperature(
        //                chart,
        //                dataRoot,
        //                selectedDate,
        //                dataset);
        //            break;

        //        case "Heatmiser":
        //            DrawHeatmiser(
        //                chart,
        //                dataRoot,
        //                selectedDate);
        //            break;
        //    }
        //}

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

        //private void DrawElectricity(
        //    Chart chart,
        //    string dataRoot,
        //    DateTime date)
        //{

        private void DrawElectricity(
            Chart chart)
        {
            var records =
                _csvService.GetElectricityForDay(
                    _context.DataRoot,
                    _context.SelectedDate);

            //List<ElectricityRecord> records =
            //    _csvService.GetElectricityForDay(
            //        dataRoot,
            //        date);

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

        //private void DrawTemperature(
        //    Chart chart,
        //    string dataRoot,
        //    DateTime date,
        //    string sensor)
        //{
        //    List<TemperatureRecord> records =
        //        _csvService.GetTemperatureForDay(
        //            dataRoot,
        //            date,
        //            sensor);
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

        //private void DrawHeatmiser(
        //    Chart chart,
        //    string dataRoot,
        //    DateTime date)
        //{
        //    List<HeatmiserRecord> records =
        //        _csvService.GetHeatmiserForDay(
        //            dataRoot,
        //            date);

        private void DrawHeatmiser(
            Chart chart)
        {
            var records =
                _csvService.GetHeatmiserForDay(
                    _context.DataRoot,
                    _context.SelectedDate);

        Series setTemp =
                CreateSeries(
                    "Set Temp",
                    Color.Black);

            Series actualTemp =
                CreateSeries(
                    "Actual Temp",
                    Color.DarkGreen);

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
            }

            chart.Series.Add(setTemp);
            chart.Series.Add(actualTemp);
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