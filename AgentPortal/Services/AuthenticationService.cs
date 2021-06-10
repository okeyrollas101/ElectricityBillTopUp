using System;
using AgentPortal.AppData;
using PortalLibrary.AgentServices;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class AuthenticationService : AgentLibraryService
    {
        private static string AgentId;

        protected static string RegisterUser(Customer model)
        {
            var alreadyRegisteredEmail = service.GetCustomerByEmail(model.EmailAddress);

            if (alreadyRegisteredEmail == null)
            {
                service.AddCustomerToRecord(model);
                AgentApplicationData.CurrentCustomerId = model.Id;
                AgentApplicationData.CurrentCustomerName = model.FirstName;
                return "success";
            }
            else
            {
                return "failed";
            }
            
        }


        //Register Agent

        protected static string RegisterAgent(Agent model)
        {
            var alreadyRegisteredEmail = service.GetAgentByEmail(model.EmailAddress);

            if (alreadyRegisteredEmail == null)
            {
                service.AddAgentToRecord(model);
                AgentId = model.Id;
                AgentApplicationData.CurrentAgentId = AgentId;
                AgentApplicationData.CurrentAgentName = model.FirstName;
                return "success";
            }
            else
            {
                return "failed";
            }
            
        }

        protected static Agent LoginAgent(string email, string password)
        {
            var agentFound = service.GetAgentByEmail(email);
            if (agentFound != null && agentFound.Password == password)
            {
                AgentId = agentFound.Id;
                AgentApplicationData.CurrentAgentId = AgentId;
                AgentApplicationData.CurrentAgentName = agentFound.FirstName;
                return agentFound;
            }
            else
            {
                AgentApplicationData.NumberOfFailedLoginAttempts++;
                return null;
            }
        }
    }
}