using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace NewsAggregator
{
    class TweetManager : IPublishTweet
    {
        public void PublishTweet(string tweetText)
        {
            var tweet = Tweet.PublishTweet(tweetText.Trim());
        }
    }
}
