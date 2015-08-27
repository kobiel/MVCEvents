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
                return RedirectToAction("Details", "Events");
            }
            catch
            {
                return View();
            }
        }

         // GET: Guest/Delete
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Guest/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}