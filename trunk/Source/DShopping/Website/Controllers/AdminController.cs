using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.DTO;

namespace Website.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        public ActionResult ManageCategory()
        {
            return View();
        }

        public ActionResult RestoreCategory()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult ManageProduct()
        {
            return View();
        }

        public ActionResult RestoreProduct()
        {
            return View();
        }
    }
}
