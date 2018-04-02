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
        public void Serealize(UserCredentials userCredentials)
        {
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream("UserCredentials.bin",
                         FileMode.OpenOrCreate,
                         FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, userCredentials);
            stream.Close();
        }

        public UserCredentials Deserealize()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                System.IO.Stream stream = new FileStream("UserCredentials.bin",
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

// c:\users\admin\documents\visual studio 2015\Projects\NewsAggregator\
