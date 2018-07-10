using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class FeedFacade
    {
        TweeterFeedManager tweeterFeedManager = new TweeterFeedManager();

        public void GetFeed(SocialNetwork socialNetwork, int maximumTweets, FeedCallback feedCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        tweeterFeedManager.GetFeed(maximumTweets, feedCallback);
                        break;
                    }
                case SocialNetwork.Facebook:
                    {
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}