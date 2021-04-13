using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.User
{
    public interface IUserCollectionDAL
    {
        void CreateUser(UserDTO newUser);
        IEnumerable<UserDTO> GetUserByUserNameOrEmail(string identifier);

        IEnumerable<UserDTO> GetUserByUserName(string userName);
    }
}
