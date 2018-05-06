namespace NewsAggregator
{
    public enum SocialNetwork { Tweeter, Facebook };

    public interface ILoginManager
    {
        void Login(SocialNetwork socialNetwork, LoginCallback loginCallback);
    }
}