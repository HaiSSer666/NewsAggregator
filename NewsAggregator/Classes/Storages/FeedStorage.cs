using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class FeedStorage : ObservableStorage<SortedSet<IFeedItem>>
    {
        public SortedSet<IFeedItem> feedItems = new SortedSet<IFeedItem>();
        Serealizator serealizator = new Serealizator();
        private const string PATH_TO_FEED = "NewsFeed.bin";
        private static FeedStorage instance;

        public static FeedStorage Storage()
        {
            if (instance == null)
            {
                 instance = new FeedStorage();
            }    
            return instance;
        }

        public FeedStorage()
        {
            SortedSet<IFeedItem> restoredFeedItems = (SortedSet<IFeedItem>)serealizator.Deserialize(PATH_TO_FEED);
            if (restoredFeedItems != null)
            {
                this.feedItems = restoredFeedItems;
            }
        }

        override protected SortedSet<IFeedItem> GetSync()
        { 
            return feedItems;
        }

        override protected void SetSync(SortedSet<IFeedItem> feedItems)
        {    
            this.feedItems = feedItems;
            this.NotifyObservers(feedItems);
            serealizator.Serialize(feedItems, PATH_TO_FEED);
        }
    }
}