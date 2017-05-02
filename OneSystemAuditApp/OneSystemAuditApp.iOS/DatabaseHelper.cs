using System;
using System.IO;
using OneSystemAudit.iOS;
using Xamarin.Forms;
using AuditAppPcl.Database;

[assembly: Dependency(typeof(DatabaseHelper))]
namespace OneSystemAudit.iOS
{
    public class DatabaseHelper: IDatabaseHelper
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