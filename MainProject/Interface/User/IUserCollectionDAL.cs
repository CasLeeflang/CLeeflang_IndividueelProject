using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.User
{
    public interface IUserCollectionDAL
    {
        void CreateUser(UserDTO newUser);
        IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier);

        IEnumerable<UserDTO> GetUserByUserName(string userName);
        IEnumerable<UserDTO> GetUserId(string userName);
    }
}
