using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class TimeSlotController : Controller
    {
        public IActionResult CreateTimeSlot()
        {
            return View();
        }
    }
}
