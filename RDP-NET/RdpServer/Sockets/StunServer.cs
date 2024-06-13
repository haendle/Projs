using LumiSoft.Net.STUN.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RdpServer.Sockets
{
    internal class StunServer
    {
        private Socket _socket;

        public StunServer()
        {
            _socket = new Socket
            (
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp
            );

            _socket.Bind(new IPEndPoint(IPAddress.Any, 0));
        }

        public string SendRequest()
        {
            var request = STUN_Client.Query("stun.l.google.com", 19302, _socket);

            if (request.NetType != STUN_NetType.UdpBlocked)
            {
                return request.PublicEndPoint.ToString();
            }

            else
            {
                return "";
            }
        }

        public string GetInternalAddr()
        {
            IPAddress[] addrs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (var addr in addrs) 
            { 
                var ipAddr = addr.ToString();

                if (!ipAddr.Contains(":"))
                { return ipAddr; }
            }

            return "0.0.0.0";
        }
    }
}
