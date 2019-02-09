using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}