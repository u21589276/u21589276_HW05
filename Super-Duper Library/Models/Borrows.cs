﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class Borrows
    {
        public int BorrowId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string bookname { get; set; }
        public string TakenDate { get; set; }
        public string BroughtDate { get; set; }

    }
}