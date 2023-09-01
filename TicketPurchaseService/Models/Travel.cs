using System.ComponentModel.DataAnnotations;

namespace TicketPurchaseService.Models;

public class Travel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Departure")]
    public DateTime DepartureDateTime { get; set; }

    [Required]
    [Display(Name = "Arrival")]
    public DateTime ArrivalDateTime { get; set; }
    public decimal Price { get; set; }

    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public int PassengerId { get; set; }
    public virtual Passenger? Passenger { get; set; }

    public virtual List<Booking>? Bookings { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} Price: {Price}";
    }
}
