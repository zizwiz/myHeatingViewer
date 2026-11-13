using System;

public sealed class Sunriset
{
    /// <summary>
    /// Calculates sunrise or sunset time in decimal hours (UTC) using NOAA algorithm.
    /// </summary>
    public double CalculateSunTime(DateTime date, double latitude, double longitude, bool isSunrise)
    {
        // Convert longitude to hour value and calculate approximate time
        int dayOfYear = date.DayOfYear;
        double lngHour = longitude / 15.0;
        double t = dayOfYear + ((isSunrise ? 6 : 18) - lngHour) / 24.0;

        // Sun's mean anomaly
        double M = (0.9856 * t) - 3.289;

        // Sun's true longitude
        double L = M + (1.916 * Math.Sin(DegToRad(M))) + (0.020 * Math.Sin(2 * DegToRad(M))) + 282.634;
        L = NormalizeDegrees(L);

        // Sun's right ascension
        double RA = RadToDeg(Math.Atan(0.91764 * Math.Tan(DegToRad(L))));
        RA = NormalizeDegrees(RA);

        // Adjust RA to same quadrant as L
        double Lquadrant = Math.Floor(L / 90.0) * 90.0;
        double RAquadrant = Math.Floor(RA / 90.0) * 90.0;
        RA = RA + (Lquadrant - RAquadrant);

        RA /= 15.0; // Convert to hours

        // Sun's declination
        double sinDec = 0.39782 * Math.Sin(DegToRad(L));
        double cosDec = Math.Cos(Math.Asin(sinDec));

        // Sun's local hour angle
        double cosH = (Math.Cos(DegToRad(90.833)) - (sinDec * Math.Sin(DegToRad(latitude)))) /
                      (cosDec * Math.Cos(DegToRad(latitude)));

        if (cosH > 1) return double.NaN; // Sun never rises
        if (cosH < -1) return double.NaN; // Sun never sets

        double H = isSunrise
            ? 360.0 - RadToDeg(Math.Acos(cosH))
            : RadToDeg(Math.Acos(cosH));

        H /= 15.0;

        // Local mean time
        double T = H + RA - (0.06571 * t) - 6.622;

        // Adjust to UTC
        double UT = T - lngHour;
        UT = (UT + 24) % 24;

        return UT; // Decimal hours UTC
    }

    private double DegToRad(double deg) => deg * Math.PI / 180.0;
    private double RadToDeg(double rad) => rad * 180.0 / Math.PI;
    private double NormalizeDegrees(double deg)
    {
        deg %= 360.0;
        if (deg < 0) deg += 360.0;
        return deg;
    }
}
