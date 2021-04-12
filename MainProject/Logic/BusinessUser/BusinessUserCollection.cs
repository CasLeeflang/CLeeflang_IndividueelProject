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

        private List<BusinessUserModel> businessUsers { get; } = new List<BusinessUserModel>();

        public void CreateBusinessUser(BusinessUserModel newBusinessUser)
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

        public IEnumerable<BusinessUserModel> GetAllBusinesses()
        {

            IEnumerable<BusinessUserDTO> businessUserDTOs = _BusinessUserCollectionDAL.GetAllBusinesses();
            foreach (var businessUserDTO in businessUserDTOs)
            {
                BusinessUserModel businessUser = new BusinessUserModel(businessUserDTO);
                businessUsers.Add(businessUser);
            }
            return businessUsers;
        }

        public IEnumerable<BusinessUserModel> GetBusinessUserByUserNameOrEmail(string identifier)
        {
            IEnumerable<BusinessUserDTO> businessUserDTOs = _BusinessUserCollectionDAL.GetBusinessByUserNameOrEmail(identifier);

            foreach (var businessUserDTO in businessUserDTOs)
            {
                BusinessUserModel businessUser = new BusinessUserModel(businessUserDTO);
                businessUsers.Add(businessUser);
            }
            return businessUsers;
        }

        public int GetBusinessId(string userName)
        {
            return _BusinessUserCollectionDAL.GetBusinessId(userName);
        }
    }
}
