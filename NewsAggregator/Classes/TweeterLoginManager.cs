using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace NewsAggregator
{
    class TweeterLoginManager
    {
        private LoginCallback loginCallback;
        private Serealizator serealizator = new Serealizator();
        private TweeterPinEntryForm tweeterPinEntryForm = new TweeterPinEntryForm();
        private ITwitterCredentials appCredentials { get; set; }
        private IAuthenticationContext authenticationContext { get; set; }

        private const string CONSUMER_KEY = "YtCb9DV9tiVk143hwd8WxkvJx";
        private const string CONSUMER_SECRET = "8aSPJYvRT8djByuofStlwd1jL9TJwoMekhKCOybBsmZ8ld3qOJ";
        private const string PATH_TO_CREDENTIALS = "UserCredentials.bin";

        public TweeterLoginManager()
        {
            this.appCredentials = new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET);
        } 

        public void Login(LoginCallback loginCallback)
        {
            this.loginCallback = loginCallback;
            tweeterPinEntryForm.pinCallback = LoginWithPIN;
            GenerateAuthenticationPIN(appCredentials);
            tweeterPinEntryForm.ShowDialog();
        }

        public void LoginWithPIN(string PIN)
        {
            tweeterPinEntryForm.Close();
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(PIN, this.authenticationContext);
            Auth.SetCredentials(userCredentials);
            if (User.GetAuthenticatedUser() != null)
            {
                UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                serealizator.Serialize(credentialsToStore, PATH_TO_CREDENTIALS);
                this.loginCallback(null);
            }
            else
            {
                this.loginCallback(new Error("", 0, null));
            }
        }

        public void RestoreSession(RestoreCallback restoreCallback)
        {
            UserCredentials userCredentials = (UserCredentials)serealizator.Deserialize(PATH_TO_CREDENTIALS);
            if (userCredentials != null)
            {
                this.appCredentials.AccessToken = userCredentials.userAccessToken;
                this.appCredentials.AccessTokenSecret = userCredentials.userAccessSecret;
                Auth.SetCredentials(this.appCredentials);
                restoreCallback();
            }
        }

        public void GenerateAuthenticationPIN(ITwitterCredentials credentials)
        {
            authenticationContext = AuthFlow.InitAuthentication(this.appCredentials);
            System.Diagnostics.Process.Start(authenticationContext.AuthorizationURL);
        }   
    }
}
