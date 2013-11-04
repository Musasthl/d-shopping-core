using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service.Handler;

namespace Website.Controllers
{
    public class ComponentLeftPanelController : Controller
    {
        //
        // GET: /ComponentLeftPanel/

        CategoryHandler _category = new CategoryHandler();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Category()
        {
            List<CategoryDto> catList = _category.getAllCategory();
            ViewBag.abc = catList.ElementAt(0).name;
                

            return PartialView(catList);
        }

        public ActionResult Advertising()
        {
            return PartialView();
        }

    }
}
