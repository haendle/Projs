using NATUPNPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class MessageStream
    {
        private TcpClient TcpClient;
        private TcpListener TcpListener;
        private SslStream SslStream;

        private static X509Certificate
        serverX509Certificate;

        private IStaticPortMappingCollection PortMapping;

        private byte[] buffer;

        private List<TcpClient> TcpList;
        private List<SslStream> SslList;

        public MessageStream(string certificatePath, int internalPort, int externalPort)
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

                    // PortMapping.Remove(49081, "TCP");
                }
            }

            buffer = new byte[255];
            TcpList = new List<TcpClient>();    
            SslList = new List<SslStream>();
        }

        public void Process(List<string> userList)
        {
            string inMessage;
            int bytes;

            while (true)
            {
                for (int i = 0; i < TcpList.Count; i++)
                {
                    bytes = -2;

                    if (!TcpList[i].Connected)
                    {
                        TcpList[i].Close();
                        TcpList.RemoveAt(i);

                        SslList[i].Close();
                        SslList.RemoveAt(i);

                        userList.RemoveAt(i);               
                        continue;
                    }

                    else
                    {
                        Array.Clear(buffer);
                        
                        Task<int> task = RecvAsync(SslList[i]);
                        Thread.Sleep(200);

                        if (task.IsCompletedSuccessfully)
                        {
                            bytes = task.Result;

                            if (bytes <= 0)
                            {
                                continue;
                            }

                            inMessage = Read(bytes);

                            if (inMessage == "/START<EOF>" ||
                                inMessage == "/START")
                            {
                                inMessage.Remove(0);
                                Array.Clear(buffer);

                                continue;
                            }

                            if (inMessage.Length > 0)
                            {
                                Socket inSocket = TcpList[i].Client;

                                inMessage = inMessage.Substring(0, inMessage.Length - 5);
                                Console.WriteLine($"// Received Message from {inSocket.RemoteEndPoint}: {inMessage}");

                                string outMessage = userList[i] + ": " + inMessage + "<EOF>";
                                byte[] outMessageBytes = Encoding.UTF8.GetBytes(outMessage);

                                for (int j = 0; j < TcpList.Count; j++)
                                {
                                    if (j == i)
                                    {
                                        continue;
                                    }

                                    Socket outSocket = TcpList[j].Client;

                                    SslList[j].Write(outMessageBytes, 0, outMessageBytes.Length);
                                    SslList[j].Flush();

                                    Console.WriteLine($"// Sent Message to {outSocket.RemoteEndPoint}: {inMessage}");
                                }

                                Array.Clear(outMessageBytes);
                                outMessage.Remove(0);
                            }

                            inMessage.Remove(0);
                        }
                    }
                }
            }
        }

        public void Listen()
        {
            while(true)
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

        private string Read(int bytes)
        {
            StringBuilder messageData = new StringBuilder();

            do
            {
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);

                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }

            } while (bytes != 0);

            return messageData.ToString();
        }

        private async Task<int> RecvAsync(SslStream stream)
        {
            CancellationTokenSource cancellationToken 
            = new CancellationTokenSource();

            int timer = 100;

            Task<int> task = stream.ReadAsync(buffer, 0, buffer.Length);

            task.Wait(500);
            cancellationToken.CancelAfter(timer);

            if (await Task.WhenAny(task, Task.Delay
               (timer, cancellationToken.Token)) == task)
            {
                return task.Result;
            }
            else
            {
                cancellationToken.Cancel();
                return -1;
            }
        }
    }
}
