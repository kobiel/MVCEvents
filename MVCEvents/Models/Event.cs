using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MVCEvents.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public String Type { get; set; }

        [Required(ErrorMessage = "Please insert date of event")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date-Of-Event")]
        public DateTime Date { get; set; }

        //public List<Guest> GuestsList { get; set; }
        public virtual ICollection<Guest> GuestsList { get; set; }
    }
}