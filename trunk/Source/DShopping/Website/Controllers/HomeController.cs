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
            return View();
        }

        public ActionResult ProductByCategory(int categoryId)
        {
            var result = _productHandler.GetProductsByCategoryId(categoryId);

            return View(result);
        }

    }
}
