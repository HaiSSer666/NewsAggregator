using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace NewsAggregator
{
    class Serealizator : ISerealizator
    {
        public void Serialize(object serializable, string pathToFile)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(pathToFile,
                                               FileMode.OpenOrCreate,
                                               FileAccess.Write, 
                                               FileShare.None);
                formatter.Serialize(stream, serializable);
                stream.Close();
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error by handling " + ex.Source);
            }
        }

        public object Deserialize(string pathToFile)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(pathToFile,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                object deserializedObject = formatter.Deserialize(stream);
                stream.Close();
                return deserializedObject;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not find " + ex.FileName);
                return null;
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Something went wrong " + ex.Message);
                return null;
            }
        }
    }
}
