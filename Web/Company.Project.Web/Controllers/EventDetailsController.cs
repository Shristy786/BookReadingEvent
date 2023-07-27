using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class EventDetailsController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult UpcomingEvents()
        {
            return View();
        }
        public IActionResult PastEvents()
        {
            return View();
        }
    }
}
