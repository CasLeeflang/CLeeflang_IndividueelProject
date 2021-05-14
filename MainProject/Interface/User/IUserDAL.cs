using DTOs;
using System.Collections.Generic;


namespace Contract_Layer.User
{
    public interface IUserDAL
    {
        void UpdateUser(UserDTO newUser);

        IEnumerable<UserDTO> CheckUserNameEmail(string userName, string email);


    }
}