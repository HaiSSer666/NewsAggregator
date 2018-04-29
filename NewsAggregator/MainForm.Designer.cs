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
            this.textboxTweet = new System.Windows.Forms.RichTextBox();
            this.labelTweet = new System.Windows.Forms.Label();
            this.buttonPublishPost = new System.Windows.Forms.Button();
            this.labelWelcomeMessage = new System.Windows.Forms.Label();
            this.tweeterLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxTweet
            //
            this.textboxTweet.Location = new System.Drawing.Point(21, 61);
            this.textboxTweet.Name = "textboxTweet";
            this.textboxTweet.Size = new System.Drawing.Size(315, 75);
            this.textboxTweet.TabIndex = 4;
            this.textboxTweet.Text = "";
            this.textboxTweet.TextChanged += new System.EventHandler(this.TextboxTweet_Changed);
            // 
            // labelTweet
            // 
            this.labelTweet.AutoSize = true;
            this.labelTweet.Location = new System.Drawing.Point(18, 35);
            this.labelTweet.Name = "labelTweet";
            this.labelTweet.Size = new System.Drawing.Size(111, 13);
            this.labelTweet.TabIndex = 6;
            this.labelTweet.Text = "Write your tweet here:";
            // 
            // buttonPublishTweet
            //
            this.buttonPublishPost.Enabled = false; 
            this.buttonPublishPost.Location = new System.Drawing.Point(236, 147);
            this.buttonPublishPost.Name = "buttonPublishTweet";
            this.buttonPublishPost.Size = new System.Drawing.Size(100, 23);
            this.buttonPublishPost.TabIndex = 7;
            this.buttonPublishPost.Text = "Publish tweet";
            this.buttonPublishPost.UseVisualStyleBackColor = true;
            this.buttonPublishPost.Click += new System.EventHandler(this.ClickButtonPublishPost);
            // 
            // labelWelcomeMessage
            // 
            this.labelWelcomeMessage.AutoSize = true;
            this.labelWelcomeMessage.Location = new System.Drawing.Point(18, 9);
            this.labelWelcomeMessage.Name = "labelWelcomeMessage";
            this.labelWelcomeMessage.Size = new System.Drawing.Size(152, 13);
            this.labelWelcomeMessage.TabIndex = 3;
            this.labelWelcomeMessage.Text = "Welcome to News Aggregator.";
            // 
            // tweeterLoginButton
            // 
            this.tweeterLoginButton.Location = new System.Drawing.Point(21, 147);
            this.tweeterLoginButton.Name = "tweeterLoginButton";
            this.tweeterLoginButton.Size = new System.Drawing.Size(100, 23);
            this.tweeterLoginButton.TabIndex = 8;
            this.tweeterLoginButton.Text = "Login to Tweeter";
            this.tweeterLoginButton.UseVisualStyleBackColor = true;
            this.tweeterLoginButton.Click += new System.EventHandler(this.tweeterLoginButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 182);
            this.Controls.Add(this.tweeterLoginButton);
            this.Controls.Add(this.buttonPublishPost);
            this.Controls.Add(this.labelTweet);
            this.Controls.Add(this.textboxTweet);
            this.Controls.Add(this.labelWelcomeMessage);
            this.Name = "MainForm";
            this.Text = "News Aggregator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPublishPost;
        private System.Windows.Forms.Label labelTweet;
        private System.Windows.Forms.RichTextBox textboxTweet;
        public System.Windows.Forms.Label labelWelcomeMessage;
        private System.Windows.Forms.Button tweeterLoginButton;
    }
}