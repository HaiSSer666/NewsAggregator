using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class Serealizator : ISerealizator
    {
        public void Serialize(object serializable, string pathToFile)
        {
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream(pathToFile,
                         FileMode.OpenOrCreate,
                         FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, serializable);
            stream.Close();
        }

        public object Deserialize(string pathToFile)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                System.IO.Stream stream = new FileStream(pathToFile,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                UserCredentials userCredentials = (UserCredentials)formatter.Deserialize(stream);
                stream.Close();
                return userCredentials;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
