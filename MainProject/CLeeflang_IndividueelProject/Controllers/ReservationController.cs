using CLeeflang_IndividueelProject.Models.Date;
using CLeeflang_IndividueelProject.Models.Reservation;
using Logic.BusinessUser;
using Logic.Reservation;
using Logic.TimeSlot;
using Logic.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Variables.ValidationResponse;

namespace CLeeflang_IndividueelProject.Controllers
{
    [Authorize(Roles = "User")]
    public class ReservationController : Controller
    {
        readonly ReservationCollection _reservationCollection = new();
        readonly TimeSlotCollection _timeSlotCollection = new();
        readonly UserCollection _userCollection = new();

        public IActionResult DatePicker(int businessId)
        {
            ViewBag.businessId = businessId;
            return View();
        }


        //public IActionResult TimeSlotPicker(int businessId, string Date)
        //{

        //    List<string> DotW = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };


        //    int dayIndex = (int)DateTime.Parse(Date).DayOfWeek;
        //    string day = DotW[dayIndex - 1];    //  Can be done more elegantly if DayOTWeek is stored as int in timeslot table 

        //    ViewBag.Day = day;
        //    ViewBag.Date = DateTime.Parse(Date);
        //    ViewBag.businessId = businessId;

        //    if (DateTime.Parse(Date) > DateTime.Now)
        //    {
        //        IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(DateTime.Parse(Date), day, businessId);

        //        return View(timeSlots);
        //    }
        //    else
        //    {
        //        TempData["ErrorDate"] = "Please select a date later than today!";
        //        return RedirectToAction("BusinessPage", "Home", new { id = businessId });
        //    }

        //}

        public IActionResult TimeSlotPicker(int businessId, DateTime date)
        {
            string d = form["Date"];
            DateTime date = DateTime.Parse(d);

            string day = DateTime.Parse(d).DayOfWeek.ToString().Substring(0,3);

            ViewBag.Day = day;
            ViewBag.Date = date;
            ViewBag.businessId = businessId;

            if (date >= DateTime.Now && date <= DateTime.Now.AddDays(14))
            {
                IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(date, day, businessId);

                return View(timeSlots);
            }
            else
            {
                TempData["ErrorDate"] = "Please select a date later than today and within two weeks!";
                return RedirectToAction("BusinessPage", "Home", new { id = businessId });
            }
        }

  
        public IActionResult CreateReservation(DateTime date, int businessId, int pickedTimeSlotId)
        {
            DateTime _date = date;
            int userId = _userCollection.GetUserId(User.Identity.Name); //  get userid from logged in user

            ReservationModel newReservation = new ReservationModel(_date, userId, businessId, pickedTimeSlotId);

            ReservationValidation _reservationValidation = newReservation.Validate();

            if (_reservationValidation.Valid)
            {
                _reservationCollection.CreateReservation(newReservation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (_reservationValidation.ExistsForUser)
                {
                    TempData["ErrorReservationExists"] = "You already have a timeslot reserved for this date!";
                }
                if (_reservationValidation.InvalidDate)
                {
                    TempData["ErrorDate"] = "Reservations can only be made between now and two weeks ahead!";
                }
                
                return RedirectToAction("TimeSlotPicker", new { date = _date, businessId = businessId });
            }
        }
    }
}
