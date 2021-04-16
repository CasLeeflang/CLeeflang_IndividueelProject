using Contract_Layer.User;
using DAL.User;

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
