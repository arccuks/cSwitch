using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public static class AppSettings
    {
        public static void setAppSettingValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings[key].Value = value;

            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string readAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
