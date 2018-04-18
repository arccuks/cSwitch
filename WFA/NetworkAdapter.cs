using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    public class NetworkAdapter : IEquatable<NetworkAdapter>
    {
        public NetworkAdapter(int index, string name, string netConnectionID, bool netEnabled)
        {
            Name = name;
            Index = index;
            NetConnectionID = netConnectionID;
            NetEnabled = netEnabled;
        }

        public static int InnerAdapterIndex { get; set; }
        public static bool InnerAdapterEnabled { get; set; }
        public static int OuterAdapterIndex { get; set; }
        public static bool OuterAdapterEnabled { get; set; }


        public int Index { get; set; }
        public string Name { get; set; }
        public string NetConnectionID { get; set; }
        public bool NetEnabled { get; set; }
        public string Status
        {
            get
            {
                if (Index.Equals(InnerAdapterIndex) && Index.Equals(OuterAdapterIndex))
                {
                    return "Inner - Outer";
                }
                if (Index.Equals(InnerAdapterIndex))
                {
                    return "Inner";
                }
                if (Index.Equals(OuterAdapterIndex))
                {
                    return "Outer";
                }
                return null;
            }
        }

        public override string ToString()
        {
            return "Index: " + Index + "   Name: " + Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            NetworkAdapter objAsPart = obj as NetworkAdapter;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Index;
        }

        public bool Equals(NetworkAdapter other)
        {
            if (other == null) return false;
            return (this.Index.Equals(other.Index));
        }

        public static void enableNetworkAdapter(int index, bool enable)
        {
            String cmd = "/c start wmic path win32_networkadapter where index=" + index + " call " + (enable == true ? "enable" : "disable");
            CommandLine.executeCommand(cmd);
        }
    }
}
