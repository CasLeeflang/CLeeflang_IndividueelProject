using Models;
using System.Collections.Generic;

namespace Interface.User
{
    public interface IUserDAL
    {
        void CreateUser(UserDTO newUser);
        void DeleteTimeSlot();
        IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier);
       
        void UpdateTimeSlot();
    }
}