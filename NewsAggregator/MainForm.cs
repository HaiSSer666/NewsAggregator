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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace NewsAggregator
{
    public partial class MainForm : Form
    {
        private IAuthenticationContext authenticationContext;
        private ITwitterCredentials appCredentials;

        public MainForm()
        {
            InitializeComponent();
            appCredentials = new TwitterCredentials("YtCb9DV9tiVk143hwd8WxkvJx", "8aSPJYvRT8djByuofStlwd1jL9TJwoMekhKCOybBsmZ8ld3qOJ");
            if(restoreSessionWithCredentials(appCredentials))
            {
                btnLogin.Enabled = false;
                txtPIN.Enabled = false;
                txtTweet.Enabled = true;
                //btnPublishTweet.Enabled = true;
            }
            else
            {
                loginWithCredentials(appCredentials);
            }
            
            /*Auth.SetUserCredentials("8nzlNUkr08dKsXzjI7ajKhegW", "tZS5wT8kMkqfL2pvGR0DwcVMhsCotWcPG2zay5B42f0vH1eryf", "974351464305975296-FZIBCunioFtTu5r7uFXR0PMMhaO2NBK", "NflD4vBGoLXXIAqjgCWGQbxFJuk2fdGUkwqI81oVKdo0T");
            Tweet.PublishTweet("App test 2");*/

            /*Tweet.PublishTweet("App test");

            // Get the details of the Authenticated User
            var authenticatedUser = User.GetAuthenticatedUser();
            var tweets = Timeline.GetHomeTimeline();

            foreach (ITweet tweet in tweets)
            {
                string name = tweet.CreatedBy.Name;
                string tweetText = tweet.FullText;
                Console.WriteLine(name+ "\n\n" + tweetText+ "\n=====");
            }
            */
        }

        private void loginWithCredentials(ITwitterCredentials credentials)
        {
            authenticationContext = AuthFlow.InitAuthentication(credentials);
            try
            {
                System.Diagnostics.Process.Start(authenticationContext.AuthorizationURL);
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. Authentication URL could not be generated.\n Try to start app one more time.");
                Application.Exit();
            }
        }

        private bool restoreSessionWithCredentials(ITwitterCredentials credentials)
        {
            UserCredentials userCredentials = deserealize();
            if(userCredentials!=null)
            {
                credentials.AccessToken = userCredentials.userAccessToken;
                credentials.AccessTokenSecret = userCredentials.userAccessSecret;
                Auth.SetCredentials(credentials);
                return User.GetAuthenticatedUser() != null;
            }
            return false;
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IAuthenticatedUser authenticatedUser;

            try
            {
                var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(txtPIN.Text, this.authenticationContext);
                Auth.SetCredentials(userCredentials);
                authenticatedUser = User.GetAuthenticatedUser();
                if(authenticatedUser != null)
                {
                    UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                    serealize(credentialsToStore);
                }
                MessageBox.Show("Hello. " + authenticatedUser.Name + "! Now you can use app.");
                btnLogin.Enabled = false;
                txtPIN.Enabled = false;
                txtTweet.Enabled = true;
            }
            /*catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. There might be internet connection lost.\n Try to authenticate one more time.");
                txtID.Clear();
                this.genarateURL();
            }*/
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                MessageBox.Show("Error is occured. You have entered the wrong PIN.\n Try to authenticate one more time. ");
                txtPIN.Clear();
                txtPIN.Enabled = true;
                //this.genarateURL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops something went wrong.\n Try to authenticate one more time.");
                txtPIN.Clear();
                txtPIN.Enabled = true;
                //this.genarateURL();
            }

        }

        private void btnPublishTweet_Click(object sender, EventArgs e)
        {
            try
            {
                //var user = User.GetAuthenticatedUser();
                //user.PublishTweet(txtTweet.Text.Trim());
                var tweet = Tweet.PublishTweet(txtTweet.Text.Trim());
                MessageBox.Show("Your tweet was published!");
                txtTweet.Clear();
            }
            catch (ArgumentException ex)
            {
                //Something went wrong with the arguments and request was not performed
                Console.WriteLine("Request parameters are invalid: '{0}'", ex.Message);
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                // Twitter API Request has been failed; Bad request, network failure or unauthorized request
                Console.WriteLine("Something went wrong when we tried to execute the http request : '{0}'", ex.TwitterDescription);
            }
        }
        
        private void serealize(UserCredentials userCredentials)
        {
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream("UserCredentials.bin",
                         FileMode.OpenOrCreate,
                         FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, userCredentials);
            stream.Close();
        }

        private UserCredentials deserealize()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                System.IO.Stream stream = new FileStream("UserCredentials.bin",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                UserCredentials userCredentials = (UserCredentials)formatter.Deserialize(stream);
                stream.Close();
                return userCredentials;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        private void txtPIN_Changed(object sender, EventArgs e)
        {
            updateButtonLogin();
        }

        private void updateButtonLogin()
        {
            btnLogin.Enabled = txtPIN.Text.Trim() != string.Empty;// && txtPIN.Text.Trim().Length == 7;
        }

        private void txtTweet_Changed(object sender, EventArgs e)
        {
            updateButtonPublish();
        }

        private void updateButtonPublish()
        {
            btnPublishTweet.Enabled = txtTweet.Text.Trim() != string.Empty && txtTweet.Text.Trim().Length <= 140;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public void genarateURL()
        {
            
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void lblTweets_Click(object sender, EventArgs e)
        {

        }

        
    }
}
