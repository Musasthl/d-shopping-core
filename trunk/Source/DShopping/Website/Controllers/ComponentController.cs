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

        public ActionResult SlideShowCenter()
        {
            return PartialView();
        }

    }
}
