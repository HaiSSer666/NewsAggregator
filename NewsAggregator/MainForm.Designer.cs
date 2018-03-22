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
            this.loginButton = new System.Windows.Forms.Button();
            this.labelWelcomeMessage = new System.Windows.Forms.Label();
            this.textboxTweet = new System.Windows.Forms.RichTextBox();
            this.textfieldPIN = new System.Windows.Forms.TextBox();
            this.labelPIN = new System.Windows.Forms.Label();
            this.labelTweet = new System.Windows.Forms.Label();
            this.buttonPublishTweet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button login
            // 
            this.loginButton.Enabled = false;
            this.loginButton.Location = new System.Drawing.Point(225, 33);
            this.loginButton.Name = "buttonLogin";
            this.loginButton.Size = new System.Drawing.Size(76, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.ClickLoginButton);
            // 
            // label wecome message
            // 
            this.labelWelcomeMessage.AutoSize = true;
            this.labelWelcomeMessage.Location = new System.Drawing.Point(18, 9);
            this.labelWelcomeMessage.Name = "labelWelcomeMessage";
            this.labelWelcomeMessage.Size = new System.Drawing.Size(318, 13);
            this.labelWelcomeMessage.TabIndex = 3;
            this.labelWelcomeMessage.Text = "Welcome to News Aggregator. To use app authentificate yourself.";
            // 
            // text tweet
            // 
            this.textboxTweet.Enabled = false;
            this.textboxTweet.Location = new System.Drawing.Point(21, 93);
            this.textboxTweet.Name = "textboxTweet";
            this.textboxTweet.Size = new System.Drawing.Size(315, 75);
            this.textboxTweet.TabIndex = 4;
            this.textboxTweet.Text = "";
            this.textboxTweet.TextChanged += new System.EventHandler(this.TextboxTweet_Changed);
            // 
            // text pin
            // 
            this.textfieldPIN.Location = new System.Drawing.Point(124, 35);
            this.textfieldPIN.Name = "textfieldPIN";
            this.textfieldPIN.Size = new System.Drawing.Size(95, 20);
            this.textfieldPIN.TabIndex = 0;
            this.textfieldPIN.TextChanged += new System.EventHandler(this.TextfieldPIN_Changed);
            // 
            // label pin
            // 
            this.labelPIN.AutoSize = true;
            this.labelPIN.Location = new System.Drawing.Point(18, 38);
            this.labelPIN.Name = "labelPIN";
            this.labelPIN.Size = new System.Drawing.Size(100, 13);
            this.labelPIN.TabIndex = 5;
            this.labelPIN.Text = "Enter your PIN here";
            // 
            // label tweet
            // 
            this.labelTweet.AutoSize = true;
            this.labelTweet.Location = new System.Drawing.Point(21, 74);
            this.labelTweet.Name = "labelTweet";
            this.labelTweet.Size = new System.Drawing.Size(87, 13);
            this.labelTweet.TabIndex = 6;
            this.labelTweet.Text = "Write your tweet here:";
            // 
            // button publish tweet
            // 
            this.buttonPublishTweet.Enabled = false;
            this.buttonPublishTweet.Location = new System.Drawing.Point(225, 175);
            this.buttonPublishTweet.Name = "buttonPublishTweet";
            this.buttonPublishTweet.Size = new System.Drawing.Size(75, 23);
            this.buttonPublishTweet.TabIndex = 7;
            this.buttonPublishTweet.Text = "Publish";
            this.buttonPublishTweet.UseVisualStyleBackColor = true;
            this.buttonPublishTweet.Click += new System.EventHandler(this.ClickButtonPublishTweet);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 206);
            this.Controls.Add(this.buttonPublishTweet);
            this.Controls.Add(this.labelTweet);
            this.Controls.Add(this.labelPIN);
            this.Controls.Add(this.textboxTweet);
            this.Controls.Add(this.labelWelcomeMessage);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.textfieldPIN);
            this.Name = "MainForm";
            this.Text = "News Aggregator";
            //this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button buttonPublishTweet;
        private System.Windows.Forms.Label labelPIN;
        private System.Windows.Forms.Label labelTweet;
        private System.Windows.Forms.Label labelWelcomeMessage;
        private System.Windows.Forms.RichTextBox textboxTweet;
        private System.Windows.Forms.TextBox textfieldPIN;  
    }
}