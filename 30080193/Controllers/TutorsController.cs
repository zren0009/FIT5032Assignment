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
    public class TutorsController : Controller
    {
        private _30080193_Model db = new _30080193_Model();

        // GET: Tutors
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var tutors = db.Tutors.Where(s => s.UserId == userId).ToList();
            // administrators are able to see all students information
            if (User.IsInRole("Administrator"))
            {
                tutors = db.Tutors.ToList();
            }
            return View(tutors);
        }

        // GET: Tutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Tutor") || User.IsInRole("Administrator"))
            {
                return View();
            }
            else
            {
                TempData["tutorCreationFailedMsg"] = " Only tutors and administrators are allowed to create tutors! ";
                return RedirectToAction("Index");
            }
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,UserId,ContactPhone,Address,Email,Nationality,UpdateTime")] Tutor tutor)
        {
            try
            {
                tutor.UserId = User.Identity.GetUserId();
                tutor.UpdateTime = DateTime.UtcNow.Date;
                ModelState.Clear();
                TryValidateModel(tutor);

                if (ModelState.IsValid)
                {
                    db.Tutors.Add(tutor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                MessageBox.Show("You are not allowed to create multiple tutor objects!");
                return RedirectToAction("Index");
            }

            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,UserId,ContactPhone,Address,Email,Nationality,UpdateTime")] Tutor tutor)
        {
            tutor.UpdateTime = DateTime.UtcNow.Date;
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutor tutor = db.Tutors.Find(id);
            db.Tutors.Remove(tutor);
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
