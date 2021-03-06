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
            string day = DateTime.Parse(Date).DayOfWeek.ToString().Substring(0, 3);

            ViewBag.Day = day;
            ViewBag.Date = DateTime.Parse(Date);
            ViewBag.businessId = businessId;

            if (DateTime.Parse(Date) >= DateTime.Now && DateTime.Parse(Date) <= DateTime.Now.AddDays(14))
            {
                IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(DateTime.Parse(Date), day, businessId);

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
            string d = form["Date"];

            string day = DateTime.Parse(d).DayOfWeek.ToString().Substring(0, 3);

            ViewBag.Day = day;
            ViewBag.Date = DateTime.Parse(d);
            ViewBag.businessId = businessId;

            if (DateTime.Parse(d) >= DateTime.Now && DateTime.Parse(d) <= DateTime.Now.AddDays(14))
            {
                IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(DateTime.Parse(d), day, businessId);

                return View(timeSlots);
            }
            else
            {
                TempData["ErrorDate"] = "Please select a date later than today and within two weeks!";
                return RedirectToAction("BusinessPage", "Home", new { id = businessId });
            }
        }


        public IActionResult CreateReservation(string date, int businessId, int pickedTimeSlotId)
        {
            DateTime _date = DateTime.Parse(date);
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

                return RedirectToAction("TimeSlotPicker", new { Date = date, businessId = businessId });
            }
        }
    }
}
