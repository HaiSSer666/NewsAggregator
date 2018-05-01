using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void TweetTextCallback(string tweetText);

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
            try
            {
                publishFacade.Publish(SocialNetwork.Tweeter, textboxTweet.Text, (delegate ()
                {
                    MessageBox.Show("Your tweet was successfully published!");
                    textboxTweet.Clear();
                }));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Request parameters are invalid: '{0}'", ex.Message);
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                Console.WriteLine("Something went wrong when we tried to execute the http request : '{0}'", ex.TwitterDescription);
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                MessageBox.Show("You try to post without login. Please login first.");
            }
        }

        private void TextboxTweet_Changed(object sender, EventArgs e)
        {
            UpdateButtonPublish();
        }

        private void UpdateButtonPublish()
        {
            buttonPublishPost.Enabled = textboxTweet.Text.Trim() != string.Empty && textboxTweet.Text.Trim().Length <= 140;
        }

        private void OnFinish(Error error)
        {
            tweeterLoginButton.Enabled = false;
        }

        private void tweeterLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Tweeter, OnFinish);
        }

        private void facebookLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Facebook, OnFinish);
        }
    }
}