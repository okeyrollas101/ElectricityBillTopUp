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
            string id = service.RegisterCustomer(model);
            customerId = id;
            return id == null ? "Failed" : "Success";
        }

        public static Customer LoginUser(string email)
        {
            var customerFound = service.GetCustomerByEmail(email);
            if (customerFound != null)
            {
                customerId = customerFound.Id;
                return customerFound;
            }
            else
            {
                return null;
            }
        }

        public static Customer GetCustomerInformation(string email)
        {
            var customerInformation = service.GetCustomerByEmail(email);
            return customerInformation == null ? null : customerInformation;
        }
    }
}