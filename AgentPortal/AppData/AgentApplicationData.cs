using System;

namespace AgentPortal.AppData
{
    public class AgentApplicationData
    {
        public DateTime LastLoginDate { get; set; }
        public static string CurrentAgentId { get; set; }
        public static string CurrentAgentName { get; set; }
        public static int NumberOfFailedLoginAttempts { get; set; }
        public static string CurrentCustomerId { get; set; }
        public static string CurrentCustomerName { get; set; }
    }
}