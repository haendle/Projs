using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AxRDPCOMAPILib;
using RDPCOMAPILib;

using MaterialSkin;
using MaterialSkin.Controls;

using Newtonsoft.Json;

using RdpClient.Data;
using RdpClient.Sockets;
using System.Security.Cryptography;
using System.Collections;
using LumiSoft.Net.IO;

namespace RdpClient.Forms
{
    public partial class ViewerDialog : MaterialForm
    {
        private string _сonnectionString;
        private string _password;
        private string _remoteHost;
        private string _accessLevel;
        private string _username;
        private string _remoteEndpoint;
        private string _endpointWAN;
        private string _endpointLAN;
        private string _path;
        private string _path2;

        private int _interPort;
        private int _exterPort;
        private int _clientPort;
        private int _counter;

        private bool _isLocal;
        private bool _enableStun;
        private bool _enableUpnp;
        private bool _blockIOStream;

        private IRDPSRAPIVirtualChannel _virtualChannel;

        private StunClient _stunClient;
        private UpnpClient _upnpClient;
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;

        private HostInfo _hostInfo;

        public ViewerDialog
        (
            string connectionString,
            string remoteHost,
            string accessLevel,
            string password,
            string username,
            bool isLocal
        )
        {
            InitializeComponent();
            InitMaterialSkin();
            InitAxRdpViewer();

            _remoteHost = remoteHost;
            _accessLevel = accessLevel;
            _сonnectionString = connectionString;
            _password = password;
            _username = username;
            _isLocal = isLocal;

            this.Text = "Unknown Host";
            _enableStun = true;
            _enableUpnp = true;
            _blockIOStream = false;
            _interPort = 0;
        }

        private void ViewerDialog_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_isLocal)
                {
                    Init();
                    PrepareClient();
                }

                else
                {
                    axRDPViewer.Connect(_сonnectionString, _remoteHost, _password);

                    _virtualChannel = axRDPViewer.VirtualChannelManager.CreateVirtualChannel
                    (
                        "TCP",
                        CHANNEL_PRIORITY.CHANNEL_PRIORITY_HI,
                        (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                    );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private async void PrepareClient()
        {
            try
            {
                _counter = 0;

                await Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        IPAddress[] addrs = Dns.GetHostAddresses(Dns.GetHostName());

                        var ipAddr = "0.0.0.0";

                        foreach (IPAddress addr in addrs)
                        {
                            if (!addr.ToString().Contains(":"))
                            {
                                ipAddr = addr.ToString();
                                _endpointLAN = addr.ToString();
                                break;
                            }
                        }

                        var connectionString = "<E><A/><C><T ID=\"1\" SID=\"0\">" +
                        "<L P=\"49157\" N=\"" + ipAddr + "\"/></T></C></E>\r\n";

                        axRDPViewer.Connect(connectionString, _remoteHost, _password);

                        Thread.Sleep(960);
                        _counter++;
                    }
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private async void Init()
        {
            try
            {
                var stream = File.Create("network.ini");
                stream.Close();

                _tcpListener = new TcpListener(IPAddress.Any, 49157);
                _tcpClient = new TcpClient();

                _tcpListener.Start();

                await Task.Run(() =>
                {
                    while (true)
                    {
                        _tcpClient = _tcpListener.AcceptTcpClient();

                        var endpoint = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
                        _clientPort = endpoint.Port;

                        var port = _clientPort.ToString() + "\n";
                        byte[] buff = Encoding.Default.GetBytes(port);

                        stream = File.Open("network.ini", FileMode.Append);
                        stream.Write(buff, 0, buff.Length);
                        stream.Close();

                        _tcpClient.Close();
                        axRDPViewer.Disconnect();

                        if (_counter == 9)
                        {
                            _tcpListener.Stop();
                            _tcpClient?.Close();
                            SearchPort();
                            break;
                        }
                    }
                });
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void SearchPort()
        {
            try
            {
                string[] lines = File.ReadAllLines("network.ini");

                var lastValue = Convert.ToInt32(lines[9]);
                var exValue = Convert.ToInt32(lines[8]);
                var step = lastValue - exValue;
                _interPort = _clientPort + step;
                _endpointLAN += ":" + _interPort.ToString();

                SendRequestToStunServer();

                axRDPViewer.Connect(_сonnectionString, _remoteHost, _password);

                _virtualChannel = axRDPViewer.VirtualChannelManager.CreateVirtualChannel
                (
                    "TCP",
                    CHANNEL_PRIORITY.CHANNEL_PRIORITY_HI,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void RDPViewer_OAttendeeConnected(object sender, AxRDPCOMAPILib._IRDPSessionEvents_OnAttendeeConnectedEvent e)
        {
            Thread.Sleep(1000);

            _enableStun = false;
        }

        private async void SendRequestToStunServer()
        {
            try
            {
                _stunClient = new StunClient();
                _upnpClient = new UpnpClient();

                await Task.Run(() =>
                {
                    while (_enableStun)
                    {
                        var endpoint = _stunClient.SendRequest();
                        _endpointWAN = endpoint.Substring(0, endpoint.IndexOf(':'));

                        if (_enableUpnp)
                        {
                            _exterPort = Convert.ToInt32(endpoint.Substring(endpoint.IndexOf(':') + 1));
                            _upnpClient.CreatePortMapping(_interPort, _exterPort);
                            _enableUpnp = false;
                        }

                        Thread.Sleep(200);
                    }
                });
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void AxRdpViewer_OnChannelDataReceived(object sender, _IRDPSessionEvents_OnChannelDataReceivedEvent e)
        {
            try
            {
                var json = e.bstrData.Trim();
                var data = JsonConvert.DeserializeObject<VirtualData>(json);

                if (data.Type == "NETINFO_EX")
                { ExchangeNetworkInfo(data); }

                if (data.Type == "ATTENDEES_LIST")
                { GetAttendeesList(data); }

                if (data.Type == "ATTENDEES_CHANGELVL")
                { ChangeAccessLevel(data); }

                if (data.Type == "ATTENDEES_DENIED")
                {
                    MessageBox.Show
                    (
                        data.Buffer,
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                if (data.Type == "ATTENDEES_ACCEPTED")
                {
                    MessageBox.Show
                    (
                        "Access level has been changed",
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Text = "Connected to " + _remoteHost + " [Interactive]";

                    GetCurrentAttendeeList();
                }

                if (data.Type == "ACCESSLVL_INFO")
                {
                    if (data.Buffer == "Interactive")
                    { this.Text = "Connected to " + _remoteHost + " [Interactive]"; }

                    else
                    { this.Text = "Connected to " + _remoteHost + " [Only View]"; }

                    GetCurrentAttendeeList();
                }

                if (data.Type == "ATTENDEES_CHANGELVL2")
                {
                    this.Text = "Connected to " + _remoteHost + " [Interactive]";
                    GetCurrentAttendeeList();
                }

                if (data.Type == "HOSTINFO_RES")
                { GetHostInfo(data); }

                if (data.Type == "REFRESH_INFO")
                { GetCurrentAttendeeList(); }

                if (data.Type == "RECVFILE_RES")
                { SendFile(); }

                if (data.Type == "SENDFILE_RES")
                { RecvFileBegin(data); }

                if (data.Type == "SENDFILE_STREAM")
                { RecvFile(data); }

                if (data.Type == "SENDFILE_END")
                { RecvFileEnd(); }

                if (data.Type == "BLOCKIOSTREAM")
                {  _blockIOStream = true; }

                if (data.Type == "UNLOCKIOSTREAM")
                { _blockIOStream = false; }
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void GetHostInfo(VirtualData data)
        {
            try
            {
                var delimiter = '#';

                string[] hostInfo = data.Buffer.Split(delimiter);

                _hostInfo = new HostInfo(hostInfo);
                _remoteEndpoint = _hostInfo.EndpointWAN;

                propertyGrid.SelectedObject = _hostInfo;
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void ChangeAccessLevel(VirtualData data)
        {
            try
            {
                var user = data.Buffer.Substring(data.Buffer.IndexOf('#') + 1);

                var result =
                MessageBox.Show
                (
                    $"Transfer access to the <{user}>?",
                    "Network Manager",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                var access = "0#" + _username + "#" + user;

                if (result == DialogResult.Yes)
                {
                    access = "1#" + _username + "#" + user;

                    this.Text = "Connected to " + _remoteHost + " [Only View]";
                }

                var request = new VirtualData("ATTENDEES_RES", access);
                var json = JsonConvert.SerializeObject(request);

                _virtualChannel.SendData
                (
                    json,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );

                GetCurrentAttendeeList();
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void GetAttendeesList(VirtualData data)
        {
            try
            {
                var users = data.Buffer;
                var delimiter = '#';

                string[] attendees = users.Split(delimiter);

                foreach (var attendee in attendees)
                {
                    var item = new MaterialListBoxItem();
                    item.Text = attendee;

                    ListBox_Attendees.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void ExchangeNetworkInfo(VirtualData data)
        {
            try
            {
                var delimiter = '#';

                string[] serverInfo = data.Buffer.Split(delimiter);

                _remoteEndpoint = serverInfo[0];
                _remoteHost = serverInfo[1];

                this.Text = "Connected to " + _remoteHost + " [" + _accessLevel + "]";

                if (!_isLocal)
                {
                    SendClientInfo();
                }

                var data2 = new VirtualData("HOSTINFO_REQ", "0");
                var json2 = JsonConvert.SerializeObject(data2);

                _virtualChannel.SendData
                (
                    json2,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void SendClientInfo()
        {
            try
            {
                var request = new SslRequest(_username, "0");

                var requestString =
                request.Username + "#" +
                request.Hostname + "#" +
                request.UserOS + "#" +
                request + "#" +
                request.SessionBegin + "#" +
                request.UserId;

                if (!_isLocal)
                {
                    requestString += "#" + _endpointWAN + ":" + _exterPort.ToString();
                    requestString += "#" + _endpointLAN;
                }

                var virtualData = new VirtualData("WAN_AUTH", requestString);
                var json = JsonConvert.SerializeObject(virtualData);

                _virtualChannel.SendData
                (
                    json,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void InitAxRdpViewer()
        {
            try
            {
                axRDPViewer.SmartSizing = true;
                axRDPViewer.DisconnectedText = "No Signal";

                axRDPViewer.OnChannelDataReceived += new AxRDPCOMAPILib.
                _IRDPSessionEvents_OnChannelDataReceivedEventHandler
                (AxRdpViewer_OnChannelDataReceived);

                axRDPViewer.OnConnectionTerminated += new AxRDPCOMAPILib.
                _IRDPSessionEvents_OnConnectionTerminatedEventHandler(RDPViewer_OnConnectionTerminated);

                axRDPViewer.OnConnectionFailed += new EventHandler
                (RDPViewer_OnConnectionFailed);

                axRDPViewer.OnAttendeeConnected += new AxRDPCOMAPILib._IRDPSessionEvents_OnAttendeeConnectedEventHandler
                (RDPViewer_OAttendeeConnected);
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void RDPViewer_OnConnectionTerminated
        (
            object sender,
            AxRDPCOMAPILib._IRDPSessionEvents_OnConnectionTerminatedEvent e
        )
        {
            if (!_enableStun)
            {
                MessageBox.Show
                (
                    "Connection temrinated",
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void RDPViewer_OnConnectionFailed(object sender, EventArgs e)
        {
            MessageBox.Show
            (
                "Connection failed: restart and try again",
                "Unhandled exception",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            Application.Exit();
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (TabControl.SelectedIndex != -1 && TabControl.SelectedIndex == 0)
                {
                    this.Sizable = true;
                    this.MaximizeBox = true;
                }

                if (TabControl.SelectedIndex != -1 && TabControl.SelectedIndex == 1)
                {
                    if (_blockIOStream)
                    {
                        MessageBox.Show
                        (
                            "IO-Stream is currently blocked",
                            "Network Manager",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    else
                    { SendFileBegin(); }

                    e.Cancel = true;
                }

                if (TabControl.SelectedIndex != -1 && TabControl.SelectedIndex == 2)
                {
                    if (_blockIOStream)
                    {
                        MessageBox.Show
                        (
                            "IO-Stream is currently blocked",
                            "Network Manager",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    else
                    { RequestRecvFile(); }

                    e.Cancel = true;
                }

                if (TabControl.SelectedIndex != -1 && TabControl.SelectedIndex == 3)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Sizable = false;
                    this.Size = new Size(800, 450);
                    this.MaximizeBox = false;

                    GetCurrentAttendeeList();
                }
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void ListBox_Attendees_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            try
            {
                if (ListBox_Attendees.SelectedIndex != -1)
                {
                    if (ListBox_Attendees.SelectedItem.Text.Contains("owner"))
                    {
                        if (ListBox_Attendees.SelectedItem.Text != _username + " (owner)")
                        {
                            var result =
                            MessageBox.Show
                            (
                                "Request access?",
                                "Unhandled exception",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (result == DialogResult.Yes)
                            {
                                var user = ListBox_Attendees.SelectedItem.Text
                                .Substring(0, ListBox_Attendees.SelectedItem.Text
                                .IndexOf(' '));

                                var request = new VirtualData("ATTENDEES_CHANGELVL", user + "#" + _username);
                                var json = JsonConvert.SerializeObject(request);

                                _virtualChannel.SendData
                                (
                                    json,
                                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                                );
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void InitMaterialSkin()
        {
            try
            {
                var materialSkinManager = MaterialSkinManager.Instance;

                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

                materialSkinManager.ColorScheme = new ColorScheme
                (
                    Primary.Grey800,
                    Primary.Grey900,
                    Primary.Grey900,
                    Accent.Blue700,
                    TextShade.WHITE
                );
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void ViewerDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _upnpClient?.DeletePortMapping(_interPort);
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Environment.Exit(0);
            }
        }

        private void GetCurrentAttendeeList()
        {
            try
            {
                ListBox_Attendees.Items.Clear();

                var data = new VirtualData("ATTENDEES_REQ", "0");
                var json = JsonConvert.SerializeObject(data);

                _virtualChannel.SendData
                (
                    json,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void SendFileBegin()
        {
            try
            {
                openFileDialog.FileName = "";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _path = openFileDialog.FileName;

                    MessageBox.Show
                    (
                        $"Wait for the file to be sent {Path.GetFileName(_path)}",
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    ); 

                    var data = new VirtualData
                    (
                        "SENDFILE_REQ",
                        Path.GetFileName(_path)
                    );

                    var json = JsonConvert.SerializeObject(data);

                    _virtualChannel.SendData
                    (
                        json,
                        (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                        (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                    );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private async void SendFile()
        {
            try
            {
                await Task.Run(() =>
                {
                    byte[] buffer = new byte[960];
                    int bytesRead;

                    using (var stream = File.OpenRead(_path))
                    {
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {                  
                            var bytes = Encoding.Default.GetString(buffer);
                            var data = new VirtualData("SENDFILE_STREAM", bytes);
                            var json = JsonConvert.SerializeObject(data);

                            _virtualChannel.SendData
                            (
                                json,
                                (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                            );
                        }

                        var response = new VirtualData("SENDFILE_END2", "0");
                        var obj = JsonConvert.SerializeObject(response);

                        _virtualChannel.SendData
                        (
                            obj,
                            (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                            (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                        );
                    }
                });
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void RequestRecvFile()
        {
            try
            {
                var data = new VirtualData("RECVFILE_REQ", "0");
                var json = JsonConvert.SerializeObject(data);

                _virtualChannel.SendData
                (
                    json,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex) 
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private void RecvFileBegin(VirtualData data)
        {
            try
            {
                saveFileDialog.FileName = data.Buffer;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var stream = File.Create(saveFileDialog.FileName);
                    stream.Close();

                    var response = new VirtualData("RECVFILE_RDY", "");
                    var json = JsonConvert.SerializeObject(response);

                    _virtualChannel.SendData
                    (
                        json,
                        (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                        (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                    );

                    _path2 = saveFileDialog.FileName;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }

        private async void RecvFile(VirtualData data)
        {
            try
            {
                Action action = new Action(() =>
                {
                    var stream = File.Open(_path2, FileMode.Append);
                    byte[] buff = Encoding.Default.GetBytes(data.Buffer);

                    stream.Write(buff, 0, buff.Length);
                    stream.Close();
                });

                await Task.Run(() =>
                {
                    if (InvokeRequired)
                    { Invoke(action); }

                    else
                    { action(); }
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }
        private void RecvFileEnd()
        {
            try
            {
                var data = new VirtualData("RECVFILE_SHOWMSG", "0");
                var json = JsonConvert.SerializeObject(data);

                _virtualChannel.SendData
                (
                    json,
                    (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );

                _blockIOStream = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }
    }
}
