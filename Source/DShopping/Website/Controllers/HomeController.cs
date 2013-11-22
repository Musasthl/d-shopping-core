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

        public ActionResult ProductDetail(string productCode)
        {
            var result = _productHandler.GetProductDetailByCode(productCode);
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

        public ActionResult SearchPoducts(string searchValue)
        {
            var result = _productHandler.GetSearchProduct(searchValue);
            return View(result);
        }


        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult PrepareLaptop()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult OtherProduct()
        {
            var result = _productHandler.GetOtherProducts();
            
            return View(result);
        }
    }
}
