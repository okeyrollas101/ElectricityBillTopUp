using System;
using System.Collections.Generic;
using AgentPortal.AppData;
using AgentPortal.Services;
using PortalLibrary.Models;

namespace AgentPortal.Menu
{
    internal class SubscriptionHandler : SubscriptionService
    {
        private static string providedCustomerId;

        public static void SelectAction(string select, string customerId)
        {
            providedCustomerId = customerId;

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
            Console.WriteLine("\n\nSelect subscription");
            Console.Write("\n> ");

            foreach (var tarrif in tarrifs)
            {
                Console.Write($"Press {tarrif.Id} for {tarrif.Name} at {tarrif.PricePerUnit} naira per unit. \n\n> ");
            }

            var response = Console.ReadLine();
            string tarrifId = "";
            string tarrifName = "";
            decimal tarrifPricePerUnit = 0;

            //Compares response with the tarrifId in tarrifs list
            Console.Clear();
            for (int i = 0; i < tarrifs.Count; i++)
            {
                if (response == tarrifs[i].Id)
                {
                    Console.WriteLine($"You have selected {tarrifs[i].Name}");
                    tarrifId = tarrifs[i].Id;
                    tarrifName = tarrifs[i].Name;
                    tarrifPricePerUnit = tarrifs[i].PricePerUnit;
                    Console.Write("\n\n> ");
                }
            }

            if (tarrifId != "")
            {
                decimal number = 0;
                Console.Write($"Enter amount in Naira : ");
                var amount = Console.ReadLine();

                while (!decimal.TryParse(amount, out number))
                {
                    Console.Write("> Enter a valid amount : ");
                    amount = Console.ReadLine();
                }

                CustomerSubscription subscription = new CustomerSubscription
                {
                    TariffId = tarrifId,
                    TarrifName = tarrifName,
                    AgentId = AgentApplicationData.CurrentAgentId,
                    Amount = number / tarrifPricePerUnit,
                };

                var result = SubscriptionService.AddSubscription(subscription, providedCustomerId);
                Console.Clear();
                Console.WriteLine($"{result} \nPress any key to return to dashboard");
                Console.ReadKey();
                Console.Clear();

            }
            else{
                Console.WriteLine("An error occured, please try again.");
            }
        }


        private static void UnsubscribeCustomer()
        {
            var result = Unsubscribe(providedCustomerId);
            Console.WriteLine($"{result} \nPress any key to go back to dashboard...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}