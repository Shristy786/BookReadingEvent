using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class SignUpUser
    {
        [Required(ErrorMessage = "please enter you Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage="please enter you mail")]
        [Display (Name ="Email Address")]
        [EmailAddress(ErrorMessage ="please enter a valid mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please enter strong password")]
        [Compare("ConfirmPassword",ErrorMessage ="password doesnot match")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
