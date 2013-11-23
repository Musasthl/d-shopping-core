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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        CategoryHandler _category = new CategoryHandler();

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

            List<CategoryDto> catList = _category.getAllCategoryByParentId(CONST.CATEGORY.CAT_TRANBAO);
            ViewBag.Message = "Chọn Hình ảnh";
            ViewBag.Href = CONST.PRODUCT.IMAGE_DEFAULT;
            return View(catList);
        }

        public ActionResult ChangePassword()
        {
            ViewBag.Type = "New";
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPass, string newPass, string newPassConfirm)
        {
            UserDto user = (UserDto) Session[CONST.SESSION.USER];
            if (oldPass != user.Password)
            {
                ViewBag.Type = "Wrong";

            }
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase file)
        {
            string currentTime = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "_";
            string path = System.IO.Path.Combine(Server.MapPath(CONST.PRODUCT.IMAGE_LOCATION), currentTime + System.IO.Path.GetFileName(file.FileName));
            file.SaveAs(path);
            ViewBag.Message = "File uploaded successfully";
            ViewBag.Image = currentTime + System.IO.Path.GetFileName(file.FileName);
            ViewBag.Href = CONST.PRODUCT.IMAGE_LOCATION + currentTime + System.IO.Path.GetFileName(file.FileName);
            List<CategoryDto> catList = _category.getAllCategoryByParentId(CONST.CATEGORY.CAT_TRANBAO);
            return View(catList);

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
