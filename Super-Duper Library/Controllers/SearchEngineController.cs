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

        [HttpPost]
        public ActionResult Index(string bookname, string author, string type)
        {
            
            LibraryRecordsVm searchdata = null;
            if(bookname != null && author == null && type == null)
            {
                searchdata = new LibraryRecordsVm
                {

                    Books = serviceData.getBooksbyName(bookname),
                    Authors = serviceData.getAllAuthors(),
                    Types = serviceData.getAllBtypes()

                };

            }
            else if(author != null && bookname == null && type == null)
            {
                Authors allauthors = new Authors();
                List<Books> specificbook = serviceData.getAllBooks().Where(b => b.AuthorId == allauthors.AuthorId).ToList();
                
                searchdata = new LibraryRecordsVm
                {

                    Books = specificbook,
                    Authors = serviceData.getbyAuthor(author),
                    Types = serviceData.getAllBtypes()

                };
            }
            else if(type != null && bookname == null && author == null)
            {
                Authors allauthors = new Authors();
                List<Books> specificbook = serviceData.getAllBooks().Where(b => b.AuthorId == allauthors.AuthorId).ToList();

                searchdata = new LibraryRecordsVm
                {

                    Books = specificbook,
                    Authors = serviceData.getAllAuthors(),
                    Types = serviceData.getbyType(type)

                };
            }

            Console.WriteLine(bookname +" "+ type +" "+ author);
            return View(searchdata);
        }
    }
}