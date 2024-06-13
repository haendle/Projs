using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpClient.Data
{
    internal class SslResponse
    {
        public string ConnectionString { get; set; }
        public string Host { get; set; }
        public string AccessLevel { get; set; }
        public string Response { get; set; }

        public SslResponse() { }
    }
}
