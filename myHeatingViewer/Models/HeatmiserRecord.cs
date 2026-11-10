using System;

namespace myHeatingViewer.Models
{
    public class HeatmiserRecord
    {
        public DateTime Timestamp { get; set; }

        public double SetTemperature { get; set; }

        public double ActualTemperature { get; set; }

        public double ChurchSensor { get; set; }

        public int State { get; set; }
    }
}
