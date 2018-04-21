namespace NewsAggregator
{
    partial class TweeterPinEntryForm
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
            this.labelWelcomeMessage = new System.Windows.Forms.Label();
            this.labelPIN = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.textfieldPIN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelWelcomeMessage
            // 
            this.labelWelcomeMessage.AutoSize = true;
            this.labelWelcomeMessage.Location = new System.Drawing.Point(12, 9);
            this.labelWelcomeMessage.Name = "labelWelcomeMessage";
            this.labelWelcomeMessage.Size = new System.Drawing.Size(318, 26);
            this.labelWelcomeMessage.TabIndex = 4;
            this.labelWelcomeMessage.Text = "Welcome to News Aggregator. To use app authentificate yourself.\nWe have generated" +
    " a link for you.";
            // 
            // labelPIN
            // 
            this.labelPIN.AutoSize = true;
            this.labelPIN.Location = new System.Drawing.Point(12, 73);
            this.labelPIN.Name = "labelPIN";
            this.labelPIN.Size = new System.Drawing.Size(100, 13);
            this.labelPIN.TabIndex = 8;
            this.labelPIN.Text = "Enter your PIN here";
            // 
            // loginButton
            // 
            this.loginButton.Enabled = false;
            this.loginButton.Location = new System.Drawing.Point(235, 68);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(76, 23);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.ClickLoginButton);
            // 
            // textfieldPIN
            // 
            this.textfieldPIN.Location = new System.Drawing.Point(118, 70);
            this.textfieldPIN.Name = "textfieldPIN";
            this.textfieldPIN.Size = new System.Drawing.Size(111, 20);
            this.textfieldPIN.TabIndex = 6;
            this.textfieldPIN.TextChanged += new System.EventHandler(this.TextfieldPIN_Changed);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 111);
            this.Controls.Add(this.labelPIN);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.textfieldPIN);
            this.Controls.Add(this.labelWelcomeMessage);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcomeMessage;
        private System.Windows.Forms.Label labelPIN;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox textfieldPIN;
    }
}