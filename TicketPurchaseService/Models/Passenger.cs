using System.ComponentModel.DataAnnotations;

namespace TicketPurchaseService.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("[A-Z]{2}[0-9]{6}")]
        public string? PassportNumber { get; set; } // make unique

        //[Key]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public int CountryId { get; set; }
        public virtual Country? Citizenship { get; set; }

        public virtual ICollection<Travel>? Travels { get; set; }
    }
}