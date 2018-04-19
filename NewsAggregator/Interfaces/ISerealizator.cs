using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    interface ISerealizator
    {
        void Serialize(object userCredentials, string pathToFile);
        object Deserialize(string pathToFile);
    }
}
