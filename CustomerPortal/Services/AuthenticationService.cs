using System;
using CustomerPortal.AppData;
using PortalLibrary.CustomerServices;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class AuthenticationService : CustomerLibraryService
    {
        private static string customerId = CustomerApplicationData.CurrentCustomerId;

        public static string RegisterUser(Customer model)
        {
            var alreadyRegisteredEmail = service.GetCustomerByEmail(model.EmailAddress);

            if (alreadyRegisteredEmail == null)
            {
                service.AddCustomerToRecord(model);
                customerId = model.Id;
                return "success";
            }
            else
            {
                return "failed";
            }
            
        }

        public static Customer LoginUser(string email, string password)
        {
            var customerFound = service.GetCustomerByEmail(email);
            if (customerFound != null && customerFound.Password == password)
            {
                customerId = customerFound.Id;
                return customerFound;
            }
            else
            {
                CustomerApplicationData.NumberOfFailedLoginAttempts++;
                return null;
            }
        }
    }
}