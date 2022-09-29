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

        
        public ActionResult Books(int id)
        {
            BorrowsVM borrows = null;
            borrows = new BorrowsVM
            {
                Borrows = serviceData.getBorrows(id),
                Books = serviceData.getAllBooks(),
                Students = serviceData.getStudents()
                
            };
            
            return View(borrows);
        }

       
    }
}