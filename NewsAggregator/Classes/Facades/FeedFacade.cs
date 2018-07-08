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

        public async Task<SortedSet<IFeedItem>> GetFeed(SocialNetwork socialNetwork, int maximumTweets, FeedCallback feedCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        return await tweeterFeedManager.GetFeed(maximumTweets, feedCallback);
                    }
                case SocialNetwork.Facebook:
                    {
                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}