using Company.Project.Web.Data;
using Company.Project.Web.Models;
using Company.Project.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class CreateEventController : Controller
    {
        private readonly CreateEventRepository _createEventRepository = null;

        
        public CreateEventController(CreateEventRepository createEventRepository)
        {
            _createEventRepository = createEventRepository;
        }

        [Authorize]
        public ViewResult CreateEvent(bool isSuccess = false, int eventId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.NewEventId = eventId;
           

            return View();
        }
        
   
     [HttpPost]
       
        public async Task<IActionResult> CreateEvent(CreateEventModel createEventModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _createEventRepository.CreateEvent(createEventModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(CreateEvent), new { isSuccess = true, eventId = id });
                }

            }

            return View();
        }

        [Route("view-details/{id}", Name = "eventDetailsRoute")]
       

        public async Task<ViewResult> GetEvent(int id)
        {
            var data = await _createEventRepository.GetEventById(id);
            
            
            return View(data);
        }

        [HttpGet]
        [Authorize]
        public async Task<ViewResult> GetAllEvents()
        {
            var data = await _createEventRepository.GetAllEvents();
            
            return View(data);

        }

        [HttpGet]
        [Authorize]
        public async Task<ViewResult> MyEvents()
        {
           string email  = HttpContext.Session.GetString("Email");
           var data = await _createEventRepository.MyEvents(email);
           return View(data);
            

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
           
         var data = await _createEventRepository.GetEventById(id);
            return View(data);
        }
       



    }



}
