namespace NewsAggregator
{
    interface ISerealizator
    {
        void Serialize(object userCredentials, string pathToFile);
        object Deserialize(string pathToFile);
    }
}