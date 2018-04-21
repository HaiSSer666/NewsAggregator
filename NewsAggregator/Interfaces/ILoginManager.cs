using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public enum SocialNetwork { Tweeter, Facebook };

    public interface ILoginManager
    {
        void Login(SocialNetwork socialNetwork, LoginCallback loginCallback);
    }
}
