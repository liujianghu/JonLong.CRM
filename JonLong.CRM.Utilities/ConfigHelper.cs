using System.Configuration;

namespace JonLong.CRM.Utilities
{
    public class ConfigHelper
    {
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string GetAppSetting(string key)
        {
            return ConfigurationSettings.AppSettings[key];
        }

    }
}
