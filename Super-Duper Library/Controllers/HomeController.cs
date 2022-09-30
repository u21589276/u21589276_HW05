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
                Types = serviceData.getAllBtypes(),
            };
            return View(bookRecords);
        }

        public ActionResult Students()
        {
            allStudentsVm students = null;
            students = new allStudentsVm
            {
                Students = serviceData.getStudents()
            };
            return View(students);
        }

        
        public ActionResult Books(int id, string Bname)
        {

            BorrowsVM borrows = null;
            borrows = new BorrowsVM
            {
                Borrows = serviceData.getBorrows(id),
                Books = serviceData.getAllBooks(),
                Students = serviceData.getStudents(),
                BookName = Bname
            };
            
            return View(borrows);
        }

        [HttpPost]
        public ActionResult search(string bookname, string author, string type)
        {

            LibraryRecordsVm searchdata = null;
            if (bookname != null)
            {
                searchdata = new LibraryRecordsVm
                {

                    Books = serviceData.getBooksbyName(bookname),
                    Authors = serviceData.getAllAuthors(),
                    Types = serviceData.getAllBtypes()

                };

            }
            else if (author != null)
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
            else if (type != null)
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

            Console.WriteLine(bookname + " " + type + " " + author);
            return RedirectToAction("Index",searchdata);
        }


    }
}