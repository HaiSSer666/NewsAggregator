using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsAggregator
{
    public partial class MainForm : Form
    {
        private TweetManager tweetPublisher = new TweetManager();

        
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClickButtonPublishTweet(object sender, EventArgs e)
        {
            try
            {
                tweetPublisher.PublishTweet(textboxTweet.Text);
                MessageBox.Show("Your tweet was successfully published!");
                textboxTweet.Clear();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Request parameters are invalid: '{0}'", ex.Message);
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                Console.WriteLine("Something went wrong when we tried to execute the http request : '{0}'", ex.TwitterDescription);
            }
        }

        private void TextboxTweet_Changed(object sender, EventArgs e)
        {
            UpdateButtonPublish();
        }

        private void UpdateButtonPublish()
        {
            buttonPublishTweet.Enabled = textboxTweet.Text.Trim() != string.Empty && textboxTweet.Text.Trim().Length <= 140;
        }    
    }
}