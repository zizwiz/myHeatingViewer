using myHeatingViewer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace myHeatingViewer.Services
{
    public class CsvDataService
    {
        private readonly TimeZoneInfo _ukTimeZone;

        private readonly Dictionary<string, CachedMonth>
            _monthCache;

        public CsvDataService()
        {
            _ukTimeZone =
                TimeZoneInfo.FindSystemTimeZoneById(
                    "GMT Standard Time");

            _monthCache =
                new Dictionary<string, CachedMonth>(
                    StringComparer.OrdinalIgnoreCase);
        }

        #region Cache

        public void ClearCache()
        {
            _monthCache.Clear();
        }

        private string GetMonthKey(
            int year,
            string month)
        {
            return year + "\\" + month;
        }

        private DateTime GetLatestWriteTime(
            string folder)
        {
            DateTime latest =
                DateTime.MinValue;

            foreach (string file in
                Directory.GetFiles(folder, "*.csv"))
            {
                DateTime writeTime =
                    File.GetLastWriteTime(file);

                if (writeTime > latest)
                {
                    latest = writeTime;
                }
            }

            return latest;
        }

        #endregion

        #region Month Loading

        public MonthData LoadMonth(
            string dataRoot,
            string year,
            string month)
        {
            string key =
                GetMonthKey(
                    Convert.ToInt32(year),
                    month);

            string folder =
                Path.Combine(
                    dataRoot,
                    year,
                    month);

            if (!Directory.Exists(folder))
            {
                return new MonthData();
            }

            DateTime latestWriteTime =
                GetLatestWriteTime(folder);

            CachedMonth cachedMonth;

            if (_monthCache.TryGetValue(
                    key,
                    out cachedMonth))
            {
                if (cachedMonth.LatestFileWriteTime ==
                    latestWriteTime)
                {
                    return cachedMonth.Data;
                }
            }

            MonthData data =
                LoadMonthInternal(folder);

            _monthCache[key] =
                new CachedMonth
                {
                    Data = data,
                    LastLoaded = DateTime.Now,
                    LatestFileWriteTime =
                        latestWriteTime
                };

            return data;
        }

        private MonthData LoadMonthInternal(
            string folder)
        {
            MonthData monthData =
                new MonthData();

            string electricityFile =
                Path.Combine(
                    folder,
                    "ChurchE.csv");

            if (File.Exists(electricityFile))
            {
                monthData.Electricity =
                    ParseElectricity(
                        electricityFile);
            }

            LoadTemperatureFile(
                folder,
                "Gallery.csv",
                monthData);

            LoadTemperatureFile(
                folder,
                "Middle.csv",
                monthData);

            LoadTemperatureFile(
                folder,
                "Outside.csv",
                monthData);

            LoadTemperatureFile(
                folder,
                "Sanctuary.csv",
                monthData);

            LoadTemperatureFile(
                folder,
                "Thermostat.csv",
                monthData);

            string heatmiserFile =
                Path.Combine(
                    folder,
                    "Heatmiser.csv");

            if (File.Exists(heatmiserFile))
            {
                monthData.Heatmiser =
                    ParseHeatmiser(
                        heatmiserFile);
            }

            return monthData;
        }

        #endregion

        #region Public Methods

        public List<int> GetAvailableDays(
            string dataRoot,
            string year,
            string month)
        {
            MonthData data =
                LoadMonth(
                    dataRoot,
                    year,
                    month);

            return data.Electricity
                .Select(x => x.Timestamp.Day)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public List<string> GetAvailableDataSets(
            string dataRoot,
            DateTime day)
        {
            List<string> result =
                new List<string>();

            MonthData data =
                LoadMonth(
                    dataRoot,
                    day.Year.ToString(),
                    day.ToString("MMMM"));

            if (data.Electricity.Any(
                x => x.Timestamp.Date == day.Date))
            {
                result.Add("Electricity");
            }

            foreach (var sensor in
                data.Temperatures)
            {
                if (sensor.Value.Any(
                    x => x.Timestamp.Date == day.Date))
                {
                    result.Add(sensor.Key);
                }
            }
            
            if (data.Heatmiser.Any(
                x => x.Timestamp.Date == day.Date))
            {
                result.Add("Heatmiser");
            }

            return result;
        }

        public List<ElectricityRecord>
            GetElectricityForDay(
                string dataRoot,
                DateTime day)
        {
            MonthData data =
                LoadMonth(
                    dataRoot,
                    day.Year.ToString(),
                    day.ToString("MMMM"));

            return data.Electricity
                .Where(x => x.Timestamp.Date ==
                            day.Date)
                .ToList();
        }

        public List<TemperatureRecord>
            GetTemperatureForDay(
                string dataRoot,
                DateTime day,
                string sensorName)
        {
            MonthData data =
                LoadMonth(
                    dataRoot,
                    day.Year.ToString(),
                    day.ToString("MMMM"));

            if (!data.Temperatures.ContainsKey(
                sensorName))
            {
                return new List<TemperatureRecord>();
            }

            return data.Temperatures[sensorName]
                .Where(x =>
                    x.Timestamp.Date == day.Date)
                .ToList();
        }

        public List<HeatmiserRecord>
            GetHeatmiserForDay(
                string dataRoot,
                DateTime day)
        {
            MonthData data =
                LoadMonth(
                    dataRoot,
                    day.Year.ToString(),
                    day.ToString("MMMM"));

            return data.Heatmiser
                .Where(x => x.Timestamp.Date ==
                            day.Date)
                .ToList();
        }

        #endregion

        #region Electricity Parsing

        private List<ElectricityRecord>
            ParseElectricity(
                string fileName)
        {
            List<ElectricityRecord> records =
                new List<ElectricityRecord>();

            foreach (string line in
                File.ReadLines(fileName).Skip(1))
            {
                string[] parts =
                    line.Split(',');

                if (parts.Length < 3)
                    continue;

                DateTime utc;

                if (!DateTime.TryParse(
                    parts[2],
                    null,
                    DateTimeStyles.RoundtripKind,
                    out utc))
                {
                    continue;
                }

                double kWh;

                if (!double.TryParse(
                    parts[1],
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out kWh))
                {
                    continue;
                }

                records.Add(
                    new ElectricityRecord
                    {
                        Timestamp =
                            TimeZoneInfo
                                .ConvertTimeFromUtc(
                                    utc,
                                    _ukTimeZone),
                        KWh = kWh
                    });
            }

            return records;
        }

        #endregion

        #region Temperature Parsing

        private void LoadTemperatureFile(
            string folder,
            string fileName,
            MonthData monthData)
        {
            string fullPath =
                Path.Combine(
                    folder,
                    fileName);

            if (!File.Exists(fullPath))
                return;

            string sensorName =
                Path.GetFileNameWithoutExtension(
                    fileName);

            monthData.Temperatures.Add(
                sensorName,
                ParseTemperature(
                    fullPath,
                    sensorName));
        }

        private List<TemperatureRecord>
            ParseTemperature(
                string fileName,
                string source)
        {
            List<TemperatureRecord> records =
                new List<TemperatureRecord>();

            foreach (string line in
                File.ReadLines(fileName).Skip(1))
            {
                string[] parts =
                    line.Split(',');

                if (parts.Length < 4)
                    continue;

                DateTime timestamp;

                string[] formats =
                {
                    "dd/MM/yyyy HH:mm:ss",
                    "MM/dd/yyyy HH:mm:ss"
                };

                if (!DateTime.TryParseExact(
                        parts[0] + " " + parts[1],
                        formats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out timestamp))
                {
                    continue;
                }

                double temperature;
                double humidity;

                if (!double.TryParse(
                    parts[2],
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out temperature))
                {
                    continue;
                }

                if (!double.TryParse(
                    parts[3],
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out humidity))
                {
                    continue;
                }

                records.Add(
                    new TemperatureRecord
                    {
                        Timestamp = timestamp,
                        Temperature = temperature,
                        Humidity = humidity,
                        Source = source
                    });
            }

            return records;
        }

        #endregion

        #region Heatmiser Parsing

        private List<HeatmiserRecord>
            ParseHeatmiser(
                string fileName)
        {
            List<HeatmiserRecord> records =
                new List<HeatmiserRecord>();

            foreach (string line in
                File.ReadLines(fileName).Skip(1))
            {
                string[] parts =
                    line.Split(',');

                if (parts.Length < 6)
                    continue;

                DateTime timestamp;

                if (!DateTime.TryParseExact(
                    parts[0] + " " + parts[1],
                    "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out timestamp))
                {
                    continue;
                }

                records.Add(
                    new HeatmiserRecord
                    {
                        Timestamp = timestamp,
                        SetTemperature =
                            Convert.ToDouble(
                                parts[2],
                                CultureInfo.InvariantCulture),

                        ActualTemperature =
                            Convert.ToDouble(
                                parts[3],
                                CultureInfo.InvariantCulture),

                        ChurchSensor =
                            Convert.ToDouble(
                                parts[4],
                                CultureInfo.InvariantCulture),

                        State =
                            Convert.ToInt32(parts[5])
                    });
            }

            return records;
        }

        #endregion
    }
}