using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ComponentLeftPanelController : Controller
    {
        //
        // GET: /ComponentLeftPanel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            return PartialView();
        }

        public ActionResult Advertising()
        {
            return PartialView();
        }

    }
}
