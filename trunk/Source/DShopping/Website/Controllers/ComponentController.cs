using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service.Handler;

namespace Website.Controllers
{
    public class ComponentController : Controller
    {
        //
        // GET: /Component/

        CategoryHandler _category = new CategoryHandler();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SlideShowCenter()
        {
            return PartialView();
        }

        public ActionResult HotCategories()
        {
            var result = _category.GetHotCategories();
            return PartialView(result);
        }

    }
}
