using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_KP_DLS.DAO;
using TP_KP_DLS.Models;
using Microsoft.AspNet.Identity;
using AspNet.Identity.MySQL;

namespace TP_KP_DLS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        Lecturer lecturer = new Lecturer();
        AccountController UserId = new AccountController();
        DAO.Student student = new DAO.Student();

        List<Book> book;
        List<Subject> subject;
        List<Test> test;
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

        public ActionResult SubjectList()
        {
            string id = "01c6d29f-9102-41cd-96fe-32ca816fbb72";
            return View(student.Get_All_Subject(id));
            //   if (ModelState.IsValid)
            //  {
            //  try
            //   {
            // string id = User.Identity.GetUserId();
            //  student.Get_All_Subject(id);
            // {   
            //   return RedirectToAction("SubjectList");
            // }
            // }
            //   catch
            //   {
            //     return View("BookList");
            //  }
            // }
            //  else
            //   {
            //   return View("_Layout");
        }
         //   }
        

      /*  public ActionResult TestList(Subject subject)
        {
            return View(student.Get_All_Test());
        }*/
    }
}
