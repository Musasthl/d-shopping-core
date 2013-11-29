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
    public class RequestController : Controller
    {
        //
        // GET: /Request/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginRequest(String Username, String Password)
        {
            //Check login

            if (UserHandler.AdminLogin(Username, Password) == CONST.ROLE.ADMIN)
            {
                UserDto currentUser = new UserDto();
                currentUser.Username = Username;
                currentUser.Password = Password;
                Session[CONST.SESSION.USER] = currentUser;
                Session[CONST.SESSION.MESSAGE] = MessageHandler.CountMessageUnread();
                return RedirectToAction("Index", "Admin");
            }
            else if (UserHandler.AdminLogin(Username, Password) == CONST.ROLE.MOD)
            {
                UserDto currentUser = new UserDto();
                currentUser.Username = Username;
                currentUser.Password = Password;
                Session[CONST.SESSION.USER] = currentUser;
                Session[CONST.SESSION.MESSAGE] = MessageHandler.CountMessageUnread();
                return RedirectToAction("Index", "Mod");
            }
            return RedirectToAction("Login", "Admin");
        }

        [HttpPost]
        public ActionResult AddCategoryRequest(String CategoryName, String ParentName)
        {
            return null;
        }

        [HttpPost]
        public ActionResult PostComment(String name, String phone, String content, String productId)
        {
            CommentDto comment = new CommentDto();
            comment.Name = name;
            try
            {
                comment.ProductId = int.Parse(productId);
            }
            catch (Exception ex)
            {
                comment.ProductId = 0;
            }
            comment.Phone = phone;
            comment.Content = content;
            ProductHandler prodHandler = new ProductHandler();
            prodHandler.AddComment(comment);
            return RedirectToAction("ProductDetail", "Home", new { productCode = productId });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProductRequest(String name, String code, String category, String price,String image,String desc)
        {
            ProductHandler prodHandler = new ProductHandler();
            ProductDto product = new ProductDto();
            product.Name = name;
            product.Code = code;
            product.CategoryId = int.Parse(category);
            product.Price = float.Parse(price);
            product.Image = image;

            product.Description = System.Net.WebUtility.HtmlDecode(desc);
            prodHandler.AddNewProduct(product);
            if(Session[CONST.SESSION.USER] != null){
                UserDto userDto = (UserDto)Session[CONST.SESSION.USER];
                if (UserHandler.AdminLogin(userDto.Username, userDto.Password) == CONST.ROLE.ADMIN)
                {

                    return RedirectToAction("Index", "Admin");
                }
                else if (UserHandler.AdminLogin(userDto.Username, userDto.Password) == CONST.ROLE.MOD)
                {

                    return RedirectToAction("Index", "Mod");
                }
            }
            return RedirectToAction("Index", "Home"); 

        }

        [HttpPost]
        public ActionResult PostOrders(String name, String email, String address, String phone, String enquiry, String title, String code)
        {
            MessageDto Message = new MessageDto();
            Message.Name = name;
            Message.Email = email;
            Message.Address = address;
            Message.Phone = phone;
            Message.Contents = enquiry;
            Message.Title = title;
            MessageHandler MessageHandler = new MessageHandler();
            MessageHandler.AddMessage(Message);
            ViewBag.Info = "Thao tác của bạn đã được thực hiện thành công";
            return RedirectToAction("ProductDetail", "Home", new { productCode = code });
        }
    }
}
