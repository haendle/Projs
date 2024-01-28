using NATUPNPLib;
using System.Configuration;
using System.Net;

namespace Server
{
    internal class Program
    {
        private static int externalAuthPort;
        private static int externalMessagePort;
        private static int externalFilePort;

        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(Server_AppClosing);

                List<string> UserData = new List<string>();
                List<string> UserList = new List<string>();

                string certificatePath = ConfigurationManager.AppSettings["Certificate"];
                string downloadsPath = ConfigurationManager.AppSettings["Path"];

                string SqlConnectionString = ConfigurationManager.ConnectionStrings
                ["SqlConnectionString"].ToString();

                int internalAuthPort = Convert.ToInt32
                (ConfigurationManager.AppSettings["InternalPort[0]"]);

                int internalMessagePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["InternalPort[1]"]);

                int internalFilePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["InternalPort[2]"]);

                externalAuthPort = Convert.ToInt32
                (ConfigurationManager.AppSettings["ExternalPort[0]"]);

                externalMessagePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["ExternalPort[1]"]);

                externalFilePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["ExternalPort[2]"]);

                AuthenticationStream authenticationStream
                = new AuthenticationStream(certificatePath,
                internalAuthPort, externalAuthPort);

                SqlStream sqlStream = new SqlStream(SqlConnectionString);

                MessageStream messageStream = new MessageStream
                (certificatePath, internalMessagePort, externalMessagePort);

                NetworkFileStream fileStream = new NetworkFileStream
                (certificatePath, internalFilePort, externalFilePort);

                UserList.Add("null");

                Thread authenticationThread = new Thread
                (() => 
                { 
                    while (true) 
                    {
                        UserData = authenticationStream.Recv();

                        string serverResponse = 
                        sqlStream.Authenticate(UserData);

                        string user = authenticationStream.Send(serverResponse);

                        if (user != null) 
                        {
                            UserList.Add(user);
                        }

                        Thread.Sleep(200); 
                    }
                });

                Thread listenerMessageThread = new Thread
                (() => 
                {
                    messageStream.Listen();
                    Thread.Sleep(200);
                });

                Thread listenerFileThread = new Thread
                (() =>
                {
                    fileStream.Listen();
                    Thread.Sleep(200);
                });

                Thread messageThread = new Thread
                (() =>
                {
                    messageStream.Process(UserList);
                    Thread.Sleep(200);
                });

                Thread fileThread = new Thread
                (() =>
                {
                    fileStream.Process(downloadsPath, UserList);
                    Thread.Sleep(200);
                });

                authenticationThread.Start();
                listenerMessageThread.Start();
                listenerFileThread.Start();
                messageThread.Start();
                fileThread.Start();

                authenticationThread.Join();
                listenerMessageThread.Join();
                listenerFileThread.Join();
                messageThread.Join();
                fileThread.Join();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        static void Server_AppClosing(object sender, EventArgs e)
        {
            UPnPNAT uPnPNAT = new UPnPNAT();

            IStaticPortMappingCollection PortMapping
            = uPnPNAT.StaticPortMappingCollection;

            PortMapping.Remove(externalAuthPort, "TCP");
            PortMapping.Remove(externalMessagePort, "TCP");
            PortMapping.Remove(externalFilePort, "TCP");
        }
    }
}