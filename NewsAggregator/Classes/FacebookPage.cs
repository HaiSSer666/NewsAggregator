using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class FacebookFeedPage
    {
        public List<FacebookFeed> data { get; set; }
        public Paging paging { get; set; }
    }

    public class FacebookFeed
    {
        public string message { get; set; }
        [JsonProperty(PropertyName = "created_time")]
        public DateTime createdAt { get; set; }
        public string id { get; set; }
    }

    public class Paging
    {
        public string previous { get; set; }
        public string next { get; set; }
    }
}
