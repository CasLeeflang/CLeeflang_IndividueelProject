using CLeeflang_IndividueelProject.Models;
using CLeeflang_IndividueelProject.Models.Reservation;
using Logic.BusinessUser;
using Logic.Reservation;
using Logic.TimeSlot;
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

        readonly UserCollection _userCollection = new();
        readonly ReservationCollection _reservationCollection = new();
        readonly TimeSlotCollection _timeSlotCollection = new();
        readonly BusinessUserCollection _businessUserCollection = new();

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

        public IActionResult ReservationOverview()
        {
            IEnumerable<ReservationModel> reservations = _reservationCollection.GetReservationByUserId(_userCollection.GetUserId(User.Identity.Name));

            List<ReservationOverviewModel> reservationOverviewModels = new List<ReservationOverviewModel>();

            foreach (var reservation in reservations)
            {
                TimeSlotModel timeSlot = _timeSlotCollection.GetTimeSlotById(reservation.TimeSlotId).LastOrDefault();

                ReservationOverviewModel reservationView = new ReservationOverviewModel
                {
                    Id = reservation.Id,
                    BusinessName = _businessUserCollection.GetBusinessByIdForView(timeSlot.BusinessId).BusinessName,
                    Date = reservation.Date.ToString("dd/MM/yyyy"),
                    StartTime = timeSlot.StartTime.ToString("HH:mm"),
                    EndTime = timeSlot.EndTime.ToString("HH:mm")
                };
                reservationOverviewModels.Add(reservationView);
            }    

            IEnumerable<ReservationOverviewModel> reservationsView = reservationOverviewModels.OrderBy(o => o.Date).ThenBy(o => o.StartTime);  
            return View(reservationsView);
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
            try
            {
                UserModel loginUser = _userCollection.GetUserByUserNameOrEmail(LogDetails.Identifier).FirstOrDefault();    // Get the User with the specic identifier which equals the username or email
                
                if (loginUser != null)
                {
                    if (Crypto.VerifyHashedPassword(loginUser.Password, LogDetails.Password + _salt))
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

            catch (Exception)
            {
                ViewBag.LoginError = "Error occured while logging in, please try again!";
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
