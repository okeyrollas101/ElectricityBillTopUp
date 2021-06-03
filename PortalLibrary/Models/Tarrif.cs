namespace PortalLibrary.Models
{
    public class Tarrif
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}