using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class LoginManagerFacade : ILoginManager
    {
        TweeterLoginManager tweeterLoginManager = new TweeterLoginManager();
        public Dictionary<SocialNetwork, bool> loginInfo = new Dictionary<SocialNetwork, bool>();

        public void Login(SocialNetwork socialNetwork, LoginCallback loginCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        tweeterLoginManager.Login(loginCallback);
                        break;
                    }
                case SocialNetwork.Facebook:
                    {
                        break;
                    } 
            }
        }

        public void RestoreSession(SocialNetwork socialNetwork, RestoreCallback restoreCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        tweeterLoginManager.RestoreSession(restoreCallback);
                        loginInfo.Add(SocialNetwork.Tweeter, true);
                        break;
                    }
                case SocialNetwork.Facebook:
                    {
                        break;
                    }
            }
        }
    }
}
