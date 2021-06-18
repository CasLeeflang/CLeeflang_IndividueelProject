using Dapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.BusinessUser;
using DAL.DataBase;
using Microsoft.Extensions.Configuration;

namespace DAL.BusinessUser
{
    public class BusinessUserDAL : IBusinessUserDAL, IBusinessUserCollectionDAL
    {


        DBManager _dBManager = new DBManager();

        public void CreateBusinessUser(BusinessUserDTO newBusinessUser)
        {
            string sql = @"insert into dbo.BusinessUser (BusinessName, UserName, Password, Email, Info, Sector, ImageByteArray)
                          values(@BusinessName, @UserName, @Password, @Email, @Info, @Sector, @ImageByteArray);";
            _dBManager.SaveData(sql, newBusinessUser);
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByUserNameOrEmail(string identifier)
        {
            string sql = $"select Id, BusinessName, UserName, Password, Email, Info, Sector, ImageByteArray from dbo.BusinessUser where UserName = @identifier or Email = @identifier";

            var dictionary = new Dictionary<string, object>
            {
                {"@identifier", identifier }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<BusinessUserDTO>(sql, parameters);
        }

        public IEnumerable<BusinessUserDTO> GetBusinessByIdForView(int id)
        {
            string sql = $"select Id, BusinessName, Info, Sector, ImageByteArray from dbo.BusinessUser where Id = @id ";

            var dictionary = new Dictionary<string, object>
            {
                {"@id", id }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<BusinessUserDTO>(sql, parameters);
        }

        public int UpdateBusinessUser(BusinessUserDTO updatedBusinessUser)
        {
            string sql = $"update dbo.BusinessUser set BusinessName = @businessName, UserName = @userName, Email = @email, Info = @info, Sector = @sector, ImageByteArray = @imageByteArray where Id = @businessId;";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessName", updatedBusinessUser.BusinessName },
                {"@userName", updatedBusinessUser.UserName },
                {"@email", updatedBusinessUser.Email },
                {"@info", updatedBusinessUser.Info },
                {"@sector", updatedBusinessUser.Sector },
                {"@businessId", updatedBusinessUser.Id },
                {"@imageByteArray", updatedBusinessUser.ImageByteArray }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.UpdateData(sql, parameters);
        }

        public int UpdateBusinessInfo(BusinessUserDTO businessInfo)
        {
            string sql = $"update dbo.BusinessUser set Info = @info where Id = @businessId;";

            var dictionary = new Dictionary<string, object>
            {
                {"@info", businessInfo.Info },
                {"@id", businessInfo.Id }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.UpdateData(sql, parameters);
        }

        public IEnumerable<BusinessUserDTO> GetAllBusinesses()
        {
            string sql = $"select Id, BusinessName, UserName, Password, Email, Info, Sector, ImageByteArray from dbo.BusinessUser;";

            return _dBManager.LoadAllData<BusinessUserDTO>(sql);
        }
  

        public int GetBusinessId(string userName)
        {
            string sql = $"select Id from dbo.BusinessUser where (UserName = @userName);";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName}

            };


            var parameters = new DynamicParameters(dictionary);

            BusinessUserDTO businessUserDTO = _dBManager.LoadData<BusinessUserDTO>(sql, parameters).FirstOrDefault();

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
        
        public IEnumerable<BusinessUserDTO> CheckBusinessUserNameEmailName(string userName, string email, string businessName)
        {
            string sql = $"select Id, BusinessName, UserName, Password, Email, Info, Sector from dbo.BusinessUser where (UserName = @userName or Email = @email or BusinessName = @businessName);";
            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName},
                {"@email", email },
                {"@businessName", businessName }
            };


            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<BusinessUserDTO>(sql, parameters);
        }
    }
}
