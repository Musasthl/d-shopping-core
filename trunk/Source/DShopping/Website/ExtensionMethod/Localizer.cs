using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Website.ExtensionMethod
{
    public static class Localizer
    {
        public static string Currency(float value)
        {
            if (value == 0)
            {
                return "Thương lượng";
            }
            return value.ToString("c", CultureInfo.CreateSpecificCulture("vi-VN"));
        }
    }
}