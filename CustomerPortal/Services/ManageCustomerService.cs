using System;
using CustomerPortal.AppData;
using CustomerPortal.Menu;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class ManageCustomerService : CustomerLibraryService
    {
        protected static string customerId = CustomerApplicationData.CurrentCustomerId;
        protected static string customerName = CustomerApplicationData.CurrentCustomerName;
        protected static Customer customerDetail = service.GetCustomerById(customerId);


        protected static void ViewCustomerDetail()
        {
            PrintCustomerDetails();
            Console.Write($"\n> Press 1 to Update Details \n\n> Press 2 to go back \n\n> ");
            var response = Console.ReadLine();
            
            switch (response)
            {
                case "1":
                    Console.Clear();
                    UpdateCustomerDetails();
                break;

                default:
                break;
            }
        }
        
        private static void UpdateCustomerDetails()
        {
            
            bool editAnother = true;

            while(editAnother)
            {
                Console.Write("What would you like to update? \n\n> Press 1 to Edit Firstname \n\n> Press 2 to Edit Lastname \n\n> Press 3 to Edit Email \n\n> Press 4 to Change Phone Number \n\n> Press 5 to Change Password \n\n> Press b to go back\n\n> ");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Write("Please enter your new First name : ");
                        customerDetail.FirstName = Console.ReadLine();
                    break;

                    case "2":
                        Console.Write("Please enter your new Last name : ");
                        customerDetail.LastName = Console.ReadLine();
                    break;

                    case "3":
                        Console.Write("Please enter your new Email : ");
                        customerDetail.EmailAddress = Console.ReadLine();
                    break;

                    case "4":
                        Console.Write("Please enter your new Phone number : ");
                        customerDetail.PhoneNumber = Console.ReadLine();
                    break;

                    case "5":
                        Console.Write("Please enter your new Password : ");
                        customerDetail.Password = AuthenticationHandler.GetConsolePassword();
                    break;

                    case "b":
                        editAnother = false;
                    break;
                }

                Console.Clear();

                if (response != "b")
                {
                    Console.WriteLine("Would you like to update another information? (Y/N)");
                    var continueEditing = Console.ReadLine();

                    if (continueEditing.ToUpper() != "Y")
                    {
                        editAnother = false;
                    }
                }

                Console.Clear();
            }

            customerDetail.ModifiedAt = DateTime.Now;

            service.UpdateCustomer(customerDetail);
        }

        private static void PrintCustomerDetails()
        {
            Console.WriteLine($"\n> First Name : {customerDetail.FirstName} \n\n> Last Name : {customerDetail.LastName} \n\n> Email Address : {customerDetail.EmailAddress}");
            Console.WriteLine($"\n> Phone Number : {customerDetail.PhoneNumber} \n\n> Tarrif Plan : {customerDetail.TarrifName}");
        }
    }
}