using Facebook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class FacebookService : IFacebookFeedManager, IFacebookLoginManager
    {
        private Serealizator serealizator = new Serealizator();

        private LoginCallback loginCallback;
        private FacebookClient fbClient;
        private BrowserForm browserform;

        private const string APP_ID = "205222496927855";
        private const string CLIENT_SECRET = "4eb3cebdc4f8158c8c6ea747470e9b76";
        private const string REDIRECT_TYPE = "code token";
        private const string PATH_TO_TOKEN = "FBToken.bin";
        private Uri REDIRECT_URL = new Uri("https://www.facebook.com/connect/login_success.html");

        public FacebookService()
        {
            this.fbClient = new FacebookClient();
        }

        public void GetFeed(FeedCallback feedCallback)
        {
            Task<object> response = fbClient.GetTaskAsync("/me/feed");
            response.ContinueWith(OnRecieveFeed);
            feedCallback(null);
        }

        private void OnRecieveFeed(Task<object> obj)
        {
            try
            {
                FacebookFeedPage fbFeedPage = new FacebookFeedPage(); 
                string jsonString = obj.Result.ToString();
                fbFeedPage = JsonConvert.DeserializeObject<FacebookFeedPage>(jsonString);
                Console.WriteLine();
            }
            catch (JsonSerializationException e)
            {
            }
        }

        public void Login(LoginCallback loginCallback)
        {
            this.loginCallback = loginCallback;
            browserform = new BrowserForm(GenerateLoginURL());
            browserform.webBrowserCallback = OnUrlOpened;
            browserform.ShowDialog();
        }

        public void RestoreSession(RestoreCallback restoreCallback)
        {
            string parsedToken = (string)serealizator.Deserialize(PATH_TO_TOKEN);
            if(parsedToken != null)
            {
                fbClient.AccessToken = parsedToken;
                GetUserInfo("/me");
                restoreCallback();
            }
            else
            {
                Login(this.loginCallback);
            }
        }

        public Uri GenerateLoginURL()
        {
            fbClient.AppId = APP_ID;
            var loginParameters = new Dictionary<string, object>();
            loginParameters.Add("client_secret", CLIENT_SECRET);
            loginParameters.Add("response_type", REDIRECT_TYPE);
            loginParameters.Add("redirect_uri", REDIRECT_URL);
            return fbClient.GetLoginUrl(loginParameters);
        }

        public void OnUrlOpened(Uri uri)
        {
            bool isHostEqual = (uri.Host == REDIRECT_URL.Host);
            bool isAbsolutePathEqual = (uri.AbsolutePath == REDIRECT_URL.AbsolutePath);

            if (isHostEqual && isAbsolutePathEqual)
            {
                string fragment = uri.Fragment;
                Regex accessTokenRegex = new Regex("(?<=access_token=).+?(?=(&|\\Z))");
                Match accessToken = accessTokenRegex.Match(fragment);
                string parsedToken = accessToken.Value;
                if (parsedToken != null && parsedToken.Length > 0)
                {
                    fbClient.AccessToken = parsedToken;
                    serealizator.Serialize(parsedToken, PATH_TO_TOKEN);
                    GetUserInfo("/me");
                }
                else
                {
                    this.loginCallback(new Error("FacebookErrorDomain", 1, "Failed to get access token"));
                }
                browserform.Close();
            }
        }

        public void GetUserInfo(string path)
        {
            try
            {
                Task<object> response = fbClient.GetTaskAsync(path, new Dictionary<string, object>() { { "fields", "first_name, picture, email" } });
                response.ContinueWith(OnReceiveUserInfo);
            }
            catch (FacebookOAuthException ex)
            {
                this.loginCallback(new Error("FacebookErrorDomain", 4, "Unabled to login"));
            }
            catch (FacebookApiLimitException ex)
            {
                this.loginCallback(new Error("FacebookErrorDomain", 5, "Api limit exception occurred"));
            }
            catch (FacebookApiException ex)
            {
                this.loginCallback(new Error("FacebookErrorDomain", 6, "General error occurred"));
            }
            catch (Exception ex)
            {
                this.loginCallback(new Error("FacebookErrorDomain", 7, "Failed to get User info"));
            }
        }

        private async Task<object> OnReceiveUserInfo(Task<object> task)
        {
            try
            {
                //TODO
                FacebookUser facebookUser = new FacebookUser();
                string jsonString = task.Result.ToString();
                facebookUser = JsonConvert.DeserializeObject<FacebookUser>(jsonString);

                //TODO
                UserStorage userStorage = UserStorage.Storage();
                User user = await userStorage.GetAsync();
                user.firstName = facebookUser.firstName;
                await userStorage.SetAsync(user);

                this.loginCallback(null);
                return null;
            }
            catch (JsonSerializationException e)
            {
                return null;
            }
        }
    }
}