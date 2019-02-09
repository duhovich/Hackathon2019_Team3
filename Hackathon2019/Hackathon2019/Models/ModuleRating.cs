using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class ModuleRating
    {
        public int ID { get; set; }

        public int ModuleID { get; set; }
        public int EnrollmentID { get; set; }

        [DisplayName("Оцінка за лабораторну")]
        public int? LabRate { get; set; }

        [DisplayName("Оцінка за тест")]
        public int? TestRate { get; set; }

        public Module Module { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}