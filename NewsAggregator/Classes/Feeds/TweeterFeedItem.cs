using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.Entities;

namespace NewsAggregator
{
    [Serializable]
    class TweeterFeedItem : IFeedItem
    {
        DateTime createdAt;
        string createdBy;
        string fullText;
        bool isRetweet;
        int publishedTweetLength;
        int retweetCount;

        public TweeterFeedItem(DateTime createdAt, string createdBy, string fullText, bool isRetweet, int publishedTweetLength, int retweetCount)
        {
            this.createdAt = createdAt;
            this.createdBy = createdBy;
            this.fullText = fullText;
            this.isRetweet = isRetweet;
            this.publishedTweetLength = publishedTweetLength;
            this.retweetCount = retweetCount;
        }

        public DateTime CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return createdBy;
            }

            set
            {
                createdBy = value;
            }
        }
        public string FullText
        {
            get
            {
                return fullText;
            }

            set
            {
                fullText = value;
            }
        }
        public bool IsRetweet
        {
            get
            {
                return isRetweet;
            }

            set
            {
                isRetweet = value;
            }
        }
        public int PublishedTweetLength
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public int RetweetCount
        {
            get
            {
                return retweetCount;
            }

            set
            {
                retweetCount = value;
            }
        }

        public int CompareTo(IFeedItem other)
        {
            if (this.CreatedAt < other.CreatedAt)
                return 1;
            if (this.CreatedAt > other.CreatedAt)
                return -1;
            else
                return 0;
        }
    }
}