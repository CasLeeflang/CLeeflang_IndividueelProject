using CLeeflang_IndividueelProject.Models.BusinessUser;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class BusinessUserController : Controller
    {
        // Initialise the Salt variable (defined in startup.cs)
        private static string _salt;

        public BusinessUserController(PasswordSalt PassSalt)
        {
            _salt = PassSalt.Salt;      // Set Salt
        }

        //  Dependicy injection?
        readonly BusinessUserCollection _businessUserCollection = new();

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(BusinessUserViewModel newViewBusinessUser)
        {
            //  Method to register a new Business user

            newViewBusinessUser.Password = Crypto.HashPassword(newViewBusinessUser.Password + _salt);   //  Hash and salt the password
            newViewBusinessUser.ConfirmPassword = null;

            if (ModelState.IsValid)     //  Check if the viewmodel is valid
            {
                BusinessUserModel newBusinessUser = new BusinessUserModel(newViewBusinessUser.BusinessName, newViewBusinessUser.UserName, newViewBusinessUser.Password, newViewBusinessUser.Email, newViewBusinessUser.Sector);

                BusinessRegistration _businessUserValidation = newBusinessUser.Validate();      //  Get the registration validation response

                if (_businessUserValidation.Valid)
                {
                    _businessUserCollection.CreateBusinessUser(newBusinessUser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //  Definde error messages for registration
                    if (_businessUserValidation.BusinessNameError)
                    {
                        ViewBag.ErrorMessageBusinessName = "Business name already in use!";
                    }
                    if (_businessUserValidation.UserNameError)
                    {
                        ViewBag.ErrorMessageUserName = "Username already in use!";

                    }
                    if (_businessUserValidation.EmailError)
                    {
                        ViewBag.ErrorMessageEmail = "Email adress already in use!";
                    }

                    return View();
                }

            }
            else
            {
                //  If this far, something went wrong and abort, view checks didnt work
                ViewBag.ErrorMessage = "Oops, something went wrong. Please try again!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(BusinessLoginModel logDetails)
        {
            //  Method to login a business user 

            try
            {
                BusinessUserModel loginBusinessUser = _businessUserCollection.GetBusinessUserByUserNameOrEmail(logDetails.Identifier).FirstOrDefault();

                if (loginBusinessUser != null)
                {
                    if (Crypto.VerifyHashedPassword(loginBusinessUser.Password, logDetails.Password + _salt))
                    {
                        logDetails.Password = null;         //  Delete the unhashed password
                        Authenticate(loginBusinessUser);    //  Authenticate the business user

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
            catch (Exception)
            {
                ViewBag.LoginError = "Error occured while loging in, please try again!";
                return View();
            }


        }

        public void Authenticate(BusinessUserModel businessUser)     // Method to authenticate the user once the password is checked
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "BusinessUser"));             //Define the role
            claims.Add(new Claim(ClaimTypes.Name, businessUser.UserName));      //Define the UserName

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public ActionResult Logout()
        {
            //  Method to log out the business user

            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "BusinessUser")]
        public IActionResult BusinessUserPage()
        {
            BusinessUserModel businessUser = _businessUserCollection.GetBusinessUserByUserNameOrEmail(User.Identity.Name).FirstOrDefault();
            return View(businessUser);
        }

        public IActionResult EditBusinessUser()
        {
            BusinessUserModel businessUser = _businessUserCollection.GetBusinessUserByUserNameOrEmail(User.Identity.Name).FirstOrDefault();
            return View(businessUser);
        }

        [HttpPost]
        public IActionResult UpdateBusinessUser(BusinessUserModel updatedBusinessUser)
        {
            BusinessRegistration _businessUserValidation = updatedBusinessUser.Validate();
            try
            {

                if (_businessUserValidation.Valid)
                {
                    if (updatedBusinessUser.Update() == 1)
                    {
                        Authenticate(updatedBusinessUser);
                        return RedirectToAction("BusinessUserPage");
                    }
                    else
                    {
                        ViewBag.LoginError = "Error occured while loging in, please try again!";
                        return RedirectToAction("EditBusinessUser");
                    }
                }
                else
                {
                    if (_businessUserValidation.BusinessNameError)
                    {
                        ViewBag.ErrorMessageBusinessName = "Business name already in use!";
                    }
                    if (_businessUserValidation.UserNameError)
                    {
                        ViewBag.ErrorMessageUserName = "Username already in use!";
                    }
                    if (_businessUserValidation.EmailError)
                    {
                        ViewBag.ErrorMessageEmail = "Email adress already in use!";
                    }

                    return RedirectToAction("EditBusinessUser");
                }
            }
            catch (Exception)
            {
                ViewBag.LoginError = "Error occured while loging in, please try again!";
                return RedirectToAction("EditBusinessUser");
            }
        }
    }
}
