using System;

namespace CustomerPortal.AppData
{
    public class CustomerApplicationData
    {
        public static DateTime LastLoginDate { get; set; }
        public static string CurrentCustomerId { get; set; } = "";
        public static string CurrentCustomerName { get; set; }
        public static int NumberOfFailedLoginAttempts { get; set; } = 0;
    }
}