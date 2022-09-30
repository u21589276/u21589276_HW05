using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Super_Duper_Library.Models;

namespace Super_Duper_Library.Controllers
{
    public class SearchEngineController : Controller
    {
        private ServiceData serviceData = new ServiceData();
        // GET: SearchEngine
        public ActionResult Index(string bookname, string author, string type)
        {
            
            LibraryRecordsVm searchdata = null;
            searchdata = new LibraryRecordsVm
            {

                Books = serviceData.getBooksbyName(bookname),
                Authors = serviceData.getAllAuthors(),
                Types = serviceData.getAllBtypes()

            };
                
            return View(searchdata);
        }
    }
}