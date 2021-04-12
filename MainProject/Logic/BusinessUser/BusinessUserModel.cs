using FactoryDAL;
using Interface.BusinessUser;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BusinessUser
{
    public class BusinessUserModel
    {
        IBusinessUserDAL _businessUserDAL = BusinessUserFactoryDAL.CreateBusinessUserDAL();

        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Sector { get; set; }

        public BusinessUserModel(string businessName, string userName, string password, string email, string sector)
        {
            BusinessName = businessName;
            UserName = userName;
            Password = password;
            Email = email;
            Info = "";
            Sector = sector;
        }

        public BusinessUserModel(BusinessUserDTO businessUserDTO)
        {
            Id = businessUserDTO.Id;
            BusinessName = businessUserDTO.BusinessName;
            UserName = businessUserDTO.UserName;
            Password = businessUserDTO.Password;
            Email = businessUserDTO.Email;
            Info = businessUserDTO.Info;
            Sector = businessUserDTO.Sector;
        }

        public void Update(BusinessUserModel updatedBusinessUser)
        {

        }

        public bool Validate()
        {
            return _businessUserDAL.ValidateNewBusinessUser(UserName, Email);
        }
    }
}
