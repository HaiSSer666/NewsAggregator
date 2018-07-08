namespace NewsAggregator
{
    public delegate void LoginCallback(Error error);
    public delegate void PublishCallback(Error error);
    public delegate void FeedCallback(Error error);
    public delegate void RestoreCallback();
}