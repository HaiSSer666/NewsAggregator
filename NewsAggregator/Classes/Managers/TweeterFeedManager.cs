using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace NewsAggregator
{
    class TweeterFeedManager
    {
        public async Task<List<IFeedItem>> GetFeed(int maximumTweets, FeedCallback feedCallback)
        {
            try
            {
                IEnumerable<ITweet> tweets = Timeline.GetHomeTimeline(maximumTweets);
                feedCallback(null);
                return await SaveTweetsToStorage(tweets);
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                feedCallback(new Error("TweeterErrorDomain", 3, "You are not logged in to perform this action"));
                Console.WriteLine(ex.Credentials);
                return null;
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                feedCallback(new Error("TweeterErrorDomain", 2, "Something went wrong"));
                Console.WriteLine(ex.TwitterDescription);
                return null;
            }
        }

        public async Task RestoreTweeterFeed()
        {
            FeedStorage feedStorage = FeedStorage.Storage();
            List<IFeedItem> feedItems = await feedStorage.GetAsync();
        }

        public async Task<List<IFeedItem>> SaveTweetsToStorage(IEnumerable<ITweet> tweets)
        {
            FeedStorage feedStorage = FeedStorage.Storage();
            List<IFeedItem> feedItems = await feedStorage.GetAsync();
            feedItems.Clear();
            foreach(ITweet tweet in tweets)
            {
                feedItems.Add(new TweeterFeedItem(
                tweet.CreatedAt, 
                tweet.CreatedBy.ToString(), 
                tweet.FullText, 
                tweet.IsRetweet,
                tweet.PublishedTweetLength,
                tweet.RetweetCount));
            } 
            await feedStorage.SetAsync(feedItems);
            return feedItems;
        }
    }
}