using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackathon2019.Models;

namespace Hackathon2019.Controllers
{
    public class ModuleRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ModuleRatings
        public ActionResult Index()
        {
            var moduleRating = db.ModuleRating
                .Include(m => m.Enrollment)
                .Include(m => m.Enrollment.Student)
                .Include(m => m.Enrollment.Student.User)
                .Include(m => m.Module);
            return View(moduleRating.ToList());
        }

        // GET: ModuleRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRating moduleRating = db.ModuleRating.Find(id);
            if (moduleRating == null)
            {
                return HttpNotFound();
            }
            return View(moduleRating);
        }

        // GET: ModuleRatings/Create
        public ActionResult Create()
        {
            List<Enrollment> enrollments = db.Enrollments.Include(e => e.Student).Include(e => e.Student.User).ToList();

            ViewBag.EnrollmentID = new SelectList(enrollments, "ID", "Student.User.LastName");
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Title");
            return View();
        }

        // POST: ModuleRatings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ModuleID,EnrollmentID,LabRate,TestRate")] ModuleRating moduleRating)
        {
            if (ModelState.IsValid)
            {
                db.ModuleRating.Add(moduleRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnrollmentID = new SelectList(db.Enrollments, "ID", "ID", moduleRating.EnrollmentID);
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Title", moduleRating.ModuleID);
            return View(moduleRating);
        }

        // GET: ModuleRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRating moduleRating = db.ModuleRating.Find(id);
            if (moduleRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnrollmentID = new SelectList(db.Enrollments, "ID", "ID", moduleRating.EnrollmentID);
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Title", moduleRating.ModuleID);
            return View(moduleRating);
        }

        // POST: ModuleRatings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ModuleID,EnrollmentID,LabRate,TestRate")] ModuleRating moduleRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnrollmentID = new SelectList(db.Enrollments, "ID", "ID", moduleRating.EnrollmentID);
            ViewBag.ModuleID = new SelectList(db.Modules, "ID", "Title", moduleRating.ModuleID);
            return View(moduleRating);
        }

        // GET: ModuleRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRating moduleRating = db.ModuleRating.Find(id);
            if (moduleRating == null)
            {
                return HttpNotFound();
            }
            return View(moduleRating);
        }

        // POST: ModuleRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleRating moduleRating = db.ModuleRating.Find(id);
            db.ModuleRating.Remove(moduleRating);
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
