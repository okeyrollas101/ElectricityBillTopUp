using System.Collections.Generic;
using CustomerPortal.AppData;
using PortalLibrary.Models;

namespace CustomerPortal.Services
{
    public class SubscriptionService : CustomerLibraryService
    {
        private static string customerId = CustomerApplicationData.CurrentCustomerId;
        
        protected static string AddSubscription(CustomerSubscription subscription)
        {
            var activeSubscription = CheckActiveSubscription(customerId);

            if (activeSubscription == null)
            {
                subscription.CustomerId = customerId;
                var processResult = service.SubscribeToTariff(subscription);
                return processResult == null ? "FAILED" : "SUCCESSFUL";
            }
            else
            {
                return "You have an active subscription, kindly unsubscribe.";
            }
        }

        protected static string Unsubscribe()
        { 
            var activeSubscription = CheckActiveSubscription(customerId);

            if (activeSubscription != null)
            {
                var result = service.RemoveSubscription(activeSubscription);
                
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