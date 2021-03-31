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

        public void CreateUser(UserModel newUser)
        {
            // Map View model to Logic Model
            UserDTO newUserDTO = new UserDTO
            {
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Password = newUser.Password,
                Email = newUser.Email,
                DoB = newUser.DoB
            };

            // _userCollectionDAL.CreateUser(newUserDTO);
        }

        public IEnumerable<UserModel> GetUserByUserNameOrEmail(string identifier)
        {
            IEnumerable<UserDTO> userDTO = _userCollectionDAL.GetUserByUserNameOrEmail(identifier);



            //IEnumerable<UserModel> user = new List<UserModel>
            //{
            //  new UserModel(userDTO.First())
            //};
  

            return userDTO as IEnumerable<UserModel>;

        }
    }
}
