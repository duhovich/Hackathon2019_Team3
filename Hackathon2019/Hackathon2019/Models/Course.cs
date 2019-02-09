using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Module> Modules { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
    }
}