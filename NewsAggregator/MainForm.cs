using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;
/*using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;*/

namespace NewsAggregator
{
    public partial class MainForm : Form
    {
        private IAuthenticationContext authenticationContext;
        private ITwitterCredentials appCredentials;
        private Serealizator serealizator = new Serealizator();
        
        public MainForm()
        {
            InitializeComponent();
            appCredentials = new TwitterCredentials("YtCb9DV9tiVk143hwd8WxkvJx", "8aSPJYvRT8djByuofStlwd1jL9TJwoMekhKCOybBsmZ8ld3qOJ");
            if(RestoreSessionWithCredentials(appCredentials))
            {
                loginButton.Enabled = false;
                textfieldPIN.Enabled = false;
                textboxTweet.Enabled = true;
            }
            else
            {
                LoginWithPIN(appCredentials);
            }
        }

        private void LoginWithPIN(ITwitterCredentials credentials)
        {
            authenticationContext = AuthFlow.InitAuthentication(credentials);
            try
            {
                System.Diagnostics.Process.Start(authenticationContext.AuthorizationURL);
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. Authentication was not successful.\n Try to start app one more time.");
                Application.Exit();
            }
        }

        private bool RestoreSessionWithCredentials(ITwitterCredentials credentials)
        {
            UserCredentials userCredentials = serealizator.Deserealize();
            if(userCredentials!=null)
            {
                credentials.AccessToken = userCredentials.userAccessToken;
                credentials.AccessTokenSecret = userCredentials.userAccessSecret;
                Auth.SetCredentials(credentials);
                return User.GetAuthenticatedUser() != null;
            }
            return false;
        } 

        private void ClickLoginButton(object sender, EventArgs e)
        {
            IAuthenticatedUser authenticatedUser;

            try
            {
                var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(textfieldPIN.Text, this.authenticationContext);
                Auth.SetCredentials(userCredentials);
                authenticatedUser = User.GetAuthenticatedUser();
                if(authenticatedUser != null)
                {
                    UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                    serealizator.Serealize(credentialsToStore);
                }
                MessageBox.Show("Hello. " + authenticatedUser.Name + "! Now you can use app.");
                loginButton.Enabled = false;
                textfieldPIN.Enabled = false;
                textboxTweet.Enabled = true;
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. There might be internet connection lost.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
                //this.genarateURL();
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                MessageBox.Show("Error is occured. You have entered the wrong PIN.\n Try to authenticate one more time. ");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
                //this.genarateURL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops something went wrong.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
                //this.genarateURL();
            }
        }

        private void ClickButtonPublishTweet(object sender, EventArgs e)
        {
            try
            {
                var tweet = Tweet.PublishTweet(textboxTweet.Text.Trim());
                MessageBox.Show("Your tweet was published!");
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