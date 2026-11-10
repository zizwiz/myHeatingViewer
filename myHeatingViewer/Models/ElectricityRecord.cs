using System;

namespace myHeatingViewer.Models
{
    public class ElectricityRecord
    {
        public DateTime Timestamp { get; set; }

        public double KWh { get; set; }

        public double KW
        {
            get { return KWh * 2.0; }
        }
    }
}

