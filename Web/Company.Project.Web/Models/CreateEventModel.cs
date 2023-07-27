using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class CreateEventModel
    {
       
        public int EventId { get; set; }
      
        public string Title { get; set; }
        [Display(Name ="Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime? Date { get; set; }
        [Display(Name = "Location")]
        [Required(ErrorMessage = "This field is required")]
        public string Location { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "Event Type")]
        
        public string EventType { get; set; }
        [Display(Name = "Duration(in hours)")]
        [Range(1, 4)]

        public int Duration { get; set; }
        [Display(Name = "Discription")]
        [StringLength(50,MinimumLength =5)]
        public string Discription { get; set; }
        [Display(Name = "Other Details")]
        [StringLength(50, MinimumLength = 5)]

        public string OtherDetails { get; set; }
        [Display(Name = "Invite By Mail")]

        public string InviteByMail { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Creator")]
        public string Creator { get; set; }
     


    }
}
