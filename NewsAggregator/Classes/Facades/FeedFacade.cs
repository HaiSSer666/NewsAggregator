using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.Classes.Managers;

namespace NewsAggregator
{
    public class FeedFacade
    {
        TweeterFeedManager tweeterFeedManager = new TweeterFeedManager();
        FacebookFeedManager facebookFeedManager = new FacebookFeedManager();
        IFacebookFeedManager fbFeedManager;

        public FeedFacade(IFacebookFeedManager fbFeedManager)
        {
            this.fbFeedManager = fbFeedManager;
        }

        public void GetFeed(SocialNetwork socialNetwork, FeedCallback feedCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        tweeterFeedManager.GetFeed(feedCallback);
                        break;
                    }
                case SocialNetwork.Facebook:
                    {
                        //facebookFeedManager.GetFeed(feedCallback);
                        fbFeedManager.GetFeed(feedCallback);
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}