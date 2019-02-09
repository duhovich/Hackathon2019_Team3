using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hackathon2019.Models
{
    public class Course
    {
        public int ID { get; set; }

        [DisplayName("Назва")]
        public string Title { get; set; }

        [DisplayName("Дата початку")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата кінця")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Module> Modules { get; set; }

        public int InstructorID { get; set; }

        [DisplayName("Викладач")]
        public Instructor Instructor { get; set; }
    }
}