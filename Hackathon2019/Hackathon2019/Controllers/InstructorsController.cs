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
            List<Instructor> nInstructors = db.Instructors.Include(c => c.User).ToList();

            return View(nInstructors);
        }

        public ActionResult Detail(string id)
        {
            var instructor = db.Instructors.Include(c => c.User).Where(c => c.ApplicationUserID == id)
                .FirstOrDefault();
            int idInCourse = db.Instructors.Where(c => c.ApplicationUserID == id).Select(c => c.ID)
                .FirstOrDefault();

            ViewBag.FirstName = instructor.User.FirstMidName;
            ViewBag.LastName = instructor.User.LastName;

            var course = db.Courses.Where(c => c.InstructorID == idInCourse);
            List<CoursesViewModel> lisrCoursesViewModels = new List<CoursesViewModel>();
            CoursesViewModel temp = new CoursesViewModel();
            foreach (var b in course)
            {
                temp.id = b.ID;
                temp.Courses = b.Title;
                lisrCoursesViewModels.Add(temp); 
            }
            
            return View(lisrCoursesViewModels);
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

        [HttpGet]
        public ActionResult SupportingRatings()
        {
            string currentUserId = User.Identity.GetUserId();
            int idInCourse = db.Instructors.Where(c => c.ApplicationUserID == currentUserId).Select(c => c.ID)
                .FirstOrDefault();

            List<Course> courses = db.Courses.Where(c => c.InstructorID == idInCourse).ToList();
            //ViewBag.Courses = courses;

            List<RatingViewModel> nRatingsViewModels = new List<RatingViewModel>();
            RatingViewModel temp = new RatingViewModel();
            
            foreach (var boxCourse in courses)
            {
                temp.NameCourse = boxCourse.Title;
                List<Module> mod = db.Modules.Where(c => c.CourseID == boxCourse.ID).ToList();
                temp.Modules = mod;
                nRatingsViewModels.Add(temp);
                temp = new RatingViewModel();
            }

            ViewBag.Courses = nRatingsViewModels;

            return View();
        }
    }
}