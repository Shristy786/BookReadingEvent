using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Company.Project.Web.Models;
using Company.Project.Web.Repository;
using Microsoft.AspNetCore.Http;

namespace Company.Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CreateEventRepository _createEventRepository = null;


      
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger, CreateEventRepository createEventRepository)
        {
            _logger = logger;
            _createEventRepository = createEventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _createEventRepository.GetAllEvents();
            string email = HttpContext.Session.GetString("Email");
            ViewBag.email = email;
            return View(data);
           
        }
        

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult CreateEvent()
        //{
        //    return View();
        //}
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
