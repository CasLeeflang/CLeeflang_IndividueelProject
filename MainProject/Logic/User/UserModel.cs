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
    public class UserModel 
    {
        IUserDAL _userDAL = UserFactoryDAL.CreateUserDAL();
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; } // Hashed and salted
        public string Email { get; set; }
        public DateTime DoB { get; set; }


        public UserModel(string userName, string firstName, string lastName, string Password, string Email, DateTime DoB)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            this.Password = Password;
            this.Email = Email;
            this.DoB = DoB;
        }

        public UserModel(UserDTO userDTO)
        {
            Id = userDTO.Id;
            UserName = userDTO.UserName;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            Password = userDTO.Password;
            Email = userDTO.Email;
            DoB = userDTO.DoB;
        }

        public void Update(UserModel updatedUser)
        {
            this.Id = updatedUser.Id;
            this.UserName = updatedUser.UserName;
            this.FirstName = updatedUser.FirstName;
            this.LastName = updatedUser.LastName;
            this.Password = updatedUser.Password;
            this.Email = updatedUser.Email;
            this.DoB = updatedUser.DoB;
        }

        public bool Validate()
        {           
            return  _userDAL.ValidateNewUser(UserName, Email);
        }
    }
}
