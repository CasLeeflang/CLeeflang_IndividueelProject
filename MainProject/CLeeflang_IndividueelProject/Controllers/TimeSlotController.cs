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
            _timeSlotCollection.CreateTimeSlot(timeSlot); 

            return RedirectToAction("CreateTimeSlot");
        }
    }
}
