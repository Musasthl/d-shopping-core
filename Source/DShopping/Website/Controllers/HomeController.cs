using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            UserDto newU = new UserDto();
            newU.addUser();
            return View();
        }

        public void TestLogger()
        {
            Logger.Instance.Info("testLog");
        }

    }
}
