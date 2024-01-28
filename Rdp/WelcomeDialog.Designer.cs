namespace Neophron
{
    partial class WelcomeDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            clientLaunch = new Button();
            serverLaunch = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(187, 34);
            label1.Name = "label1";
            label1.Size = new Size(107, 19);
            label1.TabIndex = 0;
            label1.Text = "Continue As...";
            // 
            // clientLaunch
            // 
            clientLaunch.Location = new Point(98, 67);
            clientLaunch.Name = "clientLaunch";
            clientLaunch.Size = new Size(94, 27);
            clientLaunch.TabIndex = 1;
            clientLaunch.Text = "Client";
            clientLaunch.UseVisualStyleBackColor = true;
            clientLaunch.Click += clientLaunch_Click;
            // 
            // serverLaunch
            // 
            serverLaunch.Location = new Point(290, 67);
            serverLaunch.Name = "serverLaunch";
            serverLaunch.Size = new Size(94, 27);
            serverLaunch.TabIndex = 2;
            serverLaunch.Text = "Server";
            serverLaunch.UseVisualStyleBackColor = true;
            serverLaunch.Click += serverLaunch_Click;
            // 
            // WelcomeDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 148);
            Controls.Add(serverLaunch);
            Controls.Add(clientLaunch);
            Controls.Add(label1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "WelcomeDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientLaunch;
        private Button serverLaunch;
    }
}