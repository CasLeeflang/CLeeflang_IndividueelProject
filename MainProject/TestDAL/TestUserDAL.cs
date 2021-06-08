using Contract_Layer.User;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDAL
{
    public class TestUserDAL : IUserCollectionDAL, IUserDAL
    {
        public static List<UserDTO> UserStorage { get; private set; } = new List<UserDTO>();

        public List<UserDTO> TempStorage { get; private set; } = new List<UserDTO>();

        public void CreateUser(UserDTO user)
        {
            user.Id = 0;
            UserStorage.Add(user);
        }

        public void DeleteUser(UserDTO user)
        {
            UserStorage.Remove(user);
        }

        public void UpdateUser(UserDTO user)
        {

        }

        public IEnumerable<UserDTO> GetUserByUserName(string userName)
        {
            TempStorage.Add(UserStorage.FirstOrDefault(o => o.UserName == userName));
            return TempStorage;
        }
        public IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier)
        {
            TempStorage.Add(UserStorage.FirstOrDefault(o => o.UserName == identifier || o.Email == identifier));
            return TempStorage;
        }

        public IEnumerable<UserDTO> GetUserId(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserDTO> CheckUserNameEmail(string userName, string email)
        {
            TempStorage.Add(UserStorage.FirstOrDefault(o => o.UserName == userName || o.Email == email));
            return TempStorage;
        }
    }
}
