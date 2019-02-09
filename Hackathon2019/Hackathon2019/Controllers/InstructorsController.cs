using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon2019.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using  System.Data.Entity;

namespace Hackathon2019.Controllers
{
    public class InstructorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Instructors
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
    }
}