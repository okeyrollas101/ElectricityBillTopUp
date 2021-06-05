using System;
using System.Collections.Generic;
using System.Threading;
using CustomerPortal.Services;
using PortalLibrary.Models;
using CustomerPortal.AppData;

namespace CustomerPortal.Menu
{
    public class Forms : NavigationMenu
    {

        private static string customerId = CustomerApplicationData.CurrentCustomerId;


        public static void RegistrationPage()
        {
            Console.Clear();
            Console.WriteLine("Please Provide your Details");
            AuthenticationForm.RegistrationForm();
        }

        public static void LoginPage()
        {
            Console.Clear();
            AuthenticationForm.LoginForm();
        }
        

        public static void CustomerDashboardPage()
        {
            Console.Clear();

            ManageCustomerForm.CustomerDashboard();
        }
    }
}