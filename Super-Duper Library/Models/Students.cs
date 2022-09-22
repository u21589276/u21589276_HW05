using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public int Point { get; set; }

    }
}