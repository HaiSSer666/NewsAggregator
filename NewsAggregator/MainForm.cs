using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void TweetTextCallback(string tweetText);
    public delegate void UpdateUI();
    public partial class MainForm : Form
    {
        public LoginManagerFacade loginManagerFacade);
        public PublishFacade publishFacade;

        public MainForm(LoginManagerFacade loginManagerFacade, PublishFacade publishFacade)
        {     
            InitializeComponent();
            this.loginManagerFacade = loginManagerFacade;
            this.publishFacade = publishFacade;

            loginManagerFacade.RestoreSession(SocialNetwork.Tweeter, (delegate ()
            {
                tweeterLoginButton.Enabled = false;
            }));
        }

        private void ClickButtonPublishPost(object sender, EventArgs e)
        {
                publishFacade.Publish(SocialNetwork.Tweeter, textboxTweet.Text, (delegate (Error error)
                {
                    if(error!=null)
                    {
                        MessageBox.Show(error.errorDescription);
                    }
                    else
                    {
                        MessageBox.Show("Your tweet was successfully published!");
                        textboxTweet.Clear();
                    }   
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
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    tweeterLoginButton.Enabled = false;
                }
            }));
        }

        private void facebookLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Facebook, (delegate (Error error)
            {
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    facebookLoginButton.Enabled = false;
                }
            }));
        }
    }
}