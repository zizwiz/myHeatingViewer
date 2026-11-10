using System;

namespace myHeatingViewer.Models
{
    public class TemperatureRecord
    {
        public DateTime Timestamp { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public string Source { get; set; }
    }
}
