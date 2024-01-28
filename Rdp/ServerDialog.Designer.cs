namespace Neophron
{
    partial class ServerDialog
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
            userList = new ListBox();
            menuStrip1 = new MenuStrip();
            interNetworkToolStripMenuItem = new ToolStripMenuItem();
            startToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            exterNetworkToolStripMenuItem = new ToolStripMenuItem();
            startToolStripMenuItem1 = new ToolStripMenuItem();
            stopToolStripMenuItem1 = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // userList
            // 
            userList.FormattingEnabled = true;
            userList.ItemHeight = 15;
            userList.Location = new Point(12, 39);
            userList.Name = "userList";
            userList.Size = new Size(439, 274);
            userList.TabIndex = 0;
            userList.SelectedIndexChanged += userList_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { interNetworkToolStripMenuItem, exterNetworkToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(463, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // interNetworkToolStripMenuItem
            // 
            interNetworkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startToolStripMenuItem, stopToolStripMenuItem });
            interNetworkToolStripMenuItem.Name = "interNetworkToolStripMenuItem";
            interNetworkToolStripMenuItem.Size = new Size(88, 20);
            interNetworkToolStripMenuItem.Text = "InterNetwork";
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(98, 22);
            startToolStripMenuItem.Text = "Start";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(98, 22);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // exterNetworkToolStripMenuItem
            // 
            exterNetworkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startToolStripMenuItem1, stopToolStripMenuItem1 });
            exterNetworkToolStripMenuItem.Name = "exterNetworkToolStripMenuItem";
            exterNetworkToolStripMenuItem.Size = new Size(90, 20);
            exterNetworkToolStripMenuItem.Text = "ExterNetwork";
            // 
            // startToolStripMenuItem1
            // 
            startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            startToolStripMenuItem1.Size = new Size(180, 22);
            startToolStripMenuItem1.Text = "Start";
            startToolStripMenuItem1.Click += startToolStripMenuItem1_Click;
            // 
            // stopToolStripMenuItem1
            // 
            stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            stopToolStripMenuItem1.Size = new Size(180, 22);
            stopToolStripMenuItem1.Text = "Stop";
            // 
            // ServerDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 327);
            Controls.Add(userList);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "ServerDialog";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox userList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem interNetworkToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem exterNetworkToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem1;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem1;
        private OpenFileDialog openFileDialog;
    }
}