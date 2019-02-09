using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class RatingViewModel
    {
        public string NameCourse { get; set; }
        public List<Module> Modules { get; set; }
    }
}