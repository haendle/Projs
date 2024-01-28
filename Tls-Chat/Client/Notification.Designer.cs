namespace Client
{
    partial class Notification
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
            label = new Label();
            CloseNotify = new Button();
            pictureBox = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(72, 34);
            label.Name = "label";
            label.Size = new Size(79, 21);
            label.TabIndex = 0;
            label.Text = "Message";
            // 
            // Close
            // 
            CloseNotify.FlatAppearance.BorderSize = 0;
            CloseNotify.FlatStyle = FlatStyle.Flat;
            CloseNotify.ForeColor = SystemColors.Control;
            CloseNotify.Image = Properties.Resources.Cancel;
            CloseNotify.Location = new Point(237, 24);
            CloseNotify.Name = "Close";
            CloseNotify.Size = new Size(43, 41);
            CloseNotify.TabIndex = 1;
            CloseNotify.UseVisualStyleBackColor = true;
            CloseNotify.Click += Close_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.message;
            pictureBox.Location = new Point(12, 24);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(38, 41);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // timer
            // 
            timer.Interval = 5;
            timer.Tick += timer_Tick;
            // 
            // Notification
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(292, 88);
            Controls.Add(pictureBox);
            Controls.Add(CloseNotify);
            Controls.Add(label);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Notification";
            Text = "Notification";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private Button CloseNotify;
        private PictureBox pictureBox;
        public System.Windows.Forms.Timer timer;
    }
}