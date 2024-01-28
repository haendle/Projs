using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NATUPNPLib;
using System.Net.Http;

namespace Server
{
    internal class AuthenticationStream
    {
        private TcpListener TcpListener;
        private TcpClient TcpClient;
        private SslStream SslStream;

        private static X509Certificate
        serverX509Certificate;

        private IStaticPortMappingCollection PortMapping;

        private List<string> UserData;

        private string Username;

        public AuthenticationStream(string certificatePath, int internalPort, int externalPort)
        {
            IPEndPoint IPEndPoint = new IPEndPoint(IPAddress.Any, internalPort);
            UPnPNAT uPnPNAT = new UPnPNAT();

            TcpListener = new TcpListener(IPEndPoint);
            TcpListener.AllowNatTraversal(true);

            serverX509Certificate = new X509Certificate(certificatePath);

            IPAddress[] ipAddrs = Dns.GetHostAddresses(Dns.GetHostName());

            for (int i = 0; i < ipAddrs.Length; i++)
            {
                string ipAddress = ipAddrs[i].ToString();

                Console.WriteLine($"IP : {ipAddress}");

                if (ipAddress.Contains("192.168.0.")
                    || ipAddress.Contains("192.168.1."))
                {
                    PortMapping = uPnPNAT.StaticPortMappingCollection;
                    PortMapping.Add(externalPort, "TCP", internalPort, ipAddress, true, "Neophron-Server");

                    // PortMapping.Remove(49081, "TCP");
                }
            }

            Console.WriteLine("---------------------------");

            UserData = new List<string>();
        }

        public List<string> Recv()
        {
            TcpListener.Start();

            UserData.Clear();

            while (true)
            {
                TcpClient = TcpListener.AcceptTcpClient();

                Socket socket = TcpClient.Client;
                Console.WriteLine($"tcpClient -- Remote Endpoint : {socket.RemoteEndPoint.ToString()}");
                Console.WriteLine($"tcpClient -- Local Endpoint : {socket.LocalEndPoint.ToString()}");

                SslStream = new SslStream(
                TcpClient.GetStream(), false);

                SslStream.AuthenticateAsServer(serverX509Certificate,
                clientCertificateRequired: false, checkCertificateRevocation: true);

                SslStream.ReadTimeout = 5000;
                SslStream.WriteTimeout = 5000;

                Username = Read(SslStream);
                Username = Username.Substring(0, Username.Length - 5);
                Console.WriteLine($"// Received: {Username}");
                UserData.Add(Username);
                Thread.Sleep(50);

                string pword = Read(SslStream);
                pword = pword.Substring(0, pword.Length - 5);
                Console.WriteLine($"// Received: {pword}");
                UserData.Add(pword);
                Thread.Sleep(50);

                string mode = Read(SslStream);
                mode = mode.Substring(0, mode.Length - 5);
                Console.WriteLine($"// Received: {mode}");
                UserData.Add(mode);
                Thread.Sleep(50);

                return UserData;
            }
        }

        public string Send(string response)
        {
            response += "<EOF>";

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            SslStream.Write(responseBytes);
            SslStream.Flush();
            Thread.Sleep(100);

            if (response == "/SIGN_UP_SUCCESS<EOF>" ||
                response == "/SIGN_IN_SUCCESS<EOF>")
            {
                return Username;
            }

            return null;
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
    }
}
