using System;
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
    }
}
