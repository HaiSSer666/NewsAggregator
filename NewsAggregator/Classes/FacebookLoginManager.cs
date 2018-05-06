using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Facebook;

namespace NewsAggregator
{
    class FacebookLoginManager
    {
        private LoginCallback loginCallback;
        private FacebookClient fbClient;
        private BrowserForm browserform;

        private const string APP_ID = "205222496927855";
        private const string CLIENT_SECRET = "4eb3cebdc4f8158c8c6ea747470e9b76";
        private const string REDIRECT_TYPE = "code token";
        private string access_tocken;
        private Uri REDIRECT_URL = new Uri("https://www.facebook.com/connect/login_success.html");

        public FacebookLoginManager()
        {
            this.fbClient = new FacebookClient();
        }

        public void Login(LoginCallback loginCallback)//!!!logincallBack!!!
        {
            this.loginCallback = loginCallback;
            browserform = new BrowserForm(GenerateLoginURL());
            browserform.webBrowserCallback = OnUrlOpened;
            browserform.ShowDialog();
        }

        public Uri GenerateLoginURL()
        {
            fbClient.AppId = APP_ID;
            var loginParameters = new Dictionary<string, object>();
            loginParameters["client_secret"] = CLIENT_SECRET;
            loginParameters["response_type"] = REDIRECT_TYPE;
            loginParameters["redirect_uri"] = REDIRECT_URL;
            return fbClient.GetLoginUrl(loginParameters);
        }

        public void OnUrlOpened(Uri uri)
        {
            string fragment = uri.Fragment;
            Regex accesTokenRegex = new Regex("(?<=access_token=).+?(?=(&|\\Z))");
            Match access_token = accesTokenRegex.Match(fragment);
            Console.WriteLine();
            this.access_tocken = access_token.Value;
            this.loginCallback(null);
            browserform.Close();
        }
    }
}
