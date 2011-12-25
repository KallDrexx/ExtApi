namespace ExtApi.Tester
{
    partial class fmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.lstParameters = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.btnRemoveParameter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConsumerSecret = new System.Windows.Forms.TextBox();
            this.txtTokenSecret = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtConsumerKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIncludeOAuth = new System.Windows.Forms.CheckBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditParam = new System.Windows.Forms.Button();
            this.lblStatusCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuiltUrl = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAPICallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base API URL:";
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(101, 27);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(394, 20);
            this.txtApiUrl.TabIndex = 1;
            this.txtApiUrl.TextChanged += new System.EventHandler(this.DataModifiedEvent);
            // 
            // lstParameters
            // 
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.Location = new System.Drawing.Point(12, 73);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(285, 160);
            this.lstParameters.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parameters:";
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(303, 73);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(65, 23);
            this.btnAddParameter.TabIndex = 3;
            this.btnAddParameter.Text = "Add";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // btnRemoveParameter
            // 
            this.btnRemoveParameter.Location = new System.Drawing.Point(303, 131);
            this.btnRemoveParameter.Name = "btnRemoveParameter";
            this.btnRemoveParameter.Size = new System.Drawing.Size(65, 23);
            this.btnRemoveParameter.TabIndex = 5;
            this.btnRemoveParameter.Text = "Remove Parameter";
            this.btnRemoveParameter.UseVisualStyleBackColor = true;
            this.btnRemoveParameter.Click += new System.EventHandler(this.btnRemoveParameter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConsumerSecret);
            this.groupBox1.Controls.Add(this.txtTokenSecret);
            this.groupBox1.Controls.Add(this.txtAccessToken);
            this.groupBox1.Controls.Add(this.txtConsumerKey);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkIncludeOAuth);
            this.groupBox1.Location = new System.Drawing.Point(395, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OAuth";
            // 
            // txtConsumerSecret
            // 
            this.txtConsumerSecret.Enabled = false;
            this.txtConsumerSecret.Location = new System.Drawing.Point(106, 81);
            this.txtConsumerSecret.Name = "txtConsumerSecret";
            this.txtConsumerSecret.Size = new System.Drawing.Size(214, 20);
            this.txtConsumerSecret.TabIndex = 8;
            this.txtConsumerSecret.TextChanged += new System.EventHandler(this.DataModifiedEvent);
            // 
            // txtTokenSecret
            // 
            this.txtTokenSecret.Enabled = false;
            this.txtTokenSecret.Location = new System.Drawing.Point(106, 133);
            this.txtTokenSecret.Name = "txtTokenSecret";
            this.txtTokenSecret.Size = new System.Drawing.Size(214, 20);
            this.txtTokenSecret.TabIndex = 10;
            this.txtTokenSecret.TextChanged += new System.EventHandler(this.DataModifiedEvent);
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Enabled = false;
            this.txtAccessToken.Location = new System.Drawing.Point(106, 107);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(214, 20);
            this.txtAccessToken.TabIndex = 9;
            this.txtAccessToken.TextChanged += new System.EventHandler(this.DataModifiedEvent);
            // 
            // txtConsumerKey
            // 
            this.txtConsumerKey.Enabled = false;
            this.txtConsumerKey.Location = new System.Drawing.Point(106, 55);
            this.txtConsumerKey.Name = "txtConsumerKey";
            this.txtConsumerKey.Size = new System.Drawing.Size(214, 20);
            this.txtConsumerKey.TabIndex = 7;
            this.txtConsumerKey.TextChanged += new System.EventHandler(this.DataModifiedEvent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Token Secret:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Access Token:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Consumer Secret:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Consumer Key:";
            // 
            // chkIncludeOAuth
            // 
            this.chkIncludeOAuth.AutoSize = true;
            this.chkIncludeOAuth.Location = new System.Drawing.Point(6, 19);
            this.chkIncludeOAuth.Name = "chkIncludeOAuth";
            this.chkIncludeOAuth.Size = new System.Drawing.Size(94, 17);
            this.chkIncludeOAuth.TabIndex = 6;
            this.chkIncludeOAuth.Text = "Include OAuth";
            this.chkIncludeOAuth.UseVisualStyleBackColor = true;
            this.chkIncludeOAuth.CheckedChanged += new System.EventHandler(this.chkIncludeOAuth_CheckedChanged);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(12, 315);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(723, 165);
            this.txtResults.TabIndex = 13;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(222, 239);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Call API";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Result:";
            // 
            // btnEditParam
            // 
            this.btnEditParam.Location = new System.Drawing.Point(303, 102);
            this.btnEditParam.Name = "btnEditParam";
            this.btnEditParam.Size = new System.Drawing.Size(65, 23);
            this.btnEditParam.TabIndex = 4;
            this.btnEditParam.Text = "Edit";
            this.btnEditParam.UseVisualStyleBackColor = true;
            this.btnEditParam.Click += new System.EventHandler(this.btnEditParam_Click);
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.AutoSize = true;
            this.lblStatusCode.Location = new System.Drawing.Point(75, 273);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(0, 13);
            this.lblStatusCode.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Final URL:";
            // 
            // txtBuiltUrl
            // 
            this.txtBuiltUrl.Location = new System.Drawing.Point(75, 289);
            this.txtBuiltUrl.Name = "txtBuiltUrl";
            this.txtBuiltUrl.ReadOnly = true;
            this.txtBuiltUrl.Size = new System.Drawing.Size(661, 20);
            this.txtBuiltUrl.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveAPICallToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAPICallToolStripMenuItem
            // 
            this.saveAPICallToolStripMenuItem.Name = "saveAPICallToolStripMenuItem";
            this.saveAPICallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAPICallToolStripMenuItem.Text = "Save";
            this.saveAPICallToolStripMenuItem.Click += new System.EventHandler(this.saveAPICallToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "New";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.newStripMenuItem1_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 492);
            this.Controls.Add(this.txtBuiltUrl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblStatusCode);
            this.Controls.Add(this.btnEditParam);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoveParameter);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstParameters);
            this.Controls.Add(this.txtApiUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmMain";
            this.Text = "ExtApi Web Api Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.ListBox lstParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.Button btnRemoveParameter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConsumerSecret;
        private System.Windows.Forms.TextBox txtTokenSecret;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.TextBox txtConsumerKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIncludeOAuth;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditParam;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuiltUrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAPICallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}