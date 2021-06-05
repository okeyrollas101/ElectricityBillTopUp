using System;
using System.Collections.Generic;
using CustomerPortal.AppData;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class SubscriptionForm : SubscriptionService
    {
        private static string customerId = CustomerApplicationData.CurrentCustomerId;


        //Declare a public method to select which private method to call.
        
        private static void LoadSubscriptiionForm()
        {
            List<Tarrif> tarrifs = new List<Tarrif>(SubscriptionService.GetTarrifData());
            Dictionary<string, string> itemDic = new Dictionary<string, string>();
            List<string> tarrifName = new List<string>();
            

            Console.WriteLine("Select subscription");

            //Writes available tarrif to console
            foreach (var tarrif in tarrifs)
            {
                Console.WriteLine($"{tarrif.Id}. {tarrif.Name} at {tarrif.PricePerUnit} kobo per unit");
                itemDic.Add(tarrif.Name,tarrif.Id);
                tarrifName.Add(tarrif.Name);
            }

            var response = Console.ReadLine();
            string tarrifId = "";

            //Compares response with the tarrifId in tarrifs list
            for (int i = 0; i < itemDic.Count; i++)
            {
                if (response == itemDic[tarrifName[i]])
                {
                    Console.WriteLine($"You have selected {tarrifName[i]}");
                    tarrifId = itemDic[tarrifName[i]];
                }
            }

            if (tarrifId != "")
            {
                CustomerSubscription subscription = new CustomerSubscription
                {
                    TariffId = tarrifId,
                    CustomerId = customerId,
                    AgentId = "Customer subscribed"
                };

                var result = SubscriptionService.AddSubscription(subscription, customerId);
                Console.Clear();
                Console.WriteLine($"{result}. Press any key to return to dashboard");
                Console.ReadKey();
            }
            else{
                Console.WriteLine("An error occured, please try again.");
                NavigationMenu.inCustomerDashboard = true;
            }
        }


        private static void UnsubscribeCustomer()
        {
            var result = SubscriptionService.Unsubscribe(customerId);
            Console.WriteLine($"{result} \nPress any key to go back to dashboard...");
            Console.ReadKey();
        }
    }
}