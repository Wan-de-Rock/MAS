namespace TicketPurchaseService.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    public int Id { get; set; }
    public uint Seat { get; set; }
    [Display(Name = "Tiket сlass")]
    public TiketClass TiketClass { get; set; }
    public decimal Price { get; set; }

    public int FlightId { get; set; }
    public virtual Flight? Flight { get; set; }

    public int TravelId { get; set; }
    [ForeignKey(nameof(TravelId))]
    public virtual Travel? Travel { get; set; }
    /*

    public Booking()
    {
    }

    public Booking(uint seat, Flight flight)
    {
        Seat = seat;
        if (Flight is not null)
        {
            Flight = flight;
            FlightId = flight.Id;
            Price = Flight.BasePrice + (int)TiketClass;
        }
    }
    */
}

public enum TiketClass
{
    Economy = 100,
    First = 300
}
