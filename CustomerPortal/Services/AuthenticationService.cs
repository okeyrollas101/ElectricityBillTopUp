using System;
using CustomerPortal.AppData;
using PortalLibrary.CustomerServices;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class AuthenticationService : CustomerLibraryService
    {
        private static string customerId;

        protected static string RegisterUser(Customer model)
        {
            var alreadyRegisteredEmail = service.GetCustomerByEmail(model.EmailAddress);

            if (alreadyRegisteredEmail == null)
            {
                service.AddCustomerToRecord(model);
                customerId = model.Id;
                CustomerApplicationData.CurrentCustomerId = customerId;
                CustomerApplicationData.CurrentCustomerName = model.FirstName;
                return "success";
            }
            else
            {
                return "failed";
            }
            
        }

        protected static Customer LoginUser(string email, string password)
        {
            var customerFound = service.GetCustomerByEmail(email);
            if (customerFound != null && customerFound.Password == password)
            {
                customerId = customerFound.Id;
                CustomerApplicationData.CurrentCustomerId = customerId;
                CustomerApplicationData.CurrentCustomerName = customerFound.FirstName;
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