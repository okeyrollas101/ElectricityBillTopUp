using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class SubscriptionService : AgentLibraryService
    {
        protected static string AddSubscription(CustomerSubscription subscription, string customerId)
        {
            var customerExist = service.GetCustomerById(customerId);

            if (customerExist != null)
            {
                var activeSubscription = service.CheckActiveSubscription(customerId);

                if (activeSubscription == null && customerExist.IsDeleted == false)
                {
                    subscription.CustomerId = customerId;
                    customerExist.TarrifName = subscription.TarrifName;
                    service.SubscribeToTariff(subscription);
                    return $"You have been successfully subscribed to {subscription.TarrifName} \n\nTotal amount of unit : {subscription.Amount}";
                }
                else
                {
                    return "You have an active subscription, kindly unsubscribe.";
                }
            }
            else
            {
                return "Customer not found";
            }
        }

        protected static string Unsubscribe(string customerId)
        { 
            var activeSubscription = service.CheckActiveSubscription(customerId);
            var customerExist = service.GetCustomerById(customerId);

            if (activeSubscription != null && customerExist.IsDeleted == false)
            {
                customerExist.TarrifName = "";
                service.UpdateCustomer(customerExist);
                var result = service.RemoveSubscription(activeSubscription);
                
                return result == true ? "Successfully unsubscribed" : "An error occurred please try again.";
            }
            else
            {
                return "Subscription not found";
            }

        }

        protected static List<Tarrif> GetTarrifData()
        {
            List<Tarrif> tarrifs = new List<Tarrif>();
            tarrifs = service.GetAllTarrif();
            return tarrifs;
        }
    }
}