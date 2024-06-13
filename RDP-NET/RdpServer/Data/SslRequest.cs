using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpServer.NetworkData
{
    internal class SslRequest
    {
        public string Username { get; set; }
        public string Hostname { get; set; }
        public string UserOS { get; set; }
        public string EndpointLAN { get; set; }
        public string EndpointWAN { get; set; }
        public string SessionBegin { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }

        public SslRequest() { }
    }
}
