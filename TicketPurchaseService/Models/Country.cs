namespace TicketPurchaseService.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TwoLetterISOCountryCode { get; set; }
        public string? ThreeLetterISOCountryCode { get; set; }

        //public virtual ICollection<Airport>? Airports { get; set; }
    }
}