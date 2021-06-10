using System;

namespace AgentPortal.Menu
{
    public class AgentDashboardHandler
    {
        //Agent self-service
        //Customer service

        public static void SelectService()
        {
            Console.WriteLine($"What service would you like to perform?");
            Console.Write($"\n> Press 1 for Agent Self-Service \n\n> Press 2 for Customer Service \n\n> Press 3 to Sign Out \n\n> ");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    AgentSelfServiceHandler.AgentDashboard();
                    //go to the main dashboard
                break;

                case "2":
                    Console.Clear();
                    ManageCustomerHandler.CustomerDashboard();
                    //go to main dashboard
                break;

                case "3":
                    NavigationMenu.inAgentMainDashboard = false;
                break;
                
                default:
                break;
            }
        }
    }
}