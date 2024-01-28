using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.IO;

namespace Neophron.Network
{
    public class TlsServer
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;

        private SslStream sslStream;

        private static X509Certificate serverX509Certificate;

        private string downloadsPath = Path.Combine
            (Environment.GetFolderPath
            (Environment.SpecialFolder.UserProfile),
            "Downloads\\");

        public List<TcpClient> tcpClients {  get; private set; }
        public List<SslStream> sslStreams { get; private set; }

        public TlsServer(string port, string certificatePath)
        {
            IPEndPoint endpoint = 
                new IPEndPoint
                (IPAddress.Any, Convert.ToInt32(port));

            serverX509Certificate = new X509Certificate(certificatePath);

            tcpListener = new TcpListener (endpoint);

            tcpClients = new List<TcpClient> ();
            sslStreams = new List<SslStream> ();
        }

        public TlsServer(TcpClient tcpClient, string certificatePath)
        {
            tcpClients = new List<TcpClient>();

            this.tcpClient = tcpClient;
            serverX509Certificate = new X509Certificate(certificatePath);

            sslStream = new SslStream(
            tcpClient.GetStream(), false);

            sslStream.AuthenticateAsServer(serverX509Certificate,
            clientCertificateRequired: false, checkCertificateRevocation: true);

            tcpClients.Add(tcpClient);
        }

        public AuthenticationRequest NatListen()
        {
            byte[] jsonBytes = new byte[2048];

            sslStream.Read(jsonBytes, 0, jsonBytes.Length);

            string json = Encoding.UTF8.GetString(jsonBytes);

            AuthenticationRequest userData
                = JsonConvert.DeserializeObject
                <AuthenticationRequest>(json);

            return userData;
        }

        public string Recv()
        {
            byte[] jsonBytes = new byte[2048];

            sslStream.Read(jsonBytes, 0, jsonBytes.Length);

            string json = Encoding.UTF8.GetString(jsonBytes);

            DataRequest data = JsonConvert.DeserializeObject
                <DataRequest>(json);

            if (data.mode == "SEND_DATA")
            {
                using (FileStream stream = File.Create(downloadsPath + data.name))
                {
                    byte[] buff = new byte[65535];
                    int bytesRead = 0;
                    int bytesCount = 0;

                    while (bytesCount != data.size)
                    {
                        bytesRead = sslStream.Read(buff, 0, buff.Length);
                        stream.Write(buff, 0, bytesRead);

                        bytesCount += bytesRead;
                    }

                    stream.Close();
                }
            }

            if (data.mode == "RECV_DATA")
            {
                return data.mode;
            }

            return data.name;
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

        public AuthenticationRequest Listen()
        {
            tcpListener.Start();
            tcpClient = tcpListener.AcceptTcpClient();

            tcpClients.Add(tcpClient);

            sslStream = new SslStream(
            tcpClient.GetStream(), false);

            sslStream.AuthenticateAsServer(serverX509Certificate,
            clientCertificateRequired: false, checkCertificateRevocation: true);

            byte[] jsonBytes = new byte[2048];

            sslStream.Read(jsonBytes, 0, jsonBytes.Length);

            string json = Encoding.UTF8.GetString(jsonBytes);

            AuthenticationRequest userData 
                = JsonConvert.DeserializeObject
                <AuthenticationRequest>(json);

            return userData;
        }
    }
}
