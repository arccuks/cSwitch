using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{

    public static class Proxy
    {
        private static string PROXY_REG_KEY_NAME => "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private static string PROXY_REG_VALUE_NAME => "ProxyEnable";
        public static int PROXY_OFF => 0;
        public static int PROXY_ON => 1;

        public static bool ProxyEnabled { get; set; } = false;

        // Returns proxy status from Windows Registry
        public static bool getProxyStatus()
        {
            return Registry.GetValue(PROXY_REG_KEY_NAME, PROXY_REG_VALUE_NAME, PROXY_OFF).ToString().Equals("1");
        }

        public static void enableProxy(bool enable)
        {
            Registry.SetValue(PROXY_REG_KEY_NAME, PROXY_REG_VALUE_NAME, (enable == true ? PROXY_ON : PROXY_OFF), RegistryValueKind.DWord);
        }
    }
}
