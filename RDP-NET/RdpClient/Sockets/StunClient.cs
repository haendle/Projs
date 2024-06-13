using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using LumiSoft.Net.STUN.Client;

namespace RdpClient.Sockets
{
    internal class StunClient
    {
        private Socket _socket;

        public StunClient()
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
    }
}
