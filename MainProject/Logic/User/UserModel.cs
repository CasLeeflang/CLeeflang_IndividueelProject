using FactoryDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables.ValidationResponse;
using Contract_Layer.User;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Logic.User
{
    public class UserModel
    {
        IUserDAL _userDAL = UserFactoryDAL.CreateUserDAL();

        //  Model Used For Testing
        public UserModel(string userName, string firstName, string lastName, string Password, string Email, DateTime DoB, IUserDAL userDAL)
        {
            _userDAL = userDAL;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            this.Password = Password;
            this.Email = Email;
            this.DoB = DoB;
        }


        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; } // Hashed and salted
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public IFormFile ImageFile { get; set; }
        public Byte[] ImageByteArray { get; set; }
        public string ImageBase64 { get; set; }
#nullable enable
        public int? NumberOfReservations { get; set; }
        public object CookieAuthenticationDefaults { get; private set; }
#nullable disable


        public UserModel(string userName, string firstName, string lastName, string Password, string Email, DateTime DoB)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            this.Password = Password;
            this.Email = Email;
            this.DoB = DoB;
        }

        public UserModel(IFormFile imageFile, string userName, string firstName, string lastName, string Password, string Email, DateTime DoB)
        {
            ImageFile = imageFile;
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
            NumberOfReservations = userDTO.NumberOfReservations;
            ImageByteArray = userDTO.ImageByteArray;
            ImageBase64 = ByteArrayToStringbase64();
        }

        public void Update(UserModel updatedUser)
        {
            UserDTO updateUserDTO = new UserDTO
            {
               UserName = updatedUser.UserName,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Password = updatedUser.Password,
                Email = updatedUser.Email,
                DoB = updatedUser.DoB,
                ImageByteArray = updatedUser.ImageByteArray
            };            

            _userDAL.UpdateUser(updateUserDTO);
        }

        public UserRegistration Validate()
        {
            //  Method used to Validate a new user

            UserDTO? existingUser = _userDAL.CheckUserNameEmail(UserName, Email).FirstOrDefault();

            UserRegistration _registerValidation = new UserRegistration();

            if (existingUser == null)
            {
                if (DoB.Date < DateTime.Now.Date && DoB.Date > DateTime.Parse("1/1/1800"))
                {
                    _registerValidation.Valid = true;   //  If everything checks out
                }
                else
                {
                    _registerValidation.DoBError = true;
                }

            }

            else
            {
                if (existingUser.UserName.ToLower() == UserName.ToLower())
                {
                    _registerValidation.UserNameError = true;

                }
                if (existingUser.Email.ToLower() == Email.ToLower())
                {
                    _registerValidation.EmailError = true;
                }
                if (DoB.Date >= DateTime.Now.Date || DoB.Date < DateTime.Parse("1/1/1800"))
                {
                    _registerValidation.DoBError = true;
                }
            }

            return _registerValidation;
        }
        public Byte[] ImageToByteArray()
        {
            if (ImageFile != null)
            {
                var sourceStream = ImageFile.OpenReadStream();

                using (var memoryStream = new MemoryStream())
                {
                    sourceStream.CopyTo(memoryStream);
                    var imageByteArray = memoryStream.ToArray();
                    ImageByteArray = imageByteArray;
                }
            }
            else
            {
                ImageByteArray = new Byte[0];
            }

            return ImageByteArray;
        }

        private string ByteArrayToStringbase64()
        {
            if (ImageByteArray.Length > 0)
            {
                return Convert.ToBase64String(ImageByteArray);
            }
            else
            {
                return null;
            }
        }
    }
}
