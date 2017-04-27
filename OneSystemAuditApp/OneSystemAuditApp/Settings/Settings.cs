using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

        const string ApiUrlKey = "apiurl";
        private static readonly string DefaultApiUrl = "https://onecrm.oneportal.is/mobile/OneMobileWebService/";

        const string UserServicePathKey = "userservicepath";
        private static readonly string DefaultUserServicePath = "https://onecrm.oneportal.is/mobile/OneMobileWebService/";

        const string UsernameKey = "username";
        private static readonly string DefaultUsername = string.Empty;

        const string LoginTokenKey = "logintoken";
        private static readonly string DefaultLoginToken = string.Empty;
        #endregion



        public static string AppVersion
        {
            get { return AppSettings.GetValueOrDefault<string>(AppVersionKey, DefaultAppVersion); }
            set { AppSettings.AddOrUpdateValue<string>(AppVersionKey, value); }
        }

        public static string ApiUrl
        {
            get { return AppSettings.GetValueOrDefault<string>(ApiUrlKey, DefaultApiUrl); }
            set { AppSettings.AddOrUpdateValue<string>(ApiUrlKey, value); }
        }

        public static string UserServicePath
        {
            get { return AppSettings.GetValueOrDefault<string>(UserServicePathKey, DefaultUserServicePath); }
            set { AppSettings.AddOrUpdateValue<string>(UserServicePathKey, value); }
        }

        public static string Username
        {
            get { return AppSettings.GetValueOrDefault<string>(UsernameKey, DefaultUsername); }
            set { AppSettings.AddOrUpdateValue<string>(UsernameKey, value); }
        }

        public static string LoginToken
        {
            get { return AppSettings.GetValueOrDefault<string>(LoginTokenKey, DefaultLoginToken); }
            set { AppSettings.AddOrUpdateValue<string>(LoginTokenKey, value); }
        }
    }
}
