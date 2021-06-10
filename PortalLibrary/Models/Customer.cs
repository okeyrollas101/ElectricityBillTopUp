using System;

namespace PortalLibrary.Models
{
    public class Customer : BaseUser
    {
        public string MeterNumber { get; set; }
        public string TarrifName { get; set; }
        
    }
}