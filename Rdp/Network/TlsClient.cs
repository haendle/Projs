using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Neophron.Network
{
    public class TlsClient
    {
        private TcpClient tcpClient;
        private SslStream sslStream;

        private IPEndPoint remoteEndPoint;
        private string hostname;

        private string downloadsPath = Path.Combine
           (Environment.GetFolderPath
           (Environment.SpecialFolder.UserProfile),
            "Downloads\\");

        public TlsClient(string ipAddress, string remotePort, string host)
        {
            this.remoteEndPoint = 
                new IPEndPoint
                (IPAddress.Parse(ipAddress),
                Convert.ToInt32(remotePort));

            this.hostname = host;

            this.tcpClient = new TcpClient();
        }

        public TlsClient(TcpClient tcpClient, string host)
        {
            this.hostname = host;
            this.tcpClient = tcpClient;

            sslStream = new SslStream(
            tcpClient.GetStream(),
            false,
            new RemoteCertificateValidationCallback(ValidateServerCertificate),
            null
            );

            sslStream.AuthenticateAsClient(hostname);
        }

        public void Connect()
        {
            tcpClient.Connect(remoteEndPoint);

            sslStream = new SslStream(
            tcpClient.GetStream(),
            false,
            new RemoteCertificateValidationCallback(ValidateServerCertificate),
            null
            );

            sslStream.AuthenticateAsClient(hostname);
        }

        public string Send(string path)
        {
            string name = Path.GetFileName(path);
            long size = new FileInfo(path).Length;

            DataRequest request = new DataRequest(name, size, "SEND_DATA");

            string json = JsonConvert.SerializeObject(request);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            sslStream.Write(jsonBytes, 0, jsonBytes.Length);
            sslStream.Flush();
            Thread.Sleep(100);

            using (FileStream stream = File.OpenRead(path))
            {
                byte[] buffer = new byte[65535];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    sslStream.Write(buffer, 0, bytesRead);
                    sslStream.Flush();
                    Thread.Sleep(100);
                }

                stream.Close();
            }

            return name;
        }

        public string Recv()
        {
            DataRequest request = new DataRequest("null", 0, "RECV_DATA");

            string json = JsonConvert.SerializeObject(request);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            sslStream.Write(jsonBytes, 0, jsonBytes.Length);
            sslStream.Flush();
            Thread.Sleep(100);
            
            byte[] _jsonBytes = new byte[2048];
            sslStream.Read(_jsonBytes, 0, _jsonBytes.Length);
            string _json = Encoding.UTF8.GetString(_jsonBytes);
            DataRequest response = JsonConvert.DeserializeObject
                <DataRequest>(_json);

            using (FileStream stream = File.Create(downloadsPath + response.name))
            {
                byte[] buff = new byte[65535];
                int bytesRead = 0;
                int bytesCount = 0;

                while (bytesCount != response.size)
                {
                    bytesRead = sslStream.Read(buff, 0, buff.Length);
                    stream.Write(buff, 0, bytesRead);

                    bytesCount += bytesRead;
                }

                stream.Close();
            }

            return response.name;
        }

        public void SendAuthenticationRequest(string username, string email)
        {
            Socket currentHost = tcpClient.Client;

            IPAddress ipAddr = IPAddress.Parse
                (((IPEndPoint)currentHost.LocalEndPoint).Address.ToString());

            int port = ((IPEndPoint)currentHost.LocalEndPoint).Port;
            string address = ipAddr.ToString() + ":" + port.ToString();

            AuthenticationRequest request = 
                new AuthenticationRequest(username, email, address);

            string json = JsonConvert.SerializeObject(request);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            sslStream.Write(jsonBytes, 0, jsonBytes.Length);
            sslStream.Flush();
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
