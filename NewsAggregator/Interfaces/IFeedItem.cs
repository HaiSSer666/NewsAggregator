using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.Entities;

namespace NewsAggregator
{
    public interface IFeedItem
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        string FullText { get; set; }
    }
}
