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
        List<Subject> subject;
        List<Test> test;

        public ActionResult BookList()
        {
            return View(lecturer.Get_All_Books());
        }

        public ActionResult SubjectList()
        {
            return View(lecturer.Get_All_Subject());
        }

        public ActionResult TestList()
        {
            return View(lecturer.Get_All_Test());
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
        public ActionResult DetailsSubject(int id)

        {
            subject = lecturer.Get_All_Subject();
            int trueid = 0;
            for (int i = 0; i < subject.Count; i++) if (subject[i].ID_Subject == id) trueid = i;
            return View(subject[trueid]);

        }

        [HttpGet]
        public ActionResult DetailsTest(int id)

        {
            test = lecturer.Get_All_Test();
            int trueid = 0;
            for (int i = 0; i < test.Count; i++) if (test[i].ID_Test == id) trueid = i;
            return View(test[trueid]);

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
                    
                    return RedirectToAction("CreateBook");
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
        public ActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubject(Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lecturer.Create_Subject(subject);

                    return RedirectToAction("SubjectList");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(subject);
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lecturer.Create_Test(test);

                    return RedirectToAction("CreateTest");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(test);
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
        public ActionResult EditSubject(int id)

        {
            subject = lecturer.Get_All_Subject();
            int trueid = 0;
            for (int i = 0; i < subject.Count; i++) if (subject[i].ID_Subject == id) trueid = i;
            return View(subject[trueid]);
        }

        [HttpPost]
        public ActionResult EditSubject(Subject subject)

        {
            if (ModelState.IsValid)
            {
                lecturer.Update_Subject(subject);
                return View("EditSubject");
            }
            else
            {
                return View("SubjectList");
            }
        }

        [HttpGet]
        public ActionResult EditTest(int id)

        {
            test = lecturer.Get_All_Test();
            int trueid = 0;
            for (int i = 0; i < test.Count; i++) if (test[i].ID_Test == id) trueid = i;
            return View(test[trueid]);
        }

        [HttpPost]
        public ActionResult EditTest(Test test)

        {
            if (ModelState.IsValid)
            {
                lecturer.Update_Test(test);
                return View("EditTest");
            }
            else
            {
                return View("TestList");
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
                return View("OK_DeleteBook");
            }
        }
        
        [HttpPost]
        public ActionResult DeleteBook(Int64 id)
        {
            try
            {
                int ID_Book = Convert.ToInt32(id);
                lecturer.Delete_Book(ID_Book);
                return View("OK_DeleteBook");
            }
            catch
            {
                return View("OK_DeleteBook");
            }
        }

        [HttpGet]
        public ActionResult DeleteSubject(int id)

        {
            try
            {
                subject = lecturer.Get_All_Subject();
                int trueid = 0;
                for (int i = 0; i < subject.Count; i++) if (subject[i].ID_Subject == id) trueid = i;
                return View(subject[trueid]);
            }
            catch
            {
                return View("OK_DeleteSubject");
            }
        }

        [HttpPost]
        public ActionResult DeleteSubject(Int64 id)
        {
            try
            {
                int ID_Subject = Convert.ToInt32(id);
                lecturer.Delete_Subject(ID_Subject);
                return View("OK_DeleteSubject");
            }
            catch
            {
                return View("OK_DeleteSubject");
            }
        }

        [HttpGet]
        public ActionResult DeleteTest(int id)

        {
            try
            {
                test = lecturer.Get_All_Test();
                int trueid = 0;
                for (int i = 0; i < test.Count; i++) if (test[i].ID_Test == id) trueid = i;
                return View(test[trueid]);
            }
            catch
            {
                return View("OK_DeleteTest");
            }
        }

        [HttpPost]
        public ActionResult DeleteTest(Int64 id)
        {
            try
            {
                int ID_Test = Convert.ToInt32(id);
                lecturer.Delete_Test(ID_Test);
                return View("OK_DeleteTest");
            }
            catch
            {
                return View("OK_DeleteTest");
            }
        }


    }
}