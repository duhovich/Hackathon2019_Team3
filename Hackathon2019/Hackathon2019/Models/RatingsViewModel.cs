using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class RatingsViewModel
    {
        public int IdStudent { get; set; }
        public string FullName { get; set; }
        public string NameCourse { get; set; }
        public List<string> NameModule { get; set; }
        public int LabRate { get; set; }
        public int TestRate { get; set; }
    }
}