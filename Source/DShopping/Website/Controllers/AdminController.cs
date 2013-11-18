using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.DTO;

namespace Website.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginRequest(String Username, String Password)
        {
            //Check login
            UserDto currentUser = new UserDto();
            currentUser.Username = Username;
            currentUser.Password = Password;
            if (currentUser.Login())
            {
                Session[CONST.SESSION.USER] = currentUser;
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "Admin");
        }

    }
}
