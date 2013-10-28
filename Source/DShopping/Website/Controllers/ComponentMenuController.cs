using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ComponentMenuController : Controller
    {
        //
        // GET: /ComponentMenu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BottomMenu()
        {
            return PartialView();
        }

        public ActionResult TopMenu()
        {
            return PartialView();
        }

    }
}
