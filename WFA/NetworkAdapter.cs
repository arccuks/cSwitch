using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    public class NetworkAdapter : IEquatable<NetworkAdapter>
    {
        public NetworkAdapter(string index, string name, string netConnectionID, bool netEnabled)
        {
            Name = name;
            Index = index;
            NetConnectionID = netConnectionID;
            NetEnabled = netEnabled;
        }

        public string Index { get; set; }
        public string Name { get; set; }
        public string NetConnectionID { get; set; }
        public bool NetEnabled { get; set; }

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
            return int.Parse(Index);
        }

        public bool Equals(NetworkAdapter other)
        {
            if (other == null) return false;
            return (this.Index.Equals(other.Index));
        }
    }
}
