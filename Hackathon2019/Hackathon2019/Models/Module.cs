using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Hackathon2019.Models
{
    public class Module
    {
        public int ID { get; set; }

        [DisplayName("Назва")]
        public string Title { get; set; }

        [DisplayName("Існує лабораторна")]
        public bool IsLabExists { get; set; }

        [DisplayName("Існує Тест")]
        public bool IsTestExists { get; set; }

        public int CourseID { get; set; }

        [DisplayName("Курс")]
        public Course Course { get; set; }
    }
}