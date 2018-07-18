using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace NewsAggregator.Classes.Managers
{
    class FacebookFeedManager
    {
        private FacebookClient fbClient;

        public FacebookFeedManager()
        {
            this.fbClient = new FacebookClient();
        }

        public void GetFeed(FeedCallback feedCallback)
        {
            //Task<object> response = fbClient.GetTaskAsync("/me/feed", new Dictionary<string, object>() { { "fields", "id, admin_creator, created_time" } });
            Task<object> response = fbClient.GetTaskAsync("/me/feed");
            string jsonString = response.Result.ToString();
            feedCallback(null);
        }
    }
}
