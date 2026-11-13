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


        public void LoadUserSettings()
        {
            ElectricityColour =
                Color.FromName(
                    Properties.Settings.Default
                        .ElectricityColour);

            GalleryColour =
                Color.FromName(
                    Properties.Settings.Default
                        .GalleryColour);

            MiddleColour =
                Color.FromName(
                    Properties.Settings.Default
                        .MiddleColour);

            OutsideColour =
                Color.FromName(
                    Properties.Settings.Default
                        .OutsideColour);

            SanctuaryColour =
                Color.FromName(
                    Properties.Settings.Default
                        .SanctuaryColour);

            ThermostatColour =
                Color.FromName(
                    Properties.Settings.Default
                        .ThermostatColour);

            SetTempColour =
                Color.FromName(
                    Properties.Settings.Default
                        .SetTempColour);

            ActualTempColour =
                Color.FromName(
                    Properties.Settings.Default
                        .ActualTempColour);

            ChurchSensorColour =
                Color.FromName(
                    Properties.Settings.Default
                        .ChurchSensorColour);

            StateColour =
                Color.FromName(
                    Properties.Settings.Default
                        .StateColour);

            YAxisMinimum =
                Properties.Settings.Default.YAxisMin;

            YAxisMaximum =
                Properties.Settings.Default.YAxisMax;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default
                    .ElectricityColour =
                ElectricityColour.Name;

            Properties.Settings.Default
                    .GalleryColour =
                GalleryColour.Name;

            Properties.Settings.Default
                    .MiddleColour =
                MiddleColour.Name;

            Properties.Settings.Default
                    .OutsideColour =
                OutsideColour.Name;

            Properties.Settings.Default
                    .SanctuaryColour =
                SanctuaryColour.Name;

            Properties.Settings.Default
                    .ThermostatColour =
                ThermostatColour.Name;

            Properties.Settings.Default
                    .SetTempColour =
                SetTempColour.Name;

            Properties.Settings.Default
                    .ActualTempColour =
                ActualTempColour.Name;

            Properties.Settings.Default
                    .ChurchSensorColour =
                ChurchSensorColour.Name;

            Properties.Settings.Default
                    .StateColour =
               StateColour.Name;

            Properties.Settings.Default
                    .YAxisMin =
                YAxisMinimum;

            Properties.Settings.Default
                    .YAxisMax =
                YAxisMaximum;

            Properties.Settings.Default.Save();
        }
    }
}

