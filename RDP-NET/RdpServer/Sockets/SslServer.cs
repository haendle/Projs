using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RdpServer.NetworkData;

namespace RdpServer.Sockets
{
    internal class SslServer
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private SslStream sslStream;

        private static X509Certificate2 serverX509Certificate;

        public SslServer(string cerrPath, int port)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            serverX509Certificate = new X509Certificate2(cerrPath);
            tcpListener = new TcpListener(endpoint);
        }

        public SslRequest RecvAuthenticationRequest()
        {
            try
            {
                tcpListener.Start();
                tcpClient = tcpListener.AcceptTcpClient();

                sslStream = new SslStream(tcpClient.GetStream(), false);

                sslStream.AuthenticateAsServer(serverX509Certificate,
                clientCertificateRequired: false, checkCertificateRevocation: true);

                byte[] jsonBytes = new byte[2048];

                sslStream.Read(jsonBytes, 0, jsonBytes.Length);
                string json = Encoding.UTF8.GetString(jsonBytes);

                SslRequest request = JsonConvert.DeserializeObject<SslRequest>(json);

                return request;
            }

            catch 
            {
                sslStream.Close();

                return null;
            }
        }

        public void SendAuthenticationResponse(object response)
        {
            try
            {
                string json = JsonConvert.SerializeObject(response);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

                sslStream.Write(jsonBytes, 0, jsonBytes.Length);
                sslStream.Flush();
            }

            catch
            { return; }
        }
    }
}
