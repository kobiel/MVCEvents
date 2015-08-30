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
    public class EventsController : Controller
    {
        public MVCEventDbContext Db { get; private set; }

        public EventsController()
        {
            Db = new MVCEventDbContext();
        }

        // GET: Event
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var id = User.Identity.GetUserId();
            var user = Db.Users.FirstOrDefault(x => x.Id == id);
            return View(user.Events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Index");
            }
            Event requestedEvent = Db.Events.Find(id);
            var userId = User.Identity.GetUserId();
            var user = Db.Users.FirstOrDefault(x => x.Id == userId);
            if (requestedEvent == null)
            {
                return HttpNotFound();
            }
            else if (userId == null || !user.Events.Contains(requestedEvent))
            {
                return RedirectToAction("Index");
            }
            return View(requestedEvent);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event e)
        {
            if (e.Type == null || e.Date == DateTime.MinValue)
            {
                return RedirectToAction("Index");
            }
            try
            {
                var newEvent = new Event { Type = e.Type, Date = e.Date};
                var user = Db.Users.Find(User.Identity.GetUserId());
                user.Events.Add(newEvent);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Index");
            }
            Event requestedEvent = Db.Events.Find(id);
            var userId = User.Identity.GetUserId();
            var user = Db.Users.FirstOrDefault(x => x.Id == userId);
            if (requestedEvent == null)
            {
                return HttpNotFound();
            }
            else if (!user.Events.Contains(requestedEvent))
            {
                return RedirectToAction("Index");
            }
            return View(requestedEvent);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Event e)
        {
            if (e.Type == null || e.Date == DateTime.MinValue)
            {
                return RedirectToAction("Index");
            }
            try
            {
                var EventId = Db.Events.FirstOrDefault(x => x.EventId == id);
                EventId.Date = e.Date;
                EventId.Type = e.Type;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
