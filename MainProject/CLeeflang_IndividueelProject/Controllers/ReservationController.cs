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


        public IActionResult TimeSlotPicker(int businessId, string Date)
        {

            List<string> DotW = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };


            int dayIndex = (int)DateTime.Parse(Date).DayOfWeek;
            string day = DotW[dayIndex - 1];

            ViewBag.Day = day;
            ViewBag.Date = DateTime.Parse(Date);
            ViewBag.businessId = businessId;

            if (DateTime.Parse(Date) > DateTime.Now)
            {
                IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(day, businessId);

                return View(timeSlots);
            }
            else
            {
                TempData["ErrorDate"] = "Please select a date later than today!";
                return RedirectToAction("BusinessPage", "Home", new { id = businessId });
            }

        }

        [HttpPost]
        public IActionResult TimeSlotPicker(int businessId, IFormCollection form)
        {

            List<string> DotW = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            string d = form["Date"];

            int dayIndex = (int)DateTime.Parse(d).DayOfWeek;
            string day = DotW[dayIndex - 1];

            ViewBag.Day = day;
            ViewBag.Date = DateTime.Parse(d);
            ViewBag.businessId = businessId;

            if (DateTime.Parse(d) > DateTime.Now)
            {
                IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(day, businessId);

                return View(timeSlots);
            }
            else
            {
                TempData["ErrorDate"] = "Please select a date later than today!";
                return RedirectToAction("BusinessPage", "Home", new { id = businessId });
            }
        }

        public IActionResult CreateReservation(string dateString, string userName, int businessId, int pickedTimeSlotId)
        {
            DateTime date = DateTime.Parse(dateString);

            int userId = _userCollection.GetUserId(userName);

            ReservationModel newReservation = new ReservationModel(date, userId, businessId, pickedTimeSlotId);

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
                return RedirectToAction("TimeSlotPicker", new { Date = dateString, businessId = businessId });
            }
        }
    }
}
