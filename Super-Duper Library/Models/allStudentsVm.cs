﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Duper_Library.Models
{
    public class allStudentsVm
    {
        public List<Students> Students { get; set; }

        public List<Students> Class { get; set; }
    }
}