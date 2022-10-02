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
            //List<Borrows> outborrows = serviceData.getAllBorrows().Where(b => b.BroughtDate == null).ToList();
            //List<Borrows> Availborrows = serviceData.getAllBorrows().Where(b => b.BroughtDate != null).ToList();

            LibraryRecordsVm bookRecords = null;
            bookRecords = new LibraryRecordsVm
            {
                Books = serviceData.getAllBooks(),
                Authors = serviceData.getAllAuthors(),
                Types = serviceData.getAllBtypes(),
                Borrows = serviceData.getAllBorrows()
            };
            return View(bookRecords);
        }

        public ActionResult Students(int id, int FirstborrowID)
        {
            
            allStudentsVm students = null;
            students = new allStudentsVm
            {
                Students = serviceData.getStudents(),
                StuBorrows = serviceData.getBorrows(id),
                BookId = id,
                FirtsBorrow = FirstborrowID,
             
            };
            return View(students);
        }

        public ActionResult Books(int id)
        {
            List<Books> bookname = serviceData.getAllBooks().Where(b => b.BookId == id).ToList();

            BorrowsVM borrows = null;
            borrows = new BorrowsVM
            {
                Borrows = serviceData.getBorrows(id),
                Books = serviceData.getAllBooks(),
                Students = serviceData.getStudents(),
                BookName = bookname[0].Name,
                BookID = id
            };
            
            return View(borrows);
        }

        public ActionResult borrowBook(int stuId, int borrowedbookID)
        {
            serviceData.BorrowBook(stuId, borrowedbookID);
             /*BorrowsVM borrows = null;
            borrows = new BorrowsVM
            {
                Borrows = serviceData.getBorrows(id),
                Books = serviceData.getAllBooks(),
                Students = serviceData.getStudents(),
                BookName = Bname,
                BookID = id
            };*/
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult returnBook(int borrowId, int id)
        {
            List<Books> bookname = serviceData.getAllBooks().Where(b => b.BookId == id).ToList();

            /*BorrowsVM borrows = null;
            borrows = new BorrowsVM
            {
                Borrows = serviceData.returnBook(borrowId,id),
                Books = serviceData.getAllBooks(),
                Students = serviceData.getStudents(),
                BookName = bookname[0].Name,
                BookID = id
            };*/

            serviceData.returnBook(borrowId, id);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult search(string bookname, string author, string type)
        {

            LibraryRecordsVm searchdata = null;
            if (bookname != "")
            {
                searchdata = new LibraryRecordsVm
                {

                    Books = serviceData.getBooksbyName(bookname),
                    Authors = serviceData.getAllAuthors(),
                    Types = serviceData.getAllBtypes()

                };

            }
            else if (author != "" && bookname == "")
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
            else if (type != "" && bookname == "")
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
            else if (type != "" && author != "")
            {
                Authors allauthors = new Authors();
                List<Books> specificbook = serviceData.getAllBooks().Where(b => b.AuthorId == allauthors.AuthorId).ToList();

                searchdata = new LibraryRecordsVm
                {

                    Books = specificbook,
                    Authors = serviceData.getbyAuthor(author),
                    Types = serviceData.getbyType(type)

                };
            }

            Console.WriteLine(bookname + " " + type + " " + author);
            return RedirectToAction("Index", searchdata);
        }


    }
}