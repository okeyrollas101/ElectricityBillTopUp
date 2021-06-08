using System;
using System.Collections.Generic;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class SubscriptionHandler : SubscriptionService
    {
        public static void SelectAction(string select)
        {
            switch (select)
            {
                case "subscribe":
                    SubscribeCustomer();
                break;

                case "unsubscribe":
                    UnsubscribeCustomer();
                break;
            }
        }
        
        private static void SubscribeCustomer()
        {
            List<Tarrif> tarrifs = new List<Tarrif>(GetTarrifData());
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
                    AgentId = "Customer subscribed"
                };

                var result = SubscriptionService.AddSubscription(subscription);
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
            var result = Unsubscribe();
            Console.WriteLine($"{result} \nPress any key to go back to dashboard...");
            Console.ReadKey();
        }
    }
}