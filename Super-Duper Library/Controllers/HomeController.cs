using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Super_Duper_Library.Models;

namespace Super_Duper_Library.Controllers
{
    public class HomeController : Controller
    {
        private ServiceData serviceData = new ServiceData();
        public ActionResult Index()
        {
            LibraryRecordsVm bookRecords = null;
            bookRecords = new LibraryRecordsVm
            {
                Books = serviceData.getAllBooks(),
                Authors = serviceData.getAllAuthors(),
                Types = serviceData.getAllBtypes()
                
            };
            return View(bookRecords);
        }

        public ActionResult Students()
        {
            
            return View();
        }

        public ActionResult Books()
        {
           
            return View();
        }
    }
}