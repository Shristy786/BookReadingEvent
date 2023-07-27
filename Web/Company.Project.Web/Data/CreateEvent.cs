using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Data
{
    public class CreateEvent
    {
        

        [Key]
        public int EventId { get; set; }
       
        public string Title { get; set; }
      
        public DateTime? Date { get; set; }
       
       
        public string Location { get; set; }
       
        public DateTime? StartTime { get; set; }
        
        public string EventType { get; set; }
       
        public int Duration { get; set; }
   
        public string Discription { get; set; }
        

        public string OtherDetails { get; set; }
      

        public string InviteByMail { get; set; }

        public string Creator { get; set; }
        
    }
}
