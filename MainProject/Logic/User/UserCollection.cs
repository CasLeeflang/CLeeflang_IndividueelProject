using FactoryDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.User;

namespace Logic.User
{
    public class UserCollection
    {
        //  Dependicy injection
        IUserCollectionDAL _userCollectionDAL;
        public UserCollection()
        {
            _userCollectionDAL = UserFactoryDAL.CreateUserCollectionDAL();
        }

        public UserCollection(IUserCollectionDAL userCollectionDAL)
        {
            _userCollectionDAL = userCollectionDAL;
        }

        private List<UserModel> users { get;} = new List<UserModel>();

        public void CreateUser(UserModel newUser)
        {
            //  Creates a new user

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

        public IEnumerable<UserModel> GetUserByUserNameOrEmail(string identifier)
        {
            //  Returns the user where the username or email equals the identifier

            IEnumerable<UserDTO> userDTOs = _userCollectionDAL.GetUserByUserNameOrEmail(identifier);
            foreach (var userDTO in userDTOs)
            {
                UserModel user = new UserModel(userDTO);
                users.Add(user);
            }
            return users;
        }

        public IEnumerable<UserModel> GetUserByUserName(string userName)
        {
            //  Returns a user based on the username

            IEnumerable<UserDTO> userDTOs = _userCollectionDAL.GetUserByUserName(userName);

            foreach(var userDTO in userDTOs)
            {
                Console.WriteLine(userDTO.NumberOfReservations);
                UserModel user = new UserModel(userDTO);
                users.Add(user);
            }
            return users;
        }

        public int GetUserId(string userName)
        {
            //  returns the id based on the username of the user

            int userId = _userCollectionDAL.GetUserId(userName).LastOrDefault().Id;
            return userId;
        }

    }
}
