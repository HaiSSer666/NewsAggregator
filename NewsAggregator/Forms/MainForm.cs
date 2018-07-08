using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void TweetTextCallback(string tweetText);
    public delegate void UpdateUI();

    public partial class MainForm : Form
    {
        public LoginManagerFacade loginManagerFacade; 
        public PublishFacade publishFacade;
        public FeedFacade feedFacade;

        private const int TWEET_SIZE = 140;
        private const int MAXIMUN_TWEETS = 40;

        public MainForm(LoginManagerFacade loginManagerFacade, PublishFacade publishFacade, FeedFacade feedFacade)
        {     
            InitializeComponent();

            this.loginManagerFacade = loginManagerFacade;
            this.publishFacade = publishFacade;
            this.feedFacade = feedFacade;

            UserStorage.Storage().AddObserver(this, (User user) =>
            {
                //on user info is updated
                //textboxTweet.Invoke(new Action(() => textboxTweet.Text = user.firstName));
            });
            FeedStorage.Storage().AddObserver(this, (SortedSet<IFeedItem> feedItems) =>
            {
                textBoxFeed.Invoke(new Action(() => textBoxFeed.Text = UnpackTweets(feedItems)));
            });

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
            UpdateUI updateButtonPublish = (() => buttonPublishPost.Enabled = textboxTweet.Text.Trim() != string.Empty && textboxTweet.Text.Trim().Length <= TWEET_SIZE);
            updateButtonPublish(); 
        }

        private void TweeterLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Tweeter, (delegate (Error error)
            {
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    MessageBox.Show("You are logged to Tweeter.");
                    tweeterLoginButton.Enabled = false;
                }
            }));
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e)
        {
            loginManagerFacade.Login(SocialNetwork.Facebook, (delegate (Error error)
            {
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    MessageBox.Show("You are logged to FB.");
                    facebookLoginButton.Enabled = false;  
                }
            }));
        }

        private async void ButtonUpdateTweeterFeed_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            textBoxFeed.Clear();
            SortedSet<IFeedItem> feedItems = await feedFacade.GetFeed(SocialNetwork.Tweeter, MAXIMUN_TWEETS, (delegate (Error error)
            {
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    MessageBox.Show("Here are your tweeter feed!");
                    this.Enabled = true;
                }
            }));
            textBoxFeed.Text = UnpackTweets(feedItems);
        }

        private string UnpackTweets(SortedSet<IFeedItem> feedItems)
        {
            string feed = String.Empty;
            foreach (IFeedItem tweet in feedItems)
            {
                string tweetText = tweet.FullText;
                string tweetAuthor = tweet.CreatedBy.ToString();
                feed += tweetAuthor + ":\n";
                feed += tweetText + "\n\n\n";
            }
            return feed;
        }
    }
}