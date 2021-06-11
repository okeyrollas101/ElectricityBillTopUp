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
                var activeSubscription = CheckActiveSubscription(customerId);

                if (activeSubscription == null)
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
            var activeSubscription = CheckActiveSubscription(customerId);
            var customerExist = service.GetCustomerById(customerId);

            if (activeSubscription != null)
            {
                var result = service.RemoveSubscription(activeSubscription);
                customerExist.TarrifName = null;
                
                return result == true ? "Successfully unsubscribed" : "An error occurred please try again.";
            }
            else
            {
                return "Subscription not found";
            }

        }


        protected static CustomerSubscription CheckActiveSubscription(string customerId)
        {
            if (service.GetSubscriptionByCustomerID(customerId) != null)
            {
                CustomerSubscription customerSubscription = service.GetSubscriptionByCustomerID(customerId);
                
                return customerSubscription;
            }
            else{return null;}
        }

        protected static List<Tarrif> GetTarrifData()
        {
            List<Tarrif> tarrifs = new List<Tarrif>();
            tarrifs = service.GetAllTarrif();
            return tarrifs;
        }
    }
}