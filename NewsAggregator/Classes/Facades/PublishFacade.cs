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