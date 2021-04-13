using Dapper;
using Interface.User;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;

namespace DAL.User
{
    public class UserDAL : IUserDAL, IUserCollectionDAL
    {
        public void CreateUser(UserDTO newUser)
        {
            // Prepare SQL
            string sql = @"insert into dbo.[User] (UserName, FirstName, LastName, Password, Email, DoB)
                            values(@UserName, @FirstName, @LastName, @Password, @Email, @DoB);";

            DBManager.SaveData(sql, newUser);
        }  
        
        public IEnumerable<UserDTO> GetUserByUserName(string userName)
        {
            string sql = $"select * dbo.[User] where UserName = @userName";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName}

            };


            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<UserDTO>(sql, parameters);
        }

        public IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier)
        {
            string sql = $"select * from dbo.[User] where UserName = @identifier or Email = @identifier";

            var dictionary = new Dictionary<string, object>
            {
                {"@identifier", identifier}

            };


            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<UserDTO>(sql, parameters);
        }

        public void UpdateUser(UserDTO updatedUser)
        {
            string sql = $"";
        }

        //public ValidationResponse ValidateNewUser(string userName, string email)
        //{

        //    ValidationResponse _registerValidation = new ValidationResponse();

        //    UserDTO existingUser = CheckUserNameEmail(userName, email).FirstOrDefault();


        //    if (existingUser == null)
        //    {
        //        _registerValidation.Valid = true;
        //    }
        //    else
        //    {
        //        if(existingUser.UserName == userName)
        //        {
        //            _registerValidation.Valid = false;
        //            _registerValidation.Error = "UserName";
        //        }
        //        else if(existingUser.Email == email)
        //        {
        //            _registerValidation.Valid = false;
        //            _registerValidation.Error = "Email";
        //        }
        //    }

        //    return _registerValidation;
        //}    
        
        public IEnumerable<UserDTO> CheckUserNameEmail(string userName, string email)       // Used for checking whether the username is in use or not when registering
        {
            string sql = $"select * from dbo.[User] where (UserName = @userName or Email = @email);";

            var dictionary = new Dictionary<string, object>
            {
                {"@userName", userName},
                {"@email", email }

            };

            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<UserDTO>(sql, parameters);
        }
    }
}
