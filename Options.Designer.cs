namespace $safeprojectname$
{
    partial class Options
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
            this.wowPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.guildURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accountName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // wowPath
            // 
            this.wowPath.Location = new System.Drawing.Point(97, 12);
            this.wowPath.Name = "wowPath";
            this.wowPath.Size = new System.Drawing.Size(317, 20);
            this.wowPath.TabIndex = 0;
            this.wowPath.TextChanged += new System.EventHandler(this.addonPath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Einstellungen Zurücksetzen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guildURL
            // 
            this.guildURL.Location = new System.Drawing.Point(97, 38);
            this.guildURL.Name = "guildURL";
            this.guildURL.Size = new System.Drawing.Size(317, 20);
            this.guildURL.TabIndex = 2;
            this.guildURL.TextChanged += new System.EventHandler(this.guildURL_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "WoW Pfad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gilden Website";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account Name";
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(97, 64);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(317, 20);
            this.accountName.TabIndex = 6;
            this.accountName.TextChanged += new System.EventHandler(this.accountName_TextChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 260);
            this.Controls.Add(this.accountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guildURL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wowPath);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wowPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox guildURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accountName;
    }
}