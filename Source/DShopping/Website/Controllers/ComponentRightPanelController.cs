using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ComponentRightPanelController : Controller
    {
        //
        // GET: /ComponentRightPanel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnlineContact()
        {
            return PartialView();
        }
    }
}
