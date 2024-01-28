using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Neophron
{
    public partial class ConnectionDialog : Form
    {
        public string connectionString { get; private set; }
        public string sessionPassword { get; private set; }
        public TlsClient tlsClient { get; private set; }

        private string username;
        private string email;
        private string address;
        private string hostname;

        public ConnectionDialog()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            username = userEnterBox.Text;
            email = emailEnterBox.Text;
            address = AddressEnterBox.Text;
            hostname = HostEnterBox.Text;

            string ipAddress = address.Substring(0, address.IndexOf(':'));
            string port = address.Substring(address.IndexOf(':') + 1);

            int number;
            bool isNumber = int.TryParse(port, out number);

            if (isNumber)
            {
                tlsClient = new TlsClient(ipAddress, port, hostname);

                tlsClient.Connect();
                tlsClient.SendAuthenticationRequest(username, email);

                GetButton.Enabled = false;
                PasteButton.Enabled = true;
            }

            else
            {
                MessageBox.Show("Invalid Address", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.connectionString = InvitationBox.Text;
            this.sessionPassword = PassEnterBox.Text;
            this.Close();
        }

        private void userEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(userEnterBox.Text)
                && !string.IsNullOrWhiteSpace(emailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(AddressEnterBox.Text)
                && !string.IsNullOrWhiteSpace(PassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = true;
            }
        }

        private void emailEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(userEnterBox.Text)
                && !string.IsNullOrWhiteSpace(emailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(AddressEnterBox.Text)
                && !string.IsNullOrWhiteSpace(PassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = true;
            }
        }

        private void AddressEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(userEnterBox.Text)
                && !string.IsNullOrWhiteSpace(emailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(AddressEnterBox.Text)
                && !string.IsNullOrWhiteSpace(PassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = true;
            }
        }

        private void userEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userEnterBox.Text))
            {
                errorProvider.SetError(userEnterBox, "Username is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void emailEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEnterBox.Text))
            {
                errorProvider.SetError(emailEnterBox, "Email is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void AddressEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressEnterBox.Text))
            {
                errorProvider.SetError(AddressEnterBox, "Address is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void PassEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PassEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(userEnterBox.Text)
                && !string.IsNullOrWhiteSpace(emailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(AddressEnterBox.Text)
                && !string.IsNullOrWhiteSpace(PassEnterBox.Text))
            {
                GetButton.Enabled = true;
            }
        }

        private void PassEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PassEnterBox.Text))
            {
                errorProvider.SetError(PassEnterBox, "Password is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void HostEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(userEnterBox.Text)
                && !string.IsNullOrWhiteSpace(emailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(AddressEnterBox.Text)
                && !string.IsNullOrWhiteSpace(PassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(HostEnterBox.Text))
            {
                GetButton.Enabled = true;
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
    }
}
