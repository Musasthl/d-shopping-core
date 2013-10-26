using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;

namespace Website.Controllers
{
    public class ComponentController : Controller
    {
        //
        // GET: /Component/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            UserDTO user = new UserDTO();
            user.username = "a";
            user.password = "b";
            ViewBag.test = "TestBag";
            return PartialView(user);
        }

    }
}
