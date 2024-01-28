using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neophron.Network
{
    public class DataRequest
    {
        public const string TypeRequest = "DATA_PCKT";
        public string name { get; private set; }
        public long size { get; private set; }

        public string mode { get; private set; }

        public DataRequest(string name, long size, string mode)
        {
            this.name = name;
            this.size = size;
            this.mode = mode;
        }
    }
}
