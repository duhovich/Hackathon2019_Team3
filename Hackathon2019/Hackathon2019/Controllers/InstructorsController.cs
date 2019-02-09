using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon2019.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace Hackathon2019.Controllers
{
    public class InstructorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instructors
        //[Authorize(Roles = "instructor")]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var instructor = db.Instructors.Include(c => c.User).Where(c => c.ApplicationUserID == currentUserId)
                .FirstOrDefault();
            int idInCourse = db.Instructors.Where(c => c.ApplicationUserID == currentUserId).Select(c => c.ID)
                .FirstOrDefault();

            var course = db.Courses.Where(c => c.InstructorID == idInCourse);
            List<string> listCourses = new List<string>();
            foreach (var b in course)
            {
                listCourses.Add(b.Title);
            }

            InstructorsViewModel nInsMod = new InstructorsViewModel
            {
                FirstName = instructor.User.FirstMidName,
                LastName = instructor.User.LastName,
                FixedСourses = listCourses
            };

            return View(nInsMod);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Instructor instructor, string password)
        {
            var user = new ApplicationUser
            {
                UserName = instructor.User.Email,
                Email = instructor.User.Email,
                LastName = instructor.User.LastName,
                FirstMidName = instructor.User.FirstMidName
            };

            var result = UserManager.Create(user, password);
            UserManager.AddToRoleAsync(user.Id, "instructor");
            Instructor newInstructor = new Instructor
            {
                ApplicationUserID = user.Id
            };

            db.Instructors.Add(newInstructor);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}