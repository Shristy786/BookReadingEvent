using Company.Project.Web.Data;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Repository
{
    public class CreateEventRepository
    {
        private readonly BookEventContext _context = null;
        public CreateEventRepository(BookEventContext context)
        {
            _context = context;
        }




        public async Task<int> CreateEvent(CreateEventModel model)
        {
            var newEvent = new CreateEvent()
            {
                Title = model.Title,
                Date = model.Date,
                Location = model.Location,
                StartTime = model.StartTime,
                EventType = model.EventType,
                Duration = model.Duration,
                Discription = model.Discription,
                OtherDetails = model.OtherDetails,
                InviteByMail = model.InviteByMail,
                Creator = model.Creator


            };
            await _context.CreateEvent.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent.EventId;
        }


        public async Task<List<CreateEventModel>> GetAllEvents()
        {
            return await _context.CreateEvent.Select(e => new CreateEventModel
            {
                EventId = e.EventId,
                Title = e.Title,
                Discription = e.Discription,
                Location = e.Location,
                Date = e.Date,
                StartTime = e.StartTime,
                Duration = e.Duration,
                EventType = e.EventType,
                OtherDetails = e.OtherDetails,
                InviteByMail = e.InviteByMail,
                Creator = e.Creator
            }).ToListAsync();
         
            

        }

       
        public async Task<CreateEventModel> GetEventById(int id)
        {

            var newEvent = await _context.CreateEvent.FindAsync(id);
            if (newEvent != null)
            {
                var eventDetails = new CreateEventModel()
                {
                    Title = newEvent.Title,
                    Discription = newEvent.Discription,
                    Location = newEvent.Location,
                    Date = newEvent.Date,
                    StartTime = newEvent.StartTime,
                    Duration = newEvent.Duration,
                    EventType = newEvent.EventType,
                    OtherDetails = newEvent.OtherDetails,
                    InviteByMail = newEvent.InviteByMail,
                    Creator = newEvent.Creator
                };
                return eventDetails;

            }
            return null;
        }
  
        public async Task <IList<CreateEventModel>> MyEvents(string email)
        {
           // var events = new List<CreateEventModel>();
            var myEvents = await _context.CreateEvent.Where(x => x.Creator == email)
                .Select(x => new CreateEventModel()
                {

                    Title = x.Title,
                    Discription = x.Discription,
                    Location = x.Location,
                    Date = x.Date,
                    StartTime = x.StartTime,
                    Duration = x.Duration,
                    EventType = x.EventType,
                    OtherDetails = x.OtherDetails,
                    InviteByMail = x.InviteByMail,
                    Creator = x.Creator
                }).ToListAsync();

            return myEvents;
                 
               

        }

       





    }
}

    


