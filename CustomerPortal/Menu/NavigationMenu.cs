using System;
using System.Collections.Generic;
using System.Threading;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class NavigationMenu
    {
        private static bool appIsRunning = true;
        private static bool inRegisterPage = false;
        private static bool inLoginPage = false;
        public static void HomePageMenu()
        {
            
            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS CUSTOMER PORTAL.\n");
                Console.WriteLine("Choose an Option : 1. Login         2. Register");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inLoginPage = true;
                        break;
                    case "2":
                        inRegisterPage = true;
                        break;
                }
                        while(inLoginPage)
                        {
                            LoginNavigationPage();
                        }
                        while(inRegisterPage)
                        {
                            RegistrationNavigationPage();
                        }
                


                
            }
        }

        private static void LoginNavigationPage()
        {
            Dictionary<string, string> navItemDic = new Dictionary<string, string>();
            List<string> navigationItem = new List<string>
            {
                "Email", "Password"
            };
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Please Login with your Email and Password");

                for (var i = 0; i < navigationItem.Count; i++)
                {
                    Console.WriteLine($"Please Enter your {navigationItem[i]} :");
                    var value = Console.ReadLine();
                    navItemDic.Add(navigationItem[i], value);
                }

                string Email, Password;

                Email = navItemDic["Email"];
                Password = navItemDic["Password"];

                var customer = AuthenticationService.LoginUser(Email);
                if (customer == null)
                {
                    Console.WriteLine("Invalid Login Credentials Please Try Again");
                    Thread.Sleep(3000);
                }
                else
                {
                    if (customer.Password != Password)
                    {
                        Console.WriteLine("Invalid Login Credentials Please Try Again");
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {customer.FirstName} {customer.LastName}");
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
                inLoginPage = false;
        }
            

        private static void RegistrationNavigationPage()
        {
            Dictionary<string, string> navItemDIc = new Dictionary<string, string>();
            List<string> navigationItems = new List<string>
            {
                "FirstName", "LastName", "Email", "Password", "MeterNumber", "PhoneNumber"
            };
            Console.Clear();
            Console.WriteLine("Please Provide your Details");

            for (int i = 0; i < navigationItems.Count; i++)
            {
                Console.WriteLine($"Enter your {navigationItems[i]} : ");
                var value = Console.ReadLine();
                navItemDIc.Add(navigationItems[i], value);
            }

            string FirstName, LastName, Email, Password, MeterNumber, PhoneNumber;
            FirstName = navItemDIc["FirstName"];
            LastName = navItemDIc["LastName"];
            Email = navItemDIc["Email"];
            Password = navItemDIc["Password"];
            MeterNumber = navItemDIc["MeterNumber"];
            PhoneNumber = navItemDIc["PhoneNumber"];

            Customer model = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                Password = Password,
                MeterNumber = MeterNumber,
                PhoneNumber = PhoneNumber,
            };

            string registrationResponds = AuthenticationService.RegisterUser(model);
            if (registrationResponds == "Success")
            {
                Console.WriteLine("Registration Successful");
                Console.WriteLine("Redirecting you to Home Page....");
                Thread.Sleep(3000);
            }
            else
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");
            inRegisterPage = false;
        }
    }
}