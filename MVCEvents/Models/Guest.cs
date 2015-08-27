using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEvents.Models
{
    public class Guest
    {
        [Required(ErrorMessage = "Please insert first-name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please insert last-name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Key]
        [Required(ErrorMessage = "Please insert email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email address is invalid")]
        public String Email { get; set; }
    }
}
