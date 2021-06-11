using System;
using AgentPortal.Services;

namespace AgentPortal.Menu
{
    public class ManageCustomerHandler : ManageCustomerService
    {
        private static bool onMainDashboard = true;

        public static void CustomerDashboard()
        {
            
            Console.WriteLine($"Welcome to Customer Service Dashboard! What would you like to do?\n");
            while (onMainDashboard)
            {
                Console.Clear();
                Console.Write("> Press 1 to Subscribe for Customer \n\n> Press 2 to View Customer Information \n\n> Press 3 to Unsubscribe for Customer \n\n> Press 4 to Delete Customer \n\n> Press 5 to go to Main Dashboard \n\n> ");
                var response = Console.ReadLine();

                var customerId = "";

                switch (response)
                {
                    case "1":
                        Console.Clear();
                        Console.Write($"> Enter Customer ID : ");
                        customerId = Console.ReadLine();
                        SubscriptionHandler.SelectAction("subscribe", customerId);
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write($"> Enter Customer ID : ");
                        customerId = Console.ReadLine();
                        var operationResponse = ViewCustomerDetail(customerId);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write($"> Enter Customer ID : ");
                        customerId = Console.ReadLine();
                        SubscriptionHandler.SelectAction("unsubscribe", customerId);
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write($"> Enter Customer ID : ");
                        customerId = Console.ReadLine();
                        MarkCustomerAsDeleted(customerId);
                        break;

                    case "5":
                        //Go to main dashboard
                        onMainDashboard = false;
                        break;

                    default:
                        Console.Clear();
                    break;
                }
            }

            NavigationMenu.inAgentMainDashboard = true;
            onMainDashboard = true;
        }
    }
}