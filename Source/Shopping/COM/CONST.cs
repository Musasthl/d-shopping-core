using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM
{
    public class CONST
    {
        public class PARAM
        {
            public const string PRODUCT = "ProductId";
            public const string CATEGORY = "CategoryId";
        }
        public class ROLE
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
            public const string ADMIN_INDEX = "/admin/index.aspx";
            public const string ADMIN_LOGIN = "/admin/login.aspx";
        }

    }
}
