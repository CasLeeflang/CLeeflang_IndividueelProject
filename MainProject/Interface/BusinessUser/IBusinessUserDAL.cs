using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.BusinessUser
{
    public interface IBusinessUserDAL
    {
        int UpdateBusinessUser(BusinessUserDTO newBusinessUser);

        //public bool ValidateNewBusinessUser(string userName, string email);

        IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmailName(string userName, string email, string businessName);
        int UpdateBusinessInfo(BusinessUserDTO businessInfo);
    }
}
