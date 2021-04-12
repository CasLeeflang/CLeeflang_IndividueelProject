using Dapper;
using Interface.BusinessUser;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessUser
{
    public class BusinessUserDAL : IBusinessUserDAL, IBusinessUserCollectionDAL
    {
        public void CreateBusinessUser(BusinessUserDTO newBusinessUser)
        {
            string sql = @"insert into dbo.BusinessUser (BusinessName, UserName, Password, Email, Info, Sector)
                          values(@BusinessName, @UserName, @Password, @Email, @Info, @Sector);";
            DBManager.SaveData(sql, newBusinessUser);
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier)
        {
            string sql = $"select * from dbo.BusinessUser where UserName = @identifier or Email = @identifier";

            var dictionary = new Dictionary<string, object>
            {
                {"@identifier", identifier }
            };

            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<BusinessUserDTO>(sql, parameters);
        }

        public void UpdateBusinessUser(BusinessUserDTO updatedBusinessUser)
        {
            string sql = $"";
        }

        public IEnumerable<BusinessUserDTO> GetAllBusinesses()
        {
            string sql = $"select * from dbo.BusinessUser;";

            return DBManager.LoadAllData<BusinessUserDTO>(sql);
        }
        public IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmail(string userName, string email)
        {
            string sql = $"select * from dbo.BusinessUser where (UserName = @userName or Email = @email);";
            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName},
                {"@email", email }

            };


            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<BusinessUserDTO>(sql, parameters);
        }

        public int GetBusinessId(string userName)
        {
            string sql = $"select Id from dbo.BusinessUser where (UserName = @userName);";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName}

            };


            var parameters = new DynamicParameters(dictionary);

            BusinessUserDTO businessUserDTO = DBManager.LoadData<BusinessUserDTO>(sql, parameters).FirstOrDefault();

            if (businessUserDTO != null)
            {
                try
                {
                    return businessUserDTO.Id;
                }
                catch
                {
                    throw new Exception();
                }


            }
            else
            {
                throw new Exception();
            }
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
