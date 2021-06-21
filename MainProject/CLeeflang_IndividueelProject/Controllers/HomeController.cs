using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CLeeflang_IndividueelProject.Models;
using Logic;
using Logic.BusinessUser;
using Microsoft.AspNetCore.Authorization;

namespace CLeeflang_IndividueelProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly BusinessUserCollection _businessUserCollection = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("BusinessUser"))
            {
                return RedirectToAction("BusinessDashboard");
            }
            else
            {
                return View(_businessUserCollection.GetAllBusinesses());

            }
        }

        [Authorize(Roles = "BusinessUser")]
        public IActionResult BusinessDashboard()
        {
            return View(_businessUserCollection.GetBusinessByUserNameForView(User.Identity.Name));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BusinessPage(int id)
        {
            BusinessUserModel businessUser = _businessUserCollection.GetBusinessByIdForView(id);
            return View(businessUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
