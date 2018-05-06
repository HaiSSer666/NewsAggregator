using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public class Error
    {
        public string errorDescription;
        public string domain;
        public int code;

        public Error(string domain, int code, string errorDescription)
        {
            this.domain = domain;
            this.code = code;
            this.errorDescription = errorDescription;
        }
    }
}
