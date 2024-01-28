namespace Neophron
{
    partial class ClientDialog
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
            menuStrip = new MenuStrip();
            interNetworkToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            fiToolStripMenuItem = new ToolStripMenuItem();
            sendToolStripMenuItem = new ToolStripMenuItem();
            receiveToolStripMenuItem = new ToolStripMenuItem();
            exterNetworkToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem1 = new ToolStripMenuItem();
            fileSharingToolStripMenuItem = new ToolStripMenuItem();
            sendToolStripMenuItem1 = new ToolStripMenuItem();
            receiveToolStripMenuItem1 = new ToolStripMenuItem();
            axRDPViewerBox = new GroupBox();
            openFileDialog = new OpenFileDialog();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { interNetworkToolStripMenuItem, exterNetworkToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(854, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // interNetworkToolStripMenuItem
            // 
            interNetworkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, fiToolStripMenuItem });
            interNetworkToolStripMenuItem.Name = "interNetworkToolStripMenuItem";
            interNetworkToolStripMenuItem.Size = new Size(107, 20);
            interNetworkToolStripMenuItem.Text = "Internal Network";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(135, 22);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // fiToolStripMenuItem
            // 
            fiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sendToolStripMenuItem, receiveToolStripMenuItem });
            fiToolStripMenuItem.Enabled = false;
            fiToolStripMenuItem.Name = "fiToolStripMenuItem";
            fiToolStripMenuItem.Size = new Size(135, 22);
            fiToolStripMenuItem.Text = "File Sharing";
            // 
            // sendToolStripMenuItem
            // 
            sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            sendToolStripMenuItem.Size = new Size(114, 22);
            sendToolStripMenuItem.Text = "Send";
            sendToolStripMenuItem.Click += sendToolStripMenuItem_Click;
            // 
            // receiveToolStripMenuItem
            // 
            receiveToolStripMenuItem.Name = "receiveToolStripMenuItem";
            receiveToolStripMenuItem.Size = new Size(114, 22);
            receiveToolStripMenuItem.Text = "Receive";
            receiveToolStripMenuItem.Click += receiveToolStripMenuItem_Click;
            // 
            // exterNetworkToolStripMenuItem
            // 
            exterNetworkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem1, fileSharingToolStripMenuItem });
            exterNetworkToolStripMenuItem.Name = "exterNetworkToolStripMenuItem";
            exterNetworkToolStripMenuItem.Size = new Size(109, 20);
            exterNetworkToolStripMenuItem.Text = "External Network";
            // 
            // connectToolStripMenuItem1
            // 
            connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            connectToolStripMenuItem1.Size = new Size(180, 22);
            connectToolStripMenuItem1.Text = "Connect";
            connectToolStripMenuItem1.Click += connectToolStripMenuItem1_Click;
            // 
            // fileSharingToolStripMenuItem
            // 
            fileSharingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sendToolStripMenuItem1, receiveToolStripMenuItem1 });
            fileSharingToolStripMenuItem.Enabled = false;
            fileSharingToolStripMenuItem.Name = "fileSharingToolStripMenuItem";
            fileSharingToolStripMenuItem.Size = new Size(180, 22);
            fileSharingToolStripMenuItem.Text = "File Sharing";
            // 
            // sendToolStripMenuItem1
            // 
            sendToolStripMenuItem1.Name = "sendToolStripMenuItem1";
            sendToolStripMenuItem1.Size = new Size(180, 22);
            sendToolStripMenuItem1.Text = "Send";
            // 
            // receiveToolStripMenuItem1
            // 
            receiveToolStripMenuItem1.Name = "receiveToolStripMenuItem1";
            receiveToolStripMenuItem1.Size = new Size(180, 22);
            receiveToolStripMenuItem1.Text = "Receive";
            // 
            // axRDPViewerBox
            // 
            axRDPViewerBox.Dock = DockStyle.Fill;
            axRDPViewerBox.Location = new Point(0, 24);
            axRDPViewerBox.Name = "axRDPViewerBox";
            axRDPViewerBox.Size = new Size(854, 435);
            axRDPViewerBox.TabIndex = 1;
            axRDPViewerBox.TabStop = false;
            // 
            // ClientDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 459);
            Controls.Add(axRDPViewerBox);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            Name = "ClientDialog";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem interNetworkToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem fiToolStripMenuItem;
        private ToolStripMenuItem sendToolStripMenuItem;
        private ToolStripMenuItem receiveToolStripMenuItem;
        private ToolStripMenuItem exterNetworkToolStripMenuItem;
        private GroupBox axRDPViewerBox;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem connectToolStripMenuItem1;
        private ToolStripMenuItem fileSharingToolStripMenuItem;
        private ToolStripMenuItem sendToolStripMenuItem1;
        private ToolStripMenuItem receiveToolStripMenuItem1;
    }
}