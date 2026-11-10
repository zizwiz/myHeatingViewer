using System.Collections.Generic;
using myHeatingViewer.Models;

namespace myHeatingViewer.Services
{
    public class MonthData
    {
        public List<ElectricityRecord> Electricity { get; set; }

        public Dictionary<string,
            List<TemperatureRecord>> Temperatures
        {
            get;
            set;
        }

        public List<HeatmiserRecord> Heatmiser { get; set; }

        public MonthData()
        {
            Electricity =
                new List<ElectricityRecord>();

            Temperatures =
                new Dictionary<string,
                    List<TemperatureRecord>>();

            Heatmiser =
                new List<HeatmiserRecord>();
        }
    }
}