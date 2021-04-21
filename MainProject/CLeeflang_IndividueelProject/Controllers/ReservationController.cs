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

namespace CLeeflang_IndividueelProject.Controllers
{
    [Authorize(Roles = "User")]
    public class ReservationController : Controller
    {
        ReservationCollection _reservationCollection = new();
        BusinessUserCollection _businessUserCollection = new();
        TimeSlotCollection _timeSlotCollection = new();
        UserCollection _userCollection = new();

        public IActionResult DatePicker(int businessId)
        {
            ViewBag.businessId = businessId;
            return View();
        }
        public IActionResult TimeSlotPicker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimeSlotPicker(int businessId, IFormCollection form)
        {
            
            List<string> DotW = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            int dayIndex = (int)DateTime.Parse(form["Date"]).DayOfWeek; 
            string day = DotW[dayIndex - 1];

            ViewBag.Date = DateTime.Parse(form["Date"]);
            ViewBag.Day = day;
            ViewBag.businessId = businessId;

            IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByDayAndBusinessId(day, businessId);
            return View(timeSlots);
        }

        public IActionResult CreateReservation(string dateString, string userName, int businessId, int pickedTimeSlotId)
        {
            DateTime date = DateTime.Parse(dateString);
    
            int userId = _userCollection.GetUserId(userName);

            ReservationModel newReservation = new ReservationModel(date, userId, businessId, pickedTimeSlotId);

            _reservationCollection.CreateReservation(newReservation);
            return RedirectToAction("Index", "Home");

        }
    }
}
