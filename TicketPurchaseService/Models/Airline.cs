namespace TicketPurchaseService.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Flight>? Flights { get; set; }
        public ICollection<Aircraft>? Aircrafts { get; set; }
    }
}