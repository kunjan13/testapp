using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAppPcl.Settings
{
    public static class Settings
    {

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        const string AppVersionKey = "appversion";
        private static readonly string DefaultAppVersion = "1.0";



        #endregion



        public static string AppVersion
        {
            get { return AppSettings.GetValueOrDefault<string>(AppVersionKey, DefaultAppVersion); }
            set { AppSettings.AddOrUpdateValue<string>(AppVersionKey, value); }
        }
    }
}
