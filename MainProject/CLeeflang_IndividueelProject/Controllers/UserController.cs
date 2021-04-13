﻿using CLeeflang_IndividueelProject.Models;
using Logic.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Variables;
using Variables.ValidationResponse;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class UserController : Controller
    {
        // Initialise the Salt variable (defined in startup.cs)
        private static string _salt;


        public UserController(PasswordSalt PassSalt)
        {
            _salt = PassSalt.Salt;      // Set Salt
        }

        //  Dependicy injection?
        UserCollection _userCollection = new UserCollection();

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserPage()
        {
            UserModel user = _userCollection.GetUserByUserName(User.Identity.Name).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Register(UserViewModel newViewUser)
        {
            //  Method to register a new user

            newViewUser.Password = Crypto.HashPassword(newViewUser.Password + _salt);   //  hash and salt the password
            newViewUser.PasswordConfirm = null;

            if (ModelState.IsValid)     //  Checks if viewmodel is valid
            {

                UserModel newUser = new UserModel(newViewUser.UserName, newViewUser.FirstName, newViewUser.LastName, newViewUser.Password, newViewUser.Email, newViewUser.DoB);

                UserRegistration _userValidation = newUser.Validate();      //   Get the registration validation response

                if (_userValidation.Valid)
                {
                    _userCollection.CreateUser(newUser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {   
                    //  Define the error messages for registration
                    if (_userValidation.UserNameError)
                    {
                        ViewBag.ErrorMessageUserName = "Username already in use!";

                    }
                    if (_userValidation.EmailError)
                    {
                        ViewBag.ErrorMessageEmail = "Email adress already in use!";

                    }
                    if (_userValidation.DoBError)
                    {
                        ViewBag.ErrorMessageDoB = "Please enter a valid date of birth!";
                    }
                    return View();
                }
            }
            else
            {
                //  If this far, something went wrong and abort
                ViewBag.ErrorMessage = "Oops, something went wrong. Please try again!";
                return View();
            }

        }



        [HttpPost]
        public ActionResult Login(LoginModel LogDetails)
        {
            //  Method to login a user

            UserModel loginUser = _userCollection.GetUserByUserNameOrEmail(LogDetails.Identifier).FirstOrDefault();    // Get the User with the specic identifier which equals the username or email

            if (loginUser != null)
            {
                if (Crypto.VerifyHashedPassword(loginUser.Password, LogDetails.Password + _salt) && (LogDetails.Identifier == loginUser.UserName || LogDetails.Identifier == loginUser.Email))
                {
                    LogDetails.Password = null;     //  Delete the unhashed password
                    Authenticate(loginUser);        //  authenticate the user

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginError = "Username or Password incorrect";
                    return View();
                }

            }
            else
            {
                ViewBag.LoginError = "Username or Password incorrect";
                return View();
            }

        }

        public void Authenticate(UserModel user)     // Method to authenticate the user once the password is checked
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "User"));             //  Define the role
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));      //  Define the UserName

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public ActionResult Logout()
        {
            //  Method to log out the user

            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
