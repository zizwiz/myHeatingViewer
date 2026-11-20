using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace myHeatingViewer.Helpers
{
    class DayNightShading
    {
        /////////////////
        /// Sunrise Sunset items
        public static DateTime? GetSunEventLocal(DateTime day, bool isSunrise)
        {
            Sunriset sr = new Sunriset();

            double latitude = 52.2053;
            double longitude = 0.1218;

            double utcHours = sr.CalculateSunTime(day, latitude, longitude, isSunrise);

            if (double.IsNaN(utcHours))
                return null;

            int hour = (int)Math.Floor(utcHours);
            int minute = (int)Math.Floor((utcHours - hour) * 60);
            int second = (int)Math.Floor(((utcHours - hour) * 60 - minute) * 60);

            DateTime utcTime = new DateTime(
                day.Year, day.Month, day.Day,
                hour, minute, second,
                DateTimeKind.Utc);

            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(
                utcTime,
                TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));

            return localTime;
        }

        //Draw vertical lines
        public static void AddVerticalLine(DateTime time, Color color, Chart myChart)
        {
            StripLine line = new StripLine();
            line.BorderColor = color;
            line.BorderWidth = 2;
            line.BorderDashStyle = ChartDashStyle.Solid;

            line.IntervalOffset = time.ToOADate();
            line.StripWidth = 0.0001;

            myChart.ChartAreas[0].AxisX.StripLines.Add(line);
        }

        public static void AddDaylightShading(DateTime sunrise, DateTime sunset, Chart myChart)
        {
            StripLine strip = new StripLine();
            strip.BackColor = Color.FromArgb(40, Color.Yellow); // soft daylight
            strip.IntervalOffset = sunrise.ToOADate();
            strip.StripWidth = sunset.ToOADate() - sunrise.ToOADate();

            myChart.ChartAreas[0].AxisX.StripLines.Add(strip);
        }

        public static void AddNightShading(DateTime sunset, DateTime nextSunrise, Chart myChart)
        {
            //This is added from sunset to midnight only
            StripLine strip = new StripLine();
            strip.BackColor = Color.FromArgb(40, Color.DarkBlue);
            strip.IntervalOffset = sunset.ToOADate();
            //strip.StripWidth = nextSunrise.ToOADate() - sunset.ToOADate();
            //Extract date and set to midnight
            strip.StripWidth = DateTime.Parse(nextSunrise.ToShortDateString() + " 00:00:00").ToOADate() - sunset.ToOADate();

            myChart.ChartAreas[0].AxisX.StripLines.Add(strip);
        }

        public static void AddNightBeforeSunrise(DateTime day, DateTime sunrise, Chart myChart)
        {
            DateTime midnight = day.Date;

            StripLine strip = new StripLine();
            strip.BackColor = Color.FromArgb(40, Color.DarkBlue);
            strip.IntervalOffset = midnight.ToOADate();
            strip.StripWidth = sunrise.ToOADate() - midnight.ToOADate();

            myChart.ChartAreas[0].AxisX.StripLines.Add(strip);
        }

        public static void AddYesterdayPaddingShade(DateTime day, Chart myChart)
        {
            DateTime yesterday = day.AddDays(-1);
            DateTime start = yesterday.Date.AddHours(23).AddMinutes(00);
            DateTime end = day.Date;

            StripLine strip = new StripLine();
            strip.BackColor = Color.FromArgb(40, Color.DarkBlue);
            strip.IntervalOffset = start.ToOADate();
            strip.StripWidth = end.ToOADate() - start.ToOADate();

            myChart.ChartAreas[0].AxisX.StripLines.Add(strip);
        }

    }
}
