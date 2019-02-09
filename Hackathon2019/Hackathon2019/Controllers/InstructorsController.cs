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
            List<Enrollment> nEnrollment = db.Enrollments.ToList();
            List<RatingsViewModel> ratings = new List<RatingsViewModel>();
            RatingsViewModel newStudent = new RatingsViewModel();

        var student = db.Students.Select(c => c.ID).ToList();
            List<string> temp = new List<string>();
            int idTemp;
            for (int j = 0; j < student.Count; j++)
            {
                for (int i = 0; i < nEnrollment.Count; i++)
                {
                    newStudent.IdStudent = nEnrollment[i].StudentID;
                    idTemp = student[j];
                    var user = db.Students.Include(c => c.User).Where(c => c.ID == idTemp)
                        .FirstOrDefault();
                    newStudent.FullName = user.User.LastName + " " + user.User.LastName;
                    idTemp = nEnrollment[i].CourseID;
                    newStudent.NameCourse = db.Courses.Where(c => c.ID == idTemp).Select(c => c.Title)
                        .FirstOrDefault();
                    var nameModule = db.Modules.Where(c => c.CourseID == idTemp).Select(c => c.Title)
                        .ToList();                
                    foreach (var box in nameModule)
                    {
                        temp.Add(box);
                    }

                    newStudent.NameModule = temp;
                    
                    ratings.Add(newStudent);
                }

                //newStudent = null;
            }
            

            ViewBag.Rezult = ratings;

            return View();
        }
    }
}