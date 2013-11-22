using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.ExtensionMethod
{
    public static class UrlHelperMethod
    {
        public static string Image(this UrlHelper urlHelper, string imageName)
        {
            if (imageName == "Banner")
            {
                return urlHelper.Content("~/Contents/Images/Banner.JPG");
            }
            else if(string.IsNullOrEmpty(imageName))
            {
                return urlHelper.Content("~/Contents/Images/image.jpg");
            }
            return urlHelper.Content("~/Contents/Images/" + imageName);            
        }

        public static string ImageProduct(this UrlHelper urlHelper, string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                return urlHelper.Content("~/Contents/Images/image.jpg");
            }
            return urlHelper.Content("~/Contents/Images/Product/" + imageName);
        }

        public static string Script(this UrlHelper urlHelper, string scriptName)
        {
            return urlHelper.Content("~/Contents/Scripts/" + scriptName);
        }

        public static string StyleSheet(this UrlHelper urlHelper, string stylesheetName)
        {
            return urlHelper.Content("~/Contents/Styles/" + stylesheetName);
        }

        public static string Category(this UrlHelper urlHelper, string categoryName)
        {
            return urlHelper.Content(String.Format("~/Category/" + categoryName));
        }

        public static string ProductDetail(this UrlHelper urlHelper, string productCode)
        {
            return urlHelper.Content(String.Format("~/ProductDetail/" + productCode));
        }
    }
}