using Contract_Layer.BusinessUser;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAL
{
    public class TestBusinessUserDAL: IBusinessUserCollectionDAL, IBusinessUserDAL
    {
        public static List<BusinessUserDTO> businessUserStorage { get; private set; } = new List<BusinessUserDTO>();

        public List<BusinessUserDTO> TempStorage { get; private set; } = new List<BusinessUserDTO>(); 
        private void ClearTempStorage() { TempStorage = new List<BusinessUserDTO>(); }

        public void CreateBusinessUser(BusinessUserDTO businessUser)
        {
            businessUserStorage.Add(businessUser);
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier)
        {
            TempStorage.Add(businessUserStorage.FirstOrDefault(o => o.UserName == identifier || o.Email == identifier));
            return TempStorage;
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByIdForView(int id)
        {
            throw new NotImplementedException();
        }

        public int GetBusinessId(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessUserDTO> GetAllBusinesses()
        {
            return businessUserStorage;
        }

        public int UpdateBusinessUser(BusinessUserDTO businessUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmailName(string userName, string email, string businessName)
        {
            TempStorage.Add(businessUserStorage.FirstOrDefault(o => o.UserName == userName || o.Email == email || o.BusinessName == businessName));
            return TempStorage;
        }

        public int UpdateBusinessInfo(BusinessUserDTO businessUser)
        {
            throw new NotImplementedException();
        }
    }
}
