using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service.Handler;

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

        public ActionResult AboutUs()
        {
            return PartialView();
        }

        public ActionResult ProductNewest()
        {
            List<ProductOverviewDto> newestProduct = ProductHandler.getNewestProduct();
            return PartialView(newestProduct);
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        public ActionResult Advertising()
        {
            return PartialView();
        }
    }
}
