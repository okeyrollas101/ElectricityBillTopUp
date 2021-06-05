using System;
using System.Collections.Generic;
using System.Threading;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class AuthenticationForm : NavigationMenu
    {
        internal static void RegistrationForm()
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
                    inCustomerDashboard = true;
                }
            }

            else if(customerCheck != null){
                
                Console.WriteLine("Email already exist. Please Sign-In. \nPress any key to go back to menu");
                Console.ReadKey();
                inRegisterPage = false;
            }
            else{
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");
                inRegisterPage = false;
            }
            
        }


        internal static void LoginForm()
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
                    Thread.Sleep(2000);
                }
                else
                {
                    if (customer.Password != Password)
                    {
                        Console.WriteLine("Invalid Login Credentials Please Try Again");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {customer.FirstName} {customer.LastName}");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            inLoginPage = false;
            inCustomerDashboard = true;
        }


        private static string ValidateUserInput(string value)
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