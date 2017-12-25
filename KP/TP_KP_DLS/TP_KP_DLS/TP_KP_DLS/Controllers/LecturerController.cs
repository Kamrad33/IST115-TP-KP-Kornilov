using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_KP_DLS.DAO;
using TP_KP_DLS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity;
using AspNet.Identity.MySQL;
using System.Data;

namespace TP_KP_DLS.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LecturerController : Controller
    {
        // GET: Lecturer
        Lecturer lecturer = new Lecturer();
        List<Book> book;

        

        public ActionResult BookList()
        {
            return View(lecturer.Get_All_Books());
        }

        [HttpGet]

        public ActionResult DetailsBook(int id)

        {
            book = lecturer.Get_All_Books();
            int trueid = 0;
            for (int i = 0; i < book.Count; i++) if (book[i].ID_Book == id) trueid = i;
            return View(book[trueid]);

        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lecturer.Create_Book(book);
                    
                    return RedirectToAction("BookList");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }




        [HttpGet]

        public ActionResult EditBook(int id)

        {
            book = lecturer.Get_All_Books();
            int trueid = 0;
            for (int i = 0; i < book.Count; i++) if (book[i].ID_Book == id) trueid = i;
            return View(book[trueid]);
        }
      
        [HttpPost]

        public ActionResult EditBook(Book book)

        {
            if (ModelState.IsValid)
            {
                lecturer.Update_Book(book);
                return View("EditBook");
            }
            else
            {
                return View("BookList");
            }
        }

        [HttpGet]

        public ActionResult DeleteBook(int id)

        {
            try
            {
                book = lecturer.Get_All_Books();
                int trueid = 0;
                for (int i = 0; i < book.Count; i++) if (book[i].ID_Book == id) trueid = i;
                return View(book[trueid]);
            }
            catch
            {
                return View("BookList");
            }
        }
        
        [HttpPost]

        public ActionResult DeleteBook(Int64 id)
        {
            try
            {
                int ID_Book = Convert.ToInt32(id);
                lecturer.Delete_Book(ID_Book);
                return View();
            }
            catch
            {
                return View("BookList");
            }
        }
    }
}