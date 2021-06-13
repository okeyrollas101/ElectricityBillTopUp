using System;
using AgentPortal.AppData;
using AgentPortal.Menu;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class ManageCustomerService : AgentLibraryService
    {
        //protected static string customerId = AgentApplicationData.CurrentCustomerId;
        protected static string customerName = AgentApplicationData.CurrentCustomerName;
        protected static Customer foundCustomerDetail;


        protected static string ViewCustomerDetail(string customerId)
        {
            Customer customerDetail = service.GetCustomerById(customerId);

            if (customerDetail != null && customerDetail.IsDeleted == false)
            {
                foundCustomerDetail = customerDetail;

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

                return "successful";
            }
            else
            {
                Console.WriteLine("Customer not found! \n\nPress any key to go back");
                Console.ReadKey();
                return null;
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
                        foundCustomerDetail.FirstName = Console.ReadLine();
                    break;

                    case "2":
                        Console.Write("Please enter your new Last name : ");
                        foundCustomerDetail.LastName = Console.ReadLine();
                    break;

                    case "3":
                        Console.Write("Please enter your new Email : ");
                        foundCustomerDetail.EmailAddress = Console.ReadLine();
                    break;

                    case "4":
                        Console.Write("Please enter your new Phone number : ");
                        foundCustomerDetail.PhoneNumber = Console.ReadLine();
                    break;

                    case "5":
                        Console.Write("Please enter your new Password : ");
                        foundCustomerDetail.Password = AuthenticationHandler.GetConsolePassword();
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

            foundCustomerDetail.ModifiedAt = DateTime.Now;

            service.UpdateCustomer(foundCustomerDetail);
        }

        private static void PrintCustomerDetails()
        {
            Console.WriteLine($"\n> First Name : {foundCustomerDetail.FirstName} \n\n> Last Name : {foundCustomerDetail.LastName} \n\n> Email Address : {foundCustomerDetail.EmailAddress}");
            Console.WriteLine($"\n> Phone Number : {foundCustomerDetail.PhoneNumber} \n\n> Tarrif Plan : {foundCustomerDetail.TarrifName}");
        }


        protected static void MarkCustomerAsDeleted(string customerId)
        {
            var activeSubscription = service.CheckActiveSubscription(customerId);
            var customer = service.GetCustomerById(customerId);

            if (customer != null && activeSubscription != null)
            {
                Console.WriteLine("Removing active subscription..");
                service.RemoveSubscription(activeSubscription);

                Console.WriteLine("\n Deleting customer data");
                service.DeleteCustomer(customer);
                Console.WriteLine("\n Customer Data Deleted. \nPress any key to go back");
                Console.ReadKey();

            }
            else if(customer != null && activeSubscription == null)
            {
                Console.WriteLine("No active subscription found...");
                Console.WriteLine("\n Deleting customer data");
                service.DeleteCustomer(customer);
                Console.WriteLine("\n Customer Data Deleted. \nPress any key to go back");
                Console.ReadKey();
            }
            else if(customer == null)
            {
                Console.WriteLine("Customer not found");
                Console.ReadKey();
            }
        }
    }
}