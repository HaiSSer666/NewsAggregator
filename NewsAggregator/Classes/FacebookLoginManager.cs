using System;
using System.Collections.Generic;
using Facebook;

namespace NewsAggregator
{
    class FacebookLoginManager
    {
        private LoginCallback loginCallback;
        private FacebookClient fbClient;
        private BrowserForm browserform;

        public FacebookLoginManager()
        {
            this.fbClient = new FacebookClient();
        }

        public void Login(LoginCallback loginCallback)
        {
            browserform = new BrowserForm(GenerateLoginURL());
            browserform.ShowDialog();
        }

        public Uri GenerateLoginURL()
        {
            fbClient.AppId = "205222496927855";
            var loginParameters = new Dictionary<string, object>();
            loginParameters["client_secret"] = "4eb3cebdc4f8158c8c6ea747470e9b76";
            loginParameters["response_type"] = "code token";
            loginParameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            return fbClient.GetLoginUrl(loginParameters);
        }
    }
}
