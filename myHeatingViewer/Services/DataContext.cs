using System;
using System.Drawing;
using System.Globalization;

namespace myHeatingViewer.Services
{
    public class DataContext
    {
        public string DataRoot { get; set; }

        public string CurrentYear { get; set; }

        public string CurrentMonth { get; set; }

        public int CurrentDay { get; set; }

        public double YAxisMinimum { get; set; } = 0;

        public double YAxisMaximum { get; set; } = 60;

        public Color ElectricityColour { get; set; }
            = Color.Green;

        public Color GalleryColour { get; set; }
            = Color.Blue;

        public Color MiddleColour { get; set; }
            = Color.Orange;

        public Color OutsideColour { get; set; }
            = Color.DarkCyan;

        public Color SanctuaryColour { get; set; }
            = Color.Magenta;

        public Color ThermostatColour { get; set; }
            = Color.Goldenrod;

        public Color SetTempColour { get; set; }
            = Color.DarkRed;

        public Color ActualTempColour { get; set; }
            = Color.Yellow;

        public Color ChurchSensorColour { get; set; }
            = Color.Purple;

        public Color StateColour { get; set; }
            = Color.Red;

        public DateTime SelectedDate
        {
            get
            {
                int year =
                    Convert.ToInt32(CurrentYear);

                int month =
                    DateTime.ParseExact(
                            CurrentMonth,
                            "MMMM",
                            CultureInfo.InvariantCulture)
                        .Month;

                return new DateTime(
                    year,
                    month,
                    CurrentDay);
            }
        }


        //public void LoadUserSettings()
        //{
        //    _context.ElectricityColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .ElectricityColour);

        //    _context.GalleryColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .GalleryColour);

        //    _context.MiddleColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .MiddleColour);

        //    _context.OutsideColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .OutsideColour);

        //    _context.SanctuaryColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .SanctuaryColour);

        //    _context.ThermostatColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .ThermostatColour);

        //    _context.SetTempColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .SetTempColour);

        //    _context.ActualTempColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .ActualTempColour);

        //    _context.ChurchSensorColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .ChurchSensorColour);

        //    _context.StateColor =
        //        Color.FromName(
        //            Properties.Settings.Default
        //                .StateColour);

        //    _context.YAxisMinimum =
        //        Properties.Settings.Default.YAxisMin;

        //    _context.YAxisMaximum =
        //        Properties.Settings.Default.YAxisMax;
        //}

        //private void SaveSettings()
        //{
        //    Properties.Settings.Default
        //            .ElectricityColour =
        //        _context.ElectricityColor.Name;

        //    Properties.Settings.Default
        //            .GalleryColour =
        //        _context.GalleryColor.Name;

        //    Properties.Settings.Default
        //            .MiddleColour =
        //        _context.MiddleColor.Name;

        //    Properties.Settings.Default
        //            .OutsideColour =
        //        _context.OutsideColor.Name;

        //    Properties.Settings.Default
        //            .SanctuaryColour =
        //        _context.SanctuaryColor.Name;

        //    Properties.Settings.Default
        //            .ThermostatColour =
        //        _context.ThermostatColor.Name;

        //    Properties.Settings.Default
        //            .SetTempColour =
        //        _context.SetTempColor.Name;

        //    Properties.Settings.Default
        //            .ActualTempColour =
        //        _context.ActualTempColor.Name;

        //    Properties.Settings.Default
        //            .ChurchSensorColour =
        //        _context.ChurchSensorColor.Name;

        //    Properties.Settings.Default
        //            .StateColour =
        //        _context.StateColor.Name;

        //    Properties.Settings.Default
        //            .YAxisMin =
        //        _context.YAxisMinimum;

        //    Properties.Settings.Default
        //            .YAxisMax =
        //        _context.YAxisMaximum;

        //    Properties.Settings.Default.Save();
        //}
    }
}

