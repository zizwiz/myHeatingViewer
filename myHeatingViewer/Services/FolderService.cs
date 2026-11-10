using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myHeatingViewer.Services
{
    public class FolderService
    {
        public List<string> GetYears(
            string rootFolder)
        {
            return Directory
                .GetDirectories(rootFolder)
                .Select(Path.GetFileName)
                .OrderBy(x => x)
                .ToList();
        }

        public List<string> GetMonths(
            string rootFolder,
            string year)
        {
            string folder =
                Path.Combine(
                    rootFolder,
                    year);

            return Directory
                .GetDirectories(folder)
                .Select(Path.GetFileName)
                .ToList();
        }
    }
}
