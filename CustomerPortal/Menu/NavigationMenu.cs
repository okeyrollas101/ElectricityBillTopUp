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
                "FirstName", "LastName", "PhoneNumber", "Email", "Password"
            };
            Console.Clear();
            Console.WriteLine("Please Provide your Details");

            for (int i = 0; i < navigationItems.Count; i++)
            {
                Console.WriteLine($"Enter your {navigationItems[i]} : ");
                var value = Console.ReadLine();
                var validatedValue = ValidateUserInput(value);
                navItemDIc.Add(navigationItems[i], validatedValue);
            }

            var emailCheck = AuthenticationService.GetCustomerInformation(navItemDIc["Email"]);
            if (emailCheck == null)
            {

                Customer model = new Customer
                {
                    FirstName = navItemDIc["FirstName"],
                    LastName = navItemDIc["LastName"],
                    EmailAddress = navItemDIc["Email"],
                    Password = navItemDIc["Password"],
                    PhoneNumber = navItemDIc["PhoneNumber"],
                };

                string registrationResponse = AuthenticationService.RegisterUser(model);
                if (registrationResponse == "Success")
                {
                    Console.WriteLine("Registration Successful");
                    Console.WriteLine($"Registered Details: \nCustomer ID : {model.Id} \nName : {model.FirstName} {model.LastName} \nPhone Number : {model.PhoneNumber} \nEmail : {model.EmailAddress} \nMeter Number : {model.MeterNumber} ");
                    Console.WriteLine("Redirecting you to Home Page....");
                    Thread.Sleep(5000);
                    inRegisterPage = false;
                }
            }
            // string FirstName, LastName, Email, Password, MeterNumber, PhoneNumber;
            // FirstName = 
            // LastName = ;
            // Email = navItemDIc["Email"];
            // Password = navItemDIc["Password"];
            // MeterNumber = navItemDIc["MeterNumber"];
            // PhoneNumber = navItemDIc["PhoneNumber"];

            else if(emailCheck != null){
                
                Console.WriteLine("Email already exist. Please Sign-In");
                Thread.Sleep(3000);
                inRegisterPage = false;
            }
            else{
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");
                inRegisterPage = false;
            }
            
        }

        public static string ValidateUserInput(string value)
        {
            while (value == "")
            {
                Console.WriteLine("The required field cannot be empty");
                value = Console.ReadLine();
            }

            return value;
        }
    }
}