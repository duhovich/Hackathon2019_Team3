using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class ModuleRating
    {
        public int ID { get; set; }

        public int ModuleID { get; set; }
        public int EnrollmentID { get; set; }

        public int? LabRate { get; set; }
        public int? TestRate { get; set; }

        public Module Module { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}