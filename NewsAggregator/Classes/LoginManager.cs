using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace NewsAggregator
{
    class LoginManager
    {
        private Serealizator serealizator = new Serealizator();

        public IAuthenticationContext authenticationContext { get; set; }
        public ITwitterCredentials appCredentials { get; set; }
        public IAuthenticatedUser authenticatedUser { get; set; }

        private const string CONSUMER_KEY = "YtCb9DV9tiVk143hwd8WxkvJx";
        private const string CONSUMER_SECRET = "8aSPJYvRT8djByuofStlwd1jL9TJwoMekhKCOybBsmZ8ld3qOJ";

        public void LoginWithPIN(ITwitterCredentials credentials)
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

        public bool RestoreSessionWithCredentials(ITwitterCredentials credentials)
        {
            UserCredentials userCredentials = serealizator.Deserealize();
            if (userCredentials != null)
            {
                credentials.AccessToken = userCredentials.userAccessToken;
                credentials.AccessTokenSecret = userCredentials.userAccessSecret;
                Auth.SetCredentials(credentials);
                authenticatedUser = User.GetAuthenticatedUser();
                return authenticatedUser != null;
            }
            return false;
        }

        public void Login(string PIN)
        {
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(PIN, this.authenticationContext);
            Auth.SetCredentials(userCredentials);
            authenticatedUser = User.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                serealizator.Serealize(credentialsToStore);
            }
        }

        public void SetAppCredentials()
        {
            this.appCredentials = new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET);
        }
    }
}
