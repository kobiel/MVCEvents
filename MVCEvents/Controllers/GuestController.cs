using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCEvents.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCEvents.Controllers
{
    public class GuestController : Controller
    {
        public MVCEventDbContext Db { get; private set; }

        public GuestController()
        {
            Db = new MVCEventDbContext();
        }

         // GET: Guest/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        public ActionResult Create(Guest g, int id)
        {
            if (g.Email == null)
            {
                return RedirectToAction("Create");
            }
            try
            {
                Guest newGuest = new Guest { FirstName = g.FirstName, LastName=g.LastName, Email=g.Email};
                Event eve = Db.Events.FirstOrDefault(x => x.EventId == id);
                eve.GuestsList.Add(newGuest);
                Db.SaveChanges();
                return RedirectToAction("Details", "Events", new { id = id });
            }
            catch
            {
                return View();
            }
        }

         // GET: Guest/Delete
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Guest Guest2Remove = Db.Guests.FirstOrDefault(x => x.GuestId == id);
            return View(Guest2Remove);
        }

        // POST: Guest/Delete
        [HttpPost]
        public ActionResult Delete(Guest g, int id)
        {
            try
            {
                Guest Guest2Remove = Db.Guests.FirstOrDefault(x => x.GuestId == id);
                Db.Guests.Remove(Guest2Remove);
                Db.SaveChanges();
                return RedirectToAction("Index", "Events");
            }
            catch
            {
                return View();
            }
        }
	}
}