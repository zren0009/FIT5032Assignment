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
    public class StudentsController : Controller
    {
        private _30080193_Model db = new _30080193_Model();

        // GET: Students
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var students = db.Students.Where(s => s.UserId == userId).ToList();
            // administrators are able to see all students information
            if (User.IsInRole("Administrator") || User.IsInRole("Tutor"))
            {
                students = db.Students.ToList();
            }
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Student") || User.IsInRole("Administrator"))
            {
                return View();
            }
            else
            {
                TempData["studentCreationFailedMsg"] = " Only students and administrators are allowed to create students! ";
                return RedirectToAction("Index");
            }
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,UserId,ContactPhone,Address,Email,Nationality,UpdateTime")] Student student)
        {
            try
            {
                student.UserId = User.Identity.GetUserId();
                student.UpdateTime = DateTime.UtcNow.Date;
                ModelState.Clear();
                TryValidateModel(student);

                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                MessageBox.Show("You are not allowed to create multiple student objects!");
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,UserId,ContactPhone,Address,Email,Nationality,UpdateTime")] Student student)
        {
            student.UpdateTime = DateTime.UtcNow.Date;
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
