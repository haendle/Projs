using Neophron.Network;
using RDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Net.Sockets;
using NATUPNPLib;

namespace Neophron
{
    public partial class ServerDialog : Form
    {
        private RDPSession rdpSession;

        private TlsServer tlsServer;
        private MailMessage mailMessage;
        private SmtpClient smtpClient;

        private List<AuthenticationRequest> users;
        private AuthenticationRequest user;

        private string controlMode;
        private int exterPort = -1;

        public ServerDialog()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            try
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(ExitHandler);
                rdpSession = new RDPSession { colordepth = 8 };
                rdpSession.add_OnAttendeeConnected(OnAttendeeConnected);
                rdpSession.add_OnAttendeeDisconnected(OnAttendeeDisconnected);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitHandler(object sender, EventArgs e)
        {
            UPnPNAT uPnPNAT = new UPnPNAT();

            IStaticPortMappingCollection PortMapping
            = uPnPNAT.StaticPortMappingCollection;

            PortMapping.Remove(exterPort, "TCP");
        }

        private void OnAttendeeDisconnected(object pAttendee)
        {
            for (int i = 0; i < tlsServer.tcpClients.Count; i++)
            {
                try
                {
                    NetworkStream stream = tlsServer.tcpClients[i].GetStream();
                    stream.WriteByte(0);
                }

                catch (Exception ex)
                {
                    userList.Items.RemoveAt(i);
                    userList.Refresh();
                }
            }
        }

        private void OnAttendeeConnected(object pAttendee)
        {
            IRDPSRAPIAttendee attendee = (IRDPSRAPIAttendee)pAttendee;

            if (controlMode == "INTERACTIVE")
            {
                attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
                user.AccessLevel = "INTERACTIVE";
                userList.Items.Add(user.Username);
            }

            if (controlMode == "VIEW")
            {
                attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
                user.AccessLevel = "VIEW";
                userList.Items.Add(user.Username);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListeningDialog listeningDialog = new ListeningDialog();
                listeningDialog.ShowDialog();

                if (!string.IsNullOrEmpty(listeningDialog.sessionPassword)
                    && !string.IsNullOrEmpty(listeningDialog.controlLevel)
                    && !string.IsNullOrEmpty(listeningDialog.viewers)
                    && !string.IsNullOrEmpty(listeningDialog.interPort)
                    && !string.IsNullOrEmpty(listeningDialog.cerr)
                    && !string.IsNullOrEmpty(listeningDialog.smtpServer)
                    && !string.IsNullOrEmpty(listeningDialog.smtpPort)
                    && !string.IsNullOrEmpty(listeningDialog.emailManager)
                    && !string.IsNullOrEmpty(listeningDialog.exterEmailPassword))
                {
                    controlMode = listeningDialog.controlLevel;

                    users = new List<AuthenticationRequest>();

                    tlsServer = new TlsServer
                        (listeningDialog.interPort, listeningDialog.cerr);

                    rdpSession.Open();

                    RDPSRAPIInvitation invitation =
                        rdpSession.
                        Invitations.
                        CreateInvitation
                        (null,
                        Environment.UserName,
                        listeningDialog.sessionPassword,
                        Convert.ToInt32(listeningDialog.viewers));

                    smtpClient = new SmtpClient
                        (listeningDialog.smtpServer,
                        Convert.ToInt32(listeningDialog.smtpPort));

                    mailMessage = new MailMessage();
                    mailMessage.Body = invitation.ConnectionString;

                    smtpClient.Credentials = new NetworkCredential
                        (listeningDialog.emailManager,
                        listeningDialog.exterEmailPassword);

                    smtpClient.EnableSsl = true;

                    mailMessage.From = new MailAddress(listeningDialog.emailManager);
                    mailMessage.Subject = "Invitation to RDP-Session";

                    listeningDialog.Dispose();
                    Process();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ListeningDialog2 listeningDialog = new ListeningDialog2();
                listeningDialog.ShowDialog();

                exterPort = listeningDialog.exterPort;

                if (!string.IsNullOrEmpty(listeningDialog.sessionPassword)
                    && !string.IsNullOrEmpty(listeningDialog.controlLevel)
                    && !string.IsNullOrEmpty(listeningDialog.viewers)
                    && !string.IsNullOrEmpty(listeningDialog.cerr)
                    && !string.IsNullOrEmpty(listeningDialog.smtpServer)
                    && !string.IsNullOrEmpty(listeningDialog.smtpPort)
                    && !string.IsNullOrEmpty(listeningDialog.emailManager)
                    && !string.IsNullOrEmpty(listeningDialog.exterEmailPassword))
                {
                    controlMode = listeningDialog.controlLevel;
                    
                    users = new List<AuthenticationRequest>();

                    tlsServer = listeningDialog.tlsServer;

                    rdpSession.Open();

                    RDPSRAPIInvitation invitation =
                        rdpSession.
                        Invitations.
                        CreateInvitation
                        (null,
                        Environment.UserName,
                        listeningDialog.sessionPassword,
                        Convert.ToInt32(listeningDialog.viewers));

                    smtpClient = new SmtpClient
                        (listeningDialog.smtpServer,
                        Convert.ToInt32(listeningDialog.smtpPort));

                    mailMessage = new MailMessage();
                    mailMessage.Body = invitation.ConnectionString;

                    smtpClient.Credentials = new NetworkCredential
                        (listeningDialog.emailManager,
                        listeningDialog.exterEmailPassword);

                    smtpClient.EnableSsl = true;

                    mailMessage.From = new MailAddress(listeningDialog.emailManager);
                    mailMessage.Subject = "Invitation to RDP-Session";

                    listeningDialog.Dispose();
                    NatProcess();
                }              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FileHandler()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    string res = tlsServer.Recv();

                    if (res == "RECV_DATA")
                    {
                        string file = null;

                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (openFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    file = openFileDialog.FileName;
                                }
                            });
                        }

                        else
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                file = openFileDialog.FileName;
                            }
                        }

                        if (file != null)
                        {
                            string _res = tlsServer.Send(file);

                            if (InvokeRequired)
                            {
                                Invoke
                                (() =>
                                {
                                    MessageBox.Show($"Sent: {_res}");
                                });
                            }

                            else
                            {
                                MessageBox.Show($"Sent: {_res}");
                            }
                        }

                    }

                    else
                    {
                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (res != null)
                                {
                                    MessageBox.Show($"Recv: {res}");
                                }
                            });
                        }

                        else
                        {
                            if (res != null)
                            {
                                MessageBox.Show($"Recv: {res}");
                            }
                        }
                    }
                }
            });
        }

        private async void Process()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    user = tlsServer.Listen();
                    users.Add(user);

                    if (InvokeRequired)
                    {
                        Invoke
                        (() =>
                        {
                            mailMessage.To.Add(user.Email);
                            smtpClient.Send(mailMessage);
                        });
                    }

                    else
                    {
                        mailMessage.To.Add(user.Email);
                        smtpClient.Send(mailMessage);
                    }

                    FileHandler();
                }
            });
        }

        private async void NatProcess()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    user = tlsServer.NatListen();
                    users.Add(user);

                    if (InvokeRequired)
                    {
                        Invoke
                        (() =>
                        {
                            mailMessage.To.Add(user.Email);
                            smtpClient.Send(mailMessage);
                        });
                    }

                    else
                    {
                        mailMessage.To.Add(user.Email);
                        smtpClient.Send(mailMessage);
                    }

                    NatFileHandler();
                }
            });
        }

        private async void NatFileHandler()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    string res = tlsServer.Recv();

                    if (res == "RECV_DATA")
                    {
                        string file = null;

                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (openFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    file = openFileDialog.FileName;
                                }
                            });
                        }

                        else
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                file = openFileDialog.FileName;
                            }
                        }

                        if (file != null)
                        {
                            string _res = tlsServer.Send(file);

                            if (InvokeRequired)
                            {
                                Invoke
                                (() =>
                                {
                                    MessageBox.Show($"Sent: {_res}");
                                });
                            }

                            else
                            {
                                MessageBox.Show($"Sent: {_res}");
                            }
                        }

                    }

                    else
                    {
                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (res != null)
                                {
                                    MessageBox.Show($"Recv: {res}");
                                }
                            });
                        }

                        else
                        {
                            if (res != null)
                            {
                                MessageBox.Show($"Recv: {res}");
                            }
                        }
                    }
                }
            });
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userList.SelectedIndex != -1)
            {
                ItemDialog itemDialog = new ItemDialog(users[userList.SelectedIndex]);
                itemDialog.ShowDialog();
            }
        }
    }
}
