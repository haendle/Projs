using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

using RdpClient.Data;
using RdpClient.Sockets;


namespace RdpClient.Forms
{
    public partial class StartDialog : MaterialForm
    {
        public string UsernameLAN { get; private set; }
        public string HostnameLAN { get; private set; }
        public string PasswordLAN { get; private set; }

        public string UsernameWAN { get; private set; }
        public string HostnameWAN { get; private set; }
        public string PasswordWAN { get; private set; } 
        
        public string ConnectionString { get; private set; }
        public string AccessLevel { get; private set; }
        public string RemoteHost { get; private set; }

        public bool SwitchWnd { get; private set; }
        public bool IsLocal {  get; private set; }
        
        private string _endpoint;
        private string _response;

        private SslClient _client;
        
        public StartDialog()
        {
            InitializeComponent();
            InitMaterialSkin();
        }

        private void Button_ConnectLAN_Click(object sender, EventArgs e)
        {
            try
            {
                IsLocal = true;

                UsernameLAN = TextBox_UsernameLAN.Text;
                HostnameLAN = TextBox_HostnameLAN.Text;
                PasswordLAN = TextBox_PasswordLAN.Text;

                _endpoint = TextBox_Endpoint.Text;

                _client = new SslClient(_endpoint, HostnameLAN);

                Client_AsyncAuthenticate();
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

        private void Button_ConnectWAN_Click(object sender, EventArgs e)
        {
            try
            {
                IsLocal = false;

                UsernameWAN = TextBox_UsernameWAN.Text;
                HostnameWAN = TextBox_HostnameWAN.Text;
                PasswordWAN = TextBox_PasswordWAN.Text;
                ConnectionString = MultiLineTextBox_ConnectionString.Text;

                SwitchWnd = true;

                this.Close();
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

        private void Button_SaveLAN_Click(object sender, EventArgs e)
        {
            try
            {
                UsernameLAN = TextBox_UsernameLAN.Text;
                HostnameLAN = TextBox_HostnameLAN.Text;

                _endpoint = TextBox_Endpoint.Text;

                var config = ConfigurationManager.OpenExeConfiguration
                (ConfigurationUserLevel.None);

                config.AppSettings.Settings["LAN_USERNAME"].Value = UsernameLAN;
                config.AppSettings.Settings["LAN_HOSTNAME"].Value = HostnameLAN;
                config.AppSettings.Settings["ENDPOINT"].Value = _endpoint;

                config.Save();

                ConfigurationManager.RefreshSection("appSettings");
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

        private void Button_SaveWAN_Click(object sender, EventArgs e)
        {
            try
            {
                UsernameWAN = TextBox_UsernameWAN.Text;
                HostnameWAN = TextBox_HostnameWAN.Text;
                ConnectionString = MultiLineTextBox_ConnectionString.Text;

                var config = ConfigurationManager.OpenExeConfiguration
                (ConfigurationUserLevel.None);

                config.AppSettings.Settings["WAN_USERNAME"].Value = UsernameWAN;
                config.AppSettings.Settings["WAN_HOSTNAME"].Value = HostnameWAN;
                config.AppSettings.Settings["CONNECTION_STRING"].Value = ConnectionString;

                config.Save();

                ConfigurationManager.RefreshSection("appSettings");
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

        private async void Client_AsyncAuthenticate()
        {
            try
            {
                await Task.Run
                (() =>
                {
                    _client.Connect();
                    _client.SendAuthenticationRequest(UsernameLAN, PasswordLAN);

                    SslResponse sslResponse = _client.RecvAuthenticationResponse();

                    ConnectionString = sslResponse.ConnectionString;
                    AccessLevel = sslResponse.AccessLevel;
                    RemoteHost = sslResponse.Host;

                    _response = sslResponse.Response;
                });

                if (_response == "denied")
                {
                    MessageBox.Show
                    (
                        "Access Denied",
                        "Network Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Application.Exit();
                }

                else
                {
                    _client.Close();

                    this.SwitchWnd = true;
                    this.Close();
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

        private void StartDialog_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists("RdpClient.exe.config"))
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
                    { ReadConfig(); }

                    else if (result == DialogResult.Cancel)
                    { Application.Exit(); }
                }

                else
                {
                    MessageBox.Show
                    (
                        "Config not found",
                        "Configuration Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
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

        private void ReadConfig()
        {
            try
            {
                UsernameLAN = ConfigurationManager.AppSettings
                ["LAN_USERNAME"].ToString();
                TextBox_UsernameLAN.Text = UsernameLAN;

                HostnameLAN = ConfigurationManager.AppSettings
                ["LAN_HOSTNAME"].ToString();
                TextBox_HostnameLAN.Text = HostnameLAN;

                UsernameWAN = ConfigurationManager.AppSettings
                ["WAN_USERNAME"].ToString();
                TextBox_UsernameWAN.Text = UsernameWAN;

                HostnameWAN = ConfigurationManager.AppSettings
                ["WAN_HOSTNAME"].ToString();
                TextBox_HostnameWAN.Text = HostnameWAN;

                ConnectionString = ConfigurationManager.AppSettings
                ["CONNECTION_STRING"].ToString();
                MultiLineTextBox_ConnectionString.Text = ConnectionString;

                _endpoint = ConfigurationManager.AppSettings
                ["ENDPOINT"].ToString();
                TextBox_Endpoint.Text = _endpoint;
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

        private void TextBox_UsernameLAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text))
            {
                Button_ConnectLAN.Enabled = false;
                Button_SaveLAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_Endpoint.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                Button_ConnectLAN.Enabled = true;
                Button_SaveLAN.Enabled = true;
            }
        }

        private void TextBox_PasswordLAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                Button_ConnectLAN.Enabled = false;
                Button_SaveLAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_Endpoint.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                Button_ConnectLAN.Enabled = true;
                Button_SaveLAN.Enabled = true;
            }
        }

        private void TextBox_HostnameLAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text))
            {
                Button_ConnectLAN.Enabled = false;
                Button_SaveLAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_Endpoint.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                Button_ConnectLAN.Enabled = true;
                Button_SaveLAN.Enabled = true;
            }
        }

        private void TextBox_Endpoint_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Endpoint.Text))
            {
                Button_ConnectLAN.Enabled = false;
                Button_SaveLAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_Endpoint.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                Button_ConnectLAN.Enabled = true;
                Button_SaveLAN.Enabled = true;
            }
        }

        private void TextBox_UsernameLAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_UsernameLAN.Text))
            {
                errorProvider.SetError(TextBox_UsernameLAN, "required");
                Button_ConnectLAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_PasswordLAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_PasswordLAN.Text))
            {
                errorProvider.SetError(TextBox_PasswordLAN, "required");
                Button_ConnectLAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_HostnameLAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_HostnameLAN.Text))
            {
                errorProvider.SetError(TextBox_HostnameLAN, "required");
                Button_ConnectLAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_Endpoint_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Endpoint.Text))
            {
                errorProvider.SetError(TextBox_Endpoint, "required");
                Button_ConnectLAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_UsernameWAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text))
            {
                Button_ConnectWAN.Enabled = false;
                Button_SaveWAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text) &&
                !string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                Button_ConnectWAN.Enabled = true;
                Button_SaveWAN.Enabled = true;
            }
        }

        private void TextBox_HostnameWAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text))
            {
                Button_ConnectWAN.Enabled = false;
                Button_SaveWAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text) &&
                !string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                Button_ConnectWAN.Enabled = true;
                Button_SaveWAN.Enabled = true;
            }
        }

        private void TextBox_PasswordWAN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                Button_ConnectWAN.Enabled = false;
                Button_SaveWAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text) &&
                !string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                Button_ConnectWAN.Enabled = true;
                Button_SaveWAN.Enabled = true;
            }
        }

        private void MultiLineTextBox_ConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text))
            {
                Button_ConnectWAN.Enabled = false;
                Button_SaveWAN.Enabled = false;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text) &&
                !string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text) &&
                !string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                Button_ConnectWAN.Enabled = true;
                Button_SaveWAN.Enabled = true;
            }
        }

        private void TextBox_UsernameWAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_UsernameWAN.Text))
            {
                errorProvider.SetError(TextBox_UsernameWAN, "required");
                Button_ConnectWAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_HostnameWAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_HostnameWAN.Text))
            {
                errorProvider.SetError(TextBox_HostnameWAN, "required");
                Button_ConnectWAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void TextBox_PasswordWAN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_PasswordWAN.Text))
            {
                errorProvider.SetError(TextBox_PasswordWAN, "required");
                Button_ConnectWAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }

        private void MultiLineTextBox_ConnectionString_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MultiLineTextBox_ConnectionString.Text))
            {
                errorProvider.SetError(MultiLineTextBox_ConnectionString, "required");
                Button_ConnectWAN.Enabled = false;
            }

            else
            {
                errorProvider.Clear();
            }
        }
    }
}
