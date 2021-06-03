using System;
using PortalLibrary.CustomerServices;

namespace CustomerPortal.Services
{
    public class ManageUserService
    {
        private static CustomerService service = new CustomerService();
        public void UpdateCustomerDetails(string customerID)
        {
            var customerDetail = service.GetCustomerById(customerID);
            Console.WriteLine("What would you like to update? \n1. Firstname \n2. Lastname \n3. Email \n4. Phone Number \n5. Password");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    Console.Write("Please enter your new First name :");
                    customerDetail.FirstName = Console.ReadLine();
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

            service.UpdateCustomer(customerDetail);
        }
    }
}