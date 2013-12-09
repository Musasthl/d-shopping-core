using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        private static ProductHandler _productHandler = new ProductHandler();
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
            ViewBag.Type = "Đổi mật khẩu";
            ViewBag.Display = "alert_warning";
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPass, string newPass, string newPassConfirm)
        {
            UserDto user = (UserDto) Session[CONST.SESSION.USER];
            ViewBag.Display = "visible";
            if (oldPass != user.Password)
            {
                ViewBag.Display = "alert_error";
                ViewBag.Type = "Mời bạn nhập lại mật khẩu cũ";

            }
            else if (oldPass == newPass)
            {
                ViewBag.Display = "alert_warning";
                ViewBag.Type = "Mật khẩu cũ trùng với mật khẩu mới";
            }
            else if (newPass != newPassConfirm)
            {
                ViewBag.Display = "alert_warning";
                ViewBag.Type = "Xác nhận mật khẩu mới không đúng";
            }
            else if (newPass.Length < 6)
            {
                ViewBag.Display = "alert_warning";
                ViewBag.Type = "Mật khẩu có độ dài ít nhất 6 ký tự";
            }
            else
            {
                ViewBag.Display = "alert_success";
                ViewBag.Type = "Đối mật khẩu thành công";
                UserHandler.ChangePassword(user.Username, newPass);
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
            var categories = _category.getAllCategory();
            return View(categories);
        }

        public ActionResult RestoreProduct()
        {
            return View();
        }

        public JsonResult ViewProductByCategory(int categoryId)
        {
            var result = _productHandler.GetProductsByCategoryIdForManage(categoryId);
            var jsonResult = Json(new { rows = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Logout()
        {
            Session[CONST.SESSION.USER] = null;

            return RedirectToAction("Index", "Home"); 
        }

        public ActionResult Message()
        {
            return View();
        }

        public JsonResult GetAllMessages()
        {
            return null;
        }

        public void DeleteProduct(string code) 
        {
            _productHandler.DeleteProduct(code);
        }

        public ActionResult UpdateProduct(string code)
        {
            var product = _productHandler.GetProductDetailByCode(code);

            List<CategoryDto> catList = _category.getAllCategoryByParentId(CONST.CATEGORY.CAT_TRANBAO);

            ViewBag.ListCategory = catList;
            return View(product);
        }
    }
}
