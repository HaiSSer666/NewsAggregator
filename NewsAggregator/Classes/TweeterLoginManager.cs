﻿using System;
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

        public IAuthenticatedUser authenticatedUser;
        public TweeterUser tweeterUser = new TweeterUser();

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
            if (Tweetinvi.User.GetAuthenticatedUser() != null)
            {
                //TODO
                authenticatedUser = Tweetinvi.User.GetAuthenticatedUser();
                UserCredentials credentialsToStore = new UserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                serealizator.Serialize(credentialsToStore, PATH_TO_CREDENTIALS);
                //TODO
                FillTweeterUserInfo();
                MergeUserData();
                this.loginCallback(null);
            }
            else
            {
                this.loginCallback(new Error("TweeterErrorDomain", 0, "Failed to login to Tweeter"));
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
                //TODO
                authenticatedUser = Tweetinvi.User.GetAuthenticatedUser();
                FillTweeterUserInfo();
                MergeUserData();
                restoreCallback();
            }
        }

        public void GenerateAuthenticationPIN(ITwitterCredentials credentials)
        {
            authenticationContext = AuthFlow.InitAuthentication(this.appCredentials);
            System.Diagnostics.Process.Start(authenticationContext.AuthorizationURL);
        }

        //TODO
        public void FillTweeterUserInfo()
        {
            tweeterUser.firstName = authenticatedUser.Name;
            tweeterUser.email = authenticatedUser.Email;
            tweeterUser.id = authenticatedUser.Id.ToString();
        }

        //TODO
        public async void MergeUserData()
        {
            UserStorage userStorage = UserStorage.Storage();
            User user = await userStorage.GetAsync();
            user.firstName = tweeterUser.firstName;
            await userStorage.SetAsync(user);
        }
    }
}