using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super_Duper_Library.Controllers
{
    public class SearchEngineController : Controller
    {
        // GET: SearchEngine
        [HttpPost]
        public ActionResult Index(string type, string author, string bookname)
        {
            return View();
        }
    }
}