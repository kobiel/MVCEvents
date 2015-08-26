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
            var id = User.Identity.GetUserId();
            var user = Db.Users.FirstOrDefault(x => x.Id == id);
            return View(user.Events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
