using Interface.User;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier)
        {
            string sql = $"select * from dbo.[User] where UserName = {identifier} or Email = {identifier}";

            return DBManager.LoadDataList<UserDTO>(sql);
        }

        public void DeleteTimeSlot()
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeSlot()
        {
            throw new NotImplementedException();
        }

    }
}
