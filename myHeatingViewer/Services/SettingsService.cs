using System.Drawing;

namespace myHeatingViewer.Services
{
    public class SettingsService
    {
        public Color LoadColor(
            string colorName,
            Color defaultColor)
        {
            try
            {
                return Color.FromName(colorName);
            }
            catch
            {
                return defaultColor;
            }
        }

        public string SaveColor(
            Color color)
        {
            return color.Name;
        }
    }
}
