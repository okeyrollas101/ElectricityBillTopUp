using System;
using System.Collections.Generic;
using PortalLibrary.CustomerServices;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class ManageCustomerService
    {
        private static CustomerService service = new CustomerService();
        public static void UpdateCustomerDetails(string customerID)
        {
            var customerDetail = service.GetCustomerById(customerID);
            bool editAnother = false;

            do
            {
                Console.WriteLine("What would you like to update? \n1. Firstname \n2. Lastname \n3. Email \n4. Phone Number \n5. Password");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Write("Please enter your new First name :");
                        var input = Console.ReadLine();
                        customerDetail.FirstName = input;
                    break;

                    case "2":
                        Console.Write("Please enter your new Last name :");
                        customerDetail.LastName = Console.ReadLine();
                    break;

                    case "3":
                        Console.Write("Please enter your new Email :");
                        customerDetail.EmailAddress = Console.ReadLine();
                    break;

                    case "4":
                        Console.Write("Please enter your new Phone number :");
                        customerDetail.PhoneNumber = Console.ReadLine();
                        break;

                    case "5":
                        Console.Write("Please enter your new Password :");
                        customerDetail.Password = Console.ReadLine();
                    break;
                }

                Console.WriteLine("Would you like to update another information? (Y/N)");
                var continueEditing = Console.ReadLine();

                if (continueEditing.ToUpper() == "Y")
                {
                    editAnother = true;
                }

            } while (editAnother);

            service.UpdateCustomer(customerDetail);
        }
    }
}