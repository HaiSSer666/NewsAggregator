using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace NewsAggregator
{
    class TweeterPublishManager
    {
        public void PublishTweet(string tweetText, PublishCallback publishCallback)
        {
            Tweet.PublishTweet(tweetText.Trim());
            publishCallback();
        }
    }
}
