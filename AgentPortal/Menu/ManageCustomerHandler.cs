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

                Console.Write("> Press 1 to Subscribe for Customer \n\n> Press 2 to View Customer Information \n\n> Press 3 to Unsubscribe for Customer \n\n> Press 4 to Delete Customer \n\n> Press 5 to go to Main Dashboard \n\n> ");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Clear();
                        SubscriptionHandler.SelectAction("subscribe");
                        NavigationMenu.inAgentMainDashboard = true;
                        onMainDashboard = false;
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write($"> Enter Customer ID : ");
                        var customerId = Console.ReadLine();

                        var operationResponse = ViewCustomerDetail(customerId);

                        if (operationResponse != null)
                        {
                            NavigationMenu.inAgentMainDashboard = true;
                            onMainDashboard = false;
                        }
                        break;

                    case "3":
                        Console.Clear();
                       // SubscriptionHandler.SelectAction("unsubscribe");
                        NavigationMenu.inAgentMainDashboard = true;
                        onMainDashboard = false;
                        break;

                    case "4":
                        Console.Clear();
                        //Delete account
                        //NavigationMenu.inCustomerDashboard = false;
                        onMainDashboard = false;
                        break;

                    case "5":
                        //Go to main dashboard
                        onMainDashboard = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}