using System;

namespace myHeatingViewer.Services
{
    internal class CachedMonth
    {
        public MonthData Data { get; set; }

        public DateTime LastLoaded { get; set; }

        public DateTime LatestFileWriteTime { get; set; }
    }
}
