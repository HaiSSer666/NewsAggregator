using Newtonsoft.Json;
using System;

namespace NewsAggregator
{
    internal class FacebookUser
    {
        [JsonProperty(PropertyName = "first_name")]
        public string firstName { get; set; }
        public Picture picture { get; set; }
        public string email { get; set; }
        public string id { get; set; }
    }

    public class Data
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }
}