using System;
using CustomerPortal.AppData;
using CustomerPortal.Services;

namespace CustomerPortal.Menu
{
    public class ManageCustomerHandler
    {

        private static string customerId = CustomerApplicationData.CurrentCustomerId;
        private static string customerName = CustomerApplicationData.CurrentCustomerName;


        public static void CustomerDashboard()
        {
            
            Console.WriteLine($"Welcome {customerName}! What would you like to do?\n");
            Console.Write("> Press 1 to subscribe \n> Press 2 to update personal information \n> Press 3 to unsubscribe \n> Press 4 to sign out\n\n> ");
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