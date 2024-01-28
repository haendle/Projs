using NATUPNPLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class NetworkFileStream
    {
        private TcpClient TcpClient;
        private TcpListener TcpListener;
        private SslStream SslStream;

        private static X509Certificate
        serverX509Certificate;

        private IStaticPortMappingCollection PortMapping;

        private List<TcpClient> TcpList;
        private List<SslStream> SslList;

        byte[] taskBuffer = new byte[2048];

        private Task<int> readingTask;

        public NetworkFileStream(string certificatePath, int internalPort, int externalPort)
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

                if (ipAddress.Contains("192.168.0.")
                    || ipAddress.Contains("192.168.1."))
                {
                    PortMapping = uPnPNAT.StaticPortMappingCollection;
                    PortMapping.Add(externalPort, "TCP", internalPort, ipAddress, true, "Neophron-Server");
                }
            }

            TcpList = new List<TcpClient>();
            SslList = new List<SslStream>();
        }

        public void Listen()
        {
            while (true)
            {
                TcpListener.Start();
                TcpClient = TcpListener.AcceptTcpClient();

                SslStream = new SslStream(
                TcpClient.GetStream(), false);

                SslStream.ReadTimeout = Timeout.Infinite;
                SslStream.WriteTimeout = Timeout.Infinite;

                SslStream.AuthenticateAsServer(serverX509Certificate,
                clientCertificateRequired: false, checkCertificateRevocation: true);

                TcpList.Add(TcpClient);
                SslList.Add(SslStream);
            }
        }

        public void Process(string path, List<string> userList)
        {
            string file;
            string str;
            Task<int> task;

            while (true)
            {
                for (int i = 0; i < TcpList.Count; i++)
                {
                    if (!TcpList[i].Connected)
                    {
                        TcpList[i].Close();
                        TcpList[i].Dispose();
                        TcpList.RemoveAt(i);

                        SslList[i].Close();
                        SslList[i].Dispose();
                        SslList.RemoveAt(i);

                        userList.RemoveAt(i);

                        continue;
                    }

                    task = RecvAsync(SslList[i]);
                    Thread.Sleep(200);

                    if (task.IsCompletedSuccessfully)
                    {
                        int bytes = task.Result;

                        if (bytes <= 0)
                        {
                            continue;
                        }

                        if (readingTask.IsCompleted)
                        {
                            str = ReadBytes(bytes);

                            Console.WriteLine($"STR : {str}");

                            if (str == "/START<EOF>")
                            {
                                file = Recv(SslList[i], path);

                                for (int j = 0; j < TcpList.Count; j++)
                                {
                                    if (j == i)
                                    {
                                        continue;
                                    }

                                    Send(SslList[j], file, userList[i]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private string ReadBytes(int bytes)
        {
            StringBuilder messageData = new StringBuilder();

            do
            {
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(taskBuffer, 0, bytes)];
                decoder.GetChars(taskBuffer, 0, bytes, chars, 0);
                messageData.Append(chars);

                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }

            } while (bytes != 0);

            return messageData.ToString();
        }

        private void Send(SslStream stream, string path, string sender) 
        {
            string fileName = Path.GetFileName(path) + "<EOF>";

            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
            stream.Write(fileNameBytes, 0, fileNameBytes.Length);
            stream.Flush();
            
            Console.WriteLine($"SEND fileName = {fileName}");

            byte[] senderBytes = Encoding.UTF8.GetBytes(sender + "<EOF>");
            stream.Write(senderBytes, 0, senderBytes.Length);
            stream.Flush();
            
            Console.WriteLine($"SEND sender = {sender}");

            long fileSize = new FileInfo(path).Length;
            byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
            stream.Write(fileSizeBytes, 0, fileSizeBytes.Length);
            stream.Flush();

            Console.WriteLine($"SEND fileSize = {fileSize.ToString()}");

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[65535];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                    stream.Flush();
                    Thread.Sleep(100);

                    Console.WriteLine($"bytesSend = {bytesRead.ToString()}");
                }

                fileStream.Close();
            }

            Console.WriteLine($"FILE SENT");
        }

        private async Task<int> RecvAsync(SslStream stream)
        {
            CancellationTokenSource cancellationToken
            = new CancellationTokenSource();

            int timer = 100;

            readingTask = stream.ReadAsync(taskBuffer, 0, taskBuffer.Length);

            readingTask.Wait(500);
            cancellationToken.CancelAfter(timer);        

            if (await Task.WhenAny(readingTask, Task.Delay
               (timer, cancellationToken.Token)) == readingTask)
            {
                return readingTask.Result;
            }

            else
            {
                cancellationToken.Cancel();
                return -1;
            }
        }

        private string Recv(SslStream stream, string path)
        {
            byte[] buffer = new byte[2048];

            string fileName = Read(stream);
            fileName = fileName.Substring(0, fileName.Length - 5);
            string filePath = path + fileName;

            stream.Read(buffer, 0, buffer.Length);
            long recvBytes = BitConverter.ToInt64(buffer, 0);

            Thread.Sleep(100);

            Console.WriteLine($"SIZE OF : {recvBytes.ToString()}");
            Console.WriteLine($"PATH : {filePath}");

            using (FileStream fileStream = File.Create(filePath))
            {
                byte[] buff = new byte[65535];
                int bytesRead = 0;
                int bytesCount = 0;

                while (bytesCount != recvBytes)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);

                    Console.WriteLine($"bytesRead = {bytesRead.ToString()}");
                    fileStream.Write(buffer, 0, bytesRead);

                    bytesCount += bytesRead;
                }

                fileStream.Close();
            }

            Console.WriteLine("File closed");

            return filePath;
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
