using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.BusinessUser
{
    public interface IBusinessUserCollectionDAL
    {
        void CreateBusinessUser(BusinessUserDTO newBusinessUser);

        IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier);

    }
}
