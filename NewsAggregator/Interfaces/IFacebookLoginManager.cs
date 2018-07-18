using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    public interface IFacebookLoginManager
    {
        void Login(LoginCallback loginCallback);
        void RestoreSession(RestoreCallback restoreCallback);
    }
}
