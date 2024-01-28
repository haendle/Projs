namespace Neophron
{
    partial class ConnectionDialog
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
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label label6;
            userEnterBox = new TextBox();
            emailEnterBox = new TextBox();
            AddressEnterBox = new TextBox();
            InvitationBox = new RichTextBox();
            GetButton = new Button();
            PasteButton = new Button();
            ClearButton = new Button();
            ConnectButton = new Button();
            errorProvider = new ErrorProvider(components);
            PassEnterBox = new TextBox();
            HostEnterBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 120);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "Remote-Endpoint:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 64);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 3;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 232);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Invitation:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 173);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.TabIndex = 12;
            label5.Text = "Session-Password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 120);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 14;
            label6.Text = "Remote-Host:";
            // 
            // userEnterBox
            // 
            userEnterBox.Location = new Point(12, 27);
            userEnterBox.Name = "userEnterBox";
            userEnterBox.Size = new Size(391, 23);
            userEnterBox.TabIndex = 1;
            userEnterBox.Text = "haendle";
            userEnterBox.TextChanged += userEnterBox_TextChanged;
            userEnterBox.Validating += userEnterBox_Validating;
            // 
            // emailEnterBox
            // 
            emailEnterBox.Location = new Point(12, 82);
            emailEnterBox.Name = "emailEnterBox";
            emailEnterBox.Size = new Size(391, 23);
            emailEnterBox.TabIndex = 4;
            emailEnterBox.Text = "haendle@yandex.ru";
            emailEnterBox.TextChanged += emailEnterBox_TextChanged;
            emailEnterBox.Validating += emailEnterBox_Validating;
            // 
            // AddressEnterBox
            // 
            AddressEnterBox.Location = new Point(12, 138);
            AddressEnterBox.Name = "AddressEnterBox";
            AddressEnterBox.Size = new Size(171, 23);
            AddressEnterBox.TabIndex = 5;
            AddressEnterBox.TextChanged += AddressEnterBox_TextChanged;
            AddressEnterBox.Validating += AddressEnterBox_Validating;
            // 
            // InvitationBox
            // 
            InvitationBox.Location = new Point(12, 250);
            InvitationBox.Name = "InvitationBox";
            InvitationBox.ReadOnly = true;
            InvitationBox.Size = new Size(310, 80);
            InvitationBox.TabIndex = 7;
            InvitationBox.Text = "";
            // 
            // GetButton
            // 
            GetButton.Location = new Point(335, 249);
            GetButton.Name = "GetButton";
            GetButton.Size = new Size(75, 23);
            GetButton.TabIndex = 8;
            GetButton.Text = "Get ";
            GetButton.UseVisualStyleBackColor = true;
            GetButton.Click += GetButton_Click;
            // 
            // PasteButton
            // 
            PasteButton.Enabled = false;
            PasteButton.Location = new Point(335, 278);
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(75, 23);
            PasteButton.TabIndex = 9;
            PasteButton.Text = "Paste";
            PasteButton.UseVisualStyleBackColor = true;
            PasteButton.Click += PasteButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Enabled = false;
            ClearButton.Location = new Point(335, 307);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 10;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Enabled = false;
            ConnectButton.Location = new Point(12, 346);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(398, 23);
            ConnectButton.TabIndex = 11;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // PassEnterBox
            // 
            PassEnterBox.Location = new Point(13, 191);
            PassEnterBox.Name = "PassEnterBox";
            PassEnterBox.PasswordChar = '*';
            PassEnterBox.Size = new Size(390, 23);
            PassEnterBox.TabIndex = 13;
            PassEnterBox.Text = "Pa$$w0rrrd";
            PassEnterBox.TextChanged += PassEnterBox_TextChanged;
            PassEnterBox.Validating += PassEnterBox_Validating;
            // 
            // HostEnterBox
            // 
            HostEnterBox.Location = new Point(225, 138);
            HostEnterBox.Name = "HostEnterBox";
            HostEnterBox.Size = new Size(178, 23);
            HostEnterBox.TabIndex = 15;
            HostEnterBox.Text = "HAENDLE-1721";
            HostEnterBox.TextChanged += HostEnterBox_TextChanged;
            HostEnterBox.Validating += HostEnterBox_Validating;
            // 
            // ConnectionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 383);
            Controls.Add(HostEnterBox);
            Controls.Add(label6);
            Controls.Add(PassEnterBox);
            Controls.Add(label5);
            Controls.Add(ConnectButton);
            Controls.Add(ClearButton);
            Controls.Add(PasteButton);
            Controls.Add(GetButton);
            Controls.Add(InvitationBox);
            Controls.Add(label4);
            Controls.Add(AddressEnterBox);
            Controls.Add(emailEnterBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(userEnterBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ConnectionDialog";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox userEnterBox;
        private Label label2;
        private Label label3;
        private TextBox emailEnterBox;
        private TextBox AddressEnterBox;
        private Label label4;
        private RichTextBox InvitationBox;
        private Button GetButton;
        private Button PasteButton;
        private Button ClearButton;
        private Button ConnectButton;
        private ErrorProvider errorProvider;
        private TextBox PassEnterBox;
        private TextBox HostEnterBox;
    }
}