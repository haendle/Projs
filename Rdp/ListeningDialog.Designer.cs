namespace Neophron
{
    partial class ListeningDialog
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
            Label label11;
            NetworkInfoBox = new RichTextBox();
            PortEnterBox = new TextBox();
            HostInfoBox = new TextBox();
            SmtpHostEnterBox = new TextBox();
            SmtpPortEnterBox = new TextBox();
            TlsCerrPathEnterBox = new TextBox();
            EmailEnterBox = new TextBox();
            SesPassEnterBox = new TextBox();
            ExPassEnterBox = new TextBox();
            label10 = new Label();
            ControlEnterBox = new TextBox();
            ViewersEnterBox = new TextBox();
            StartButton = new Button();
            errorProvider = new ErrorProvider(components);
            openFileDialog = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(159, 15);
            label1.TabIndex = 0;
            label1.Text = "Available Internal-Addresses:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 168);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "TLS Internal-Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 113);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 4;
            label3.Text = "Host:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(224, 113);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 6;
            label4.Text = "SMTP-Host:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(224, 168);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 8;
            label5.Text = "SMTP Port:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 223);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 10;
            label6.Text = "TLS Certificate:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(224, 223);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 12;
            label7.Text = "Email-Manager:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 279);
            label8.Name = "label8";
            label8.Size = new Size(104, 15);
            label8.TabIndex = 14;
            label8.Text = "Session-Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(224, 279);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 16;
            label9.Text = "Mail-Password:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(224, 335);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 20;
            label11.Text = "Viewers:";
            // 
            // NetworkInfoBox
            // 
            NetworkInfoBox.Location = new Point(12, 27);
            NetworkInfoBox.Name = "NetworkInfoBox";
            NetworkInfoBox.ReadOnly = true;
            NetworkInfoBox.Size = new Size(382, 74);
            NetworkInfoBox.TabIndex = 1;
            NetworkInfoBox.Text = "";
            // 
            // PortEnterBox
            // 
            PortEnterBox.Location = new Point(12, 186);
            PortEnterBox.Name = "PortEnterBox";
            PortEnterBox.Size = new Size(167, 23);
            PortEnterBox.TabIndex = 3;
            PortEnterBox.Text = "49150";
            PortEnterBox.TextChanged += PortEnterBox_TextChanged;
            PortEnterBox.Validating += PortEnterBox_Validating;
            // 
            // HostInfoBox
            // 
            HostInfoBox.Location = new Point(12, 131);
            HostInfoBox.Name = "HostInfoBox";
            HostInfoBox.ReadOnly = true;
            HostInfoBox.Size = new Size(167, 23);
            HostInfoBox.TabIndex = 5;
            // 
            // SmtpHostEnterBox
            // 
            SmtpHostEnterBox.Location = new Point(224, 131);
            SmtpHostEnterBox.Name = "SmtpHostEnterBox";
            SmtpHostEnterBox.Size = new Size(170, 23);
            SmtpHostEnterBox.TabIndex = 7;
            SmtpHostEnterBox.Text = "smtp.mail.ru";
            SmtpHostEnterBox.TextChanged += SmtpHostEnterBox_TextChanged;
            SmtpHostEnterBox.Validating += SmtpHostEnterBox_Validating;
            // 
            // SmtpPortEnterBox
            // 
            SmtpPortEnterBox.Location = new Point(224, 186);
            SmtpPortEnterBox.Name = "SmtpPortEnterBox";
            SmtpPortEnterBox.Size = new Size(170, 23);
            SmtpPortEnterBox.TabIndex = 9;
            SmtpPortEnterBox.Text = "587";
            SmtpPortEnterBox.TextChanged += SmtpPortEnterBox_TextChanged;
            SmtpPortEnterBox.Validating += SmtpPortEnterBox_Validating;
            // 
            // TlsCerrPathEnterBox
            // 
            TlsCerrPathEnterBox.Location = new Point(12, 241);
            TlsCerrPathEnterBox.Name = "TlsCerrPathEnterBox";
            TlsCerrPathEnterBox.Size = new Size(167, 23);
            TlsCerrPathEnterBox.TabIndex = 11;
            TlsCerrPathEnterBox.Click += TlsCerrPathEnterBox_Click;
            TlsCerrPathEnterBox.TextChanged += TlsCerrPathEnterBox_TextChanged;
            TlsCerrPathEnterBox.Validating += TlsCerrPathEnterBox_Validating;
            // 
            // EmailEnterBox
            // 
            EmailEnterBox.Location = new Point(224, 241);
            EmailEnterBox.Name = "EmailEnterBox";
            EmailEnterBox.Size = new Size(170, 23);
            EmailEnterBox.TabIndex = 13;
            EmailEnterBox.Text = "haendlle@mail.ru";
            EmailEnterBox.TextChanged += EmailEnterBox_TextChanged;
            EmailEnterBox.Validating += EmailEnterBox_Validating;
            // 
            // SesPassEnterBox
            // 
            SesPassEnterBox.Location = new Point(12, 297);
            SesPassEnterBox.Name = "SesPassEnterBox";
            SesPassEnterBox.PasswordChar = '*';
            SesPassEnterBox.Size = new Size(167, 23);
            SesPassEnterBox.TabIndex = 15;
            SesPassEnterBox.Text = "Pa$$w0rrrd";
            SesPassEnterBox.TextChanged += SesPassEnterBox_TextChanged;
            SesPassEnterBox.Validating += SesPassEnterBox_Validating;
            // 
            // ExPassEnterBox
            // 
            ExPassEnterBox.Location = new Point(224, 297);
            ExPassEnterBox.Name = "ExPassEnterBox";
            ExPassEnterBox.PasswordChar = '*';
            ExPassEnterBox.Size = new Size(170, 23);
            ExPassEnterBox.TabIndex = 17;
            ExPassEnterBox.Text = "xRquz76u9qYYmGahDdpp";
            ExPassEnterBox.TextChanged += ExPassEnterBox_TextChanged;
            ExPassEnterBox.Validating += ExPassEnterBox_Validating;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 335);
            label10.Name = "label10";
            label10.Size = new Size(82, 15);
            label10.TabIndex = 18;
            label10.Text = "Control-Level:";
            // 
            // ControlEnterBox
            // 
            ControlEnterBox.Location = new Point(12, 353);
            ControlEnterBox.Name = "ControlEnterBox";
            ControlEnterBox.Size = new Size(167, 23);
            ControlEnterBox.TabIndex = 19;
            ControlEnterBox.Text = "INTERACTIVE";
            ControlEnterBox.TextChanged += ControlEnterBox_TextChanged;
            ControlEnterBox.Validating += ControlEnterBox_Validating;
            // 
            // ViewersEnterBox
            // 
            ViewersEnterBox.Location = new Point(224, 353);
            ViewersEnterBox.Name = "ViewersEnterBox";
            ViewersEnterBox.Size = new Size(170, 23);
            ViewersEnterBox.TabIndex = 21;
            ViewersEnterBox.Text = "4";
            ViewersEnterBox.TextChanged += ViewersEnterBox_TextChanged;
            ViewersEnterBox.Validating += ViewersEnterBox_Validating;
            // 
            // StartButton
            // 
            StartButton.Enabled = false;
            StartButton.Location = new Point(164, 391);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 22;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Cerr |*.pfx";
            // 
            // ListeningDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 429);
            Controls.Add(StartButton);
            Controls.Add(ViewersEnterBox);
            Controls.Add(label11);
            Controls.Add(ControlEnterBox);
            Controls.Add(label10);
            Controls.Add(ExPassEnterBox);
            Controls.Add(label9);
            Controls.Add(SesPassEnterBox);
            Controls.Add(label8);
            Controls.Add(EmailEnterBox);
            Controls.Add(label7);
            Controls.Add(TlsCerrPathEnterBox);
            Controls.Add(label6);
            Controls.Add(SmtpPortEnterBox);
            Controls.Add(label5);
            Controls.Add(SmtpHostEnterBox);
            Controls.Add(label4);
            Controls.Add(HostInfoBox);
            Controls.Add(label3);
            Controls.Add(PortEnterBox);
            Controls.Add(label2);
            Controls.Add(NetworkInfoBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListeningDialog";
            Load += ListeningDialog_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox NetworkInfoBox;
        private TextBox PortEnterBox;
        private TextBox HostInfoBox;
        private TextBox SmtpHostEnterBox;
        private TextBox SmtpPortEnterBox;
        private TextBox TlsCerrPathEnterBox;
        private TextBox EmailEnterBox;
        private TextBox SesPassEnterBox;
        private TextBox ExPassEnterBox;
        private Label label10;
        private TextBox ControlEnterBox;
        private TextBox ViewersEnterBox;
        private Button StartButton;
        private ErrorProvider errorProvider;
        private OpenFileDialog openFileDialog;
    }
}