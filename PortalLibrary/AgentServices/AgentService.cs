using System;
using System.Collections.Generic;
using PortalLibrary.Models;

namespace PortalLibrary.AgentServices
{
    public class AgentService : AgentFileService
    {
        public void AddCustomerToRecord(Customer customer)
        {
            fileService.database.Customers.Add(customer);
            fileService.SaveChanges();
        }

        public void AddAgentToRecord(Agent agent)
        {
            fileService.database.Agents.Add(agent);
            fileService.SaveChanges();
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

        public Customer GetCustomerByEmail(string email)
        {
            Customer foundcustomer = fileService.database.Customers.Find(c => c.EmailAddress == email);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        //Get agent by email

        public Agent GetAgentByEmail(string email)
        {
            Agent foundAgent = fileService.database.Agents.Find(c => c.EmailAddress == email);
            if (foundAgent != null)
            {
                return foundAgent;
            }
            return null;
        }

        public string UpdateCustomer(Customer modifiedCustomer)
        {
            Customer customer = this.GetCustomerById(modifiedCustomer.Id);
            if(customer != null)
            {
                fileService.SaveChanges();
                return "SUCCESSFULLY UPDATED";
            }
            return "Failed, Customer not found";
        }

        public void SubscribeToTariff(CustomerSubscription customerSubscription)
        {
            Random r = new Random();
            customerSubscription.Id = "SUB-" + r.Next(1000000,99999999);
            fileService.database.Subcriptions.Add(customerSubscription);
            fileService.SaveChanges();
        }

        public CustomerSubscription CheckActiveSubscription(string customerId)
        {
            if (GetSubscriptionByCustomerID(customerId) != null)
            {
                CustomerSubscription customerSubscription = GetSubscriptionByCustomerID(customerId);
                
                return customerSubscription;
            }
            else{return null;}
        }


        public CustomerSubscription GetSubscriptionByCustomerID(string customerId)
        {
            CustomerSubscription foundSubscription = fileService.database.Subcriptions.Find(c => c.CustomerId == customerId);
            if (foundSubscription != null)
            {
                return foundSubscription;
            }
            return null;
        }

        public bool RemoveSubscription(CustomerSubscription subscription)
        {
            bool isRemoved = fileService.database.Subcriptions.Remove(subscription);
            fileService.SaveChanges();
            return isRemoved;
        }

        public List<Tarrif> GetAllTarrif()
        {
            List<Tarrif> tarrifList = new List<Tarrif>();
            tarrifList = fileService.database.Tariffs;
            return tarrifList;
        }

        public void DeleteCustomer(Customer customer)
        {
            customer.IsDeleted = true;
            fileService.SaveChanges();
        }
    
    }
}