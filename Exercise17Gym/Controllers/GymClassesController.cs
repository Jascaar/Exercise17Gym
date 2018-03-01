using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exercise17Gym.Models;

namespace Exercise17Gym.Controllers
{
    [Authorize]
    public class GymClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult BookingToggle (int id)
        {
            GymClass CurrentClass = db.GymClasses.Where(g => g.Id == id).FirstOrDefault();
            ApplicationUser CurrentUser = db.Users.Where(g => g.UserName == User.Identity.Name).FirstOrDefault();

            if (CurrentClass.AttendingMembers.Contains(CurrentUser))
            {
                CurrentClass.AttendingMembers.Remove(CurrentUser);
                db.SaveChanges();
            }
            else
            {
                CurrentClass.AttendingMembers.Add(CurrentUser);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: GymClasses
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Gymclass index";
            var role = new Role();
            ViewBag.Roles = role;
            ApplicationUser CurrentUser = db.Users.Where(g => g.UserName == User.Identity.Name).FirstOrDefault();
            if (CurrentUser== null) ViewBag.WelcomeMessage = "Please sign in to see more information from the Gym";
            else ViewBag.WelcomeMessage = "Welcome to the Gym " + CurrentUser.FullName;
            
            return View(db.GymClasses.ToList());
            
        }

        // GET: GymClasses/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Gymclass, details";
            var role = new Role();
            ViewBag.Roles = role;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // GET: GymClasses/Create
        [Authorize(Roles =Role.Admin)]
        public ActionResult Create()
        {
            ViewBag.Title = "Create new gymclass";
            return View();
        }

        // POST: GymClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                db.GymClasses.Add(gymClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gymClass);
        }

        // GET: GymClasses/Edit/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit gymclass";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gymClass);
        }

        // GET: GymClasses/Delete/5
        [Authorize(Roles = Role.Admin)]
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete gymclass";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymClass = db.GymClasses.Find(id);
            if (gymClass == null)
            {
                return HttpNotFound();
            }
            return View(gymClass);
        }

        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            GymClass gymClass = db.GymClasses.Find(id);
            db.GymClasses.Remove(gymClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Admin)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
