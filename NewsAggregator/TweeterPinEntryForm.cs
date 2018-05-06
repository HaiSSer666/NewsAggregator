using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void PinCallback(string PIN);

    public partial class TweeterPinEntryForm : Form
    {
        public PinCallback pinCallback;
        public string PIN;

        public TweeterPinEntryForm()
        {
            InitializeComponent();
        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            pinCallback(textfieldPIN.Text);
        }

        private void TextfieldPIN_Changed(object sender, EventArgs e)
        {
            UpdateButtonLogin();
        }

        private void UpdateButtonLogin()
        {
            loginButton.Enabled = textfieldPIN.Text.Trim() != string.Empty;
        }
    }
}