using System;
using System.Collections.Generic;
using CustomerPortal.AppData;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class ManageCustomerHandler
    {

        private static string customerId = CustomerApplicationData.CurrentCustomerId;


        public static void CustomerDashboard()
        {
            
            Console.WriteLine("Welcome! What would you like to do?");
            Console.WriteLine("1. Subscribe \n2. Update personal information \n3. Unsubscribe \n4. Sign Out");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    Console.Clear();
                    SubscriptionHandler.SelectAction("subscribe");
                    NavigationMenu.inCustomerDashboard = true;
                    break;

                case "2":
                    Console.Clear();
                    UpdateCustomerDetailForm();
                    NavigationMenu.inCustomerDashboard = true;
                    break;

                case "3":
                    Console.Clear();
                    SubscriptionHandler.SelectAction("unsubscribe");
                    NavigationMenu.inCustomerDashboard = true;
                    break;

                case "4":
                    Console.Clear();
                    NavigationMenu.inCustomerDashboard = false;
                    customerId = "";
                    break;
            }
        }



        private static void UpdateCustomerDetailForm()
        {
            //still need to refactor
            ManageCustomerService.UpdateCustomerDetails(customerId);
        }
    }
}