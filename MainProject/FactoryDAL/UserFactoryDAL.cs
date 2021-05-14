using Contract_Layer.User;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDAL
{
    public class UserFactoryDAL
    {
        public static IUserDAL CreateUserDAL()
        {
            return new UserDAL();
        }

        public static IUserCollectionDAL CreateUserCollectionDAL()
        {
            return new UserDAL();
        }
    }
}
