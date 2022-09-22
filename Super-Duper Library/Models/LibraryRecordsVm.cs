using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class LibraryRecordsVm
    {
        public List<Books> Books { get; set; }
        public List<Students> Students { get; set; }

        public LibraryRecordsVm()
        {

        }
    }
}