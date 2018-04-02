using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using Tweetinvi;
using Tweetinvi.Models;*/
/*using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;*/

namespace NewsAggregator
{
    public partial class MainForm : Form
    {
        private LoginManager loginManager = new LoginManager();
        private TweetManager tweetPublisher = new TweetManager();
        
        public MainForm()
        {
            InitializeComponent();
            loginManager.SetAppCredentials();
            if(loginManager.RestoreSessionWithCredentials(loginManager.appCredentials))
            {
                loginButton.Enabled = false;
                textfieldPIN.Enabled = false;
                textboxTweet.Enabled = true;
                MessageBox.Show("Hello. " + loginManager.authenticatedUser.Name + "! Now you can use app.");
            }
            else
            {
                MessageBox.Show("You are not authorised user, Please enter a valid PIN from the generated link.");
                loginManager.LoginWithPIN(loginManager.appCredentials);
            }
        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            try
            {
                loginManager.Login(textfieldPIN.Text);
                MessageBox.Show("Hello. " + loginManager.authenticatedUser.Name + "! Now you can use app.");
                loginButton.Enabled = false;
                textfieldPIN.Enabled = false;
                textboxTweet.Enabled = true;
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. There might be internet connection lost.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                MessageBox.Show("Error is occured. You have entered the wrong PIN.\n Try to authenticate one more time. ");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops something went wrong.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
            }
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

        private void TextfieldPIN_Changed(object sender, EventArgs e)
        {
            UpdateButtonLogin();
        }

        private void UpdateButtonLogin()
        {
            loginButton.Enabled = textfieldPIN.Text.Trim() != string.Empty;
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