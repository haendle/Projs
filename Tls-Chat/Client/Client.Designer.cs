namespace Client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            textBox = new TextBox();
            sendBtn = new Button();
            messageBox = new RichTextBox();
            pinBtn = new Button();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            closeToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Location = new Point(13, 366);
            textBox.MaxLength = 256;
            textBox.Name = "textBox";
            textBox.Size = new Size(294, 23);
            textBox.TabIndex = 1;
            textBox.TextChanged += textBox_TextChanged;
            // 
            // sendBtn
            // 
            sendBtn.Enabled = false;
            sendBtn.Location = new Point(313, 366);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(75, 23);
            sendBtn.TabIndex = 2;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // messageBox
            // 
            messageBox.BorderStyle = BorderStyle.FixedSingle;
            messageBox.Cursor = Cursors.Cross;
            messageBox.DetectUrls = false;
            messageBox.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            messageBox.Location = new Point(13, 15);
            messageBox.Name = "messageBox";
            messageBox.ReadOnly = true;
            messageBox.ShortcutsEnabled = false;
            messageBox.Size = new Size(456, 340);
            messageBox.TabIndex = 3;
            messageBox.Text = "";
            // 
            // pinBtn
            // 
            pinBtn.Location = new Point(394, 366);
            pinBtn.Name = "pinBtn";
            pinBtn.Size = new Size(75, 23);
            pinBtn.TabIndex = 4;
            pinBtn.Text = "Pin";
            pinBtn.UseVisualStyleBackColor = true;
            pinBtn.Click += pinBtn_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Neophron";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 402);
            Controls.Add(pinBtn);
            Controls.Add(messageBox);
            Controls.Add(sendBtn);
            Controls.Add(textBox);
            Cursor = Cursors.Cross;
            Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Client";
            Text = "Client";
            FormClosing += Client_FormClosing;
            Load += Client_Load;
            Resize += Client_Resize;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private Button sendBtn;
        private RichTextBox messageBox;
        private Button pinBtn;
        private ToolStripMenuItem closeToolStripMenuItem;
        public NotifyIcon notifyIcon;
        public ContextMenuStrip contextMenuStrip;
        private OpenFileDialog openFileDialog;
    }
}