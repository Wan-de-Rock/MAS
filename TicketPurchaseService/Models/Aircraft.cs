namespace TicketPurchaseService.Models;

using System.ComponentModel.DataAnnotations;

public class Aircraft
{
    [Key]
    public string Number { get; set; }

    [Required]
    [Range(1, 1000)]
    [Display(Name = "Number of seats")]
    public uint SeatsNumber { get; set; }

    public int AirlineId { get; set; }
    public Airline? Airline { get; set; }

    public ICollection<Flight>? Flights { get; set; }
}