﻿using System;
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

        public ActionResult ProductDetail(int productId)
        {
            var result = _productHandler.GetProductDetailById(productId);
            return View(result);
        }

        public ActionResult ProductByCategory(int categoryId, string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            var result = _productHandler.GetProductsByCategoryId(categoryId);

            return View(result);
        }

    }
}
