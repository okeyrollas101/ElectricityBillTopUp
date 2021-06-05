using System;
using CustomerPortal.AppData;

namespace CustomerPortal.Menu
{
    public class Pages : NavigationMenu
    {

        private static string customerId = CustomerApplicationData.CurrentCustomerId;


        public static void RegistrationPage()
        {
            Console.Clear();
            Console.WriteLine("Please Provide your Details");
            AuthenticationHandler.RegistrationForm();
        }

        public static void LoginPage()
        {
            Console.Clear();
            AuthenticationHandler.LoginForm();
        }
        

        public static void CustomerDashboardPage()
        {
            Console.Clear();
            ManageCustomerHandler.CustomerDashboard();
        }
    }
}