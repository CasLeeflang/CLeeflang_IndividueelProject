using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLeeflang_IndividueelProject.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class TimeSlotController : Controller
    {
        List<ITimeSlot> timeSlots = new List<ITimeSlot>();

        public IActionResult CreateTimeSlot()
        {
            return View();
        }

        public IActionResult SaveTimeSlot(TimeSlotViewModel timeSlot)
        {
            TimeSlotManager.SaveTimeSlot(timeSlot); 

            return RedirectToAction("CreateTimeSlot");
        }
    }
}
