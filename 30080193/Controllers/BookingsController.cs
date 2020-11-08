using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _30080193.Models;
using _30080193.Utils;
using Microsoft.AspNet.Identity;

namespace _30080193.Controllers
{
    public class BookingsController : Controller
    {
        private BookingSystemModel db = new BookingSystemModel();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Locations);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // GET: Events/Create?date=YYYY-MM-DD
        public ActionResult Create(String date)
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Description");
            if (null == date)
                return RedirectToAction("Index");
            Bookings b = new Bookings();
            DateTime convertedDate = DateTime.Parse(date);
            b.BookingDate = convertedDate.Date;
            b.Bookinghours = 1;
            return View(b);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,UserId,LocationId,Email,FirstName,LastName,BookingDate,BookingTime,Bookinghours")] Bookings bookings)
        {
            bookings.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(bookings);
            if (ModelState.IsValid)
            {
                db.Bookings.Add(bookings);
                db.SaveChanges();
                EmailSender es = new EmailSender();
                es.Send(bookings.Email, "Booking Confirmed", "Your booking is confirmed. Thank you!", "zren education");
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Description", bookings.LocationId);
            return View(bookings);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Description", bookings.LocationId);
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,LocationId,Email,FirstName,LastName,BookingDate,BookingTime,Bookinghours")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Description", bookings.LocationId);
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings bookings = db.Bookings.Find(id);
            db.Bookings.Remove(bookings);
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
