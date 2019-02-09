using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Institution { get; set; }
        public string Faculty { get; set; }
        public int InstitutionCourse { get; set; }
        public string AboutMe { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}