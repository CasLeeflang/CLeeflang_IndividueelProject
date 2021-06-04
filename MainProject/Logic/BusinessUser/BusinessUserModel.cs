using FactoryDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Variables.ValidationResponse;
using Contract_Layer.BusinessUser;

namespace Logic.BusinessUser
{
    public class BusinessUserModel
    {
        IBusinessUserDAL _businessUserDAL = BusinessUserFactoryDAL.CreateBusinessUserDAL();

        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Sector { get; set; }

        public BusinessUserModel()
        {

        }
        public BusinessUserModel(string businessName, string userName, string password, string email, string sector)
        {
            BusinessName = businessName;
            UserName = userName;
            Password = password;
            Email = email;
            Info = "";
            Sector = sector;
        }

        public BusinessUserModel(BusinessUserDTO businessUserDTO)
        {
            Id = businessUserDTO.Id;
            BusinessName = businessUserDTO.BusinessName;
            UserName = businessUserDTO.UserName;
            Password = businessUserDTO.Password;
            Email = businessUserDTO.Email;
            Info = businessUserDTO.Info;
            Sector = businessUserDTO.Sector;
        }

        public int Update()
        {
            BusinessUserDTO updatedBusinessUserDTO = new BusinessUserDTO
            {
                Id = Id,
                BusinessName = BusinessName,
                UserName = UserName,
                Email = Email,
                Info = Info,
                Sector = Sector
            };

            return _businessUserDAL.UpdateBusinessUser(updatedBusinessUserDTO);
        }

        public BusinessRegistration Validate()
        {
            //  Method to validate a new business user

            IEnumerable<BusinessUserDTO> _existingBusinessUsers = _businessUserDAL.CheckBusinessUserNameEmailName(UserName, Email, BusinessName);

            BusinessRegistration _registerValidation = new BusinessRegistration();

            foreach (var existingBusinessUser in _existingBusinessUsers)
            {

                if (existingBusinessUser == null)
                {
                    _registerValidation.Valid = true;
                }
                else
                {
                    if(existingBusinessUser.Id == Id && _existingBusinessUsers.Count() == 1)
                    {
                        _registerValidation.Valid = true;
                    }

                    if (existingBusinessUser.Id != Id)
                    {
                        if (existingBusinessUser.UserName.ToLower() == UserName.ToLower())
                        {
                            _registerValidation.UserNameError = true;

                        }
                        if (existingBusinessUser.Email.ToLower() == Email.ToLower())
                        {
                            _registerValidation.EmailError = true;
                        }
                        if (existingBusinessUser.BusinessName.ToLower() == BusinessName.ToLower())
                        {
                            _registerValidation.BusinessNameError = true;
                        }

                        if (!_registerValidation.UserNameError && !_registerValidation.EmailError && !_registerValidation.BusinessNameError)
                        {
                            _registerValidation.Valid = true;   
                        }
                    }                                    
                }
            }

            return _registerValidation;
        }

        public void UpdateInfo()
        {
            BusinessUserDTO updatedBusinessUserDTO = new BusinessUserDTO
            {
                Id = Id,
                Info = Info
            };

            _businessUserDAL.UpdateBusinessInfo(updatedBusinessUserDTO);
        }
    }
}
