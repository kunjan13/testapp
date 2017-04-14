using System;
using System.IO;
using TestaApp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseHelper))]
namespace TestaApp.iOS
{
    public class DatabaseHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}