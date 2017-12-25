using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_KP_DLS.DAO;

using TP_KP_DLS.Models;
using Microsoft.AspNet.Identity;
using AspNet.Identity.MySQL;

using System.Web.Mvc;

namespace TP_KP_DLS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}