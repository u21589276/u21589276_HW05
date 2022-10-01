using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class BorrowsVM
    {
        public List<Borrows> Borrows { get; set; }
        public List<Books> Books { get; set; }
        public List<Students> Students { get; set; }
        public List<Authors> Authors { get; set; }
        public string BookName { get; set; }
        public BorrowsVM()
        {
            
        }

    }
}