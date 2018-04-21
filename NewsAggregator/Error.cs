using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class Error
    {
        public string domain;
        public int code;
        public Dictionary<string, object> info;

        public Error(string domain, int code, Dictionary<string, object> info)
        {
            this.domain = domain;
            this.code = code;
            this.info = info;
        }
    }
}
