using Contract_Layer.BusinessUser;
using DAL.BusinessUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDAL
{
    public class BusinessUserFactoryDAL
    {
        public static IBusinessUserDAL CreateBusinessUserDAL()
        {
            return new BusinessUserDAL();
        }

        public static IBusinessUserCollectionDAL CreateBusinessUserCollectionDAL()
        {
            return new BusinessUserDAL();
        }
    }
}
