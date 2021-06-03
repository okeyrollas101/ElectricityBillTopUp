using System;
using PortalLibrary.CustomerServices;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class AuthenticationService
    {
         public static string RegisterUser(Customer model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                CustomerService service = new CustomerService();
                string id = service.RegisterCustomer(model);
                return id == null ? "Failed" : "Success";
            }
        }

        public static Customer LoginUser(string email)
        {
            CustomerService service = new CustomerService();
            var customerfound = service.GetCustomerByEmail(email);
            return customerfound;
        }
    }
}