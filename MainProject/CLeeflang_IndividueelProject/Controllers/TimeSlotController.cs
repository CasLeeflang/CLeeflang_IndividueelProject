using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLeeflang_IndividueelProject.Models;
using Interface;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class TimeSlotController : Controller
    {
        TimeSlotCollection _timeSlotCollection = new TimeSlotCollection();

        List<ITimeSlot> timeSlots = new List<ITimeSlot>();

        public IActionResult CreateTimeSlot()
        {
            return View();
        }

        public IActionResult SaveTimeSlot(TimeSlotViewModel timeSlot)
        {
            // Map viewmodel to logic model
            TimeSlotModel timeSlotLog = new TimeSlotModel(timeSlot.BusinessId, timeSlot.DayOTWeek, timeSlot.StartTime, timeSlot.EndTime, timeSlot.NumberOfSpots);

            // Validate the timespan
            if (timeSlotLog.Validate())
            {
                _timeSlotCollection.CreateTimeSlot(timeSlotLog);
                return RedirectToAction("CreateTimeSlot");
            }
            else
            {
                Console.WriteLine("Model not valid");
                return RedirectToAction("CreateTimeSlot");
            }
        }
    }
}
