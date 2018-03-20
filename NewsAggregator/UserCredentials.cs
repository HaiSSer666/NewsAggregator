using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    [Serializable]
    class UserCredentials
    {
        public string userAccessToken { get; }
        public string userAccessSecret { get; }

        public UserCredentials(string userAccessToken, string userAccessSecret)
        {
            this.userAccessToken = userAccessToken;
            this.userAccessSecret = userAccessSecret;
        }

    }
}
