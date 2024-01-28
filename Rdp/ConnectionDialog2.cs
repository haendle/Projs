using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Neophron
{
    public partial class ConnectionDialog2 : Form
    {
        public string connectionString { get; private set; }
        public string sessionPassword { get; private set; }
        public int exterPort { get; private set; }

        public TlsClient tlsClient { get; private set; }

        private NatSession natSession;

        private string username;
        private string email;
        private string address;
        private string hostname;
        private string stunAddr;
        private int stunPort;

        private bool IsPrepared = false;

        public ConnectionDialog2()
        {
            InitializeComponent();
        }

        private void GetInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.username = UserEnterBox.Text;
                this.email = EmailEnterBox.Text;
                this.hostname = HostEnterBox.Text;

                this.stunAddr = StunAddrEnterBox.Text;
                this.stunPort = Convert.ToInt32(StunPortEnterBox.Text);

                natSession = new NatSession(stunAddr, stunPort);

                string exterAddr = natSession.publicEndPoint.ToString();
                string interAddr = natSession.privateEndPoint.ToString();
                exterPort = natSession.exterClientPort;

                NetworkInfoBox.AppendText(exterAddr + "\n");
                NetworkInfoBox.AppendText(interAddr + "\n");

                GetInfoButton.Enabled = false;
                IsPrepared = true;

                EndpointEnterBox.Enabled = true;
                HostEnterBox.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            address = EndpointEnterBox.Text;

            string ipAddress = address.Substring(0, address.IndexOf(':'));
            string port = address.Substring(address.IndexOf(':') + 1);

            int number;
            bool isNumber = int.TryParse(port, out number);

            if (isNumber)
            {
                string state = natSession.Process(ipAddress, Convert.ToInt32(port));

                MessageBox.Show(state.ToString());

                tlsClient = new TlsClient(natSession.tcpClient, hostname);
                tlsClient.SendAuthenticationRequest(username, email);

                GetButton.Enabled = false;
                PasteButton.Enabled = true;
            }

            else
            {
                MessageBox.Show("Invalid Address", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.connectionString = InvitationBox.Text;
            this.sessionPassword = SesPasswordEnterBox.Text;
            this.Close();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            InvitationBox.Text = Clipboard.GetText();

            if (InvitationBox.Text.Length > 0 && InvitationBox.Text.Contains("</E>"))
            {
                ConnectButton.Enabled = true;
                ClearButton.Enabled = true;
                PasteButton.Enabled = false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InvitationBox.Clear();

            ConnectButton.Enabled = false;
            ClearButton.Enabled = false;
            PasteButton.Enabled = true;
        }

        private void UserEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void EmailEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void EndpointEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EndpointEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void HostEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void SesPasswordEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void StunAddrEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void StunPortEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunPortEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(UserEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EndpointEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void UserEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserEnterBox.Text))
            {
                errorProvider.SetError(UserEnterBox, "Username is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void EmailEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEnterBox.Text))
            {
                errorProvider.SetError(EmailEnterBox, "Email is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void EndpointEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EndpointEnterBox.Text))
            {
                errorProvider.SetError(EndpointEnterBox, "Endpoint is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void HostEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                errorProvider.SetError(HostEnterBox, "Hostname is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void SesPasswordEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SesPasswordEnterBox.Text))
            {
                errorProvider.SetError(SesPasswordEnterBox, "Password is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void StunAddrEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunAddrEnterBox.Text))
            {
                errorProvider.SetError(StunAddrEnterBox, "Address is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void StunPortEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunPortEnterBox.Text))
            {
                errorProvider.SetError(StunPortEnterBox, "Port is required");
                GetButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(StunPortEnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(StunPortEnterBox, "Port is number");
                    GetButton.Enabled = false;
                }
            }
        }
    }
}
