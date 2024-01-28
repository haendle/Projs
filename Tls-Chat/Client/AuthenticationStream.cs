using Microsoft.VisualBasic.Logging;
using NATUPNPLib;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class AuthenticationStream
    {
        private TcpClient TcpClient;
        private IPEndPoint RemoteEndPoint;
        private SslStream SslStream;

        private IStaticPortMappingCollection PortMapping;

        public AuthenticationStream(IPAddress IPAddress, int remotePort, int internalPort, int externalPort)
        {
            UPnPNAT uPnPNAT = new UPnPNAT();

            IPAddress[] ipAddrs = Dns.GetHostAddresses(Dns.GetHostName());

            for (int i = 0; i < ipAddrs.Length; i++)
            {
                string ipAddress = ipAddrs[i].ToString();

                if (ipAddress.Contains("192.168.0.") || 
                    ipAddress.Contains("192.168.1."))
                {
                    PortMapping = uPnPNAT.StaticPortMappingCollection;

                    PortMapping.Add(externalPort, "TCP", internalPort,
                    ipAddress, true, "Neophron-App");

                    RemoteEndPoint = new IPEndPoint(IPAddress, remotePort);

                    IPEndPoint endPoint = new IPEndPoint
                    (IPAddress.Any, internalPort);

                    TcpClient = new TcpClient(endPoint);
                }
            }
        }

        public void Connect(string serverName)
        {
            TcpClient.Connect(RemoteEndPoint);

            SslStream = new SslStream(
            TcpClient.GetStream(),
            false,
            new RemoteCertificateValidationCallback(ValidateServerCertificate),
            null
            );

            SslStream.AuthenticateAsClient(serverName);
        }

        public void Send(string username, string pword, string mode)
        {
            username += "<EOF>";
            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);

            pword += "<EOF>";
            byte[] pwordBytes = Encoding.UTF8.GetBytes(pword);

            mode += "<EOF>";
            byte[] modeBytes = Encoding.UTF8.GetBytes(mode);

            SslStream.Write(usernameBytes);
            SslStream.Flush();
            Thread.Sleep(100);

            SslStream.Write(pwordBytes);
            SslStream.Flush();
            Thread.Sleep(100);

            SslStream.Write(modeBytes);
            SslStream.Flush();
            Thread.Sleep(100);
        }

        public string Recv()
        {
            string result = Read(SslStream);
            result = result.Substring(0, result.Length - 5);

            TcpClient.Close();
            TcpClient.Dispose();

            SslStream.Close();
            SslStream.Dispose();

            return result;
        }

        private string Read(SslStream stream)
        {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();

            int recvBytes = -1;

            do
            {
                recvBytes = stream.Read(buffer, 0, buffer.Length);

                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, recvBytes)];
                decoder.GetChars(buffer, 0, recvBytes, chars, 0);
                messageData.Append(chars);

                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
            } 
            while (recvBytes != 0);

            return messageData.ToString();
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

            return false;
        }
    }
}
