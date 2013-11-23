using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class CONST
    {
        public static class PARAM
        {
            public const string PRODUCT = "ProductId";
            public const string CATEGORY = "CategoryId";
            public const string USER = "UserId";
        }
        public static class ROLE
        {
            public const int SADMIN = 0;
            public const int ADMIN = 10;
            public const int MOD = 20;
            public const int NORMALUSER = 30;
            public const int GUEST = 40;
        }
        public class CUSTOMER
        {

        }
        public static class STATUS
        {
            public const string ACTIVE = "Active";
            public const string DELETE = "Delete";
            public const string PENDING = "Pending";

            public const string P_IMAGE = "P_Image";
        }

        public class GENDER
        {
            public const string MALE = "M";
            public const string FEMALE = "F";
            public const string UNKNOWN_GENDER = "U";
        }
        public class SESSION
        {
            public const string USER = "SESSION_USER";
            public const string PRODUCT = "SESSION_PRODUCT";
            public const string CATEGORY = "SESSION_CATEGORY";
            
        }
        public class PAGE
        {
            
        }

        public class PRODUCT
        {
            public const int NO_NEWEST = 5;
            public const string IMAGE_LOCATION = "/Contents/Images/Product/";
            public const string IMAGE_DEFAULT = "/Contents/Images/image.jpg";

        }

        public class CATEGORY
        {
            public const int CAT_TRANBAO = 1;
            public const int CAT_SHOPMUABAN = 3;
            public const int CAT_HOTCATEGORY = 2;
        }


    }
}
