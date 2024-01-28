using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neophron
{
    public partial class ListeningDialog : Form
    {
        public string sessionPassword { get; private set; }
        public string controlLevel { get; private set; }
        public string viewers { get; private set; }
        public string interPort { get; private set; }
        public string cerr { get; private set; }
        public string smtpServer { get; private set; }
        public string smtpPort { get; private set; }
        public string emailManager { get; private set; }
        public string exterEmailPassword { get; private set; }

        public ListeningDialog()
        {
            InitializeComponent();
        }

        private void ListeningDialog_Load(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            HostInfoBox.Text = host;

            IPAddress[] ipAddresses = Dns.GetHostAddresses(host);

            for (int i = 0; i < ipAddresses.Length; i++)
            {
                NetworkInfoBox.AppendText(ipAddresses[i].ToString() + "\n");
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            interPort = PortEnterBox.Text;
            cerr = TlsCerrPathEnterBox.Text;

            viewers = ViewersEnterBox.Text;
            controlLevel = ControlEnterBox.Text;
            sessionPassword = SesPassEnterBox.Text;

            smtpServer = SmtpHostEnterBox.Text;
            smtpPort = SmtpPortEnterBox.Text;

            emailManager = EmailEnterBox.Text;
            exterEmailPassword = ExPassEnterBox.Text;

            StartButton.Enabled = false;
        }

        private void PortEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PortEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void TlsCerrPathEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void SesPassEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SesPassEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void ControlEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ControlEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void SmtpHostEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void SmtpPortEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void EmailEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void ExPassEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExPassEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void ViewersEnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(PortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerrPathEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SesPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ExPassEnterBox.Text)
                && !string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                StartButton.Enabled = true;
            }
        }

        private void PortEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PortEnterBox.Text))
            {
                errorProvider.SetError(PortEnterBox, "Port is required");
                StartButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(PortEnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(PortEnterBox, "Port is number");
                    StartButton.Enabled = false;
                }
            }
        }

        private void TlsCerrPathEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PortEnterBox.Text))
            {
                errorProvider.SetError(TlsCerrPathEnterBox, "Path is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void SesPassEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SesPassEnterBox.Text))
            {
                errorProvider.SetError(SesPassEnterBox, "Password is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void ControlEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ControlEnterBox.Text))
            {
                errorProvider.SetError(ControlEnterBox, "Field is required");
                StartButton.Enabled = false;
            }

            else
            {
                if (ControlEnterBox.Text == "VIEW" || ControlEnterBox.Text == "INTERACTIVE")
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(ControlEnterBox, "Must be VIEW/INTERACTIVE");
                    StartButton.Enabled = false;
                }
            }
        }

        private void SmtpHostEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpHostEnterBox.Text))
            {
                errorProvider.SetError(SmtpHostEnterBox, "Hostname is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void SmtpPortEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpPortEnterBox.Text))
            {
                errorProvider.SetError(SmtpPortEnterBox, "Port is required");
                StartButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(SmtpPortEnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(SmtpPortEnterBox, "Port is number");
                    StartButton.Enabled = false;
                }
            }
        }

        private void EmailEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailEnterBox.Text))
            {
                errorProvider.SetError(EmailEnterBox, "Email is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void ExPassEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExPassEnterBox.Text))
            {
                errorProvider.SetError(ExPassEnterBox, "Password is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void ViewersEnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ViewersEnterBox.Text))
            {
                errorProvider.SetError(ViewersEnterBox, "Field is required");
                StartButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(ViewersEnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(ViewersEnterBox, "Field is number");
                    StartButton.Enabled = false;
                }
            }
        }

        private void TlsCerrPathEnterBox_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TlsCerrPathEnterBox.Text = openFileDialog.FileName;
            }
        }
    }
}
