using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLeeflang_IndividueelProject.Models;
using Logic;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Variables.ValidationResponse;

namespace CLeeflang_IndividueelProject.Controllers
{
    [Authorize(Roles = "BusinessUser")]
    public class TimeSlotController : Controller
    {
        TimeSlotCollection _timeSlotCollection = new TimeSlotCollection();
        BusinessUserCollection _businessUserCollection = new BusinessUserCollection();

        public IActionResult ManageTimeSlot()
        {
            var t = TempData["TimeSlotError"];
            var s = TempData["SpotError"];

            if (t != null || s != null)
            {
                ViewBag.TimeSlotError = t;
                ViewBag.SpotError = s;
            }
            return View();
        }

        public IActionResult SaveTimeSlot(TimeSlotViewModel timeSlot)
        {
            // Map viewmodel to logic model
            TimeSlotModel timeSlotLog = new TimeSlotModel(_businessUserCollection.GetBusinessId(User.Identity.Name), timeSlot.DayOTWeek, timeSlot.StartTime, timeSlot.EndTime, timeSlot.NumberOfSpots);

            TimeSlotCreation _creationValidation = timeSlotLog.Validate();   //  Initialise validation object

            // Validate the timespan
            if (_creationValidation.Valid)
            {
                _timeSlotCollection.CreateTimeSlot(timeSlotLog);
                return RedirectToAction("ManageTimeSlot");
            }
            else
            {
                if (_creationValidation.TimeError)
                {
                    TempData["TimeSlotError"] = "Select end time later than start time!";
                }
                if (_creationValidation.SpotError)
                {
                    TempData["SpotError"] = "Timeslot needs at least 1 spot!";
                }
                return RedirectToAction("ManageTimeSlot");
            }
        }

        public IActionResult DeleteTimeSlot(int id)
        {
            _timeSlotCollection.DeleteTimeSlot(id);
            return RedirectToAction("ManageTimeSlot");
        }
    }
}
