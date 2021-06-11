using System;
using AgentPortal.AppData;

namespace AgentPortal.Menu
{
    public class NavigationMenu
    {
        private static bool appIsRunning = true;
        public static bool inRegisterPage = false;
        public static bool inLoginPage = false;
        public static bool inAgentMainDashboard = false;
        public static void HomePageMenu()
        {
            
            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS AGENT PORTAL.");
                string choice = "";
                if (AgentApplicationData.NumberOfFailedLoginAttempts < 3)
                {

                    Console.Write("\n> Press 1 to Login \n\n> Press 2 to Register \n\n> Press 3 to Exit\n\n> ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            inLoginPage = true;
                            break;
                        case "2":
                            inRegisterPage = true;
                            break;
                        case "3":
                            appIsRunning = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.Write("\n\nYour account is currently locked due to multiple failed login attempts. \n> Press 1 to Register \n> Press 2 to Exit\n\n> ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            inRegisterPage = true;
                        break;

                        case "2":
                            appIsRunning = false;
                        break;

                        default:
                            appIsRunning = false;
                        break;
                    }
                }


                while (inLoginPage)
                {
                    Pages.LoginPage();
                }

                while (inRegisterPage)
                {
                    Pages.RegistrationPage();
                }
                
                while (inAgentMainDashboard)
                {
                    Pages.AgentDashboardPage();
                }
            }

            Console.Clear();
            Environment.Exit(0);
        }
    }
}