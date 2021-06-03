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
        public static void RegistrationPage()
        {
            Console.Clear();
            Console.WriteLine("Please Provide your Details");
            RegistrationForm();
        }

        public static void LoginPage()
        {
            LoginForm();
        }
        private static void RegistrationForm()
        {
            Dictionary<string, string> navItemDic = new Dictionary<string, string>();
            List<string> navigationItems = new List<string>
            {
                "FirstName", "LastName", "PhoneNumber", "Email", "Password"
            };

            for (int i = 0; i < navigationItems.Count; i++)
            {
                Console.WriteLine($"Enter your {navigationItems[i]} : ");
                var value = Console.ReadLine();
                var validatedValue = ValidateUserInput(value);
                navItemDic.Add(navigationItems[i], validatedValue);
            }

            //Check if there is an existing customer with the email provided

            var customerCheck = AuthenticationService.GetCustomerInformation(navItemDic["Email"]);
            if (customerCheck == null)
            {

                Customer model = new Customer
                {
                    FirstName = navItemDic["FirstName"],
                    LastName = navItemDic["LastName"],
                    EmailAddress = navItemDic["Email"],
                    Password = navItemDic["Password"],
                    PhoneNumber = navItemDic["PhoneNumber"],
                    Id = "CUS-" + Guid.NewGuid().ToString(),
                    MeterNumber = "MN" + Guid.NewGuid().ToString(),
                };

                string registrationResponse = AuthenticationService.RegisterUser(model);
                if (registrationResponse == "Success")
                {
                    Console.Clear();
                    Console.WriteLine("Registration Successful");
                    Console.WriteLine($"Registered Details: \nCustomer ID : {model.Id} \nName : {model.FirstName} {model.LastName} \nPhone Number : {model.PhoneNumber} \nEmail : {model.EmailAddress} \nMeter Number : {model.MeterNumber} ");
                    Console.WriteLine("Press any key to go to dashboard....");
                    Console.ReadKey();
                    inRegisterPage = false;
                    //add link to dashboard
                }
            }

            else if(customerCheck != null){
                
                Console.WriteLine("Email already exist. Please Sign-In");
                Thread.Sleep(3000);
                inRegisterPage = false;
            }
            else{
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");
                inRegisterPage = false;
            }
            
        }

        public static void CustomerDashboard()
        {
            Console.WriteLine("Welcome! What would you like to do?");
            Console.WriteLine("1. Subscribe \n2. Update personal information \n3. Unsubscribe");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    //customerDetail.FirstName = Console.ReadLine();
                break;

                case "2":
                    ManageUserService.UpdateCustomerDetails(CustomerApplicationData.CurrentCustomerId);
                break;
                case "3":
                    //klihvv
                break;                
            }
        }

        private static void LoginForm()
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
                //inLoginPage = false;
                inLoginPage = false;
                inCustomerDashboard = true;
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