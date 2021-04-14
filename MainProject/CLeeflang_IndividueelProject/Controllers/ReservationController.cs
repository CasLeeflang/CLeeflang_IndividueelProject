using Logic.Reservation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class ReservationController : Controller
    {
        ReservationCollection _reservationCollection = new();

        public IActionResult Index()
        {
            return View();
        }
    }
}
