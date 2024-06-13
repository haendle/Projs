using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpServer.NetworkData
{
    internal class VirtualData
    {
        public string Type { get; set; }
        public string Buffer { get; set; }

        public VirtualData(string type, string data)
        {
            Type = type;
            Buffer = data;
        }
    }
}
