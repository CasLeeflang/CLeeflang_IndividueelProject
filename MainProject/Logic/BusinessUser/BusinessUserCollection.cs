using FactoryDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.BusinessUser;

namespace Logic.BusinessUser
{
    public class BusinessUserCollection
    {
        //  Dependicy injection
        IBusinessUserCollectionDAL _BusinessUserCollectionDAL = BusinessUserFactoryDAL.CreateBusinessUserCollectionDAL();

        private List<BusinessUserModel> businessUsers { get; } = new List<BusinessUserModel>();

        public void CreateBusinessUser(BusinessUserModel newBusinessUser)
        {
            //  Creates new business user

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
            //  Returns all businesses

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
            //  Returns businesses where username or email equals the identifier
            
            IEnumerable<BusinessUserDTO> businessUserDTOs = _BusinessUserCollectionDAL.GetBusinessByUserNameOrEmail(identifier);

            foreach (var businessUserDTO in businessUserDTOs)
            {
                BusinessUserModel businessUser = new BusinessUserModel(businessUserDTO);
                businessUsers.Add(businessUser);
            }
            return businessUsers;
        }

        public BusinessUserModel GetBusinessByIdForView(int id)
        {
            IEnumerable<BusinessUserDTO> _businessDTOS =  _BusinessUserCollectionDAL.GetBusinessByIdForView(id);

            foreach (var businessDTO in _businessDTOS)
            {
                BusinessUserModel business = new BusinessUserModel(businessDTO);
                businessUsers.Add(business);
            }

            return businessUsers.LastOrDefault();
            
        }

        public int GetBusinessId(string userName)
        {
            //  Returns te business id based on the username of the business

            return _BusinessUserCollectionDAL.GetBusinessId(userName);
        }
    }
}
