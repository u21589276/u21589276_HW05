using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class LibraryRecordsVm
    {
        public List<Books> Books { get; set; }
        public List<Authors> Authors { get; set; }
        public List<Types> Types { get; set; }
        public List<Borrows> Borrows { get; set; }
        public LibraryRecordsVm()
        {

        }
    }
}