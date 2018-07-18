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
        public void GetFeed(FeedCallback feedCallback)
        {
            try
            {
                IEnumerable<ITweet> tweets = Timeline.GetHomeTimeline();
                feedCallback(null);
                SaveTweetsToStorage(tweets);
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                feedCallback(new Error("TweeterErrorDomain", 3, "You are not logged in to perform this action"));
                Console.WriteLine(ex.Credentials);
            }
            catch (Tweetinvi.Exceptions.TwitterException ex)
            {
                feedCallback(new Error("TweeterErrorDomain", 2, "Something went wrong"));
                Console.WriteLine(ex.TwitterDescription);
            }
        }

        public async Task RestoreTweeterFeed()
        {
            FeedStorage feedStorage = FeedStorage.Storage();
            SortedSet<IFeedItem> feedItems = await feedStorage.GetAsync();
        }

        public void SaveTweetsToStorage(IEnumerable<ITweet> tweets)
        {
            FeedStorage feedStorage = FeedStorage.Storage();
            feedStorage.Update(delegate (SortedSet<IFeedItem> feedItems)
            {
                feedItems = feedStorage.feedItems;
                foreach (ITweet tweet in tweets)
                {
                    feedItems.Add(new TweeterFeedItem(
                    tweet.CreatedAt,
                    tweet.CreatedBy.ToString(),
                    tweet.FullText,
                    tweet.IsRetweet,
                    tweet.PublishedTweetLength,
                    tweet.RetweetCount));
                }
                return feedItems;
            });
        }
    }
}