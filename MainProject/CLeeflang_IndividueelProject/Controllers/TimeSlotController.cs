using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLeeflang_IndividueelProject.Models;
using Interface;
using Logic;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLeeflang_IndividueelProject.Controllers
{
    [Authorize(Roles = "BusinessUser")]
    public class TimeSlotController : Controller
    {
        TimeSlotCollection _timeSlotCollection = new TimeSlotCollection();
        BusinessUserCollection _businessUserCollection = new BusinessUserCollection();

        public IActionResult ManageTimeSlot()
        {
            return View();
        }

        public IActionResult SaveTimeSlot(TimeSlotViewModel timeSlot)
        {
            // Map viewmodel to logic model
            TimeSlotModel timeSlotLog = new TimeSlotModel(_businessUserCollection.GetBusinessId(User.Identity.Name), timeSlot.DayOTWeek, timeSlot.StartTime, timeSlot.EndTime, timeSlot.NumberOfSpots);

            // Validate the timespan
            if (timeSlotLog.Validate())
            {
                _timeSlotCollection.CreateTimeSlot(timeSlotLog);
                return RedirectToAction("ManageTimeSlot");
            }
            else
            {
                Console.WriteLine("Model not valid");
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
