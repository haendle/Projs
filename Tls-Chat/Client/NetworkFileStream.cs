using NATUPNPLib;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Client
{
    internal class NetworkFileStream
    {
        private TcpClient TcpClient;
        private IPEndPoint RemoteEndPoint;
        private SslStream SslStream;

        private int ExternalPort;

        private IStaticPortMappingCollection PortMapping;

        public NetworkFileStream(IPAddress IPAddress, int remotePort, int internalPort, int externalPort)
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

        public string Send(string path)
        {
            string cmd = "/START<EOF>";
            byte[] cmdBytes = Encoding.UTF8.GetBytes(cmd);
            SslStream.Write(cmdBytes, 0, cmdBytes.Length);
            SslStream.Flush();
            Thread.Sleep(100);

            SslStream.Write(cmdBytes, 0, cmdBytes.Length);
            SslStream.Flush();
            Thread.Sleep(500);

            string fileName = Path.GetFileName(path) + "<EOF>";
            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
            SslStream.Write(fileNameBytes, 0, fileNameBytes.Length);
            SslStream.Flush();
            Thread.Sleep(100);

            long fileSize = new FileInfo(path).Length;
            byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
            SslStream.Write(fileSizeBytes, 0, fileSizeBytes.Length);
            SslStream.Flush();
            Thread.Sleep(100);

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[65535];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    SslStream.Write(buffer, 0, bytesRead);
                    SslStream.Flush();
                    Thread.Sleep(100);
                }

                fileStream.Close();
            }

            return Path.GetFileName(path);
        }

        public string fileName;
        public string filePath;
        public string sender;
        public long recvBytes;

        public string Recv(string path)
        {
            byte[] buffer = new byte[2048];

            fileName = Read(SslStream);
            SslStream.Flush();
            
            sender = Read(SslStream);
            SslStream.Flush();

            SslStream.Read(buffer, 0, buffer.Length);
            recvBytes = BitConverter.ToInt64(buffer, 0);
            SslStream.Flush();

            fileName = fileName.Substring(0, fileName.Length - 5);
            filePath = path + fileName;

            sender = sender.Substring(0, sender.Length - 5);

            using (FileStream fileStream = File.Create(filePath))
            {
                byte[] buff = new byte[65535];
                int bytesRead = 0;
                int bytesCount = 0;

                while (bytesCount != recvBytes)
                {
                    bytesRead = SslStream.Read(buffer, 0, buffer.Length);

                    fileStream.Write(buffer, 0, bytesRead);
                    bytesCount += bytesRead;
                }

                fileStream.Close();
            }         

            string res = "Recv file: " + fileName 
            + " [sender: " + sender + "]";

            return res;
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
