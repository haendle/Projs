using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

using RdpClient.Data;

namespace RdpClient.Sockets
{
    internal class SslClient
    {
        private TcpClient tcpClient;
        private SslStream sslStream;

        private IPEndPoint remotePoint;
        private string hostname;

        public SslClient(string endpoint, string host)
        {
            hostname = host;

            string ip = endpoint.Substring(0, endpoint.IndexOf(':'));
            int port = Convert.ToInt32(endpoint.Substring(endpoint.IndexOf(':') + 1));

            remotePoint = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
            tcpClient = new TcpClient();
        }

        public void SendAuthenticationRequest(string username, string password)
        {
            SslRequest request = new SslRequest(username, password);

            string json = JsonConvert.SerializeObject(request);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            sslStream.Write(jsonBytes, 0, jsonBytes.Length);
            sslStream.Flush();
        }

        public SslResponse RecvAuthenticationResponse()
        {
            byte[] jsonBytes = new byte[2048];

            sslStream.Read(jsonBytes, 0, jsonBytes.Length);

            string json = Encoding.UTF8.GetString(jsonBytes);

            SslResponse response = JsonConvert.DeserializeObject<SslResponse>(json);

            return response;
        }

        public void Connect()
        {
            tcpClient.Connect(remotePoint);

            sslStream = new SslStream(
            tcpClient.GetStream(),
            false,
            new RemoteCertificateValidationCallback(ValidateServerCertificate),
            null
            );

            sslStream.AuthenticateAsClient(hostname);
        }

        public void Close()
        {
            sslStream?.Close();
            sslStream?.Dispose();

            tcpClient?.Close();
            tcpClient?.Dispose();
        }

        private static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            return true;
        }
    }
}
