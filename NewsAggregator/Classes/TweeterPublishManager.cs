using System;
using System.Collections.Generic;
using Tweetinvi;

namespace NewsAggregator
{
    class TweeterPublishManager
    {
        public void PublishTweet(string tweetText, PublishCallback publishCallback)
        {
            try
            {
                Tweet.PublishTweet(tweetText.Trim());
                publishCallback(null);
            }
            catch (ArgumentException ex)
            {
                publishCallback(new Error("TweeterErrorDomain", 1, new Dictionary<Type, string>
                {
                    {ex.GetType(), ex.StackTrace}
                }));
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                publishCallback(new Error("TweeterErrorDomain", 2, new Dictionary<Type, string>
                {
                    {ex.GetType(), ex.StackTrace}
                }));
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                publishCallback(new Error("TweeterErrorDomain", 3, new Dictionary<Type, string>
                {
                    {ex.GetType(), ex.StackTrace}
                }));
            }
        }
    }
}