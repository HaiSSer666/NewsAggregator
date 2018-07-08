using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.Entities;

namespace NewsAggregator
{
    class FacebookFeedItem : IFeedItem
    {
        DateTime createdAt;
        string createdBy;
        string fullText;

        public FacebookFeedItem()
        {

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
    }
}