using CLeeflang_IndividueelProject.Models;
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

namespace CLeeflang_IndividueelProject.Controllers
{
    public class UserController : Controller
    {
        // Initialise the Salt variable (defined in startup.cs)
        private static string _salt; 
        //private readonly UserManager<UserModel> _userManager;

        public UserController(PasswordSalt PassSalt /*, UserManager<UserModel> userManager*/)
        {
            _salt = PassSalt.Salt;      // Set Salt
            //_userManager = userManager;
        }


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
            //ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel newViewUser)
        {
            newViewUser.Password = Crypto.HashPassword(newViewUser.Password + _salt);   // hash and salt the password

            if (ModelState.IsValid)
            {

                UserModel newUser = new UserModel(newViewUser.UserName, newViewUser.FirstName, newViewUser.LastName, newViewUser.Password, newViewUser.Email, newViewUser.DoB);


                _userCollection.CreateUser(newUser);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }



        [HttpPost]
        public ActionResult Login(LoginModel LogDetails)
        {
            UserModel loginUser = _userCollection.GetUserByUserNameOrEmail(LogDetails.Identifier).FirstOrDefault();    // Get the User with the specic identifier, username or email

            if (Crypto.VerifyHashedPassword(loginUser.Password, LogDetails.Password + _salt))    // Check if the password is correct with the hashed password in the DB
            {
                LogDetails.Password = null;     // Delete the unhashed password
                Authenticate(loginUser);        // authenticate the user
            }
            return RedirectToAction("Index", "Home");
        }

        public void Authenticate(UserModel user)     // Method to authenticate the user once the password is checked
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
            //claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
