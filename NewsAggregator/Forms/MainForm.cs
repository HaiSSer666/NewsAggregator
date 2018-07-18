using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void TweetTextCallback(string tweetText);
    public delegate void UpdateUI();

    public partial class MainForm : Form
    {
        public LoginFacade loginManagerFacade; 
        public PublishFacade publishFacade;
        public FeedFacade feedFacade;

        private const int TWEET_SIZE = 140;

        public MainForm()
        {     
            InitializeComponent();

            FacebookService fbService = new FacebookService();

            this.loginManagerFacade = new LoginFacade(fbService);
            this.publishFacade = new PublishFacade();
            this.feedFacade = new FeedFacade(fbService);

            UserStorage.Storage().AddObserver(this, (User user) =>
            {
                //textboxTweet.BeginInvoke(new Action(() => textboxTweet.Text = user.firstName));
                //Console.WriteLine(user.firstName);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!USER UPDATED!!!!!!!!!!!!!!!!!!!!");
            });
            FeedStorage.Storage().AddObserver(this, (SortedSet<IFeedItem> feedItems) =>
            {
                //textBoxFeed.Invoke(new Action(() => textBoxFeed.Text = UnpackTweets(feedItems)));
                //Console.WriteLine(UnpackTweets(feedItems));
            });

            loginManagerFacade.RestoreSession(SocialNetwork.Tweeter, (delegate ()
            {
                tweeterLoginButton.Enabled = false;
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!SESSION TWEETER RESTORED!!!!!!!!!!!!!!!!!!!!");
            }));

            loginManagerFacade.RestoreSession(SocialNetwork.Facebook, (delegate ()
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!SESSION FB RESTORED!!!!!!!!!!!!!!!!!!!!");
                facebookLoginButton.Enabled = false;
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

        private void ButtonUpdateFeed_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            textBoxFeed.Clear();
            //feedFacade.GetFeed(SocialNetwork.Tweeter, (delegate (Error error)
            //{
            //    if (error != null)
            //    {
            //        MessageBox.Show(error.errorDescription);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Here are your tweeter feed!");
            //        this.Enabled = true;
            //    }
            //}));

            feedFacade.GetFeed(SocialNetwork.Facebook, (delegate (Error error)
            {
                if (error != null)
                {
                    MessageBox.Show(error.errorDescription);
                }
                else
                {
                    //MessageBox.Show("Here are your tweeter feed!");
                    //this.Enabled = true;
                }
            }));
        }

        private string UnpackTweets(SortedSet<IFeedItem> feedItems)
        {
            string feed = String.Empty;
            foreach (IFeedItem tweet in feedItems)
            {
                string tweetText = tweet.FullText;
                string creationTime = tweet.CreatedAt.ToString();
                string tweetAuthor = tweet.CreatedBy.ToString();
                feed += tweetAuthor + " " + creationTime + ":\n";
                feed += tweetText + "\n\n\n";
            }
            return feed;
        }
    }
}