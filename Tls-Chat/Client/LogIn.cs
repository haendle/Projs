using NATUPNPLib;
using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;

namespace Client
{
    public partial class LogIn : Form
    {
        private IPAddress IpAddr;

        private int RemotePort;
        private int InternalPort;
        private int ExternalPort;

        private string ServerName;
        private string AuthenticationMode;

        private AuthenticationStream AuthenticationStream;

        public bool SwitchWnd { get; private set; }

        public string Username { get; private set; }

        public LogIn()
        {
            InitializeComponent();
        }

        private void ProcessExit()
        {
            try
            {
                UPnPNAT uPnPNAT = new UPnPNAT();

                IStaticPortMappingCollection PortMapping
                = uPnPNAT.StaticPortMappingCollection;

                PortMapping.Remove(ExternalPort, "TCP");
            }
            catch
            {
                Application.Exit();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            try
            {
                authModeIn.Checked = true;

                IpAddr = IPAddress.Parse(ConfigurationManager.ConnectionStrings["IpAddress"].ToString());
                RemotePort = Convert.ToInt32(ConfigurationManager.ConnectionStrings["Port[0]"].ToString());
                ServerName = ConfigurationManager.ConnectionStrings["ServerName"].ToString();
                InternalPort = Convert.ToInt32(ConfigurationManager.AppSettings["InternalPort[0]"]);
                ExternalPort = Convert.ToInt32(ConfigurationManager.AppSettings["ExternalPort[0]"]);

                Thread.Sleep(1000);
                
                unameText.Text = "admin";
                pwordText.Text = "admin";

                AuthenticationStream = new AuthenticationStream(IpAddr,
                RemotePort, InternalPort, ExternalPort);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.Message, "Neophron-App",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessExit();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string serverResponse;

            string username = unameText.Text;
            string pword = pwordText.Text;

            try
            {
                AuthenticationStream.Connect(ServerName);

                AuthenticationStream.Send(username,
                pword, AuthenticationMode);

                serverResponse = AuthenticationStream.Recv();

                if (serverResponse == "/SIGN_IN_SUCCESS" ||
                    serverResponse == "/SIGN_UP_SUCCESS")
                {
                    MessageBox.Show("Authentication completed", "Neophron-App",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.SwitchWnd = true;
                    this.Username = username;
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Authentication failed: " + serverResponse, "Neophron-App",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.Message, "Neophron-App",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void unameText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(unameText.Text))
            {
                errorProvider.SetError(unameText, "Username is required");
                submitBtn.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void unameText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(unameText.Text))
            {
                submitBtn.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(unameText.Text)
                && !string.IsNullOrWhiteSpace(pwordText.Text))
            {
                submitBtn.Enabled = true;
            }
        }

        private void pwordText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwordText.Text))
            {
                errorProvider.SetError(pwordText, "Password is required");
                submitBtn.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void pwordText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwordText.Text))
            {
                submitBtn.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(unameText.Text)
                && !string.IsNullOrWhiteSpace(pwordText.Text))
            {
                submitBtn.Enabled = true;
            }
        }

        private void authModeIn_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationMode = "/SIGN_IN";

            if (!string.IsNullOrWhiteSpace(pwordText.Text)
                && !string.IsNullOrWhiteSpace(unameText.Text)
                && authModeIn.Checked)
            {
                submitBtn.Enabled = true;
                authModeUp.Checked = false;
            }

            else
            {
                submitBtn.Enabled = false;
            }
        }

        private void authModeUp_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationMode = "/SIGN_UP";

            if (!string.IsNullOrWhiteSpace(pwordText.Text)
                && !string.IsNullOrWhiteSpace(unameText.Text)
                && authModeUp.Checked)
            {
                submitBtn.Enabled = true;
                authModeIn.Checked = false;
            }

            else
            {
                submitBtn.Enabled = false;
            }
        }
    }
}