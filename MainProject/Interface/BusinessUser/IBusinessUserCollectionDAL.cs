using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.BusinessUser
{
    public interface IBusinessUserCollectionDAL
    {
        void CreateBusinessUser(BusinessUserDTO newBusinessUser);

        IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier);
        IEnumerable<BusinessUserDTO> GetBusinessByIdForView(int id);


        int GetBusinessId(string userName);

        IEnumerable<BusinessUserDTO> GetAllBusinesses();
    }
}
