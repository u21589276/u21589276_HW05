using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Pagecount { get; set; }
        public int Point { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}