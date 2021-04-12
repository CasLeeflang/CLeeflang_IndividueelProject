using CLeeflang_IndividueelProject.Models.BusinessUser;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Variables;

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
            newViewBusinessUser.ConfirmPassword = "";

            if (ModelState.IsValid)
            {
                BusinessUserModel newBusinessUser = new BusinessUserModel(newViewBusinessUser.BusinessName, newViewBusinessUser.UserName, newViewBusinessUser.Password, newViewBusinessUser.Email, newViewBusinessUser.Sector);

                if (newBusinessUser.Validate())
                {
                    _businessUserCollection.CreateBusinessUser(newBusinessUser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Username or Email already in use!";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Oops, something went wrong. Please try again!";
                return View();
            }
        }



    }
}
