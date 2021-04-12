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
    public class BusinessUserCollection
    {
        IBusinessUserCollectionDAL _BusinessUserCollectionDAL = BusinessUserFactoryDAL.CreateBusinessUserCollectionDAL();

        private List<BusinessUserModel> businessUsers { get; set; } = new List<BusinessUserModel>();

        public void CreateBusinessUser(BusinessUserModel newBusinessUser)
        {
            if (newBusinessUser.Validate())
            {
                BusinessUserDTO newBusinessUserDTO = new BusinessUserDTO
                {
                    BusinessName = newBusinessUser.BusinessName,
                    UserName = newBusinessUser.UserName,
                    Password = newBusinessUser.Password,
                    Email = newBusinessUser.Email,
                    Info = newBusinessUser.Info,
                    Sector = newBusinessUser.Sector
                };

                _BusinessUserCollectionDAL.CreateBusinessUser(newBusinessUserDTO);
            }

            else
            {
                Console.WriteLine("Model invalid"); 
            }
        }

        public IEnumerable<BusinessUserModel> GetBusinessUserByUserNameOrEmail(string identifier)
        {
            IEnumerable<BusinessUserDTO> businessUserDTOs = _BusinessUserCollectionDAL.GetBusinessByUserNameOrEmail(identifier);

            foreach(var businessUserDTO in businessUserDTOs)
            {
                BusinessUserModel businessUser = new BusinessUserModel(businessUserDTO);
                businessUsers.Add(businessUser);
            }
            return businessUsers;
        }

    }
}
