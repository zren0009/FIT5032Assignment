using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using _30080193.Models;
using Microsoft.AspNet.Identity;

namespace _30080193.Controllers
{
    public class ratingsController : Controller
    {
        private BookingSystemModel db = new BookingSystemModel();

        // GET: ratings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var ratings = db.ratings.Include(r => r.Bookings).Where(s => s.Bookings.UserId == userId);
            
            return View(ratings.ToList());
        }

        // GET: ratings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = db.ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // GET: ratings/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.BookingId = new SelectList(db.Bookings.Where(s => s.UserId == userId), "Id", "BookingTime");
            var booking = db.Bookings.Where(s => s.UserId == userId);
            if (booking.ToList().Count == 0)
            {
                MessageBox.Show("You have nothing to rate!");
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookingId,Rating,Comment")] ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.ratings.Add(ratings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "BookingTime", ratings.BookingId);
            return View(ratings);
        }

        // GET: ratings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = db.ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "BookingTime", ratings.BookingId);
            return View(ratings);
        }

        // POST: ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookingId,Rating,Comment")] ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "BookingTime", ratings.BookingId);
            return View(ratings);
        }

        // GET: ratings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = db.ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // POST: ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ratings ratings = db.ratings.Find(id);
            db.ratings.Remove(ratings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
