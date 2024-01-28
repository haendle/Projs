using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using NATUPNPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Data.Common;

namespace Client
{
    public partial class Client : Form
    {
        private IPAddress IpAddr;

        private string ServerName;
        private string Username;
        private string DownloadsPath;

        private int InternalMessagePort;
        private int InternalFilePort;

        private int ExternalMessagePort;
        private int ExternalFilePort;

        private int RemoteMessagePort;
        private int RemoteFilePort;

        private MessageStream messageStream;
        private NetworkFileStream fileStream;

        private bool HideWND;
        private bool ShowWND;
        private bool NotifyWND;

        public Client(string username)
        {
            InitializeComponent();

            Username = username;
            this.Text = Username;
        }

        private void ProcessExit()
        {
            try
            {
                UPnPNAT uPnPNAT = new UPnPNAT();

                IStaticPortMappingCollection PortMapping
                = uPnPNAT.StaticPortMappingCollection;

                PortMapping.Remove(ExternalMessagePort, "TCP");
                PortMapping.Remove(ExternalFilePort, "TCP");
            }
            catch
            {
                Application.Exit();
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            try
            {
                IpAddr = IPAddress.Parse
               (ConfigurationManager.ConnectionStrings["IpAddress"]
               .ToString());

                InternalMessagePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["InternalPort[1]"]);

                InternalFilePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["InternalPort[2]"]);

                ExternalMessagePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["ExternalPort[1]"]);

                ExternalFilePort = Convert.ToInt32
                (ConfigurationManager.AppSettings["ExternalPort[2]"]);

                RemoteMessagePort = Convert.ToInt32
                (ConfigurationManager.ConnectionStrings["Port[1]"].ToString());

                RemoteFilePort = Convert.ToInt32
                (ConfigurationManager.ConnectionStrings["Port[2]"].ToString());

                ServerName = ConfigurationManager.ConnectionStrings["ServerName"].ToString();

                DownloadsPath = ConfigurationManager.AppSettings["Path"];

                messageStream = new MessageStream(IpAddr, RemoteMessagePort,
                InternalMessagePort, ExternalMessagePort);

                fileStream = new NetworkFileStream(IpAddr, RemoteFilePort,
                InternalFilePort, ExternalFilePort);
                
                messageStream.Connect(ServerName);
                fileStream.Connect(ServerName);

                messageBox.AppendText("Connected...\n");
   
                RecvMessage();
                RecvFile();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.Message, "Neophron-App",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HideWND)
            {
                e.Cancel = true;
                this.Show();
            }

            if (e.CloseReason == CloseReason.UserClosing && !HideWND)
            {
                DialogResult dialogResult = MessageBox.Show
                (
                    "Dispose?",
                    "Neophron-App",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                    HideWND = false;
                    ShowWND = true;

                    this.Show();
                }

                else
                {
                    HideWND = false;
                    ShowWND = false;

                    ProcessExit();
                }
            }

            if (e.CloseReason != CloseReason.UserClosing &&
                !HideWND && ShowWND)
            {
                e.Cancel = true;

                this.Show();
            }

            if (e.CloseReason == CloseReason.UserClosing
                && !HideWND && !ShowWND)
            {
                Environment.Exit(0);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string message = textBox.Text;
                messageStream.Send(message);

                DateTime dateTime = DateTime.Now;
                string prefix = "(You) [" + dateTime.ToString() + "] //   " + Username + ": ";

                messageBox.AppendText(prefix + message + "\n");
                textBox.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.Message, "Neophron-App",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private async void RecvFile()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    string fileMessage = fileStream.Recv(DownloadsPath);
                    Thread.Sleep(500);

                    if (fileMessage.Length > 0)
                    {
                        DateTime dateTime = DateTime.Now;
                        string prefix = "[" + dateTime.ToString() + "] //   ";

                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (NotifyWND)
                                {
                                    showNotification(fileMessage);
                                }

                                fileMessage += "\n";
                                messageBox.AppendText(prefix + fileMessage);
                            });
                        }

                        else
                        {
                            if (NotifyWND)
                            {
                                showNotification(fileMessage);
                            }

                            fileMessage += "\n";
                            messageBox.AppendText(prefix + fileMessage);
                        }

                        fileMessage.Remove(0);
                    }
                }
            });
        }

        private async void RecvMessage()
        {
            await Task.Run
            (() =>
            {
                while (true)
                {
                    string message = messageStream.Recv();

                    Thread.Sleep(100);
                    message = message.Substring(0, message.Length - 5);

                    if (message.Length > 0)
                    {
                        DateTime dateTime = DateTime.Now;
                        string prefix = "[" + dateTime.ToString() + "] //   ";

                        if (InvokeRequired)
                        {
                            Invoke
                            (() =>
                            {
                                if (NotifyWND)
                                {
                                    showNotification(message);
                                }

                                message += "\n";
                                messageBox.AppendText(prefix + message);
                            });
                        }
                        else
                        {
                            if (NotifyWND)
                            {
                                showNotification(message);
                            }

                            message += "\n";
                            messageBox.AppendText(prefix + message);
                        }
                    }

                    message.Remove(0);
                }
            });
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                sendBtn.Enabled = false;
            }

            else
            {
                sendBtn.Enabled = true;
            }
        }

        private void showNotification(string message)
        {
            Notification notification = new Notification();
            notification.showNotification(message);
        }

        private void Client_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                ShowInTaskbar = false;

                NotifyWND = true;
                HideWND = true;
                ShowWND = false;

                this.Hide();
            }

            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon.Visible = false;
                ShowInTaskbar = true;

                NotifyWND = false;
                HideWND = false;
                ShowWND = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideWND = false;
            ShowWND = false;

            this.Close();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void pinBtn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileStream.Send(openFileDialog.FileName);
                Thread.Sleep(500);

                DateTime dateTime = DateTime.Now;
                string prefix = "(You) [" + dateTime.ToString() + "] //   ";
                messageBox.AppendText(prefix + "Sent: " + fileName + "\n");
            }

            openFileDialog.Reset();
        }
    }
}
