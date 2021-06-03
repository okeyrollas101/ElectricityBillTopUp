using System;
using PortalLibrary.Models;

namespace PortalLibrary.CustomerServices
{
    public class CustomerService : CustomerFileService
    {
        public string RegisterCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            //This ill Handle registration of a customer
            else
            {
                fileService.database.Customers.Add(customer);
                fileService.SaveChanges();
                return customer.Id;
            }
        }

        public Customer GetCustomerById(string customerId)
        {
            Customer foundcustomer = fileService.database.Customers.Find(c => c.Id == customerId);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        //Find Customer via Email
        public Customer GetCustomerByEmail(string email)
        {
            Customer foundcustomer = fileService.database.Customers.Find(c => c.EmailAddress == email);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        public string UpdateCustomer(Customer modifiedCustomer)
        {
            Customer customer = this.GetCustomerById(modifiedCustomer.Id);
            if(customer != null)
            {
                int indexOfCustomer = fileService.database.Customers.IndexOf(customer);
                //fileService.database.Customers.Insert(indexOfCustomer, modifiedCustomer);
                fileService.SaveChanges();
                return "SUCCESSFULLY UPDATED";
            }
            return "Failed, Customer not found";
        }
    }
}