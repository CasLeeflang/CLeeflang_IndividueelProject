using FactoryDAL;
using Interface.User;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.User
{
    public class UserCollection
    {
        IUserCollectionDAL _userCollectionDAL = UserFactoryDAL.CreateUserCollectionDAL();
        private List<UserModel> users { get; set; } = new List<UserModel>();
        public void CreateUser(UserModel newUser)
        {
            // newUser.Validate();      // Validate the new userModel
            if (newUser.Validate())
            {
                // Map Logic model to DTO
                UserDTO newUserDTO = new UserDTO
                {
                    UserName = newUser.UserName,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Password = newUser.Password,
                    Email = newUser.Email,
                    DoB = newUser.DoB
                };

                _userCollectionDAL.CreateUser(newUserDTO);
            }
            else
            {
                Console.WriteLine("UserModel not valid");
            }
        }

        public IEnumerable<UserModel> GetUserByUserNameOrEmail(string identifier)
        {
            IEnumerable<UserDTO> userDTOs = _userCollectionDAL.GetUserByUserNameOrEmail(identifier);
            foreach(var userDTO in userDTOs)
            {
                UserModel user = new UserModel(userDTO);
                users.Add(user);
            }
            return users;
        }


    }
}
