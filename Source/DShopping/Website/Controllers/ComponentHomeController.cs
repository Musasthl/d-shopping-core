using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ComponentHomeController : Controller
    {
        //
        // GET: /ComponentHome/

        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Banner()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
