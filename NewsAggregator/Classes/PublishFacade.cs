using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class PublishFacade
    {
        TweeterPublishManager tweeterPublishManager = new TweeterPublishManager();

        public void Publish(SocialNetwork socialNetwork, string postText, PublishCallback publishCallback)
        {
            switch (socialNetwork)
            {
                case SocialNetwork.Tweeter:
                    {
                        tweeterPublishManager.PublishTweet(postText, publishCallback);
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
