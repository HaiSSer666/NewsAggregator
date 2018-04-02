﻿using System;
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

        private IAuthenticationContext authenticationContext { get; set; }
        private ITwitterCredentials appCredentials { get; set; }
        private IAuthenticatedUser authenticatedUser { get; set; }

        private const string CONSUMER_KEY = "YtCb9DV9tiVk143hwd8WxkvJx";
        private const string CONSUMER_SECRET = "8aSPJYvRT8djByuofStlwd1jL9TJwoMekhKCOybBsmZ8ld3qOJ";
        private const string PATH_TO_CREDENTIALS = "UserCredentials.bin";

        public string userName;

        public LoginManager()
        {
            this.appCredentials = new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET);
        }

        public void LoginWithPIN()
        {
            authenticationContext = AuthFlow.InitAuthentication(this.appCredentials);
            System.Diagnostics.Process.Start(authenticationContext.AuthorizationURL);
        }

        public bool RestoreSessionWithCredentials()
        {
            UserCredentials userCredentials = (UserCredentials)serealizator.Deserealize(PATH_TO_CREDENTIALS);
            if (userCredentials != null)
            {
                this.appCredentials.AccessToken = userCredentials.userAccessToken;
                this.appCredentials.AccessTokenSecret = userCredentials.userAccessSecret;
                Auth.SetCredentials(this.appCredentials);
                authenticatedUser = User.GetAuthenticatedUser();
                userName = authenticatedUser.Name;
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
                userName = authenticatedUser.Name;
                UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                serealizator.Serealize(credentialsToStore, PATH_TO_CREDENTIALS);
            }
        }

        public void SetAppCredentials()
        {
            this.appCredentials = new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET);
        }
    }
}
