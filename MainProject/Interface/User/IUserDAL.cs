﻿using Models;
using System.Collections.Generic;

namespace Interface.User
{
    public interface IUserDAL
    {
        void UpdateUser(UserDTO newUser);
        bool ValidateNewUser(string userName, string email);


    }
}