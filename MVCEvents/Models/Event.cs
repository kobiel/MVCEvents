using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MVCEvents.Models
{
    public class Event
    {
        public String IdEvent { get; set; }
        public String Type { get; set; }
        public DateTime Date { get; set; }
        public List<Guest> GuestsList { get; set; }
    }
}