using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Text;

using MaterialSkin;
using MaterialSkin.Controls;

using RDPCOMAPILib;
using RdpServer.Sockets;
using RdpServer.NetworkData;

using Newtonsoft.Json;
using Mono.Nat;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace RdpServer
{
    public partial class ServerWnd : MaterialForm
    {
        private int _viewers;
        private int _frameInterval;
        private int _sslPort;
        private int _exterRdpPort;
        private int _interRdpPort;
        private int _autostart;
        private int _clipboard;
        private int _fips;
        private int _rdpViewerCounter;

        private string _emailManager;
        private string _emailPassword;
        private string _rdpPassword;
        private string _sslCerr;
        private string _path;
        private string _path2;
        private string _exterAddress;
        private string _interAddress;

        private RDPSession _session;
        private SslServer _server;
        private SmtpServer _smtpServer;
        private StunServer _stunServer;
        INatDevice _device;

        private IRDPSRAPIVirtualChannel _virtualChannel;
        private RDPSRAPIInvitation _invitation;
        private SslRequest _request;

        private List<SslRequest> _userList;
        private List<IRDPSRAPIAttendee> _attendeeList;

        private bool _isSslAttendee;

        public ServerWnd()
        {
            InitializeComponent();
            InitMaterialSkin();

            _isSslAttendee = false;
            _rdpViewerCounter = 0;
        }

        private void ServerWnd_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void DeviceFound(object sender, DeviceEventArgs e)
        {
            try
            {
                _device = e.Device;

                WriteLog($"UPNP: NAT-Device {_device.DeviceEndpoint} found");

                var mappings = _device.GetAllMappings();

                foreach (var mapping in mappings)
                {
                    if (mapping.PrivatePort == _interRdpPort)
                    {
                        WriteLog($"UPNP: Created portmapping {mapping.PublicPort} --> {_interRdpPort}");
                        WriteLog($"RDP-Session started");
                        WriteLog($"RDP-LAN: {_interAddress}:{_interRdpPort}");
                        WriteLog($"RDP-WAN: {_exterAddress}:{mapping.PublicPort}");
                        WriteLog($"SMTP: Invitation sent to smtp-server");
                        _exterRdpPort = mapping.PublicPort;
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void ClearDevice()
        {        
            try
            {
                var mappings = _device.GetAllMappings();

                foreach (var mapping in mappings)
                {
                    WriteLog($"UPNP: Deleted portmapping {mapping.PublicPort} --> {_interRdpPort}");
                    WriteLog($"RDP-Session closed");
                    _device.DeletePortMap(mapping);
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void StartServer()
        {
            try
            {
                if (!File.Exists("smtp.ini"))
                {
                    WriteLog($"Unhandled exception: <smtp.ini> not found");

                    MessageBox.Show
                    (
                        "<smtp.ini> not found",
                        "Unhandled exception",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Application.Exit();
                }

                if (!File.Exists("logs.dat"))
                {
                    MessageBox.Show
                    (
                        "<logs.dat> not found",
                        "Unhandled exception",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    WriteLog($"Unhandled exception: <logs.dat> not found");

                    Application.Exit();
                }

                DisableControls();

                _session = new RDPSession { colordepth = 32 };

                _session.OnAttendeeConnected += OnAttendeeConnected;
                _session.OnAttendeeDisconnected += OnAttendeeDisconnected;

                _session.OnChannelDataReceived += new
                _IRDPSessionEvents_OnChannelDataReceivedEventHandler
                (OnChannelDataReceived);

                var sessionProps = _session.Properties;

                if (_clipboard == 1)
                { sessionProps["EnableClipboardRedirect"] = true; }

                else
                { sessionProps["EnableClipboardRedirect"] = false; }

                if (_fips == 1)
                { sessionProps["EnforceStrongEncryption"] = true; }

                else
                { sessionProps["EnforceStrongEncryption"] = false; }

                sessionProps["PortId"] = _interRdpPort;
                sessionProps["PortProtocol"] = 2;
                sessionProps["FrameCaptureIntervalInMs"] = _frameInterval;
                sessionProps["EnabledTransports"] = 1;
                sessionProps["DefaultAttendeeControlLevel"] = CTRL_LEVEL.CTRL_LEVEL_INVALID;

                _server = new SslServer(_sslCerr, _sslPort);
                _userList = new List<SslRequest>();
                _attendeeList = new List<IRDPSRAPIAttendee>();

                _session.Open();

                _virtualChannel = _session.VirtualChannelManager.CreateVirtualChannel
                (
                    "TCP",
                    CHANNEL_PRIORITY.CHANNEL_PRIORITY_HI,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );

                _invitation = _session.Invitations.CreateInvitation
                (
                    null,
                    Environment.UserName,
                    _rdpPassword,
                    _viewers
                );

                NatUtility.DeviceFound += DeviceFound;
                NatUtility.StartDiscovery();

                _stunServer = new StunServer();
                var publicEndpoint = _stunServer.SendRequest();

                _exterAddress = publicEndpoint.Substring(0, publicEndpoint.IndexOf(':'));
                _interAddress = _stunServer.GetInternalAddr();

                var connectionString = CreateConnectionString(_exterAddress);

                _smtpServer = new SmtpServer(_emailManager, _emailPassword);
                _smtpServer.SendRequest(connectionString);

                AsyncListen();

                Button_Pause.Enabled = true;
                Button_Start.Enabled = false;

                Check();
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private async void Check()
        {
            await Task.Run(() => 
            {
                Thread.Sleep(5000);

                if (_device == null)
                {
                    WriteLog($"UPNP: NAT-Device not found");

                    var res = MessageBox.Show
                    (
                        "NAT-Device not found. Continue?",
                        "Unhandled exception",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (res == DialogResult.Yes) 
                    {
                        WriteLog($"RDP-Session started");
                        WriteLog($"RDP-LAN: {_interAddress}:{_interRdpPort}");
                        WriteLog($"RDP-WAN: Disabled");
                        WriteLog($"SMTP: Disabled");
                    }

                    else
                    {
                        Application.Exit();
                    }
                }
            });
        }

        private void OnAttendeeConnected(object pAttendee)
        {
            try
            {
                var attendee = (IRDPSRAPIAttendee)pAttendee;
                _attendeeList.Add(attendee);

                var info = (IRDPSRAPITcpConnectionInfo)attendee.ConnectivityInfo;

                if (_isSslAttendee)
                {
                    _request.EndpointLAN = info.PeerIP + ":" + info.PeerPort.ToString();
                    _request.EndpointWAN = "</>";
                    _request.SessionBegin = DateTime.Now.ToString();

                    WriteLog($"User {_request.Username} connected");
                    WriteLog($"LAN-Endpoint: {_request.EndpointLAN}");

                    if (_rdpViewerCounter == 1)
                    {
                        attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
                        _request.AccessLevel = "INTERACTIVE";
                        WriteLog($"User {_request.Username} --> INTERACTIVE");
                    }

                    else
                    {
                        attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
                        _request.AccessLevel = "VIEW";
                        WriteLog($"User {_request.Username} --> ONLY_VIEW");
                    }

                    _request.Password = "</>";

                    var item = new MaterialListBoxItem();
                    item.Text = _request.Username;

                    ListBox_Attendees.Items.Add(item);

                    _isSslAttendee = false;
                }

                else
                {
                    if (_rdpViewerCounter == 0)
                    { attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE; }

                    else
                    { attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW; }
                }

                SendInfoToAttendee(attendee, info);
                RefreshAttendeeInfo();

                _interAddress = info.LocalIP;

                //var msg = "CLIENT_ATTENDEE:" + info.PeerIP.ToString() + ":" + info.PeerPort.ToString() + "\n" +
                //    "Protocol: " + info.Protocol.ToString() + "\n";

                //MessageBox.Show(msg);
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void OnAttendeeDisconnected(object pDisconnectInfo)
        {
            try
            {
                propertyGrid.SelectedObject = null;

                var attendee = (IRDPSRAPIAttendeeDisconnectInfo)pDisconnectInfo;

                for (int i = 0; i < _attendeeList.Count; i++)
                {
                    if (_attendeeList[i] == attendee.Attendee)
                    {
                        if (i >= 0 && i < ListBox_Attendees.Items.Count)
                        {
                            WriteLog($"User {_userList[i].Username} disconnected");
                            ListBox_Attendees.Items.RemoveAt(i);
                            _userList.RemoveAt(i);
                            _attendeeList.RemoveAt(i);                  
                        }
                    }
                }

                if (ListBox_Attendees.Items.Count == 0 || _attendeeList.Count == 0)
                { _rdpViewerCounter = 0; }

                if (ListBox_Attendees.Items.Count == 1 || _attendeeList.Count == 1)
                {
                    for (int i = 0; i < _attendeeList.Count; i++)
                    {
                        _attendeeList[i].ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
                        _userList[i].AccessLevel = "CTRL_LEVEL_INTERACTIVE";

                        WriteLog($"User {_userList[i].Username} --> INTERACTIVE");

                        var data = new VirtualData("ATTENDEES_CHANGELVL2", "0");
                        var json = JsonConvert.SerializeObject(data);

                        _virtualChannel.SendData
                        (
                            json,
                            (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                            (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                        );
                    }
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void OnChannelDataReceived(object pChannel, int lAttendeeId, string bstrData)
        {
            try
            {
                var json = bstrData.Trim();
                var data = JsonConvert.DeserializeObject<VirtualData>(json);

                if (data.Type == "ATTENDEES_REQ")
                { SendAttendeeList(lAttendeeId); }

                if (data.Type == "ATTENDEES_CHANGELVL")
                { SendChangeLevelRequest(data); }

                if (data.Type == "ATTENDEES_RES")
                { ChangeAccessLevel(data); }

                if (data.Type == "WAN_AUTH")
                { AuthenticateWanAttendee(data, lAttendeeId); }

                if (data.Type == "HOSTINFO_REQ")
                { SendHostInfo(lAttendeeId); }

                if (data.Type == "SENDFILE_REQ")
                { RecvFileBegin(data, lAttendeeId); }

                if (data.Type == "SENDFILE_STREAM")
                { RecvFile(data); }

                if (data.Type == "SENDFILE_END2")
                {
                    var sender = "unknown";

                    for (int i = 0; i < _userList.Count; i++) 
                    { 
                        if (_attendeeList[i].Id == lAttendeeId)
                        {
                            sender = _userList[i].Username;
                        }
                    }

                    WriteLog($"Recv {Path.GetFileName(_path)} from {sender}");

                    MessageBox.Show
                    (
                        "Recv: " + Path.GetFileName(_path),
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    UnlockIONetworkStream();
                }

                if (data.Type == "RECVFILE_REQ")
                { SendFileBegin(lAttendeeId); }

                if (data.Type == "RECVFILE_RDY")
                { SendFile(lAttendeeId); }

                if (data.Type == "RECVFILE_SHOWMSG")
                {
                    var receiver = "unknown";

                    for (int i = 0; i < _userList.Count; i++)
                    {
                        if (_attendeeList[i].Id == lAttendeeId)
                        {
                            receiver = _userList[i].Username;
                        }
                    }

                    WriteLog($"Sent {Path.GetFileName(_path2)} to {receiver}");

                    MessageBox.Show
                    (
                        "Sent: " + Path.GetFileName(_path2),
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }

            catch (Exception ex) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private async void AsyncListen()
        {
            try
            {
                var access = "";
                var result = "";

                await Task.Run(() =>
                {
                    while (true)
                    {
                        _request = _server.RecvAuthenticationRequest();

                        if (_request == null) { continue; }

                        if (_rdpViewerCounter == 0) 
                        { access = "Interactive"; }

                        else 
                        { access = "Only View"; }

                        if (_request.Password == _rdpPassword)
                        { result = "accepted"; }

                        else
                        { result = "denied"; }

                        var response = new SslResponse
                        (
                            _invitation.ConnectionString,
                            Dns.GetHostName(),
                            access,
                            result
                        );

                        _server.SendAuthenticationResponse(response);

                        if (response.Result == "accepted")
                        {
                            _rdpViewerCounter++;
                            _isSslAttendee = true;
                            _userList.Add(_request);
                        }

                        else
                        {
                            WriteLog($"User {_request.Username} connection denied");
                        }
                    }
                });
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

                MessageBox.Show
                (
                    ex.Message,
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit(); ;
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void Button_Accept_Click(object sender, EventArgs e)
        {
            try
            {
                _viewers = (int)NumericUpDown_Viewers.Value;
                _frameInterval = (int)NumericUpDown_FrameInterval.Value;
                _sslPort = Convert.ToInt32(TextBox_SslPort.Text);
                _interRdpPort = Convert.ToInt32(TextBox_RdpPort.Text);

                if (CheckBox_ClipBoard.Checked)
                { _clipboard = 1; }

                else
                { _clipboard = 0; }

                if (CheckBox_Fips.Checked)
                { _fips = 1; }

                else
                { _fips = 0; }

                _emailManager = TextBox_EmailManager.Text;
                _emailPassword = TextBox_EmailPassword.Text;
                _rdpPassword = TextBox_SessionPassword.Text;
                _sslCerr = TextBox_Cerr.Text;

                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
                Button_Start.Enabled = true;
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Accept.Enabled = false;

                _sslPort = Convert.ToInt32(TextBox_SslPort.Text);
                _interRdpPort = Convert.ToInt32(TextBox_RdpPort.Text);
                _frameInterval = (int) NumericUpDown_FrameInterval.Value;
                _viewers = (int) NumericUpDown_Viewers.Value;

                if (CheckBox_Autostart.Checked)
                { _autostart = 1; }

                else
                { _autostart = 0; }

                if (CheckBox_ClipBoard.Checked)
                { _clipboard = 1; }

                else
                { _clipboard = 0; }

                if (CheckBox_Fips.Checked)
                { _fips = 1; }

                else
                { _fips = 0; }

                _emailManager = TextBox_EmailManager.Text;
                _emailPassword = TextBox_EmailPassword.Text;
                _rdpPassword = TextBox_SessionPassword.Text;
                _sslCerr = TextBox_Cerr.Text;

                var config = ConfigurationManager.OpenExeConfiguration
                (ConfigurationUserLevel.None);

                config.AppSettings.Settings["VIEWERS"].Value 
                = _viewers.ToString();

                config.AppSettings.Settings["FRAME_INTERVAL"].Value 
                = _frameInterval.ToString();

                config.AppSettings.Settings["SSL_PORT"].Value
                = _sslPort.ToString();

                config.AppSettings.Settings["RDP_PORT"].Value
                = _interRdpPort.ToString();

                config.AppSettings.Settings["AUTOSTART"].Value
                = _autostart.ToString();

                config.AppSettings.Settings["CLIPBOARD"].Value
                = _clipboard.ToString();

                config.AppSettings.Settings["FIPS"].Value
                = _fips.ToString();

                config.AppSettings.Settings["EMAIL_MANAGER"].Value = _emailManager;
                config.AppSettings.Settings["EMAIL_PASSWORD"].Value = _emailPassword;
                config.AppSettings.Settings["SESSION_PASSWORD"].Value = _rdpPassword;
                config.AppSettings.Settings["SSL_CERR"].Value = _sslCerr;

                config.Save();

                ConfigurationManager.RefreshSection("appSettings");

                WriteLog($"Config refreshed");

                MessageBox.Show
                (
                    "Changes accepted. Restart",
                    "Configuration Manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Application.Exit();
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void AuthenticateWanAttendee(VirtualData data, int id)
        {
            try
            {
                var accessLevel = "";
                var delimiter = '#';

                string[] strArray = data.Buffer.Split(delimiter);

                var sslRequest = new SslRequest();

                sslRequest.Username = strArray[0];
                sslRequest.Hostname = strArray[1];
                sslRequest.UserOS = strArray[2];
                sslRequest.EndpointLAN = strArray[3];
                sslRequest.SessionBegin = DateTime.Now.ToString();
                sslRequest.UserId = strArray[5];
                sslRequest.EndpointWAN = strArray[6];
                sslRequest.EndpointLAN = strArray[7];
                sslRequest.Password = "</>";

                WriteLog($"User {sslRequest.Username} connected");
                WriteLog($"WAN-Endpoint: {strArray[6]}");
                WriteLog($"LAN-Endpoint: {strArray[7]}");

                if (_rdpViewerCounter == 0)
                {
                    sslRequest.AccessLevel = "CTRL_LEVEL_INTERACTIVE";
                    accessLevel = "Interactive";
                    WriteLog($"User {sslRequest.Username} --> INTERACTIVE");
                }

                else
                {
                    sslRequest.AccessLevel = "CTRL_LEVEL_VIEW";
                    accessLevel = "Only view";
                    WriteLog($"User {sslRequest.Username} --> ONLY_VIEW");
                }

                var item = new MaterialListBoxItem();
                item.Text = sslRequest.Username;

                ListBox_Attendees.Items.Add(item);
                _userList.Add(sslRequest);

                _rdpViewerCounter++;

                var response = new VirtualData("ACCESSLVL_INFO", accessLevel);
                var json = JsonConvert.SerializeObject(response);

                _virtualChannel.SendData
                (
                    json,
                    id,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void SendHostInfo(int id)
        {
            try
            {
                var endpointWan = _exterAddress + ":"
            + _exterRdpPort.ToString();

                var endpointLan = _interAddress + ":"
                + _interRdpPort.ToString();

                var interval = _frameInterval.ToString();
                var clipboard = "";
                var fips = "";

                if (_clipboard == 1)
                { clipboard = "true"; }

                else
                { clipboard = "false"; }

                if (_fips == 1)
                { fips = "true"; }

                else
                { fips = "false"; }

                var info =
                Dns.GetHostName() + "#" +
                endpointWan + "#" +
                endpointLan + "#" +
                interval + "#" +
                clipboard + "#" +
                "TCP" + "#" +
                fips + "#" +
                "false";

                var response = new VirtualData("HOSTINFO_RES", info);
                var json = JsonConvert.SerializeObject(response);

                _virtualChannel.SendData
                (
                    json,
                    id,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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
                var delimiter = '#';

                string[] commands = data.Buffer.Split(delimiter);

                if (commands[0] == "1")
                {
                    for (int i = 0; i < _userList.Count; i++)
                    {
                        if (commands[1] == _userList[i].Username)
                        {
                            _attendeeList[i].ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
                            _userList[i].AccessLevel = "CTRL_LEVEL_VIEW";
                            WriteLog($"User {_userList[i].Username} --> ONLY_VIEW");
                        }

                        if (commands[2] == _userList[i].Username)
                        {
                            _attendeeList[i].ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
                            _userList[i].AccessLevel = "CTRL_LEVEL_INTERACTIVE";
                            WriteLog($"User {_userList[i].Username} --> INTERACTIVE");

                            var response = new VirtualData("ATTENDEES_ACCEPTED", "OK");
                            var json = JsonConvert.SerializeObject(response);

                            _virtualChannel.SendData
                            (
                                json,
                                _attendeeList[i].Id,
                                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                            );
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < _userList.Count; i++)
                    {
                        if (commands[2] == _userList[i].Username)
                        {
                            var response = new VirtualData
                            (
                                "ATTENDEES_DENIED",
                                "User " + "<" + commands[1] + ">" + " rejected the request"
                            );

                            var json = JsonConvert.SerializeObject(response);

                            _virtualChannel.SendData
                            (
                                json,
                                _attendeeList[i].Id,
                                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                            );
                        }
                    }
                }
            }

            catch (Exception ex) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void SendChangeLevelRequest(VirtualData data)
        {
            try
            {
                var user = data.Buffer.Substring(0, data.Buffer.IndexOf("#"));

                for (int i = 0; i < _userList.Count; i++)
                {
                    if (user == _userList[i].Username)
                    {
                        var request = new VirtualData("ATTENDEES_CHANGELVL", data.Buffer);
                        var json = JsonConvert.SerializeObject(request);

                        _virtualChannel.SendData
                        (
                            json,
                            _attendeeList[i].Id,
                            (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                        );
                    }
                }
            }

            catch (Exception ex ) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void SendAttendeeList(int id)
        {
            try
            {
                var users = "";

                for (int i = 0; i < _attendeeList.Count; i++)
                {
                    users += _userList[i].Username;

                    if
                    (
                        _attendeeList[i].ControlLevel ==
                        CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE
                    )
                    { users += " (owner)"; }

                    users += "#";
                }

                var data = new VirtualData("ATTENDEES_LIST", users);
                var json = JsonConvert.SerializeObject(data);

                _virtualChannel.SendData
                (
                    json,
                    id,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void ReadConfig()
        {
            try
            {
                _viewers = Convert.ToInt32
                (ConfigurationManager.AppSettings["VIEWERS"].ToString());
                NumericUpDown_Viewers.Value = _viewers;

                _frameInterval = Convert.ToInt32
                (ConfigurationManager.AppSettings["FRAME_INTERVAL"].ToString());
                NumericUpDown_FrameInterval.Value = _frameInterval;

                _sslPort = Convert.ToInt32
                (ConfigurationManager.AppSettings["SSL_PORT"].ToString());
                TextBox_SslPort.Text = _sslPort.ToString();

                _interRdpPort = Convert.ToInt32
                (ConfigurationManager.AppSettings["RDP_PORT"].ToString());
                TextBox_RdpPort.Text = _interRdpPort.ToString();

                _autostart = Convert.ToInt32
                (ConfigurationManager.AppSettings["AUTOSTART"].ToString());

                if (_autostart == 1)
                { CheckBox_Autostart.Checked = true; }

                else
                { CheckBox_Autostart.Checked = false; }

                _clipboard = Convert.ToInt32
                (ConfigurationManager.AppSettings["CLIPBOARD"].ToString());

                if (_clipboard == 1)
                { CheckBox_ClipBoard.Checked = true; }

                else
                { CheckBox_ClipBoard.Checked = false; }

                _fips = Convert.ToInt32
                (ConfigurationManager.AppSettings["FIPS"].ToString());

                if (_fips == 1)
                { CheckBox_Fips.Checked = true; }

                else
                { CheckBox_Fips.Checked = false; }

                _emailManager =
                (ConfigurationManager.AppSettings["EMAIL_MANAGER"].ToString());
                TextBox_EmailManager.Text = _emailManager;

                _emailPassword =
                (ConfigurationManager.AppSettings["EMAIL_PASSWORD"].ToString());
                TextBox_EmailPassword.Text = _emailPassword;

                _rdpPassword =
                (ConfigurationManager.AppSettings["SESSION_PASSWORD"].ToString());
                TextBox_SessionPassword.Text = _rdpPassword;

                _sslCerr =
                (ConfigurationManager.AppSettings["SSL_CERR"].ToString());
                TextBox_Cerr.Text = _sslCerr;

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void LoadConfig()
        {
            try
            {
                if (File.Exists("RdpServer.exe.config"))
                {
                    _autostart = Convert.ToInt32(ConfigurationManager.AppSettings["AUTOSTART"].ToString());

                    if (_autostart == 1)
                    {
                        ReadConfig();
                        StartServer();
                    }

                    else
                    {
                        var result =
                        MessageBox.Show
                        (
                            "Do you accept config?",
                            "Configuration Manager",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            ReadConfig();

                            TextBox_SessionPassword.Clear();
                        }

                        else if 
                        (result == DialogResult.Cancel)
                        {  Application.Exit(); }
                    }
                }

                else
                {
                    MessageBox.Show
                    (
                        "Config not found",
                        "Configuration Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    Application.Exit();
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void TextBox_Cerr_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Cerr.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_SslPort_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_RdpPort_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_RdpPort.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_EmailManager_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_EmailManager.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_EmailPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_SessionPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text))
            {
                Button_Accept.Enabled = false;
                Button_Save.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Cerr.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailManager.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_RdpPort.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                Button_Accept.Enabled = true;
                Button_Save.Enabled = true;
            }
        }

        private void TextBox_Cerr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Cerr.Text))
            {
                errorProvider.SetError(TextBox_Cerr, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled= false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_SslPort_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_SslPort.Text))
            {
                errorProvider.SetError(TextBox_SslPort, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_RdpPort_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_RdpPort.Text))
            {
                errorProvider.SetError(TextBox_RdpPort, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_EmailManager_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_EmailManager.Text))
            {
                errorProvider.SetError(TextBox_EmailManager, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_EmailPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_EmailPassword.Text))
            {
                errorProvider.SetError(TextBox_EmailPassword, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_SessionPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_SessionPassword.Text))
            {
                errorProvider.SetError(TextBox_SessionPassword, "required");

                Button_Save.Enabled = false;
                Button_Accept.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_Cerr_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBox_Cerr.Text = openFileDialog.FileName;

                openFileDialog.FileName = "";
            }
        }

        private void ServerWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_device != null)
            {
                ClearDevice();

                NatUtility.StopDiscovery();
            }
        }

        private void ListBox_Attendees_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (ListBox_Attendees.SelectedIndex != -1)
            {
                propertyGrid.SelectedObject = 
                _userList[ListBox_Attendees.SelectedIndex];
            }
        }
        private void Button_Pause_Click(object sender, EventArgs e)
        {
            _session?.Pause();

            Button_Pause.Enabled = false;
            Button_Resume.Enabled = true;
        }

        private void Button_Resume_Click(object sender, EventArgs e)
        {
            _session?.Resume();

            Button_Pause.Enabled = true;
            Button_Resume.Enabled = false;
        }

        private void DisableControls()
        {
            TextBox_SessionPassword.Enabled = false;
            TextBox_EmailPassword.Enabled = false;
            TextBox_RdpPort.Enabled = false;
            TextBox_SslPort.Enabled = false;
            TextBox_EmailManager.Enabled = false;
            TextBox_Cerr.Enabled = false;
            CheckBox_Fips.Enabled = false;
            CheckBox_Autostart.Enabled = false;
            CheckBox_ClipBoard.Enabled = false;
            NumericUpDown_Viewers.Enabled = false;
            NumericUpDown_FrameInterval.Enabled = false;
        }

        private void RefreshAttendeeInfo()
        {
            try
            {
                var data = new VirtualData("REFRESH_INFO", "");

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
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void SendInfoToAttendee(IRDPSRAPIAttendee attendee, IRDPSRAPITcpConnectionInfo info)
        {
            try
            {
                var data = new VirtualData
                (
                    "NETINFO_EX",
                    info.LocalIP + ":" + info.LocalPort.ToString()
                    + "#" + Dns.GetHostName().ToString()
                );

                var json = JsonConvert.SerializeObject(data);

                _virtualChannel.SetAccess
                (
                    attendee.Id,
                    CHANNEL_ACCESS_ENUM.CHANNEL_ACCESS_ENUM_SENDRECEIVE
                );

                _virtualChannel.SendData
                (
                    json,
                    attendee.Id,
                    (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                );
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void RecvFileBegin(VirtualData data, int id)
        {
            try
            {
                saveFileDialog.FileName = data.Buffer;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LockIONetworkStream();

                    var stream = File.Create(saveFileDialog.FileName);
                    stream.Close();

                    var response = new VirtualData("RECVFILE_RES", "");
                    var json = JsonConvert.SerializeObject(response);

                    _virtualChannel.SendData
                    (
                        json,
                        id,
                        (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                    );

                    _path = saveFileDialog.FileName;
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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
                var action = new Action(() =>
                {
                    var stream = File.Open(_path, FileMode.Append); 

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
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void SendFileBegin(int id)
        {
            try
            {
                openFileDialog.FileName = "";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LockIONetworkStream();

                    _path2 = openFileDialog.FileName;

                    var data = new VirtualData
                    (
                        "SENDFILE_RES",
                        Path.GetFileName(_path2)
                    );

                    var json = JsonConvert.SerializeObject(data);

                    _virtualChannel.SendData
                    (
                        json,
                        id,
                        (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                    );
                }
            }

            catch (Exception ex)
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private async void SendFile(int id)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var stream = File.OpenRead(_path2))
                    {
                        byte[] buffer = new byte[960];
                        int bytesRead;

                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            var bytes = Encoding.Default.GetString(buffer);
                            var data = new VirtualData("SENDFILE_STREAM", bytes);
                            var json = JsonConvert.SerializeObject(data);

                            _virtualChannel.SendData
                            (
                                json,
                                id,
                                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                            );
                        }

                        stream.Close();

                        Thread.Sleep(200);

                        var response = new VirtualData("SENDFILE_END", "0");
                        var obj = JsonConvert.SerializeObject(response);

                        _virtualChannel.SendData
                        (
                            obj,
                            id,
                            (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
                        );
                    }
                });
            }

            catch (Exception ex) 
            {
                WriteLog($"Unhandled exception: {ex.Message}");

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

        private void WriteLog(string log)
        {
            try
            {
                if (MultiTextBox_Logs.TextLength >= 2147483640)
                { MultiTextBox_Logs.Clear(); }

                var line = "   [" + DateTime.Now.ToString() + "] > " + log + "\n";

                MultiTextBox_Logs.Text += line;
                MultiTextBox_Logs.Text += "\n";

                var stream = File.Open("logs.dat", FileMode.Append);
                byte[] buff = Encoding.Default.GetBytes(line);
                stream.Write(buff, 0, buff.Length);
                stream.Close();
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

        private void LockIONetworkStream()
        {
            var data = new VirtualData("BLOCKIOSTREAM", "0");
            var json = JsonConvert.SerializeObject(data);

            _virtualChannel.SendData
            (
                json,
                (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
            );
        }

        private void UnlockIONetworkStream()
        {
            var data = new VirtualData("UNLOCKIOSTREAM", "0");
            var json = JsonConvert.SerializeObject(data);

            _virtualChannel.SendData
            (
                json,
                (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE,
                (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY
            );
        }

        private string CreateConnectionString(string ip)
        {
            var subString = "N=";
            var index = _invitation.ConnectionString.LastIndexOf(subString);
            var prepareString = _invitation.ConnectionString.Remove(index);

            prepareString += $"N=\"{ip}\"/></T></C></E>";

            return prepareString;
        }
    }
}
