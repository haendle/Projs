namespace Neophron
{
    partial class ListeningDialog2
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
            Label label7;
            Label label8;
            Label label9;
            Label label10;
            Label label11;
            Label label12;
            StunHost_EnterBox = new TextBox();
            StunPort_EnterBox = new TextBox();
            SmtpHost_EnterBox = new TextBox();
            SmtpPort_EnterBox = new TextBox();
            TlsCerr_EnterBox = new TextBox();
            Email_EnterBox = new TextBox();
            EmailPass_EnterBox = new TextBox();
            SessionPass_EnterBox = new TextBox();
            ControlLvl_Enterbox = new TextBox();
            Viewers_EnterBox = new TextBox();
            NetworkInfoBox = new RichTextBox();
            Endpoint_EnterBox = new TextBox();
            GetButton = new Button();
            StartButton = new Button();
            openFileDialog = new OpenFileDialog();
            errorProvider = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Stun-Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Stun-Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "Smtp-Host:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 6;
            label4.Text = "Smtp-Port:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 232);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 8;
            label5.Text = "TLS-Certificate:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(207, 9);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 10;
            label6.Text = "Email-Manager:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(207, 63);
            label7.Name = "label7";
            label7.Size = new Size(141, 15);
            label7.TabIndex = 12;
            label7.Text = "External-Email-Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(207, 119);
            label8.Name = "label8";
            label8.Size = new Size(104, 15);
            label8.TabIndex = 14;
            label8.Text = "Session-Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(207, 175);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 16;
            label9.Text = "Control-Level:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(207, 232);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 18;
            label10.Text = "Viewers:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(398, 9);
            label11.Name = "label11";
            label11.Size = new Size(153, 15);
            label11.TabIndex = 20;
            label11.Text = "External/Internal Endpoints:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(398, 175);
            label12.Name = "label12";
            label12.Size = new Size(151, 15);
            label12.TabIndex = 22;
            label12.Text = "Remote-External-Endpoint:";
            // 
            // StunHost_EnterBox
            // 
            StunHost_EnterBox.Location = new Point(12, 27);
            StunHost_EnterBox.Name = "StunHost_EnterBox";
            StunHost_EnterBox.Size = new Size(165, 23);
            StunHost_EnterBox.TabIndex = 1;
            StunHost_EnterBox.Text = "stun.schlund.de";
            StunHost_EnterBox.TextChanged += StunHost_EnterBox_TextChanged;
            StunHost_EnterBox.Validating += StunHost_EnterBox_Validating;
            // 
            // StunPort_EnterBox
            // 
            StunPort_EnterBox.Location = new Point(12, 81);
            StunPort_EnterBox.Name = "StunPort_EnterBox";
            StunPort_EnterBox.Size = new Size(165, 23);
            StunPort_EnterBox.TabIndex = 3;
            StunPort_EnterBox.Text = "3478";
            StunPort_EnterBox.TextChanged += StunPort_EnterBox_TextChanged;
            StunPort_EnterBox.Validating += StunPort_EnterBox_Validating;
            // 
            // SmtpHost_EnterBox
            // 
            SmtpHost_EnterBox.Location = new Point(12, 137);
            SmtpHost_EnterBox.Name = "SmtpHost_EnterBox";
            SmtpHost_EnterBox.Size = new Size(165, 23);
            SmtpHost_EnterBox.TabIndex = 5;
            SmtpHost_EnterBox.Text = "smtp.mail.ru";
            SmtpHost_EnterBox.TextChanged += SmtpHost_EnterBox_TextChanged;
            SmtpHost_EnterBox.Validating += SmtpHost_EnterBox_Validating;
            // 
            // SmtpPort_EnterBox
            // 
            SmtpPort_EnterBox.Location = new Point(12, 193);
            SmtpPort_EnterBox.Name = "SmtpPort_EnterBox";
            SmtpPort_EnterBox.Size = new Size(165, 23);
            SmtpPort_EnterBox.TabIndex = 7;
            SmtpPort_EnterBox.Text = "587";
            SmtpPort_EnterBox.TextChanged += SmtpPort_EnterBox_TextChanged;
            SmtpPort_EnterBox.Validating += SmtpPort_EnterBox_Validating;
            // 
            // TlsCerr_EnterBox
            // 
            TlsCerr_EnterBox.Location = new Point(12, 250);
            TlsCerr_EnterBox.Name = "TlsCerr_EnterBox";
            TlsCerr_EnterBox.Size = new Size(165, 23);
            TlsCerr_EnterBox.TabIndex = 9;
            TlsCerr_EnterBox.Click += TlsCerr_EnterBox_Click;
            TlsCerr_EnterBox.TextChanged += TlsCerr_EnterBox_TextChanged;
            TlsCerr_EnterBox.Validating += TlsCerr_EnterBox_Validating;
            // 
            // Email_EnterBox
            // 
            Email_EnterBox.Location = new Point(207, 27);
            Email_EnterBox.Name = "Email_EnterBox";
            Email_EnterBox.Size = new Size(165, 23);
            Email_EnterBox.TabIndex = 11;
            Email_EnterBox.Text = "haendlle@mail.ru";
            Email_EnterBox.TextChanged += Email_EnterBox_TextChanged;
            Email_EnterBox.Validating += Email_EnterBox_Validating;
            // 
            // EmailPass_EnterBox
            // 
            EmailPass_EnterBox.Location = new Point(207, 81);
            EmailPass_EnterBox.Name = "EmailPass_EnterBox";
            EmailPass_EnterBox.PasswordChar = '*';
            EmailPass_EnterBox.Size = new Size(165, 23);
            EmailPass_EnterBox.TabIndex = 13;
            EmailPass_EnterBox.Text = "xRquz76u9qYYmGahDdpp";
            EmailPass_EnterBox.TextChanged += EmailPass_EnterBox_TextChanged;
            EmailPass_EnterBox.Validating += EmailPass_EnterBox_Validating;
            // 
            // SessionPass_EnterBox
            // 
            SessionPass_EnterBox.Location = new Point(207, 137);
            SessionPass_EnterBox.Name = "SessionPass_EnterBox";
            SessionPass_EnterBox.PasswordChar = '*';
            SessionPass_EnterBox.Size = new Size(165, 23);
            SessionPass_EnterBox.TabIndex = 15;
            SessionPass_EnterBox.Text = "Pa$$w0rrrd";
            SessionPass_EnterBox.TextChanged += SessionPass_EnterBox_TextChanged;
            SessionPass_EnterBox.Validating += SessionPass_EnterBox_Validating;
            // 
            // ControlLvl_Enterbox
            // 
            ControlLvl_Enterbox.Location = new Point(207, 193);
            ControlLvl_Enterbox.Name = "ControlLvl_Enterbox";
            ControlLvl_Enterbox.Size = new Size(165, 23);
            ControlLvl_Enterbox.TabIndex = 17;
            ControlLvl_Enterbox.Text = "INTERACTIVE";
            ControlLvl_Enterbox.TextChanged += ControlLvl_Enterbox_TextChanged;
            ControlLvl_Enterbox.Validating += ControlLvl_Enterbox_Validating;
            // 
            // Viewers_EnterBox
            // 
            Viewers_EnterBox.Location = new Point(207, 250);
            Viewers_EnterBox.Name = "Viewers_EnterBox";
            Viewers_EnterBox.Size = new Size(165, 23);
            Viewers_EnterBox.TabIndex = 19;
            Viewers_EnterBox.Text = "4";
            Viewers_EnterBox.TextChanged += Viewers_EnterBox_TextChanged;
            Viewers_EnterBox.Validating += Viewers_EnterBox_Validating;
            // 
            // NetworkInfoBox
            // 
            NetworkInfoBox.Location = new Point(398, 27);
            NetworkInfoBox.Name = "NetworkInfoBox";
            NetworkInfoBox.ReadOnly = true;
            NetworkInfoBox.Size = new Size(190, 133);
            NetworkInfoBox.TabIndex = 21;
            NetworkInfoBox.Text = "";
            // 
            // Endpoint_EnterBox
            // 
            Endpoint_EnterBox.Enabled = false;
            Endpoint_EnterBox.Location = new Point(398, 193);
            Endpoint_EnterBox.Name = "Endpoint_EnterBox";
            Endpoint_EnterBox.Size = new Size(189, 23);
            Endpoint_EnterBox.TabIndex = 23;
            Endpoint_EnterBox.TextChanged += Endpoint_EnterBox_TextChanged;
            Endpoint_EnterBox.Validating += Endpoint_EnterBox_Validating;
            // 
            // GetButton
            // 
            GetButton.Location = new Point(398, 249);
            GetButton.Name = "GetButton";
            GetButton.Size = new Size(75, 23);
            GetButton.TabIndex = 24;
            GetButton.Text = "Get";
            GetButton.UseVisualStyleBackColor = true;
            GetButton.Click += GetButton_Click;
            // 
            // StartButton
            // 
            StartButton.Enabled = false;
            StartButton.Location = new Point(513, 250);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 25;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Cerr |*.pfx";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ListeningDialog2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 288);
            Controls.Add(StartButton);
            Controls.Add(GetButton);
            Controls.Add(Endpoint_EnterBox);
            Controls.Add(label12);
            Controls.Add(NetworkInfoBox);
            Controls.Add(label11);
            Controls.Add(Viewers_EnterBox);
            Controls.Add(label10);
            Controls.Add(ControlLvl_Enterbox);
            Controls.Add(label9);
            Controls.Add(SessionPass_EnterBox);
            Controls.Add(label8);
            Controls.Add(EmailPass_EnterBox);
            Controls.Add(label7);
            Controls.Add(Email_EnterBox);
            Controls.Add(label6);
            Controls.Add(TlsCerr_EnterBox);
            Controls.Add(label5);
            Controls.Add(SmtpPort_EnterBox);
            Controls.Add(label4);
            Controls.Add(SmtpHost_EnterBox);
            Controls.Add(label3);
            Controls.Add(StunPort_EnterBox);
            Controls.Add(label2);
            Controls.Add(StunHost_EnterBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListeningDialog2";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox StunHost_EnterBox;
        private TextBox StunPort_EnterBox;
        private TextBox SmtpHost_EnterBox;
        private TextBox SmtpPort_EnterBox;
        private TextBox TlsCerr_EnterBox;
        private TextBox Email_EnterBox;
        private TextBox EmailPass_EnterBox;
        private TextBox SessionPass_EnterBox;
        private TextBox ControlLvl_Enterbox;
        private TextBox Viewers_EnterBox;
        private RichTextBox NetworkInfoBox;
        private TextBox Endpoint_EnterBox;
        private Button GetButton;
        private Button StartButton;
        private OpenFileDialog openFileDialog;
        private ErrorProvider errorProvider;
    }
}