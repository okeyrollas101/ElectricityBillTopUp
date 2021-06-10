using System;
using AgentPortal.AppData;

namespace AgentPortal.Menu
{
    public class Pages : NavigationMenu
    {
        private static string agentId = AgentApplicationData.CurrentAgentId;


        public static void RegistrationPage()
        {
            Console.Clear();
            Console.WriteLine("Please Provide your Details");
            AuthenticationHandler.AgentRegistrationForm();
        }

        public static void LoginPage()
        {
            Console.Clear();
            AuthenticationHandler.LoginForm();
        }
        

        public static void AgentDashboardPage()
        {
            Console.Clear();
            AgentDashboardHandler.SelectService();
           // ManageCustomerHandler.CustomerDashboard();
        }
    }
}