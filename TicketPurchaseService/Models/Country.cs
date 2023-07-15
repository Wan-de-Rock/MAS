namespace TicketPurchaseService.Models
{
    public class Country : IComparable<Country>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TwoLetterISOCountryCode { get; set; }
        public string? ThreeLetterISOCountryCode { get; set; }

        public int CompareTo(Country? other)
        {
            return Name.CompareTo(other.Name);
        }

        //public virtual ICollection<Airport>? Airports { get; set; }
    }
}