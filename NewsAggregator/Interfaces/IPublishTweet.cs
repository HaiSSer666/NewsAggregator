using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    interface IPublishTweet
    {
        void PublishTweet(string tweetText);
    }
}
