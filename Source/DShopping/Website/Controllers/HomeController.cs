using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service;
using Service.Handler;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private static ProductHandler _productHandler = new ProductHandler();

        public ActionResult Index()
        {
            UserDto newU = new UserDto();
            //newU.addUser();
            return View();
        }

        public void TestLogger()
        {
            Logger.Instance.Info("testLog");
        }

        public ActionResult ProductDetail(int id)
        {
            var result = _productHandler.GetProductDetailById(id);
            return View(result);
        }

        public ActionResult Category(int id)
        {
            
            var result = _productHandler.GetProductsByCategoryId(id);
            if (result != null && result.Any())
                ViewBag.CategoryName = result.FirstOrDefault().Category.name;
            else ViewBag.CategoryName = String.Empty;
            return View(result);
        }

    }
}
