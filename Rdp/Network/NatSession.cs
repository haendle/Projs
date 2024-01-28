using LumiSoft.Net.STUN.Client;
using NATUPNPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Neophron.Network
{
    public class NatSession
    {
        private TcpListener tcpListener;

        private TcpClient iTcpClient;
        private TcpClient jTcpClient;

        public TcpClient tcpClient { get; private set; }

        private Socket udpSocket;

        public int exterClientPort { get; private set; }
        private int interClientPort;

        public IPEndPoint publicEndPoint { get; private set; }
        public IPEndPoint privateEndPoint { get; private set; }

        private IStaticPortMappingCollection portMapping;
        private UPnPNAT uPnPNAT;

        private Thread iThread;
        private Thread jThread;

        private string info;

        public NatSession(string stunAddr, int stunPort)
        {
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
            STUN_Result request = STUN_Client.Query(stunAddr, stunPort, udpSocket);

            if (request.NetType != STUN_NetType.UdpBlocked)
            {
                publicEndPoint = request.PublicEndPoint;
                exterClientPort = publicEndPoint.Port;

                IPEndPoint interUdpIPEndPoint = (IPEndPoint)udpSocket.LocalEndPoint;
                interClientPort = interUdpIPEndPoint.Port;

                IPAddress[] interIPAddressList = Dns.GetHostAddresses(Dns.GetHostName());
                string interIPAddress = "0.0.0.0";

                for (int i = 0; i < interIPAddressList.Length; i++)
                {
                    interIPAddress = interIPAddressList[i].ToString();

                    if (interIPAddress.Contains("192.168.0.")
                    || interIPAddress.Contains("192.168.1."))
                    {
                        break;
                    }
                }

                privateEndPoint = new IPEndPoint(IPAddress.Parse(interIPAddress), interClientPort);

                uPnPNAT = new UPnPNAT();

                portMapping = uPnPNAT.StaticPortMappingCollection;

                portMapping.Add
                    (exterClientPort,
                    "TCP",
                    interClientPort,
                    interIPAddress,
                    true,
                    "Neophron-App");

                IPEndPoint listenerEndPoint = new IPEndPoint(IPAddress.Any, interClientPort);

                tcpListener = new TcpListener(listenerEndPoint);

                tcpListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, false);
                tcpListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                tcpListener.AllowNatTraversal(true);

                jTcpClient = new TcpClient(privateEndPoint);

                jTcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, false);
                jTcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            }
        }

        public string Process(string exterAddr, int exterPort)
        {
            info = "null";

            IPEndPoint exterServerIPEndPoint =
                new IPEndPoint
                (IPAddress.Parse(exterAddr),
                exterPort);

            tcpListener.Start();

            Task<TcpClient> iTask = tcpListener.AcceptTcpClientAsync();       

            Task jTask = jTcpClient.ConnectAsync(exterServerIPEndPoint);

            iThread = new Thread(() => 
            {
                Task<int> res = iTaskHandler(iTask);

                if (res.Result == 1)
                {
                    return;
                }

                else
                {
                    tcpListener.Stop();
                    return;
                }
            });

            jThread = new Thread(() => 
            {
                Task<int> res = jTaskHandler(jTask);

                if (res.Result == 1)
                {
                    return;
                }

                else
                {
                    jTcpClient.Close();
                    return;
                }
            });

            iThread.Start();
            jThread.Start();

            jThread.Join();
            iThread.Join();

            return info;
        }

        private async Task<int> iTaskHandler(Task<TcpClient> iTask)
        {
            CancellationTokenSource cancellationToken
                = new CancellationTokenSource();

            int timer = 3000;

            iTask.Wait(3000);
            cancellationToken.CancelAfter(timer);

            if (await Task.WhenAny(iTask, Task.Delay
            (timer, cancellationToken.Token)) == iTask)
            {
                tcpClient = iTask.Result;
                info = "iThread " + iTask.Status.ToString();
                return 1;
            }
            else
            {
                cancellationToken.Cancel();
                info = "iThread " + iTask.Status.ToString();
                return -1;
            }
        }

        private async Task<int> jTaskHandler(Task jTask)
        {
            CancellationTokenSource cancellationToken
                = new CancellationTokenSource();

            int timer = 3000;

            jTask.Wait(3000);
            cancellationToken.CancelAfter(timer);

            if (await Task.WhenAny(jTask, Task.Delay
            (timer, cancellationToken.Token)) == jTask)
            {
                tcpClient = jTcpClient;
                tcpClient.Client = jTcpClient.Client;

                info = "jThread " + jTask.Status.ToString();
                return 1;
            }
            else
            {
                cancellationToken.Cancel();
                info = "jThread " + jTask.Status.ToString();
                return -1;
            }
        }
    }

}
