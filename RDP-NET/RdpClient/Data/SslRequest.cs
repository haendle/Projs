using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RdpClient.Data
{
    internal class SslRequest
    {
        public string Username { get; }
        public string Hostname { get; }
        public string UserOS { get; }
        public string EndpointLAN { get; }
        public string EndpointWAN { get; }
        public string SessionBegin { get; }
        public string AccessLevel { get; }
        public string UserId { get; }
        public string Password { get; }

        public SslRequest(string username, string password)
        {
            Username = username;

            Hostname = Dns.GetHostName();
            UserOS = Environment.UserName;

            Guid guid = Guid.NewGuid();
            UserId = guid.ToString();

            Password = password;

            EndpointLAN = "";
            EndpointWAN = "";
            SessionBegin = "";
        }
    }
}

