namespace NewsAggregator
{
    partial class MainForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtTweet = new System.Windows.Forms.RichTextBox();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.lblPIN = new System.Windows.Forms.Label();
            this.lblTweet = new System.Windows.Forms.Label();
            this.btnPublishTweet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(225, 33);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(18, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(318, 13);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome to News Aggregator. To use app authentificate yourself.";
            this.lblWelcome.Click += new System.EventHandler(this.lblTweets_Click);
            // 
            // txtTweet
            // 
            this.txtTweet.Enabled = false;
            this.txtTweet.Location = new System.Drawing.Point(21, 93);
            this.txtTweet.Name = "txtTweet";
            this.txtTweet.Size = new System.Drawing.Size(315, 75);
            this.txtTweet.TabIndex = 4;
            this.txtTweet.Text = "";
            this.txtTweet.TextChanged += new System.EventHandler(this.txtTweet_Changed);
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(124, 35);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(95, 20);
            this.txtPIN.TabIndex = 0;
            this.txtPIN.TextChanged += new System.EventHandler(this.txtPIN_Changed);
            // 
            // lblPIN
            // 
            this.lblPIN.AutoSize = true;
            this.lblPIN.Location = new System.Drawing.Point(18, 38);
            this.lblPIN.Name = "lblPIN";
            this.lblPIN.Size = new System.Drawing.Size(100, 13);
            this.lblPIN.TabIndex = 5;
            this.lblPIN.Text = "Enter your PIN here";
            // 
            // lblTweet
            // 
            this.lblTweet.AutoSize = true;
            this.lblTweet.Location = new System.Drawing.Point(21, 74);
            this.lblTweet.Name = "lblTweet";
            this.lblTweet.Size = new System.Drawing.Size(87, 13);
            this.lblTweet.TabIndex = 6;
            this.lblTweet.Text = "Write your tweet:";
            // 
            // btnPublishTweet
            // 
            this.btnPublishTweet.Enabled = false;
            this.btnPublishTweet.Location = new System.Drawing.Point(225, 175);
            this.btnPublishTweet.Name = "btnPublishTweet";
            this.btnPublishTweet.Size = new System.Drawing.Size(75, 23);
            this.btnPublishTweet.TabIndex = 7;
            this.btnPublishTweet.Text = "Publish";
            this.btnPublishTweet.UseVisualStyleBackColor = true;
            this.btnPublishTweet.Click += new System.EventHandler(this.btnPublishTweet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 206);
            this.Controls.Add(this.btnPublishTweet);
            this.Controls.Add(this.lblTweet);
            this.Controls.Add(this.lblPIN);
            this.Controls.Add(this.txtTweet);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPIN);
            this.Name = "MainForm";
            this.Text = "News Aggregator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.RichTextBox txtTweet;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label lblPIN;
        private System.Windows.Forms.Label lblTweet;
        private System.Windows.Forms.Button btnPublishTweet;
    }
}

