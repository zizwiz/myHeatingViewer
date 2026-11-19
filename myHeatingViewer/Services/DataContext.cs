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

        public double YAxisMinimum { get; set; }

        public double YAxisMaximum { get; set; } = 60;

        public Color ElectricityColour { get; set; }

        public Color GalleryColour { get; set; }

        public Color MiddleColour { get; set; }

        public Color OutsideColour { get; set; }

        public Color SanctuaryColour { get; set; }

        public Color ThermostatColour { get; set; }

        public Color SetTempColour { get; set; }

        public Color ActualTempColour { get; set; }

        public Color ChurchSensorColour { get; set; }

        public Color StateColour { get; set; }

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
            ElectricityColour = Properties.Settings.Default.ElectricityColour;
            GalleryColour = Properties.Settings.Default.GalleryColour;
            MiddleColour = Properties.Settings.Default.MiddleColour;
            OutsideColour = Properties.Settings.Default.OutsideColour;
            SanctuaryColour = Properties.Settings.Default.SanctuaryColour;
            ThermostatColour = Properties.Settings.Default.ThermostatColour;
            SetTempColour = Properties.Settings.Default.SetTempColour;
            ActualTempColour = Properties.Settings.Default.ActualTempColour;
            ChurchSensorColour = Properties.Settings.Default.ChurchSensorColour;
            StateColour = Properties.Settings.Default.StateColour;
            
            YAxisMinimum = Properties.Settings.Default.YAxisMin;
            YAxisMaximum = Properties.Settings.Default.YAxisMax;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.ElectricityColour = ElectricityColour;
            Properties.Settings.Default.GalleryColour = GalleryColour;
            Properties.Settings.Default.MiddleColour = MiddleColour;
            Properties.Settings.Default.OutsideColour = OutsideColour;
            Properties.Settings.Default.SanctuaryColour = SanctuaryColour;
            Properties.Settings.Default.ThermostatColour = ThermostatColour;
            Properties.Settings.Default.SetTempColour = SetTempColour;
            Properties.Settings.Default.ActualTempColour = ActualTempColour;
            Properties.Settings.Default.ChurchSensorColour = ChurchSensorColour;
            Properties.Settings.Default.StateColour = StateColour;

            Properties.Settings.Default.YAxisMin = YAxisMinimum;
            Properties.Settings.Default.YAxisMax = YAxisMaximum;

            Properties.Settings.Default.Save();
        }
    }
}

