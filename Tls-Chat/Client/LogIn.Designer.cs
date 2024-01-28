namespace Client
{
    partial class LogIn
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
            components = new System.ComponentModel.Container();
            Label pwordLabel;
            Label unameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            groupBox = new GroupBox();
            authModeUp = new RadioButton();
            authModeIn = new RadioButton();
            submitBtn = new Button();
            pwordText = new TextBox();
            unameText = new TextBox();
            errorProvider = new ErrorProvider(components);
            pwordLabel = new Label();
            unameLabel = new Label();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // pwordLabel
            // 
            pwordLabel.AutoSize = true;
            pwordLabel.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            pwordLabel.Location = new Point(29, 139);
            pwordLabel.Name = "pwordLabel";
            pwordLabel.Size = new Size(69, 16);
            pwordLabel.TabIndex = 2;
            pwordLabel.Text = "Password:";
            // 
            // unameLabel
            // 
            unameLabel.AutoSize = true;
            unameLabel.BackColor = SystemColors.Control;
            unameLabel.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            unameLabel.Location = new Point(28, 51);
            unameLabel.Name = "unameLabel";
            unameLabel.Size = new Size(71, 16);
            unameLabel.TabIndex = 0;
            unameLabel.Text = "Username:";
            // 
            // groupBox
            // 
            groupBox.BackColor = SystemColors.Control;
            groupBox.Controls.Add(authModeUp);
            groupBox.Controls.Add(authModeIn);
            groupBox.Controls.Add(submitBtn);
            groupBox.Controls.Add(pwordText);
            groupBox.Controls.Add(pwordLabel);
            groupBox.Controls.Add(unameText);
            groupBox.Controls.Add(unameLabel);
            groupBox.Cursor = Cursors.Cross;
            groupBox.Location = new Point(12, 5);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(445, 310);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            // 
            // authModeUp
            // 
            authModeUp.AutoSize = true;
            authModeUp.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            authModeUp.Location = new Point(32, 242);
            authModeUp.Name = "authModeUp";
            authModeUp.Size = new Size(69, 20);
            authModeUp.TabIndex = 6;
            authModeUp.Text = "Sign Up";
            authModeUp.UseVisualStyleBackColor = true;
            authModeUp.CheckedChanged += authModeUp_CheckedChanged;
            // 
            // authModeIn
            // 
            authModeIn.AutoSize = true;
            authModeIn.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            authModeIn.Location = new Point(32, 213);
            authModeIn.Name = "authModeIn";
            authModeIn.Size = new Size(64, 20);
            authModeIn.TabIndex = 5;
            authModeIn.Text = "Sign In";
            authModeIn.UseVisualStyleBackColor = true;
            authModeIn.CheckedChanged += authModeIn_CheckedChanged;
            // 
            // submitBtn
            // 
            submitBtn.BackColor = SystemColors.ControlLight;
            submitBtn.Enabled = false;
            submitBtn.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            submitBtn.Location = new Point(334, 234);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(75, 23);
            submitBtn.TabIndex = 4;
            submitBtn.Text = "&Submit";
            submitBtn.UseVisualStyleBackColor = false;
            submitBtn.Click += submitBtn_Click;
            // 
            // pwordText
            // 
            pwordText.BorderStyle = BorderStyle.FixedSingle;
            pwordText.Font = new Font("Bahnschrift SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            pwordText.Location = new Point(32, 167);
            pwordText.MaxLength = 32;
            pwordText.Name = "pwordText";
            pwordText.ShortcutsEnabled = false;
            pwordText.Size = new Size(377, 23);
            pwordText.TabIndex = 3;
            pwordText.UseSystemPasswordChar = true;
            pwordText.WordWrap = false;
            pwordText.TextChanged += pwordText_TextChanged;
            pwordText.Validating += pwordText_Validating;
            // 
            // unameText
            // 
            unameText.BorderStyle = BorderStyle.FixedSingle;
            unameText.Font = new Font("Bahnschrift SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            unameText.Location = new Point(32, 79);
            unameText.MaxLength = 32;
            unameText.Name = "unameText";
            unameText.ShortcutsEnabled = false;
            unameText.Size = new Size(377, 23);
            unameText.TabIndex = 1;
            unameText.WordWrap = false;
            unameText.TextChanged += unameText_TextChanged;
            unameText.Validating += unameText_Validating;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 326);
            Controls.Add(groupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LogIn";
            Text = "LogIn";
            TopMost = true;
            FormClosing += LogIn_FormClosing;
            Load += LogIn_Load;
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox;
        private TextBox unameText;
        private TextBox pwordText;
        private Button submitBtn;
        private RadioButton authModeUp;
        private RadioButton authModeIn;
        private ErrorProvider errorProvider;
    }
}