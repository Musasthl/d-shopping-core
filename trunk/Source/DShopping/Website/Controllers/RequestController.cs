using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.DTO;
using Service.Handler;

namespace Website.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginRequest(String Username, String Password)
        {
            //Check login

            if (!UserHandler.AdminLogin(Username,Password))
            {
                UserDto currentUser = new UserDto();
                currentUser.Username = Username;
                currentUser.Password = Password;
                Session[CONST.SESSION.USER] = currentUser;
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "Admin");
        }

        [HttpPost]
        public ActionResult AddCategoryRequest(String CategoryName, String ParentName)
        {
            return null;
        }
    }
}
