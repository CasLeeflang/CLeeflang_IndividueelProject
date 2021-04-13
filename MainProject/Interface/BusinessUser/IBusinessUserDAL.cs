using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.BusinessUser
{
    public interface IBusinessUserDAL
    {
        void UpdateBusinessUser(BusinessUserDTO newBusinessUser);

        //public bool ValidateNewBusinessUser(string userName, string email);

        IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmailName(string userName, string email, string businessName);

    }
}
