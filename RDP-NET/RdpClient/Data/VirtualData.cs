using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpClient.Data
{
    internal class VirtualData
    {
        public string Type { get; set; }
        public string Buffer { get; set; }

        public VirtualData(string type, string buff)
        {
            Type = type;
            Buffer = buff;
        }
    }
}
