namespace RdpClient.Forms
{
    partial class ViewerDialog
    {
        private System.ComponentModel.IContainer components = null;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerDialog));
            this.TabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPage_AxRdpViewer = new System.Windows.Forms.TabPage();
            this.axRDPViewer = new AxRDPCOMAPILib.AxRDPViewer();
            this.TabPage_SendFile = new System.Windows.Forms.TabPage();
            this.TabPage_RecvFile = new System.Windows.Forms.TabPage();
            this.TabPage_Attendees = new System.Windows.Forms.TabPage();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.Label_Properties = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Attendees = new MaterialSkin.Controls.MaterialLabel();
            this.ListBox_Attendees = new MaterialSkin.Controls.MaterialListBox();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TabControl.SuspendLayout();
            this.TabPage_AxRdpViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer)).BeginInit();
            this.TabPage_Attendees.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage_AxRdpViewer);
            this.TabControl.Controls.Add(this.TabPage_SendFile);
            this.TabControl.Controls.Add(this.TabPage_RecvFile);
            this.TabControl.Controls.Add(this.TabPage_Attendees);
            this.TabControl.Depth = 0;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImageList = this.ImageList;
            this.TabControl.Location = new System.Drawing.Point(3, 64);
            this.TabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(794, 383);
            this.TabControl.TabIndex = 0;
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // TabPage_AxRdpViewer
            // 
            this.TabPage_AxRdpViewer.Controls.Add(this.axRDPViewer);
            this.TabPage_AxRdpViewer.ImageKey = "Local.png";
            this.TabPage_AxRdpViewer.Location = new System.Drawing.Point(4, 35);
            this.TabPage_AxRdpViewer.Name = "TabPage_AxRdpViewer";
            this.TabPage_AxRdpViewer.Size = new System.Drawing.Size(786, 344);
            this.TabPage_AxRdpViewer.TabIndex = 5;
            this.TabPage_AxRdpViewer.Text = "RDP Session";
            this.TabPage_AxRdpViewer.UseVisualStyleBackColor = true;
            // 
            // axRDPViewer
            // 
            this.axRDPViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRDPViewer.Enabled = true;
            this.axRDPViewer.Location = new System.Drawing.Point(0, 0);
            this.axRDPViewer.Name = "axRDPViewer";
            this.axRDPViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRDPViewer.OcxState")));
            this.axRDPViewer.Size = new System.Drawing.Size(786, 344);
            this.axRDPViewer.TabIndex = 2;
            // 
            // TabPage_SendFile
            // 
            this.TabPage_SendFile.ImageKey = "Send.png";
            this.TabPage_SendFile.Location = new System.Drawing.Point(4, 35);
            this.TabPage_SendFile.Name = "TabPage_SendFile";
            this.TabPage_SendFile.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_SendFile.Size = new System.Drawing.Size(786, 344);
            this.TabPage_SendFile.TabIndex = 0;
            this.TabPage_SendFile.Text = "Send File";
            this.TabPage_SendFile.UseVisualStyleBackColor = true;
            // 
            // TabPage_RecvFile
            // 
            this.TabPage_RecvFile.ImageKey = "Recv.png";
            this.TabPage_RecvFile.Location = new System.Drawing.Point(4, 35);
            this.TabPage_RecvFile.Name = "TabPage_RecvFile";
            this.TabPage_RecvFile.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_RecvFile.Size = new System.Drawing.Size(786, 344);
            this.TabPage_RecvFile.TabIndex = 1;
            this.TabPage_RecvFile.Text = "Receive File";
            this.TabPage_RecvFile.UseVisualStyleBackColor = true;
            // 
            // TabPage_Attendees
            // 
            this.TabPage_Attendees.Controls.Add(this.propertyGrid);
            this.TabPage_Attendees.Controls.Add(this.Label_Properties);
            this.TabPage_Attendees.Controls.Add(this.Label_Attendees);
            this.TabPage_Attendees.Controls.Add(this.ListBox_Attendees);
            this.TabPage_Attendees.ImageKey = "Attendees.png";
            this.TabPage_Attendees.Location = new System.Drawing.Point(4, 35);
            this.TabPage_Attendees.Name = "TabPage_Attendees";
            this.TabPage_Attendees.Size = new System.Drawing.Size(786, 344);
            this.TabPage_Attendees.TabIndex = 2;
            this.TabPage_Attendees.Text = "Attendees";
            this.TabPage_Attendees.UseVisualStyleBackColor = true;
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.propertyGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.Location = new System.Drawing.Point(277, 38);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedItemWithFocusForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.propertyGrid.Size = new System.Drawing.Size(436, 324);
            this.propertyGrid.TabIndex = 4;
            this.propertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            // 
            // Label_Properties
            // 
            this.Label_Properties.AutoSize = true;
            this.Label_Properties.Depth = 0;
            this.Label_Properties.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Properties.Location = new System.Drawing.Point(278, 16);
            this.Label_Properties.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Properties.Name = "Label_Properties";
            this.Label_Properties.Size = new System.Drawing.Size(76, 19);
            this.Label_Properties.TabIndex = 3;
            this.Label_Properties.Text = "Properties:";
            // 
            // Label_Attendees
            // 
            this.Label_Attendees.AutoSize = true;
            this.Label_Attendees.Depth = 0;
            this.Label_Attendees.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Attendees.Location = new System.Drawing.Point(27, 16);
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
            this.ListBox_Attendees.Location = new System.Drawing.Point(27, 38);
            this.ListBox_Attendees.MouseState = MaterialSkin.MouseState.HOVER;
            this.ListBox_Attendees.Name = "ListBox_Attendees";
            this.ListBox_Attendees.SelectedIndex = -1;
            this.ListBox_Attendees.SelectedItem = null;
            this.ListBox_Attendees.Size = new System.Drawing.Size(244, 324);
            this.ListBox_Attendees.TabIndex = 0;
            this.ListBox_Attendees.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.ListBox_Attendees_SelectedIndexChanged);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Attendees.png");
            this.ImageList.Images.SetKeyName(1, "Info.png");
            this.ImageList.Images.SetKeyName(2, "Properties.png");
            this.ImageList.Images.SetKeyName(3, "Recv.png");
            this.ImageList.Images.SetKeyName(4, "Send.png");
            this.ImageList.Images.SetKeyName(5, "Local.png");
            // 
            // ViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControl;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewerDialog_FormClosed);
            this.Load += new System.EventHandler(this.ViewerDialog_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPage_AxRdpViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer)).EndInit();
            this.TabPage_Attendees.ResumeLayout(false);
            this.TabPage_Attendees.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControl;
        private System.Windows.Forms.TabPage TabPage_SendFile;
        private System.Windows.Forms.TabPage TabPage_RecvFile;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.TabPage TabPage_Attendees;
        private System.Windows.Forms.TabPage TabPage_AxRdpViewer;
        private AxRDPCOMAPILib.AxRDPViewer axRDPViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private MaterialSkin.Controls.MaterialListBox ListBox_Attendees;
        private MaterialSkin.Controls.MaterialLabel Label_Properties;
        private MaterialSkin.Controls.MaterialLabel Label_Attendees;
    }
}