using Models;
using System.Collections.Generic;
using Variables;

namespace Interface.User
{
    public interface IUserDAL
    {
        void UpdateUser(UserDTO newUser);

        IEnumerable<UserDTO> CheckUserNameEmail(string userName, string email);


    }
}