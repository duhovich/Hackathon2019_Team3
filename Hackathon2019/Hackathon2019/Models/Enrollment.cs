using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

        public ICollection<ModuleRating> ModuleRating { get; set; }
    }
}