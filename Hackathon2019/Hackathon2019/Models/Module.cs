using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsLabExists { get; set; }
        public bool IsTestExists { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}