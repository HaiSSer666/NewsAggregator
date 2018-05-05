using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void TweetTextCallback(string tweetText);
    public delegate void UpdateUI();
    public partial class MainForm : Form
    {
        public LoginManagerFacade loginManagerFacade = new LoginManagerFacade();
        public PublishFacade publishFacade = new PublishFacade();

        public MainForm()
        {     
            InitializeComponent();

            loginManagerFacade.RestoreSession(SocialNetwork.Tweeter, (delegate ()
            {
                tweeterLoginButton.Enabled = false;
            }));
        }

        private void ClickButtonPublishPost(object sender, EventArgs e)
        {
                publishFacade.Publish(SocialNetwork.Tweeter, textboxTweet.Text, (delegate (Error error)
                {
                    error = null;
                    MessageBox.Show("Your tweet was successfully published!");
                    textboxTweet.Clear();
                }));
        }

        private void TextboxTweet_Changed(object sender, EventArgs e)
        {
            UpdateUI updateButtonPublish = () => buttonPublishPost.Enabled = textboxTweet.Text.Trim() != string.Empty && textboxTweet.Text.Trim().Length <= 140;
            updateButtonPublish(); 
        }

        private void tweeterLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Tweeter, (delegate (Error error)
            {
                tweeterLoginButton.Enabled = false;
            }));
        }

        private void facebookLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Facebook, (delegate (Error error)
            {
                facebookLoginButton.Enabled = false;
            }));
        }
    }
}