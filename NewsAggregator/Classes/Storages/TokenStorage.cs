using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class TokenStorage : ObservableStorage<Dictionary<SocialNetwork, string>>
    {
        private Dictionary<SocialNetwork, string> tokenList = new Dictionary<SocialNetwork, string>();
        private static TokenStorage instance;

        public static TokenStorage Storage()
        {
            if (instance == null)
                instance = new TokenStorage();
            return instance;
        }

        override protected Dictionary<SocialNetwork, string> GetSync()
        {
            return tokenList;
        }

        override protected void SetSync(Dictionary<SocialNetwork, string> tokenList)
        {
            this.tokenList = tokenList;
            this.NotifyObservers(tokenList);
        }
    }
}