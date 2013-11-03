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
            return urlHelper.Content("~/Contents/Images/" + imageName);            
        }

        public static string Script(this UrlHelper urlHelper, string scriptName)
        {
            return urlHelper.Content("~/Contents/Scripts/" + scriptName);
        }

        public static string StyleSheet(this UrlHelper urlHelper, string stylesheetName)
        {
            return urlHelper.Content("~/Contents/Styles/" + stylesheetName);
        }
    }
}