using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Student
    {
        public int ID { get; set; }
        [DisplayName("Університет")]
        public string Institution { get; set; }
        [DisplayName("Факультет")]
        public string Faculty { get; set; }
        [DisplayName("Курс навчання")]
        public int InstitutionCourse { get; set; }
        [DisplayName("Про себе")]
        public string AboutMe { get; set; }
        [DataType("Date")]
        public DateTime EnrollmentDate { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}