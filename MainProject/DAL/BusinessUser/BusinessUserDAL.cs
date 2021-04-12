using Interface.BusinessUser;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessUser
{
    public class BusinessUserDAL : IBusinessUserDAL, IBusinessUserCollectionDAL
    {
        public void CreateBusinessUser(BusinessUserDTO newBusinessUser)
        {
            string sql = @"insert into dbo.BusinessUser ()
                          values();";
            DBManager.SaveData(sql, newBusinessUser);
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier)
        {
            string sql = $"select * from dbo.BusinessUser where UserName = '{identifier}' or Email = '{identifier}'";

            return DBManager.LoadData<BusinessUserDTO>(sql);
        }

        public void UpdateBusinessUser(BusinessUserDTO updatedBusinessUser)
        {
            string sql = $"";
        }

        public IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmail(string userName, string email)
        {
            string sql = $"select * from dbo.BusinessUser where (UserName = '{userName}' or Email = '{email}');";

            return DBManager.LoadData<BusinessUserDTO>(sql);
        }

        public bool ValidateNewBusinessUser(string userName, string email)
        {

            bool valid = false;

            BusinessUserDTO existingBusinessUser = CheckBusinessUserNameEmail(userName, email).FirstOrDefault();


            if (existingBusinessUser == null)
            {
                valid = true;
            }

            return valid;
        }
    }
}
