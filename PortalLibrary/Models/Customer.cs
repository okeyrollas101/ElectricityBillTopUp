using System;

namespace PortalLibrary.Models
{
    public class Customer : BaseUser
    {
        public Customer()
        {
            this.Id = "CUS-" + Guid.NewGuid().ToString();
        }
        public string MeterNumber { get; set; }
    }
}