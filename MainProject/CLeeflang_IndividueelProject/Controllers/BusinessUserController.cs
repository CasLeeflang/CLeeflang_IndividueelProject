using CLeeflang_IndividueelProject.Models.BusinessUser;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        //private readonly UserManager<UserModel> _userManager;

        public BusinessUserController(PasswordSalt PassSalt /*, UserManager<UserModel> userManager*/)
        {
            _salt = PassSalt.Salt;      // Set Salt
            //_userManager = userManager;
        }

        BusinessUserCollection _businessUserCollection = new BusinessUserCollection();

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
            newViewBusinessUser.Password = Crypto.HashPassword(newViewBusinessUser.Password + _salt);
            newViewBusinessUser.ConfirmPassword = null;

            if (ModelState.IsValid)
            {
                BusinessUserModel newBusinessUser = new BusinessUserModel(newViewBusinessUser.BusinessName, newViewBusinessUser.UserName, newViewBusinessUser.Password, newViewBusinessUser.Email, newViewBusinessUser.Sector);
                BusinessRegistration _businessUserValidation = newBusinessUser.Validate();

                if (_businessUserValidation.Valid)
                {
                    _businessUserCollection.CreateBusinessUser(newBusinessUser);
                    return RedirectToAction("Index", "Home");
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
                    return View();

                }

            }
            else
            {
                ViewBag.ErrorMessage = "Oops, something went wrong. Please try again!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(BusinessLoginModel logDetails)
        {
            BusinessUserModel loginBusinessUser = _businessUserCollection.GetBusinessUserByUserNameOrEmail(logDetails.Identifier).FirstOrDefault();

            if(loginBusinessUser != null)
            {
                if (Crypto.VerifyHashedPassword(loginBusinessUser.Password, logDetails.Password + _salt) && (logDetails.Identifier == loginBusinessUser.UserName || logDetails.Identifier == loginBusinessUser.Email))
                {
                    logDetails.Password = null;
                    Authenticate(loginBusinessUser);
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

        public void Authenticate(BusinessUserModel businessUser)     // Method to authenticate the user once the password is checked
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "BusinessUser"));
            claims.Add(new Claim(ClaimTypes.Name, businessUser.UserName));
            //claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
