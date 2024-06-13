namespace RdpClient.Forms
{
    partial class StartDialog
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartDialog));
            this.TabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPage_Local = new System.Windows.Forms.TabPage();
            this.Button_SaveLAN = new MaterialSkin.Controls.MaterialButton();
            this.Button_ConnectLAN = new MaterialSkin.Controls.MaterialButton();
            this.TextBox_HostnameLAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_Hostname = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_Endpoint = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_Password = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_PasswordLAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_Endpoint = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Username = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_UsernameLAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.TabPage_Global = new System.Windows.Forms.TabPage();
            this.Button_SaveWAN = new MaterialSkin.Controls.MaterialButton();
            this.Label_ConnectionString = new MaterialSkin.Controls.MaterialLabel();
            this.Button_ConnectWAN = new MaterialSkin.Controls.MaterialButton();
            this.Label_Password2 = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Hostname2 = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Username2 = new MaterialSkin.Controls.MaterialLabel();
            this.MultiLineTextBox_ConnectionString = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.TextBox_PasswordWAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.TextBox_HostnameWAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.TextBox_UsernameWAN = new MaterialSkin.Controls.MaterialTextBox2();
            this.TabPage_Info = new System.Windows.Forms.TabPage();
            this.ImageList_Tabs = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MultiLineTextBox_Info = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.TabControl.SuspendLayout();
            this.TabPage_Local.SuspendLayout();
            this.TabPage_Global.SuspendLayout();
            this.TabPage_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage_Local);
            this.TabControl.Controls.Add(this.TabPage_Global);
            this.TabControl.Controls.Add(this.TabPage_Info);
            this.TabControl.Depth = 0;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImageList = this.ImageList_Tabs;
            this.TabControl.Location = new System.Drawing.Point(3, 64);
            this.TabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(654, 383);
            this.TabControl.TabIndex = 0;
            // 
            // TabPage_Local
            // 
            this.TabPage_Local.Controls.Add(this.Button_SaveLAN);
            this.TabPage_Local.Controls.Add(this.Button_ConnectLAN);
            this.TabPage_Local.Controls.Add(this.TextBox_HostnameLAN);
            this.TabPage_Local.Controls.Add(this.Label_Hostname);
            this.TabPage_Local.Controls.Add(this.TextBox_Endpoint);
            this.TabPage_Local.Controls.Add(this.Label_Password);
            this.TabPage_Local.Controls.Add(this.TextBox_PasswordLAN);
            this.TabPage_Local.Controls.Add(this.Label_Endpoint);
            this.TabPage_Local.Controls.Add(this.Label_Username);
            this.TabPage_Local.Controls.Add(this.TextBox_UsernameLAN);
            this.TabPage_Local.ImageKey = "Local.png";
            this.TabPage_Local.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Local.Name = "TabPage_Local";
            this.TabPage_Local.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Local.Size = new System.Drawing.Size(646, 344);
            this.TabPage_Local.TabIndex = 0;
            this.TabPage_Local.Text = "Local Network";
            this.TabPage_Local.UseVisualStyleBackColor = true;
            // 
            // Button_SaveLAN
            // 
            this.Button_SaveLAN.AutoSize = false;
            this.Button_SaveLAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_SaveLAN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_SaveLAN.Depth = 0;
            this.Button_SaveLAN.Enabled = false;
            this.Button_SaveLAN.HighEmphasis = true;
            this.Button_SaveLAN.Icon = null;
            this.Button_SaveLAN.Location = new System.Drawing.Point(373, 296);
            this.Button_SaveLAN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_SaveLAN.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_SaveLAN.Name = "Button_SaveLAN";
            this.Button_SaveLAN.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_SaveLAN.Size = new System.Drawing.Size(83, 25);
            this.Button_SaveLAN.TabIndex = 19;
            this.Button_SaveLAN.Text = "Save";
            this.Button_SaveLAN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_SaveLAN.UseAccentColor = false;
            this.Button_SaveLAN.UseVisualStyleBackColor = true;
            this.Button_SaveLAN.Click += new System.EventHandler(this.Button_SaveLAN_Click);
            // 
            // Button_ConnectLAN
            // 
            this.Button_ConnectLAN.AutoSize = false;
            this.Button_ConnectLAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_ConnectLAN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_ConnectLAN.Depth = 0;
            this.Button_ConnectLAN.Enabled = false;
            this.Button_ConnectLAN.HighEmphasis = true;
            this.Button_ConnectLAN.Icon = null;
            this.Button_ConnectLAN.Location = new System.Drawing.Point(480, 296);
            this.Button_ConnectLAN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_ConnectLAN.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_ConnectLAN.Name = "Button_ConnectLAN";
            this.Button_ConnectLAN.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_ConnectLAN.Size = new System.Drawing.Size(83, 25);
            this.Button_ConnectLAN.TabIndex = 9;
            this.Button_ConnectLAN.Text = "Connect";
            this.Button_ConnectLAN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_ConnectLAN.UseAccentColor = false;
            this.Button_ConnectLAN.UseVisualStyleBackColor = true;
            this.Button_ConnectLAN.Click += new System.EventHandler(this.Button_ConnectLAN_Click);
            // 
            // TextBox_HostnameLAN
            // 
            this.TextBox_HostnameLAN.AnimateReadOnly = false;
            this.TextBox_HostnameLAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_HostnameLAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_HostnameLAN.Depth = 0;
            this.TextBox_HostnameLAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_HostnameLAN.HideSelection = true;
            this.TextBox_HostnameLAN.LeadingIcon = global::RdpClient.Properties.Resources.Host;
            this.TextBox_HostnameLAN.Location = new System.Drawing.Point(314, 99);
            this.TextBox_HostnameLAN.MaxLength = 32;
            this.TextBox_HostnameLAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_HostnameLAN.Name = "TextBox_HostnameLAN";
            this.TextBox_HostnameLAN.PasswordChar = '\0';
            this.TextBox_HostnameLAN.PrefixSuffixText = null;
            this.TextBox_HostnameLAN.ReadOnly = false;
            this.TextBox_HostnameLAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_HostnameLAN.SelectedText = "";
            this.TextBox_HostnameLAN.SelectionLength = 0;
            this.TextBox_HostnameLAN.SelectionStart = 0;
            this.TextBox_HostnameLAN.ShortcutsEnabled = true;
            this.TextBox_HostnameLAN.Size = new System.Drawing.Size(250, 36);
            this.TextBox_HostnameLAN.TabIndex = 8;
            this.TextBox_HostnameLAN.TabStop = false;
            this.TextBox_HostnameLAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_HostnameLAN.TrailingIcon = null;
            this.TextBox_HostnameLAN.UseSystemPasswordChar = false;
            this.TextBox_HostnameLAN.UseTallSize = false;
            this.TextBox_HostnameLAN.TextChanged += new System.EventHandler(this.TextBox_HostnameLAN_TextChanged);
            this.TextBox_HostnameLAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_HostnameLAN_Validating);
            // 
            // Label_Hostname
            // 
            this.Label_Hostname.AutoSize = true;
            this.Label_Hostname.Depth = 0;
            this.Label_Hostname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Hostname.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Hostname.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.Label_Hostname.Location = new System.Drawing.Point(314, 76);
            this.Label_Hostname.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Hostname.Name = "Label_Hostname";
            this.Label_Hostname.Size = new System.Drawing.Size(78, 19);
            this.Label_Hostname.TabIndex = 7;
            this.Label_Hostname.Text = "Hostname:";
            // 
            // TextBox_Endpoint
            // 
            this.TextBox_Endpoint.AnimateReadOnly = false;
            this.TextBox_Endpoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_Endpoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_Endpoint.Depth = 0;
            this.TextBox_Endpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_Endpoint.HideSelection = true;
            this.TextBox_Endpoint.LeadingIcon = global::RdpClient.Properties.Resources.Endpoint;
            this.TextBox_Endpoint.Location = new System.Drawing.Point(314, 206);
            this.TextBox_Endpoint.MaxLength = 32;
            this.TextBox_Endpoint.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_Endpoint.Name = "TextBox_Endpoint";
            this.TextBox_Endpoint.PasswordChar = '\0';
            this.TextBox_Endpoint.PrefixSuffixText = null;
            this.TextBox_Endpoint.ReadOnly = false;
            this.TextBox_Endpoint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_Endpoint.SelectedText = "";
            this.TextBox_Endpoint.SelectionLength = 0;
            this.TextBox_Endpoint.SelectionStart = 0;
            this.TextBox_Endpoint.ShortcutsEnabled = true;
            this.TextBox_Endpoint.Size = new System.Drawing.Size(250, 36);
            this.TextBox_Endpoint.TabIndex = 6;
            this.TextBox_Endpoint.TabStop = false;
            this.TextBox_Endpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_Endpoint.TrailingIcon = null;
            this.TextBox_Endpoint.UseSystemPasswordChar = false;
            this.TextBox_Endpoint.UseTallSize = false;
            this.TextBox_Endpoint.TextChanged += new System.EventHandler(this.TextBox_Endpoint_TextChanged);
            this.TextBox_Endpoint.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Endpoint_Validating);
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Depth = 0;
            this.Label_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Password.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Password.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.Label_Password.Location = new System.Drawing.Point(32, 183);
            this.Label_Password.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(75, 19);
            this.Label_Password.TabIndex = 5;
            this.Label_Password.Text = "Password:";
            // 
            // TextBox_PasswordLAN
            // 
            this.TextBox_PasswordLAN.AnimateReadOnly = false;
            this.TextBox_PasswordLAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_PasswordLAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_PasswordLAN.Depth = 0;
            this.TextBox_PasswordLAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_PasswordLAN.HideSelection = true;
            this.TextBox_PasswordLAN.LeadingIcon = global::RdpClient.Properties.Resources.Secure;
            this.TextBox_PasswordLAN.Location = new System.Drawing.Point(32, 206);
            this.TextBox_PasswordLAN.MaxLength = 64;
            this.TextBox_PasswordLAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_PasswordLAN.Name = "TextBox_PasswordLAN";
            this.TextBox_PasswordLAN.PasswordChar = '●';
            this.TextBox_PasswordLAN.PrefixSuffixText = null;
            this.TextBox_PasswordLAN.ReadOnly = false;
            this.TextBox_PasswordLAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_PasswordLAN.SelectedText = "";
            this.TextBox_PasswordLAN.SelectionLength = 0;
            this.TextBox_PasswordLAN.SelectionStart = 0;
            this.TextBox_PasswordLAN.ShortcutsEnabled = true;
            this.TextBox_PasswordLAN.Size = new System.Drawing.Size(250, 36);
            this.TextBox_PasswordLAN.TabIndex = 4;
            this.TextBox_PasswordLAN.TabStop = false;
            this.TextBox_PasswordLAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_PasswordLAN.TrailingIcon = null;
            this.TextBox_PasswordLAN.UseSystemPasswordChar = true;
            this.TextBox_PasswordLAN.UseTallSize = false;
            this.TextBox_PasswordLAN.TextChanged += new System.EventHandler(this.TextBox_PasswordLAN_TextChanged);
            this.TextBox_PasswordLAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_PasswordLAN_Validating);
            // 
            // Label_Endpoint
            // 
            this.Label_Endpoint.AutoSize = true;
            this.Label_Endpoint.Depth = 0;
            this.Label_Endpoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Endpoint.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Endpoint.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.Label_Endpoint.Location = new System.Drawing.Point(314, 183);
            this.Label_Endpoint.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Endpoint.Name = "Label_Endpoint";
            this.Label_Endpoint.Size = new System.Drawing.Size(68, 19);
            this.Label_Endpoint.TabIndex = 3;
            this.Label_Endpoint.Text = "Endpoint:";
            // 
            // Label_Username
            // 
            this.Label_Username.AutoSize = true;
            this.Label_Username.Depth = 0;
            this.Label_Username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Username.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Username.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.Label_Username.Location = new System.Drawing.Point(32, 75);
            this.Label_Username.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Username.Name = "Label_Username";
            this.Label_Username.Size = new System.Drawing.Size(76, 19);
            this.Label_Username.TabIndex = 2;
            this.Label_Username.Text = "Username:";
            // 
            // TextBox_UsernameLAN
            // 
            this.TextBox_UsernameLAN.AnimateReadOnly = false;
            this.TextBox_UsernameLAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_UsernameLAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_UsernameLAN.Depth = 0;
            this.TextBox_UsernameLAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_UsernameLAN.HideSelection = true;
            this.TextBox_UsernameLAN.LeadingIcon = global::RdpClient.Properties.Resources.User;
            this.TextBox_UsernameLAN.Location = new System.Drawing.Point(32, 99);
            this.TextBox_UsernameLAN.MaxLength = 32;
            this.TextBox_UsernameLAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_UsernameLAN.Name = "TextBox_UsernameLAN";
            this.TextBox_UsernameLAN.PasswordChar = '\0';
            this.TextBox_UsernameLAN.PrefixSuffixText = null;
            this.TextBox_UsernameLAN.ReadOnly = false;
            this.TextBox_UsernameLAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_UsernameLAN.SelectedText = "";
            this.TextBox_UsernameLAN.SelectionLength = 0;
            this.TextBox_UsernameLAN.SelectionStart = 0;
            this.TextBox_UsernameLAN.ShortcutsEnabled = true;
            this.TextBox_UsernameLAN.Size = new System.Drawing.Size(250, 36);
            this.TextBox_UsernameLAN.TabIndex = 1;
            this.TextBox_UsernameLAN.TabStop = false;
            this.TextBox_UsernameLAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_UsernameLAN.TrailingIcon = null;
            this.TextBox_UsernameLAN.UseSystemPasswordChar = false;
            this.TextBox_UsernameLAN.UseTallSize = false;
            this.TextBox_UsernameLAN.TextChanged += new System.EventHandler(this.TextBox_UsernameLAN_TextChanged);
            this.TextBox_UsernameLAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_UsernameLAN_Validating);
            // 
            // TabPage_Global
            // 
            this.TabPage_Global.Controls.Add(this.Button_SaveWAN);
            this.TabPage_Global.Controls.Add(this.Label_ConnectionString);
            this.TabPage_Global.Controls.Add(this.Button_ConnectWAN);
            this.TabPage_Global.Controls.Add(this.Label_Password2);
            this.TabPage_Global.Controls.Add(this.Label_Hostname2);
            this.TabPage_Global.Controls.Add(this.Label_Username2);
            this.TabPage_Global.Controls.Add(this.MultiLineTextBox_ConnectionString);
            this.TabPage_Global.Controls.Add(this.TextBox_PasswordWAN);
            this.TabPage_Global.Controls.Add(this.TextBox_HostnameWAN);
            this.TabPage_Global.Controls.Add(this.TextBox_UsernameWAN);
            this.TabPage_Global.ImageKey = "Global.png";
            this.TabPage_Global.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Global.Name = "TabPage_Global";
            this.TabPage_Global.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Global.Size = new System.Drawing.Size(646, 344);
            this.TabPage_Global.TabIndex = 1;
            this.TabPage_Global.Text = "Global Network";
            this.TabPage_Global.UseVisualStyleBackColor = true;
            // 
            // Button_SaveWAN
            // 
            this.Button_SaveWAN.AutoSize = false;
            this.Button_SaveWAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_SaveWAN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_SaveWAN.Depth = 0;
            this.Button_SaveWAN.Enabled = false;
            this.Button_SaveWAN.HighEmphasis = true;
            this.Button_SaveWAN.Icon = null;
            this.Button_SaveWAN.Location = new System.Drawing.Point(378, 315);
            this.Button_SaveWAN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_SaveWAN.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_SaveWAN.Name = "Button_SaveWAN";
            this.Button_SaveWAN.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_SaveWAN.Size = new System.Drawing.Size(83, 25);
            this.Button_SaveWAN.TabIndex = 18;
            this.Button_SaveWAN.Text = "Save";
            this.Button_SaveWAN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_SaveWAN.UseAccentColor = false;
            this.Button_SaveWAN.UseVisualStyleBackColor = true;
            this.Button_SaveWAN.Click += new System.EventHandler(this.Button_SaveWAN_Click);
            // 
            // Label_ConnectionString
            // 
            this.Label_ConnectionString.AutoSize = true;
            this.Label_ConnectionString.Depth = 0;
            this.Label_ConnectionString.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_ConnectionString.Location = new System.Drawing.Point(288, 62);
            this.Label_ConnectionString.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_ConnectionString.Name = "Label_ConnectionString";
            this.Label_ConnectionString.Size = new System.Drawing.Size(131, 19);
            this.Label_ConnectionString.TabIndex = 17;
            this.Label_ConnectionString.Text = "Connection String:";
            // 
            // Button_ConnectWAN
            // 
            this.Button_ConnectWAN.AutoSize = false;
            this.Button_ConnectWAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_ConnectWAN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_ConnectWAN.Depth = 0;
            this.Button_ConnectWAN.Enabled = false;
            this.Button_ConnectWAN.HighEmphasis = true;
            this.Button_ConnectWAN.Icon = null;
            this.Button_ConnectWAN.Location = new System.Drawing.Point(485, 315);
            this.Button_ConnectWAN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_ConnectWAN.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_ConnectWAN.Name = "Button_ConnectWAN";
            this.Button_ConnectWAN.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_ConnectWAN.Size = new System.Drawing.Size(83, 25);
            this.Button_ConnectWAN.TabIndex = 16;
            this.Button_ConnectWAN.Text = "Connect";
            this.Button_ConnectWAN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_ConnectWAN.UseAccentColor = false;
            this.Button_ConnectWAN.UseVisualStyleBackColor = true;
            this.Button_ConnectWAN.Click += new System.EventHandler(this.Button_ConnectWAN_Click);
            // 
            // Label_Password2
            // 
            this.Label_Password2.AutoSize = true;
            this.Label_Password2.Depth = 0;
            this.Label_Password2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Password2.Location = new System.Drawing.Point(29, 218);
            this.Label_Password2.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Password2.Name = "Label_Password2";
            this.Label_Password2.Size = new System.Drawing.Size(75, 19);
            this.Label_Password2.TabIndex = 14;
            this.Label_Password2.Text = "Password:";
            // 
            // Label_Hostname2
            // 
            this.Label_Hostname2.AutoSize = true;
            this.Label_Hostname2.Depth = 0;
            this.Label_Hostname2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Hostname2.Location = new System.Drawing.Point(29, 140);
            this.Label_Hostname2.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Hostname2.Name = "Label_Hostname2";
            this.Label_Hostname2.Size = new System.Drawing.Size(78, 19);
            this.Label_Hostname2.TabIndex = 12;
            this.Label_Hostname2.Text = "Hostname:";
            // 
            // Label_Username2
            // 
            this.Label_Username2.AutoSize = true;
            this.Label_Username2.Depth = 0;
            this.Label_Username2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Username2.Location = new System.Drawing.Point(29, 62);
            this.Label_Username2.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Username2.Name = "Label_Username2";
            this.Label_Username2.Size = new System.Drawing.Size(76, 19);
            this.Label_Username2.TabIndex = 11;
            this.Label_Username2.Text = "Username:";
            // 
            // MultiLineTextBox_ConnectionString
            // 
            this.MultiLineTextBox_ConnectionString.AnimateReadOnly = false;
            this.MultiLineTextBox_ConnectionString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MultiLineTextBox_ConnectionString.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MultiLineTextBox_ConnectionString.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MultiLineTextBox_ConnectionString.Depth = 0;
            this.MultiLineTextBox_ConnectionString.HideSelection = true;
            this.MultiLineTextBox_ConnectionString.Location = new System.Drawing.Point(288, 84);
            this.MultiLineTextBox_ConnectionString.MaxLength = 32767;
            this.MultiLineTextBox_ConnectionString.MouseState = MaterialSkin.MouseState.OUT;
            this.MultiLineTextBox_ConnectionString.Name = "MultiLineTextBox_ConnectionString";
            this.MultiLineTextBox_ConnectionString.PasswordChar = '\0';
            this.MultiLineTextBox_ConnectionString.ReadOnly = false;
            this.MultiLineTextBox_ConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MultiLineTextBox_ConnectionString.SelectedText = "";
            this.MultiLineTextBox_ConnectionString.SelectionLength = 0;
            this.MultiLineTextBox_ConnectionString.SelectionStart = 0;
            this.MultiLineTextBox_ConnectionString.ShortcutsEnabled = true;
            this.MultiLineTextBox_ConnectionString.Size = new System.Drawing.Size(280, 194);
            this.MultiLineTextBox_ConnectionString.TabIndex = 0;
            this.MultiLineTextBox_ConnectionString.TabStop = false;
            this.MultiLineTextBox_ConnectionString.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MultiLineTextBox_ConnectionString.UseSystemPasswordChar = false;
            this.MultiLineTextBox_ConnectionString.TextChanged += new System.EventHandler(this.MultiLineTextBox_ConnectionString_TextChanged);
            this.MultiLineTextBox_ConnectionString.Validating += new System.ComponentModel.CancelEventHandler(this.MultiLineTextBox_ConnectionString_Validating);
            // 
            // TextBox_PasswordWAN
            // 
            this.TextBox_PasswordWAN.AnimateReadOnly = false;
            this.TextBox_PasswordWAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_PasswordWAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_PasswordWAN.Depth = 0;
            this.TextBox_PasswordWAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_PasswordWAN.HideSelection = true;
            this.TextBox_PasswordWAN.LeadingIcon = global::RdpClient.Properties.Resources.Secure;
            this.TextBox_PasswordWAN.Location = new System.Drawing.Point(28, 240);
            this.TextBox_PasswordWAN.MaxLength = 64;
            this.TextBox_PasswordWAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_PasswordWAN.Name = "TextBox_PasswordWAN";
            this.TextBox_PasswordWAN.PasswordChar = '●';
            this.TextBox_PasswordWAN.PrefixSuffixText = null;
            this.TextBox_PasswordWAN.ReadOnly = false;
            this.TextBox_PasswordWAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_PasswordWAN.SelectedText = "";
            this.TextBox_PasswordWAN.SelectionLength = 0;
            this.TextBox_PasswordWAN.SelectionStart = 0;
            this.TextBox_PasswordWAN.ShortcutsEnabled = true;
            this.TextBox_PasswordWAN.Size = new System.Drawing.Size(219, 36);
            this.TextBox_PasswordWAN.TabIndex = 15;
            this.TextBox_PasswordWAN.TabStop = false;
            this.TextBox_PasswordWAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_PasswordWAN.TrailingIcon = null;
            this.TextBox_PasswordWAN.UseSystemPasswordChar = true;
            this.TextBox_PasswordWAN.UseTallSize = false;
            this.TextBox_PasswordWAN.TextChanged += new System.EventHandler(this.TextBox_PasswordWAN_TextChanged);
            this.TextBox_PasswordWAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_PasswordWAN_Validating);
            // 
            // TextBox_HostnameWAN
            // 
            this.TextBox_HostnameWAN.AnimateReadOnly = false;
            this.TextBox_HostnameWAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_HostnameWAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_HostnameWAN.Depth = 0;
            this.TextBox_HostnameWAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_HostnameWAN.HideSelection = true;
            this.TextBox_HostnameWAN.LeadingIcon = global::RdpClient.Properties.Resources.Host;
            this.TextBox_HostnameWAN.Location = new System.Drawing.Point(28, 162);
            this.TextBox_HostnameWAN.MaxLength = 32;
            this.TextBox_HostnameWAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_HostnameWAN.Name = "TextBox_HostnameWAN";
            this.TextBox_HostnameWAN.PasswordChar = '\0';
            this.TextBox_HostnameWAN.PrefixSuffixText = null;
            this.TextBox_HostnameWAN.ReadOnly = false;
            this.TextBox_HostnameWAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_HostnameWAN.SelectedText = "";
            this.TextBox_HostnameWAN.SelectionLength = 0;
            this.TextBox_HostnameWAN.SelectionStart = 0;
            this.TextBox_HostnameWAN.ShortcutsEnabled = true;
            this.TextBox_HostnameWAN.Size = new System.Drawing.Size(219, 36);
            this.TextBox_HostnameWAN.TabIndex = 13;
            this.TextBox_HostnameWAN.TabStop = false;
            this.TextBox_HostnameWAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_HostnameWAN.TrailingIcon = null;
            this.TextBox_HostnameWAN.UseSystemPasswordChar = false;
            this.TextBox_HostnameWAN.UseTallSize = false;
            this.TextBox_HostnameWAN.TextChanged += new System.EventHandler(this.TextBox_HostnameWAN_TextChanged);
            this.TextBox_HostnameWAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_HostnameWAN_Validating);
            // 
            // TextBox_UsernameWAN
            // 
            this.TextBox_UsernameWAN.AnimateReadOnly = false;
            this.TextBox_UsernameWAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_UsernameWAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_UsernameWAN.Depth = 0;
            this.TextBox_UsernameWAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_UsernameWAN.HideSelection = true;
            this.TextBox_UsernameWAN.LeadingIcon = global::RdpClient.Properties.Resources.User;
            this.TextBox_UsernameWAN.Location = new System.Drawing.Point(28, 84);
            this.TextBox_UsernameWAN.MaxLength = 32;
            this.TextBox_UsernameWAN.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_UsernameWAN.Name = "TextBox_UsernameWAN";
            this.TextBox_UsernameWAN.PasswordChar = '\0';
            this.TextBox_UsernameWAN.PrefixSuffixText = null;
            this.TextBox_UsernameWAN.ReadOnly = false;
            this.TextBox_UsernameWAN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_UsernameWAN.SelectedText = "";
            this.TextBox_UsernameWAN.SelectionLength = 0;
            this.TextBox_UsernameWAN.SelectionStart = 0;
            this.TextBox_UsernameWAN.ShortcutsEnabled = true;
            this.TextBox_UsernameWAN.Size = new System.Drawing.Size(219, 36);
            this.TextBox_UsernameWAN.TabIndex = 1;
            this.TextBox_UsernameWAN.TabStop = false;
            this.TextBox_UsernameWAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_UsernameWAN.TrailingIcon = null;
            this.TextBox_UsernameWAN.UseSystemPasswordChar = false;
            this.TextBox_UsernameWAN.UseTallSize = false;
            this.TextBox_UsernameWAN.TextChanged += new System.EventHandler(this.TextBox_UsernameWAN_TextChanged);
            this.TextBox_UsernameWAN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_UsernameWAN_Validating);
            // 
            // TabPage_Info
            // 
            this.TabPage_Info.Controls.Add(this.MultiLineTextBox_Info);
            this.TabPage_Info.ImageKey = "Info.png";
            this.TabPage_Info.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Info.Name = "TabPage_Info";
            this.TabPage_Info.Size = new System.Drawing.Size(646, 344);
            this.TabPage_Info.TabIndex = 3;
            this.TabPage_Info.Text = "Info";
            this.TabPage_Info.UseVisualStyleBackColor = true;
            // 
            // ImageList_Tabs
            // 
            this.ImageList_Tabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_Tabs.ImageStream")));
            this.ImageList_Tabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_Tabs.Images.SetKeyName(0, "Local.png");
            this.ImageList_Tabs.Images.SetKeyName(1, "Global.png");
            this.ImageList_Tabs.Images.SetKeyName(2, "Info.png");
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // MultiLineTextBox_Info
            // 
            this.MultiLineTextBox_Info.AnimateReadOnly = false;
            this.MultiLineTextBox_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MultiLineTextBox_Info.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MultiLineTextBox_Info.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MultiLineTextBox_Info.Depth = 0;
            this.MultiLineTextBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MultiLineTextBox_Info.HideSelection = true;
            this.MultiLineTextBox_Info.Location = new System.Drawing.Point(0, 0);
            this.MultiLineTextBox_Info.MaxLength = 32767;
            this.MultiLineTextBox_Info.MouseState = MaterialSkin.MouseState.OUT;
            this.MultiLineTextBox_Info.Name = "MultiLineTextBox_Info";
            this.MultiLineTextBox_Info.PasswordChar = '\0';
            this.MultiLineTextBox_Info.ReadOnly = true;
            this.MultiLineTextBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MultiLineTextBox_Info.SelectedText = "";
            this.MultiLineTextBox_Info.SelectionLength = 0;
            this.MultiLineTextBox_Info.SelectionStart = 0;
            this.MultiLineTextBox_Info.ShortcutsEnabled = true;
            this.MultiLineTextBox_Info.Size = new System.Drawing.Size(646, 344);
            this.MultiLineTextBox_Info.TabIndex = 0;
            this.MultiLineTextBox_Info.TabStop = false;
            this.MultiLineTextBox_Info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MultiLineTextBox_Info.UseSystemPasswordChar = false;
            // 
            // StartDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Controls.Add(this.TabControl);
            this.DrawerIndicatorWidth = 2;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControl;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartDialog";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Desktop Connection";
            this.Load += new System.EventHandler(this.StartDialog_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPage_Local.ResumeLayout(false);
            this.TabPage_Local.PerformLayout();
            this.TabPage_Global.ResumeLayout(false);
            this.TabPage_Global.PerformLayout();
            this.TabPage_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControl;
        private System.Windows.Forms.TabPage TabPage_Local;
        private System.Windows.Forms.TabPage TabPage_Global;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_UsernameLAN;
        private MaterialSkin.Controls.MaterialLabel Label_Username;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_PasswordLAN;
        private MaterialSkin.Controls.MaterialLabel Label_Endpoint;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_HostnameLAN;
        private MaterialSkin.Controls.MaterialLabel Label_Hostname;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_Endpoint;
        private MaterialSkin.Controls.MaterialLabel Label_Password;
        private MaterialSkin.Controls.MaterialButton Button_ConnectLAN;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_UsernameWAN;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 MultiLineTextBox_ConnectionString;
        private MaterialSkin.Controls.MaterialLabel Label_Username2;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_HostnameWAN;
        private MaterialSkin.Controls.MaterialLabel Label_Hostname2;
        private MaterialSkin.Controls.MaterialLabel Label_Password2;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_PasswordWAN;
        private MaterialSkin.Controls.MaterialButton Button_ConnectWAN;
        private MaterialSkin.Controls.MaterialLabel Label_ConnectionString;
        private MaterialSkin.Controls.MaterialButton Button_SaveWAN;
        private MaterialSkin.Controls.MaterialButton Button_SaveLAN;
        private System.Windows.Forms.TabPage TabPage_Info;
        private System.Windows.Forms.ImageList ImageList_Tabs;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 MultiLineTextBox_Info;
    }
}

