using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class InstructorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<string> FixedСourses { get; set; }
    }
}