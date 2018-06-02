using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator
{
    class UserStorage : SyncStorage<User>
    {
        private User user = new User();
        private static UserStorage instance;

        private UserStorage()
        { }

        public static UserStorage Storage()
        {
            if (instance == null)
                instance = new UserStorage();
            return instance;
        }

        override protected User GetSync()
        {
            return user;
        }

        override protected  void SetSync(User user)
        {
            this.user = user;
        }
    }
}
