namespace RdpServer
{
    partial class ServerWnd
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerWnd));
            this.TabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPage_Server = new System.Windows.Forms.TabPage();
            this.MultiTextBox_Logs = new System.Windows.Forms.RichTextBox();
            this.Button_Resume = new MaterialSkin.Controls.MaterialButton();
            this.Button_Pause = new MaterialSkin.Controls.MaterialButton();
            this.Button_Start = new MaterialSkin.Controls.MaterialButton();
            this.TabPage_Attendees = new System.Windows.Forms.TabPage();
            this.Label_Properties = new MaterialSkin.Controls.MaterialLabel();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.Label_Attendees = new MaterialSkin.Controls.MaterialLabel();
            this.ListBox_Attendees = new MaterialSkin.Controls.MaterialListBox();
            this.TabPage_Settings = new System.Windows.Forms.TabPage();
            this.Button_Save = new MaterialSkin.Controls.MaterialButton();
            this.Button_Accept = new MaterialSkin.Controls.MaterialButton();
            this.CheckBox_Fips = new MaterialSkin.Controls.MaterialCheckbox();
            this.NumericUpDown_FrameInterval = new System.Windows.Forms.NumericUpDown();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_SessionPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_SessionPassword = new MaterialSkin.Controls.MaterialLabel();
            this.Label_EmailPassword = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_EmailPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.TextBox_EmailManager = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_EmailManager = new MaterialSkin.Controls.MaterialLabel();
            this.CheckBox_ClipBoard = new MaterialSkin.Controls.MaterialCheckbox();
            this.CheckBox_Autostart = new MaterialSkin.Controls.MaterialCheckbox();
            this.TextBox_RdpPort = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_RdpPort = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_SslPort = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_SslPort = new MaterialSkin.Controls.MaterialLabel();
            this.TextBox_Cerr = new MaterialSkin.Controls.MaterialTextBox2();
            this.Label_Cerr = new MaterialSkin.Controls.MaterialLabel();
            this.NumericUpDown_Viewers = new System.Windows.Forms.NumericUpDown();
            this.Label_Viewers = new MaterialSkin.Controls.MaterialLabel();
            this.TabPage_Info = new System.Windows.Forms.TabPage();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TabControl.SuspendLayout();
            this.TabPage_Server.SuspendLayout();
            this.TabPage_Attendees.SuspendLayout();
            this.TabPage_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FrameInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Viewers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage_Server);
            this.TabControl.Controls.Add(this.TabPage_Attendees);
            this.TabControl.Controls.Add(this.TabPage_Settings);
            this.TabControl.Controls.Add(this.TabPage_Info);
            this.TabControl.Depth = 0;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImageList = this.ImageList;
            this.TabControl.Location = new System.Drawing.Point(3, 64);
            this.TabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(694, 433);
            this.TabControl.TabIndex = 0;
            // 
            // TabPage_Server
            // 
            this.TabPage_Server.Controls.Add(this.MultiTextBox_Logs);
            this.TabPage_Server.Controls.Add(this.Button_Resume);
            this.TabPage_Server.Controls.Add(this.Button_Pause);
            this.TabPage_Server.Controls.Add(this.Button_Start);
            this.TabPage_Server.ImageKey = "Local.png";
            this.TabPage_Server.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Server.Name = "TabPage_Server";
            this.TabPage_Server.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Server.Size = new System.Drawing.Size(686, 394);
            this.TabPage_Server.TabIndex = 0;
            this.TabPage_Server.Text = "Server";
            this.TabPage_Server.UseVisualStyleBackColor = true;
            // 
            // MultiTextBox_Logs
            // 
            this.MultiTextBox_Logs.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiTextBox_Logs.Location = new System.Drawing.Point(6, 6);
            this.MultiTextBox_Logs.Name = "MultiTextBox_Logs";
            this.MultiTextBox_Logs.ReadOnly = true;
            this.MultiTextBox_Logs.Size = new System.Drawing.Size(625, 363);
            this.MultiTextBox_Logs.TabIndex = 13;
            this.MultiTextBox_Logs.Text = "";
            // 
            // Button_Resume
            // 
            this.Button_Resume.AutoSize = false;
            this.Button_Resume.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Resume.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_Resume.Depth = 0;
            this.Button_Resume.Enabled = false;
            this.Button_Resume.HighEmphasis = true;
            this.Button_Resume.Icon = null;
            this.Button_Resume.Location = new System.Drawing.Point(187, 390);
            this.Button_Resume.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_Resume.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Resume.Name = "Button_Resume";
            this.Button_Resume.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_Resume.Size = new System.Drawing.Size(83, 25);
            this.Button_Resume.TabIndex = 12;
            this.Button_Resume.Text = "Resume";
            this.Button_Resume.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_Resume.UseAccentColor = false;
            this.Button_Resume.UseVisualStyleBackColor = true;
            this.Button_Resume.Click += new System.EventHandler(this.Button_Resume_Click);
            // 
            // Button_Pause
            // 
            this.Button_Pause.AutoSize = false;
            this.Button_Pause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Pause.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_Pause.Depth = 0;
            this.Button_Pause.Enabled = false;
            this.Button_Pause.HighEmphasis = true;
            this.Button_Pause.Icon = null;
            this.Button_Pause.Location = new System.Drawing.Point(278, 390);
            this.Button_Pause.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_Pause.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Pause.Name = "Button_Pause";
            this.Button_Pause.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_Pause.Size = new System.Drawing.Size(83, 25);
            this.Button_Pause.TabIndex = 11;
            this.Button_Pause.Text = "Pause";
            this.Button_Pause.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_Pause.UseAccentColor = false;
            this.Button_Pause.UseVisualStyleBackColor = true;
            this.Button_Pause.Click += new System.EventHandler(this.Button_Pause_Click);
            // 
            // Button_Start
            // 
            this.Button_Start.AutoSize = false;
            this.Button_Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Start.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_Start.Depth = 0;
            this.Button_Start.Enabled = false;
            this.Button_Start.HighEmphasis = true;
            this.Button_Start.Icon = null;
            this.Button_Start.Location = new System.Drawing.Point(369, 390);
            this.Button_Start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_Start.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_Start.Size = new System.Drawing.Size(83, 25);
            this.Button_Start.TabIndex = 10;
            this.Button_Start.Text = "Start";
            this.Button_Start.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_Start.UseAccentColor = false;
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // TabPage_Attendees
            // 
            this.TabPage_Attendees.Controls.Add(this.Label_Properties);
            this.TabPage_Attendees.Controls.Add(this.propertyGrid);
            this.TabPage_Attendees.Controls.Add(this.Label_Attendees);
            this.TabPage_Attendees.Controls.Add(this.ListBox_Attendees);
            this.TabPage_Attendees.ImageKey = "Attendees.png";
            this.TabPage_Attendees.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Attendees.Name = "TabPage_Attendees";
            this.TabPage_Attendees.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Attendees.Size = new System.Drawing.Size(686, 394);
            this.TabPage_Attendees.TabIndex = 1;
            this.TabPage_Attendees.Text = "Attendees";
            this.TabPage_Attendees.UseVisualStyleBackColor = true;
            // 
            // Label_Properties
            // 
            this.Label_Properties.AutoSize = true;
            this.Label_Properties.Depth = 0;
            this.Label_Properties.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Properties.Location = new System.Drawing.Point(228, 38);
            this.Label_Properties.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Properties.Name = "Label_Properties";
            this.Label_Properties.Size = new System.Drawing.Size(76, 19);
            this.Label_Properties.TabIndex = 3;
            this.Label_Properties.Text = "Properties:";
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.Location = new System.Drawing.Point(228, 60);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedItemWithFocusForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.Size = new System.Drawing.Size(403, 339);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            // 
            // Label_Attendees
            // 
            this.Label_Attendees.AutoSize = true;
            this.Label_Attendees.Depth = 0;
            this.Label_Attendees.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Attendees.Location = new System.Drawing.Point(6, 38);
            this.Label_Attendees.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Attendees.Name = "Label_Attendees";
            this.Label_Attendees.Size = new System.Drawing.Size(75, 19);
            this.Label_Attendees.TabIndex = 1;
            this.Label_Attendees.Text = "Attendees:";
            // 
            // ListBox_Attendees
            // 
            this.ListBox_Attendees.BackColor = System.Drawing.Color.White;
            this.ListBox_Attendees.BorderColor = System.Drawing.Color.LightGray;
            this.ListBox_Attendees.Depth = 0;
            this.ListBox_Attendees.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ListBox_Attendees.Location = new System.Drawing.Point(6, 60);
            this.ListBox_Attendees.MouseState = MaterialSkin.MouseState.HOVER;
            this.ListBox_Attendees.Name = "ListBox_Attendees";
            this.ListBox_Attendees.SelectedIndex = -1;
            this.ListBox_Attendees.SelectedItem = null;
            this.ListBox_Attendees.Size = new System.Drawing.Size(216, 339);
            this.ListBox_Attendees.TabIndex = 0;
            this.ListBox_Attendees.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.ListBox_Attendees_SelectedIndexChanged);
            // 
            // TabPage_Settings
            // 
            this.TabPage_Settings.Controls.Add(this.Button_Save);
            this.TabPage_Settings.Controls.Add(this.Button_Accept);
            this.TabPage_Settings.Controls.Add(this.CheckBox_Fips);
            this.TabPage_Settings.Controls.Add(this.NumericUpDown_FrameInterval);
            this.TabPage_Settings.Controls.Add(this.materialLabel5);
            this.TabPage_Settings.Controls.Add(this.TextBox_SessionPassword);
            this.TabPage_Settings.Controls.Add(this.Label_SessionPassword);
            this.TabPage_Settings.Controls.Add(this.Label_EmailPassword);
            this.TabPage_Settings.Controls.Add(this.TextBox_EmailPassword);
            this.TabPage_Settings.Controls.Add(this.TextBox_EmailManager);
            this.TabPage_Settings.Controls.Add(this.Label_EmailManager);
            this.TabPage_Settings.Controls.Add(this.CheckBox_ClipBoard);
            this.TabPage_Settings.Controls.Add(this.CheckBox_Autostart);
            this.TabPage_Settings.Controls.Add(this.TextBox_RdpPort);
            this.TabPage_Settings.Controls.Add(this.Label_RdpPort);
            this.TabPage_Settings.Controls.Add(this.TextBox_SslPort);
            this.TabPage_Settings.Controls.Add(this.Label_SslPort);
            this.TabPage_Settings.Controls.Add(this.TextBox_Cerr);
            this.TabPage_Settings.Controls.Add(this.Label_Cerr);
            this.TabPage_Settings.Controls.Add(this.NumericUpDown_Viewers);
            this.TabPage_Settings.Controls.Add(this.Label_Viewers);
            this.TabPage_Settings.ImageKey = "Properties.png";
            this.TabPage_Settings.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Settings.Name = "TabPage_Settings";
            this.TabPage_Settings.Size = new System.Drawing.Size(686, 394);
            this.TabPage_Settings.TabIndex = 2;
            this.TabPage_Settings.Text = "Settings";
            this.TabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // Button_Save
            // 
            this.Button_Save.AutoSize = false;
            this.Button_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_Save.Depth = 0;
            this.Button_Save.Enabled = false;
            this.Button_Save.HighEmphasis = true;
            this.Button_Save.Icon = null;
            this.Button_Save.Location = new System.Drawing.Point(464, 301);
            this.Button_Save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_Save.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_Save.Size = new System.Drawing.Size(83, 25);
            this.Button_Save.TabIndex = 20;
            this.Button_Save.Text = "Save";
            this.Button_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_Save.UseAccentColor = false;
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Accept
            // 
            this.Button_Accept.AutoSize = false;
            this.Button_Accept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Accept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Button_Accept.Depth = 0;
            this.Button_Accept.Enabled = false;
            this.Button_Accept.HighEmphasis = true;
            this.Button_Accept.Icon = null;
            this.Button_Accept.Location = new System.Drawing.Point(464, 261);
            this.Button_Accept.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Button_Accept.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Accept.Name = "Button_Accept";
            this.Button_Accept.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Button_Accept.Size = new System.Drawing.Size(83, 25);
            this.Button_Accept.TabIndex = 19;
            this.Button_Accept.Text = "Accept";
            this.Button_Accept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Button_Accept.UseAccentColor = false;
            this.Button_Accept.UseVisualStyleBackColor = true;
            this.Button_Accept.Click += new System.EventHandler(this.Button_Accept_Click);
            // 
            // CheckBox_Fips
            // 
            this.CheckBox_Fips.AutoSize = true;
            this.CheckBox_Fips.Depth = 0;
            this.CheckBox_Fips.Location = new System.Drawing.Point(456, 210);
            this.CheckBox_Fips.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBox_Fips.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBox_Fips.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_Fips.Name = "CheckBox_Fips";
            this.CheckBox_Fips.ReadOnly = false;
            this.CheckBox_Fips.Ripple = true;
            this.CheckBox_Fips.Size = new System.Drawing.Size(109, 37);
            this.CheckBox_Fips.TabIndex = 18;
            this.CheckBox_Fips.Text = "FIPS-Crypt";
            this.CheckBox_Fips.UseVisualStyleBackColor = true;
            // 
            // NumericUpDown_FrameInterval
            // 
            this.NumericUpDown_FrameInterval.Location = new System.Drawing.Point(263, 102);
            this.NumericUpDown_FrameInterval.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NumericUpDown_FrameInterval.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumericUpDown_FrameInterval.Name = "NumericUpDown_FrameInterval";
            this.NumericUpDown_FrameInterval.Size = new System.Drawing.Size(170, 20);
            this.NumericUpDown_FrameInterval.TabIndex = 17;
            this.NumericUpDown_FrameInterval.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(263, 80);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(143, 19);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Frame-Interval (ms):";
            // 
            // TextBox_SessionPassword
            // 
            this.TextBox_SessionPassword.AnimateReadOnly = false;
            this.TextBox_SessionPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_SessionPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_SessionPassword.Depth = 0;
            this.TextBox_SessionPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_SessionPassword.HideSelection = true;
            this.TextBox_SessionPassword.LeadingIcon = global::RdpServer.Properties.Resources.Secure;
            this.TextBox_SessionPassword.Location = new System.Drawing.Point(263, 322);
            this.TextBox_SessionPassword.MaxLength = 32767;
            this.TextBox_SessionPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_SessionPassword.Name = "TextBox_SessionPassword";
            this.TextBox_SessionPassword.PasswordChar = '●';
            this.TextBox_SessionPassword.PrefixSuffixText = null;
            this.TextBox_SessionPassword.ReadOnly = false;
            this.TextBox_SessionPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_SessionPassword.SelectedText = "";
            this.TextBox_SessionPassword.SelectionLength = 0;
            this.TextBox_SessionPassword.SelectionStart = 0;
            this.TextBox_SessionPassword.ShortcutsEnabled = true;
            this.TextBox_SessionPassword.Size = new System.Drawing.Size(170, 36);
            this.TextBox_SessionPassword.TabIndex = 15;
            this.TextBox_SessionPassword.TabStop = false;
            this.TextBox_SessionPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_SessionPassword.TrailingIcon = null;
            this.TextBox_SessionPassword.UseSystemPasswordChar = true;
            this.TextBox_SessionPassword.UseTallSize = false;
            this.TextBox_SessionPassword.TextChanged += new System.EventHandler(this.TextBox_SessionPassword_TextChanged);
            this.TextBox_SessionPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_SessionPassword_Validating);
            // 
            // Label_SessionPassword
            // 
            this.Label_SessionPassword.AutoSize = true;
            this.Label_SessionPassword.Depth = 0;
            this.Label_SessionPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_SessionPassword.Location = new System.Drawing.Point(263, 300);
            this.Label_SessionPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_SessionPassword.Name = "Label_SessionPassword";
            this.Label_SessionPassword.Size = new System.Drawing.Size(135, 19);
            this.Label_SessionPassword.TabIndex = 14;
            this.Label_SessionPassword.Text = "Session-Password:";
            // 
            // Label_EmailPassword
            // 
            this.Label_EmailPassword.AutoSize = true;
            this.Label_EmailPassword.Depth = 0;
            this.Label_EmailPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_EmailPassword.Location = new System.Drawing.Point(263, 221);
            this.Label_EmailPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_EmailPassword.Name = "Label_EmailPassword";
            this.Label_EmailPassword.Size = new System.Drawing.Size(119, 19);
            this.Label_EmailPassword.TabIndex = 13;
            this.Label_EmailPassword.Text = "Email-Password:";
            // 
            // TextBox_EmailPassword
            // 
            this.TextBox_EmailPassword.AnimateReadOnly = false;
            this.TextBox_EmailPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_EmailPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_EmailPassword.Depth = 0;
            this.TextBox_EmailPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_EmailPassword.HideSelection = true;
            this.TextBox_EmailPassword.LeadingIcon = global::RdpServer.Properties.Resources.Secure;
            this.TextBox_EmailPassword.Location = new System.Drawing.Point(263, 243);
            this.TextBox_EmailPassword.MaxLength = 32767;
            this.TextBox_EmailPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_EmailPassword.Name = "TextBox_EmailPassword";
            this.TextBox_EmailPassword.PasswordChar = '●';
            this.TextBox_EmailPassword.PrefixSuffixText = null;
            this.TextBox_EmailPassword.ReadOnly = false;
            this.TextBox_EmailPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_EmailPassword.SelectedText = "";
            this.TextBox_EmailPassword.SelectionLength = 0;
            this.TextBox_EmailPassword.SelectionStart = 0;
            this.TextBox_EmailPassword.ShortcutsEnabled = true;
            this.TextBox_EmailPassword.Size = new System.Drawing.Size(170, 36);
            this.TextBox_EmailPassword.TabIndex = 12;
            this.TextBox_EmailPassword.TabStop = false;
            this.TextBox_EmailPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_EmailPassword.TrailingIcon = null;
            this.TextBox_EmailPassword.UseSystemPasswordChar = true;
            this.TextBox_EmailPassword.UseTallSize = false;
            this.TextBox_EmailPassword.TextChanged += new System.EventHandler(this.TextBox_EmailPassword_TextChanged);
            this.TextBox_EmailPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_EmailPassword_Validating);
            // 
            // TextBox_EmailManager
            // 
            this.TextBox_EmailManager.AnimateReadOnly = false;
            this.TextBox_EmailManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_EmailManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_EmailManager.Depth = 0;
            this.TextBox_EmailManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_EmailManager.HideSelection = true;
            this.TextBox_EmailManager.LeadingIcon = global::RdpServer.Properties.Resources.Email;
            this.TextBox_EmailManager.Location = new System.Drawing.Point(263, 163);
            this.TextBox_EmailManager.MaxLength = 32767;
            this.TextBox_EmailManager.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_EmailManager.Name = "TextBox_EmailManager";
            this.TextBox_EmailManager.PasswordChar = '\0';
            this.TextBox_EmailManager.PrefixSuffixText = null;
            this.TextBox_EmailManager.ReadOnly = false;
            this.TextBox_EmailManager.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_EmailManager.SelectedText = "";
            this.TextBox_EmailManager.SelectionLength = 0;
            this.TextBox_EmailManager.SelectionStart = 0;
            this.TextBox_EmailManager.ShortcutsEnabled = true;
            this.TextBox_EmailManager.Size = new System.Drawing.Size(170, 36);
            this.TextBox_EmailManager.TabIndex = 11;
            this.TextBox_EmailManager.TabStop = false;
            this.TextBox_EmailManager.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_EmailManager.TrailingIcon = null;
            this.TextBox_EmailManager.UseSystemPasswordChar = false;
            this.TextBox_EmailManager.UseTallSize = false;
            this.TextBox_EmailManager.TextChanged += new System.EventHandler(this.TextBox_EmailManager_TextChanged);
            this.TextBox_EmailManager.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_EmailManager_Validating);
            // 
            // Label_EmailManager
            // 
            this.Label_EmailManager.AutoSize = true;
            this.Label_EmailManager.Depth = 0;
            this.Label_EmailManager.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_EmailManager.Location = new System.Drawing.Point(263, 142);
            this.Label_EmailManager.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_EmailManager.Name = "Label_EmailManager";
            this.Label_EmailManager.Size = new System.Drawing.Size(112, 19);
            this.Label_EmailManager.TabIndex = 10;
            this.Label_EmailManager.Text = "Email-Manager:";
            // 
            // CheckBox_ClipBoard
            // 
            this.CheckBox_ClipBoard.AutoSize = true;
            this.CheckBox_ClipBoard.Depth = 0;
            this.CheckBox_ClipBoard.Location = new System.Drawing.Point(456, 170);
            this.CheckBox_ClipBoard.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBox_ClipBoard.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBox_ClipBoard.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_ClipBoard.Name = "CheckBox_ClipBoard";
            this.CheckBox_ClipBoard.ReadOnly = false;
            this.CheckBox_ClipBoard.Ripple = true;
            this.CheckBox_ClipBoard.Size = new System.Drawing.Size(104, 37);
            this.CheckBox_ClipBoard.TabIndex = 9;
            this.CheckBox_ClipBoard.Text = "ClipBoard";
            this.CheckBox_ClipBoard.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Autostart
            // 
            this.CheckBox_Autostart.AutoSize = true;
            this.CheckBox_Autostart.Depth = 0;
            this.CheckBox_Autostart.Location = new System.Drawing.Point(456, 130);
            this.CheckBox_Autostart.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBox_Autostart.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBox_Autostart.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_Autostart.Name = "CheckBox_Autostart";
            this.CheckBox_Autostart.ReadOnly = false;
            this.CheckBox_Autostart.Ripple = true;
            this.CheckBox_Autostart.Size = new System.Drawing.Size(100, 37);
            this.CheckBox_Autostart.TabIndex = 8;
            this.CheckBox_Autostart.Text = "Autostart";
            this.CheckBox_Autostart.UseVisualStyleBackColor = true;
            // 
            // TextBox_RdpPort
            // 
            this.TextBox_RdpPort.AnimateReadOnly = false;
            this.TextBox_RdpPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_RdpPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_RdpPort.Depth = 0;
            this.TextBox_RdpPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_RdpPort.HideSelection = true;
            this.TextBox_RdpPort.LeadingIcon = global::RdpServer.Properties.Resources.Port;
            this.TextBox_RdpPort.Location = new System.Drawing.Point(66, 322);
            this.TextBox_RdpPort.MaxLength = 32767;
            this.TextBox_RdpPort.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_RdpPort.Name = "TextBox_RdpPort";
            this.TextBox_RdpPort.PasswordChar = '\0';
            this.TextBox_RdpPort.PrefixSuffixText = null;
            this.TextBox_RdpPort.ReadOnly = false;
            this.TextBox_RdpPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_RdpPort.SelectedText = "";
            this.TextBox_RdpPort.SelectionLength = 0;
            this.TextBox_RdpPort.SelectionStart = 0;
            this.TextBox_RdpPort.ShortcutsEnabled = true;
            this.TextBox_RdpPort.Size = new System.Drawing.Size(170, 36);
            this.TextBox_RdpPort.TabIndex = 7;
            this.TextBox_RdpPort.TabStop = false;
            this.TextBox_RdpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_RdpPort.TrailingIcon = null;
            this.TextBox_RdpPort.UseSystemPasswordChar = false;
            this.TextBox_RdpPort.UseTallSize = false;
            this.TextBox_RdpPort.TextChanged += new System.EventHandler(this.TextBox_RdpPort_TextChanged);
            this.TextBox_RdpPort.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_RdpPort_Validating);
            // 
            // Label_RdpPort
            // 
            this.Label_RdpPort.AutoSize = true;
            this.Label_RdpPort.Depth = 0;
            this.Label_RdpPort.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_RdpPort.Location = new System.Drawing.Point(66, 300);
            this.Label_RdpPort.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_RdpPort.Name = "Label_RdpPort";
            this.Label_RdpPort.Size = new System.Drawing.Size(69, 19);
            this.Label_RdpPort.TabIndex = 6;
            this.Label_RdpPort.Text = "RDP-Port:";
            // 
            // TextBox_SslPort
            // 
            this.TextBox_SslPort.AnimateReadOnly = false;
            this.TextBox_SslPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_SslPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_SslPort.Depth = 0;
            this.TextBox_SslPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_SslPort.HideSelection = true;
            this.TextBox_SslPort.LeadingIcon = global::RdpServer.Properties.Resources.Port;
            this.TextBox_SslPort.Location = new System.Drawing.Point(66, 243);
            this.TextBox_SslPort.MaxLength = 32767;
            this.TextBox_SslPort.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_SslPort.Name = "TextBox_SslPort";
            this.TextBox_SslPort.PasswordChar = '\0';
            this.TextBox_SslPort.PrefixSuffixText = null;
            this.TextBox_SslPort.ReadOnly = false;
            this.TextBox_SslPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_SslPort.SelectedText = "";
            this.TextBox_SslPort.SelectionLength = 0;
            this.TextBox_SslPort.SelectionStart = 0;
            this.TextBox_SslPort.ShortcutsEnabled = true;
            this.TextBox_SslPort.Size = new System.Drawing.Size(170, 36);
            this.TextBox_SslPort.TabIndex = 5;
            this.TextBox_SslPort.TabStop = false;
            this.TextBox_SslPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_SslPort.TrailingIcon = null;
            this.TextBox_SslPort.UseSystemPasswordChar = false;
            this.TextBox_SslPort.UseTallSize = false;
            this.TextBox_SslPort.TextChanged += new System.EventHandler(this.TextBox_SslPort_TextChanged);
            this.TextBox_SslPort.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_SslPort_Validating);
            // 
            // Label_SslPort
            // 
            this.Label_SslPort.AutoSize = true;
            this.Label_SslPort.Depth = 0;
            this.Label_SslPort.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_SslPort.Location = new System.Drawing.Point(66, 221);
            this.Label_SslPort.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_SslPort.Name = "Label_SslPort";
            this.Label_SslPort.Size = new System.Drawing.Size(67, 19);
            this.Label_SslPort.TabIndex = 4;
            this.Label_SslPort.Text = "SSL-Port:";
            // 
            // TextBox_Cerr
            // 
            this.TextBox_Cerr.AnimateReadOnly = false;
            this.TextBox_Cerr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox_Cerr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBox_Cerr.Depth = 0;
            this.TextBox_Cerr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_Cerr.HideSelection = true;
            this.TextBox_Cerr.LeadingIcon = global::RdpServer.Properties.Resources.Cerr;
            this.TextBox_Cerr.Location = new System.Drawing.Point(66, 163);
            this.TextBox_Cerr.MaxLength = 32767;
            this.TextBox_Cerr.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBox_Cerr.Name = "TextBox_Cerr";
            this.TextBox_Cerr.PasswordChar = '\0';
            this.TextBox_Cerr.PrefixSuffixText = null;
            this.TextBox_Cerr.ReadOnly = false;
            this.TextBox_Cerr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_Cerr.SelectedText = "";
            this.TextBox_Cerr.SelectionLength = 0;
            this.TextBox_Cerr.SelectionStart = 0;
            this.TextBox_Cerr.ShortcutsEnabled = true;
            this.TextBox_Cerr.Size = new System.Drawing.Size(170, 36);
            this.TextBox_Cerr.TabIndex = 3;
            this.TextBox_Cerr.TabStop = false;
            this.TextBox_Cerr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_Cerr.TrailingIcon = null;
            this.TextBox_Cerr.UseSystemPasswordChar = false;
            this.TextBox_Cerr.UseTallSize = false;
            this.TextBox_Cerr.Click += new System.EventHandler(this.TextBox_Cerr_Click);
            this.TextBox_Cerr.TextChanged += new System.EventHandler(this.TextBox_Cerr_TextChanged);
            this.TextBox_Cerr.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Cerr_Validating);
            // 
            // Label_Cerr
            // 
            this.Label_Cerr.AutoSize = true;
            this.Label_Cerr.Depth = 0;
            this.Label_Cerr.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Cerr.Location = new System.Drawing.Point(66, 142);
            this.Label_Cerr.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Cerr.Name = "Label_Cerr";
            this.Label_Cerr.Size = new System.Drawing.Size(110, 19);
            this.Label_Cerr.TabIndex = 2;
            this.Label_Cerr.Text = "SSL-Certificate:";
            // 
            // NumericUpDown_Viewers
            // 
            this.NumericUpDown_Viewers.Location = new System.Drawing.Point(66, 102);
            this.NumericUpDown_Viewers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDown_Viewers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Viewers.Name = "NumericUpDown_Viewers";
            this.NumericUpDown_Viewers.Size = new System.Drawing.Size(170, 20);
            this.NumericUpDown_Viewers.TabIndex = 1;
            this.NumericUpDown_Viewers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_Viewers
            // 
            this.Label_Viewers.AutoSize = true;
            this.Label_Viewers.Depth = 0;
            this.Label_Viewers.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Viewers.Location = new System.Drawing.Point(66, 80);
            this.Label_Viewers.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Viewers.Name = "Label_Viewers";
            this.Label_Viewers.Size = new System.Drawing.Size(60, 19);
            this.Label_Viewers.TabIndex = 0;
            this.Label_Viewers.Text = "Viewers:";
            // 
            // TabPage_Info
            // 
            this.TabPage_Info.ImageKey = "Info.png";
            this.TabPage_Info.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Info.Name = "TabPage_Info";
            this.TabPage_Info.Size = new System.Drawing.Size(686, 394);
            this.TabPage_Info.TabIndex = 3;
            this.TabPage_Info.Text = "Info";
            this.TabPage_Info.UseVisualStyleBackColor = true;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Attendees.png");
            this.ImageList.Images.SetKeyName(1, "Info.png");
            this.ImageList.Images.SetKeyName(2, "Local.png");
            this.ImageList.Images.SetKeyName(3, "Properties.png");
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ServerWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.TabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControl;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServerWnd";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Desktop Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerWnd_FormClosed);
            this.Load += new System.EventHandler(this.ServerWnd_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPage_Server.ResumeLayout(false);
            this.TabPage_Attendees.ResumeLayout(false);
            this.TabPage_Attendees.PerformLayout();
            this.TabPage_Settings.ResumeLayout(false);
            this.TabPage_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FrameInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Viewers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControl;
        private System.Windows.Forms.TabPage TabPage_Server;
        private System.Windows.Forms.TabPage TabPage_Attendees;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.TabPage TabPage_Settings;
        private System.Windows.Forms.TabPage TabPage_Info;
        private MaterialSkin.Controls.MaterialButton Button_Start;
        private MaterialSkin.Controls.MaterialButton Button_Resume;
        private MaterialSkin.Controls.MaterialButton Button_Pause;
        private MaterialSkin.Controls.MaterialListBox ListBox_Attendees;
        private MaterialSkin.Controls.MaterialLabel Label_Attendees;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private MaterialSkin.Controls.MaterialLabel Label_Properties;
        private MaterialSkin.Controls.MaterialLabel Label_Viewers;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Viewers;
        private MaterialSkin.Controls.MaterialLabel Label_Cerr;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_Cerr;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_SslPort;
        private MaterialSkin.Controls.MaterialLabel Label_SslPort;
        private MaterialSkin.Controls.MaterialLabel Label_RdpPort;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_RdpPort;
        private MaterialSkin.Controls.MaterialCheckbox CheckBox_ClipBoard;
        private MaterialSkin.Controls.MaterialCheckbox CheckBox_Autostart;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_EmailManager;
        private MaterialSkin.Controls.MaterialLabel Label_EmailManager;
        private MaterialSkin.Controls.MaterialLabel Label_EmailPassword;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_EmailPassword;
        private MaterialSkin.Controls.MaterialTextBox2 TextBox_SessionPassword;
        private MaterialSkin.Controls.MaterialLabel Label_SessionPassword;
        private System.Windows.Forms.NumericUpDown NumericUpDown_FrameInterval;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialCheckbox CheckBox_Fips;
        private MaterialSkin.Controls.MaterialButton Button_Save;
        private MaterialSkin.Controls.MaterialButton Button_Accept;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox MultiTextBox_Logs;
    }
}

