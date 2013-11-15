using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
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
            List<CategoryDto> catList = _category.getAllCategoryByParentId(CONST.CATEGORY.CAT_TRANBAO);
            

            return PartialView(catList);
        }

        public ActionResult Advertising()
        {
            return PartialView();
        }

        public ActionResult ProductHot()
        {
            return PartialView();
        }

        public ActionResult ProductNewest()
        {
            List<ProductOverviewDto> newestProduct = ProductHandler.getNewestProduct();
            return PartialView(newestProduct);
        }
    }
}
