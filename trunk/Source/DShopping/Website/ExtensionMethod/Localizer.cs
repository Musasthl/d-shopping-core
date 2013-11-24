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
            var xx = Convert.ToInt32(value);
            return string.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,###.#}", value) + " đ";
        }
    }
}