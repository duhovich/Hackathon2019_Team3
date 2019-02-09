using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon2019.Models;

namespace Hackathon2019.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            List<Student> students = context.Students.Include(s => s.User).ToList();
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id, int? selectedCourse)
        {
            Student student = context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Enrollments.Select(e => e.Course))
                .Include(s => s.Enrollments.Select(e => e.Course.Instructor))
                .Include(s => s.Enrollments.Select(e => e.Course.Instructor.User))
                .FirstOrDefault(s => s.ID == id);

            if (selectedCourse.HasValue)
            {
                List<Module> modulesDM = context
                    .Courses
                    .Include(c => c.Modules)
                    .FirstOrDefault(c => c.ID == selectedCourse)
                    .Modules.ToList();

                List<StudentRatingVM> modules = new List<StudentRatingVM>();
                Enrollment enr = context.Enrollments.FirstOrDefault(e => e.CourseID == selectedCourse && e.StudentID == id);

                foreach (Module module in modulesDM)
                {
                    ModuleRating rating = context.ModuleRating.FirstOrDefault(mr => mr.EnrollmentID == enr.ID && mr.ModuleID == module.ID);
                    modules.Add(new StudentRatingVM { Module = module, LabRate = rating?.LabRate, TestRate = rating?.TestRate });
                }

                ViewBag.Modules = modules;

            }

            //List<Course>
            if (student == null)
            {
                return HttpNotFound();
            }

            return View("Details", student);

        }


        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = context.Students.Include(s => s.User).Where(s => s.ID == id).FirstOrDefault();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Student student)
        {
            var existStudent = context.Students.Include(s => s.User).Where(s => s.ID == student.ID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                existStudent.User.FirstMidName = student.User.FirstMidName;
                existStudent.User.LastName = student.User.FirstMidName;
                existStudent.Faculty = student.Faculty;
                existStudent.Institution = student.Institution;
                existStudent.InstitutionCourse = student.InstitutionCourse;
                existStudent.AboutMe = student.AboutMe;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = context.Students.Include(s => s.User).FirstOrDefault();
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteStudent(int ID)
        {
            var existStudent = context.Students.Include(s => s.User).Where(s => s.ID == ID).FirstOrDefault();
            if (existStudent != null)
            {
                var existUser = existStudent.User;
                context.Students.Remove(existStudent);
                context.Users.Remove(existUser);
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Students");
        }

        public ActionResult ValidateStudents()
        {
            var unconfirmedStudents = context.Roles
                .Include(r => r.Users)
                .FirstOrDefault(r => r.Name == "unconfirmed")
                .Users
                .Select(u => u.UserId);

            List<ApplicationUser> users = context.Users.Join(unconfirmedStudents,
                u => u.Id,
                un => un,
                (u, un) => u).ToList();


            return View(users);
        }

        public ActionResult ConfirmValidation(string id)
        {
            var user = context.Students.Where(s => s.User.Id == id).FirstOrDefault();
            return View(user);
        }

        public ActionResult ConfirmValidationStudent(Student student)
        {
            //var unconfirmedStudents = context.Users
            //    .Include(r => r.Roles)
            //    .FirstOrDefault(r => r.Id == student.User.Id).Roles;
            //context.SaveChanges();
            //var role = context.Roles.Where(r => r.Name == "unconfirmed");
            //student.User.Roles.Remove(role);

            return RedirectToAction("ValidateStudents", "Students");
        }
    }
}
