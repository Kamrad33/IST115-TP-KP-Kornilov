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
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        Administrator administrator = new Administrator();
        List<User> user;
        List<UserRole> userrole;
        List<Role> role;
        public ActionResult UserList()
        {
            return View(administrator.Get_All_User());
        }
        public ActionResult UserRoleList()
        {
            return View(administrator.Get_All_User_Role());
        }

        public ActionResult RoleList()
        {
            return View(administrator.Get_All_Role());
        }


        // GET: Administrator/Details/5
        [HttpGet]
        public ActionResult DetailsUser(string id)

        {
            user = administrator.Get_All_User();
            int trueid = 0;
            for (int i = 0; i < user.Count; i++) if (user[i].Id == id) trueid = i;
            return View(user[trueid]);

        }

        [HttpGet]
        public ActionResult DetailsUserRole(string id)

        {
            userrole = administrator.Get_All_User_Role();
            int trueid = 0;
            for (int i = 0; i < userrole.Count; i++) if (userrole[i].UserId == id) trueid = i;
            return View(userrole[trueid]);

        }

        [HttpGet]
        public ActionResult DetailsRole(string id)

        {
            role = administrator.Get_All_Role();
            int trueid = 0;
            for (int i = 0; i < role.Count; i++) if (role[i].Id == id) trueid = i;
            return View(role[trueid]);

        }

        // GET: Administrator/Create
        [HttpGet]
        public ActionResult CreateUserRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserRole(UserRole userrole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    administrator.Create_User_Role(userrole);

                    return RedirectToAction("CreateUserRole");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(userrole);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    administrator.Create_Role(role);

                    return RedirectToAction("CreateRole");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(role);
        }

        // GET: Administrator/Edit/5
        [HttpGet]
        public ActionResult EditUser(string id)

        {
            user = administrator.Get_All_User();
            int trueid = 0;
            for (int i = 0; i < user.Count; i++) if (user[i].Id == id) trueid = i;
            return View(user[trueid]);
        }

        [HttpPost]
        public ActionResult EditUser(User user)

        {
            if (ModelState.IsValid)
            {
                administrator.Update_User(user);
                return View("EditUser");
            }
            else
            {
                return View("UserList");
            }
        }

        [HttpGet]
        public ActionResult EditUserRole(string id)

        {
            userrole = administrator.Get_All_User_Role();
            int trueid = 0;
            for (int i = 0; i < userrole.Count; i++) if (userrole[i].UserId == id) trueid = i;
            return View(userrole[trueid]);
        }

        [HttpPost]
        public ActionResult EditUserRole(UserRole userrole)

        {
            if (ModelState.IsValid)
            {
                administrator.Update_User_Role(userrole);
                return View("EditUserRole");
            }
            else
            {
                return View("UserList");
            }
        }

        [HttpGet]
        public ActionResult EditRole(string id)

        {
            role = administrator.Get_All_Role();
            int trueid = 0;
            for (int i = 0; i < role.Count; i++) if (role[i].Id == id) trueid = i;
            return View(role[trueid]);
        }

        [HttpPost]
        public ActionResult EditRole(Role role)

        {
            if (ModelState.IsValid)
            {
                administrator.Update_Role(role);
                return View("EditRole");
            }
            else
            {
                return View("UserList");
            }
        }

        // GET: Administrator/Delete/5
        [HttpGet]
        public ActionResult DeleteUser(string id)

        {
            try
            {
                user = administrator.Get_All_User();
                int trueid = 0;
                for (int i = 0; i < user.Count; i++) if (user[i].Id == id) trueid = i;
                return View(user[trueid]);
            }
            catch
            {
                return View("OK_DeleteUser");
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(string id, User user)
        {
            try
            {
                //int ID_Book = Convert.ToInt32(id);
               // string Id = Convert.ToString(id);
                
                administrator.Delete_User(id);
                return View("OK_DeleteUser");
            }
            catch
            {
                return View("OK_DeleteUser");
            }
        }

        [HttpGet]
        public ActionResult DeleteUserRole(string id)

        {
            try
            {
                userrole = administrator.Get_All_User_Role();
                int trueid = 0;
                for (int i = 0; i < userrole.Count; i++) if (userrole[i].UserId == id) trueid = i;
                return View(userrole[trueid]);
            }
            catch
            {
                return View("OK_DeleteUserRole");
            }
        }

        [HttpPost]
        public ActionResult DeleteUserRole(string id, UserRole userrole)
        {
            try
            {
                //int ID_Book = Convert.ToInt32(id);
                // string Id = Convert.ToString(id);

                administrator.Delete_User_Role(id);
                return View("OK_DeleteUserRole");
            }
            catch
            {
                return View("OK_DeleteUserRole");
            }
        }

        [HttpGet]
        public ActionResult DeleteRole(string id)

        {
            try
            {
                role = administrator.Get_All_Role();
                int trueid = 0;
                for (int i = 0; i < role.Count; i++) if (role[i].Id == id) trueid = i;
                return View(role[trueid]);
            }
            catch
            {
                return View("OK_DeleteRole");
            }
        }

        [HttpPost]
        public ActionResult DeleteRole(string id, Role role)
        {
            try
            {
                //int ID_Book = Convert.ToInt32(id);
                // string Id = Convert.ToString(id);

                administrator.Delete_Role(id);
                return View("OK_DeleteRole");
            }
            catch
            {
                return View("OK_DeleteRole");
            }
        }
    }
}
