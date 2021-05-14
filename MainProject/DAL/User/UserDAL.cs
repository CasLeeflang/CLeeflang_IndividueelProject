using Dapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Contract_Layer.User;
using DAL.DataBase;
using Microsoft.Extensions.Configuration;

namespace DAL.User
{
    public class UserDAL : IUserDAL, IUserCollectionDAL
    {


        DBManager _dBManager = new DBManager();
        public void CreateUser(UserDTO newUser)
        {
            // Prepare SQL
            string sql = @"insert into dbo.[User] (UserName, FirstName, LastName, Password, Email, DoB)
                            values(@UserName, @FirstName, @LastName, @Password, @Email, @DoB);";

            _dBManager.SaveData(sql, newUser);
        }  
        
        public IEnumerable<UserDTO> GetUserByUserName(string userName)
        {
            string sql = $"select * from dbo.[User] where UserName = @userName";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName}

            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<UserDTO>(sql, parameters);
        }

        public IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier)
        {
            string sql = $"select * from dbo.[User] where UserName = @identifier or Email = @identifier";

            var dictionary = new Dictionary<string, object>
            {
                {"@identifier", identifier}

            };


            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<UserDTO>(sql, parameters);
        }

        public void UpdateUser(UserDTO updatedUser)
        {
            string sql = $"";
        }
        
        public IEnumerable<UserDTO> CheckUserNameEmail(string userName, string email)       // Used for checking whether the username is in use or not when registering
        {
            string sql = $"select * from dbo.[User] where (UserName = @userName or Email = @email);";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName},
                {"@email", email }

            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<UserDTO>(sql, parameters);
        }
    }
}
