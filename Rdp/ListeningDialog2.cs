using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Neophron
{
    public partial class ListeningDialog2 : Form
    {
        public string sessionPassword { get; private set; }
        public string controlLevel { get; private set; }
        public string viewers { get; private set; }
        public string cerr { get; private set; }
        public string smtpServer { get; private set; }
        public string smtpPort { get; private set; }
        public string emailManager { get; private set; }
        public string exterEmailPassword { get; private set; }

        public int exterPort { get; private set; }

        private NatSession natSession;

        public TlsServer tlsServer { get; private set; }

        private string stunAddr;
        private int stunPort;

        private bool IsPrepared = false;

        public ListeningDialog2()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            cerr = TlsCerr_EnterBox.Text;
            viewers = Viewers_EnterBox.Text;
            controlLevel = ControlLvl_Enterbox.Text;
            sessionPassword = SessionPass_EnterBox.Text;
            smtpServer = SmtpHost_EnterBox.Text;
            smtpPort = SmtpPort_EnterBox.Text;
            emailManager = Email_EnterBox.Text;
            exterEmailPassword = EmailPass_EnterBox.Text;

            stunAddr = StunHost_EnterBox.Text;
            stunPort = Convert.ToInt32(StunPort_EnterBox.Text);

            natSession = new NatSession(stunAddr, stunPort);

            string exterAddr = natSession.publicEndPoint.ToString();
            string interAddr = natSession.privateEndPoint.ToString();
            exterPort = natSession.exterClientPort;

            NetworkInfoBox.AppendText(exterAddr + "\n");
            NetworkInfoBox.AppendText(interAddr + "\n");

            GetButton.Enabled = false;
            Endpoint_EnterBox.Enabled = true;
            IsPrepared = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string address = Endpoint_EnterBox.Text;

            string ipAddress = address.Substring(0, address.IndexOf(':'));
            string port = address.Substring(address.IndexOf(':') + 1);

            int number;
            bool isNumber = int.TryParse(port, out number);

            if (isNumber)
            {
                string state = natSession.Process(ipAddress, Convert.ToInt32(port));

                MessageBox.Show(state.ToString());

                tlsServer = new TlsServer(natSession.tcpClient, cerr);

                StartButton.Enabled = false;
            }

            else
            {
                MessageBox.Show("Invalid Address", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TlsCerr_EnterBox_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TlsCerr_EnterBox.Text = openFileDialog.FileName;
            }
        }

        private void StunHost_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunHost_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void StunPort_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunPort_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void SmtpHost_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void SmtpPort_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpPort_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void TlsCerr_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void Email_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void EmailPass_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void SessionPass_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void ControlLvl_Enterbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void Viewers_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                GetButton.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(StunHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Email_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(StunPort_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text)
                && !string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text)
                && !string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                if (IsPrepared)
                {
                    GetButton.Enabled = true;
                }
            }
        }

        private void Endpoint_EnterBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text))
            {
                StartButton.Enabled = false;
            }

            else
            {
                StartButton.Enabled = true;
            }
        }

        private void Endpoint_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Endpoint_EnterBox.Text))
            {
                errorProvider.SetError(Endpoint_EnterBox, "Endpoint is required");
                StartButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void StunHost_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunHost_EnterBox.Text))
            {
                errorProvider.SetError(StunHost_EnterBox, "Hostname is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void StunPort_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StunPort_EnterBox.Text))
            {
                errorProvider.SetError(StunPort_EnterBox, "Port is required");
                GetButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(StunPort_EnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(StunPort_EnterBox, "Port is number");
                    GetButton.Enabled = false;
                }
            }
        }

        private void SmtpHost_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpHost_EnterBox.Text))
            {
                errorProvider.SetError(SmtpHost_EnterBox, "Hostname is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void SmtpPort_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SmtpPort_EnterBox.Text))
            {
                errorProvider.SetError(SmtpPort_EnterBox, "Port is required");
                GetButton.Enabled = false;
            }

            else
            {
                int number;

                bool isNumber = int.TryParse(SmtpPort_EnterBox.Text, out number);

                if (isNumber)
                {
                    errorProvider.Clear();
                }

                else
                {
                    errorProvider.SetError(SmtpPort_EnterBox, "Port is number");
                    GetButton.Enabled = false;
                }
            }
        }

        private void TlsCerr_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TlsCerr_EnterBox.Text))
            {
                errorProvider.SetError(TlsCerr_EnterBox, "Cerr is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void Email_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_EnterBox.Text))
            {
                errorProvider.SetError(Email_EnterBox, "Email is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void EmailPass_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailPass_EnterBox.Text))
            {
                errorProvider.SetError(EmailPass_EnterBox, "Password is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void SessionPass_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SessionPass_EnterBox.Text))
            {
                errorProvider.SetError(SessionPass_EnterBox, "Password is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void ControlLvl_Enterbox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ControlLvl_Enterbox.Text))
            {
                errorProvider.SetError(ControlLvl_Enterbox, "Level is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void Viewers_EnterBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Viewers_EnterBox.Text))
            {
                errorProvider.SetError(Viewers_EnterBox, "Viewers is required");
                GetButton.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }
    }
}
