namespace TicketPurchaseService.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public virtual ICollection<Flight>? Flights { get; set; }
    }
}
