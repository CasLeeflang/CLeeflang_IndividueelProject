using Interface.User;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.User
{
    public class UserModel : IUser
    {
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

        public bool Validate()
        {
            // implement validation for all properties
            return true;
        }

        public bool HashSaltPassword()
        {
            try
            {
                // Hash and Salt password, then overwrite
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
