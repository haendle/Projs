using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Neophron.Network
{
    public class AuthenticationRequest
    {
        public const string TypeRequest = "AUTH_PCKT";
        public string Username { get; set; }
        public string Hostname { get; set; }
        public string UserOS { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SessionBegin { get; set; }
        public string AccessLevel { get; set; }
        public string UserId { get; set; }

        public AuthenticationRequest(string username, string email, string address)
        {
            this.Username = username;
            this.Email = email;
            this.Address = address;

            DateTime dateTime = DateTime.Now;
            this.SessionBegin = dateTime.ToString();

            this.Hostname = Dns.GetHostName();
            this.UserOS = Environment.UserName;

            Guid guid = Guid.NewGuid();
            this.UserId = guid.ToString();
        }
    }
}
