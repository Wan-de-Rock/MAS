namespace TicketPurchaseService.Models;

using System.ComponentModel.DataAnnotations;

public class Booking
{
    public int Id { get; init; }

    [Required]
    [Range(1, 1000)]
    public uint Seat { get; set; }

    [Display(Name = "Tiket сlass")]
    public TiketClass TiketClass { get; set; }
    public decimal Price { get; set; }

    public int FlightId { get; set; }
    public virtual Flight? Flight { get; set; }

    public int TravelId { get; set; }
    public virtual Travel? Travel { get; set; }
}

public enum TiketClass
{
    Economy = 100,
    First = 300
}
