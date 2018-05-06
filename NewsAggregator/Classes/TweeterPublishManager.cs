using System;
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
                publishCallback(new Error("TweeterErrorDomain", 1, "You entred invalid text"));
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                publishCallback(new Error("TweeterErrorDomain", 2, "Something went wrong"));
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                publishCallback(new Error("TweeterErrorDomain", 3, "You are not logged in to perform this action"));
            }
        }
    }
}