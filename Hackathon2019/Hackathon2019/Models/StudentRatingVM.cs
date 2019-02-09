using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class StudentRatingVM
    {
        public Module Module { get; set; }
        public int? LabRate { get; set; }
        public int? TestRate { get; set; }
    }
}