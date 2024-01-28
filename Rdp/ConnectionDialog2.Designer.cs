namespace Neophron
{
    partial class ConnectionDialog2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label label2;
            Label label3;
            Label label4;
            Label label6;
            Label label7;
            Label label8;
            Label label9;
            label1 = new Label();
            UserEnterBox = new TextBox();
            EmailEnterBox = new TextBox();
            NetworkInfoBox = new RichTextBox();
            EndpointEnterBox = new TextBox();
            label5 = new Label();
            HostEnterBox = new TextBox();
            GetInfoButton = new Button();
            SesPasswordEnterBox = new TextBox();
            InvitationBox = new RichTextBox();
            GetButton = new Button();
            PasteButton = new Button();
            ClearButton = new Button();
            ConnectButton = new Button();
            errorProvider = new ErrorProvider(components);
            StunAddrEnterBox = new TextBox();
            StunPortEnterBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(153, 15);
            label3.TabIndex = 4;
            label3.Text = "External/Internal Endpoints:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(215, 116);
            label4.Name = "label4";
            label4.Size = new Size(151, 15);
            label4.TabIndex = 6;
            label4.Text = "Remote-External-Endpoint:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 251);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 11;
            label6.Text = "Session-Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 304);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 13;
            label7.Text = "Invitation:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 62);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 19;
            label8.Text = "STUN-Address:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(216, 62);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 21;
            label9.Text = "STUN-Port:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // UserEnterBox
            // 
            UserEnterBox.Location = new Point(12, 27);
            UserEnterBox.Name = "UserEnterBox";
            UserEnterBox.Size = new Size(188, 23);
            UserEnterBox.TabIndex = 1;
            UserEnterBox.Text = "haendle";
            UserEnterBox.TextChanged += UserEnterBox_TextChanged;
            UserEnterBox.Validating += UserEnterBox_Validating;
            // 
            // EmailEnterBox
            // 
            EmailEnterBox.Location = new Point(215, 27);
            EmailEnterBox.Name = "EmailEnterBox";
            EmailEnterBox.Size = new Size(197, 23);
            EmailEnterBox.TabIndex = 3;
            EmailEnterBox.TextChanged += EmailEnterBox_TextChanged;
            EmailEnterBox.Validating += EmailEnterBox_Validating;
            // 
            // NetworkInfoBox
            // 
            NetworkInfoBox.Location = new Point(12, 134);
            NetworkInfoBox.Name = "NetworkInfoBox";
            NetworkInfoBox.ReadOnly = true;
            NetworkInfoBox.Size = new Size(188, 105);
            NetworkInfoBox.TabIndex = 5;
            NetworkInfoBox.Text = "";
            // 
            // EndpointEnterBox
            // 
            EndpointEnterBox.Enabled = false;
            EndpointEnterBox.Location = new Point(215, 134);
            EndpointEnterBox.Name = "EndpointEnterBox";
            EndpointEnterBox.Size = new Size(197, 23);
            EndpointEnterBox.TabIndex = 7;
            EndpointEnterBox.TextChanged += EndpointEnterBox_TextChanged;
            EndpointEnterBox.Validating += EndpointEnterBox_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(215, 169);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 8;
            label5.Text = "Remote-External-Host:";
            // 
            // HostEnterBox
            // 
            HostEnterBox.Enabled = false;
            HostEnterBox.Location = new Point(215, 187);
            HostEnterBox.Name = "HostEnterBox";
            HostEnterBox.Size = new Size(197, 23);
            HostEnterBox.TabIndex = 9;
            HostEnterBox.Text = "HAENDLE-1721";
            HostEnterBox.TextChanged += HostEnterBox_TextChanged;
            HostEnterBox.Validating += HostEnterBox_Validating;
            // 
            // GetInfoButton
            // 
            GetInfoButton.Location = new Point(215, 216);
            GetInfoButton.Name = "GetInfoButton";
            GetInfoButton.Size = new Size(199, 23);
            GetInfoButton.TabIndex = 10;
            GetInfoButton.Text = "Get Info";
            GetInfoButton.UseVisualStyleBackColor = true;
            GetInfoButton.Click += GetInfoButton_Click;
            // 
            // SesPasswordEnterBox
            // 
            SesPasswordEnterBox.Location = new Point(13, 269);
            SesPasswordEnterBox.Name = "SesPasswordEnterBox";
            SesPasswordEnterBox.PasswordChar = '*';
            SesPasswordEnterBox.Size = new Size(399, 23);
            SesPasswordEnterBox.TabIndex = 12;
            SesPasswordEnterBox.Text = "Pa$$w0rrrd";
            SesPasswordEnterBox.TextChanged += SesPasswordEnterBox_TextChanged;
            SesPasswordEnterBox.Validating += SesPasswordEnterBox_Validating;
            // 
            // InvitationBox
            // 
            InvitationBox.Location = new Point(13, 322);
            InvitationBox.Name = "InvitationBox";
            InvitationBox.ReadOnly = true;
            InvitationBox.Size = new Size(276, 80);
            InvitationBox.TabIndex = 14;
            InvitationBox.Text = "";
            // 
            // GetButton
            // 
            GetButton.Enabled = false;
            GetButton.Location = new Point(325, 321);
            GetButton.Name = "GetButton";
            GetButton.Size = new Size(75, 23);
            GetButton.TabIndex = 15;
            GetButton.Text = "Get";
            GetButton.UseVisualStyleBackColor = true;
            GetButton.Click += GetButton_Click;
            // 
            // PasteButton
            // 
            PasteButton.Enabled = false;
            PasteButton.Location = new Point(325, 350);
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(75, 23);
            PasteButton.TabIndex = 16;
            PasteButton.Text = "Paste";
            PasteButton.UseVisualStyleBackColor = true;
            PasteButton.Click += PasteButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Enabled = false;
            ClearButton.Location = new Point(325, 379);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 17;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Enabled = false;
            ConnectButton.Location = new Point(12, 418);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(405, 23);
            ConnectButton.TabIndex = 18;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // StunAddrEnterBox
            // 
            StunAddrEnterBox.Location = new Point(13, 80);
            StunAddrEnterBox.Name = "StunAddrEnterBox";
            StunAddrEnterBox.Size = new Size(187, 23);
            StunAddrEnterBox.TabIndex = 20;
            StunAddrEnterBox.Text = "stun.schlund.de";
            StunAddrEnterBox.TextChanged += StunAddrEnterBox_TextChanged;
            StunAddrEnterBox.Validating += StunAddrEnterBox_Validating;
            // 
            // StunPortEnterBox
            // 
            StunPortEnterBox.Location = new Point(215, 80);
            StunPortEnterBox.Name = "StunPortEnterBox";
            StunPortEnterBox.Size = new Size(197, 23);
            StunPortEnterBox.TabIndex = 22;
            StunPortEnterBox.Text = "3478";
            StunPortEnterBox.TextChanged += StunPortEnterBox_TextChanged;
            StunPortEnterBox.Validating += StunPortEnterBox_Validating;
            // 
            // ConnectionDialog2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 454);
            Controls.Add(StunPortEnterBox);
            Controls.Add(label9);
            Controls.Add(StunAddrEnterBox);
            Controls.Add(label8);
            Controls.Add(ConnectButton);
            Controls.Add(ClearButton);
            Controls.Add(PasteButton);
            Controls.Add(GetButton);
            Controls.Add(InvitationBox);
            Controls.Add(label7);
            Controls.Add(SesPasswordEnterBox);
            Controls.Add(label6);
            Controls.Add(GetInfoButton);
            Controls.Add(HostEnterBox);
            Controls.Add(label5);
            Controls.Add(EndpointEnterBox);
            Controls.Add(label4);
            Controls.Add(NetworkInfoBox);
            Controls.Add(label3);
            Controls.Add(EmailEnterBox);
            Controls.Add(label2);
            Controls.Add(UserEnterBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ConnectionDialog2";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserEnterBox;
        private TextBox EmailEnterBox;
        private RichTextBox NetworkInfoBox;
        private TextBox EndpointEnterBox;
        private Label label5;
        private TextBox HostEnterBox;
        private Button GetInfoButton;
        private TextBox SesPasswordEnterBox;
        private RichTextBox InvitationBox;
        private Button GetButton;
        private Button PasteButton;
        private Button ClearButton;
        private Button ConnectButton;
        private ErrorProvider errorProvider;
        private TextBox StunPortEnterBox;
        private TextBox StunAddrEnterBox;
    }
}