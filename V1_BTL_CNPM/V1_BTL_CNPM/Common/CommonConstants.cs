using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V1_BTL_CNPM.Common
{
    public class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";


        public static int ADMIN = 1;
        public static int GIANGVIEN = 2;
        public static int SINHVIEN = 3;

        public static string CurrentCulture { set; get; }
    }
}