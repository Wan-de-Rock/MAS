namespace TicketPurchaseService.Models;

public class Travel
{
    public int Id { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public decimal TotalPrice { get; set; }

    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public int PassengerId { get; set; }
    public virtual Passenger? Passenger { get; set; }
    public virtual ICollection<Booking>? Bookings { get; set; }
    /*
    public virtual HashSet<Booking>? Bookings { get; set; } = new HashSet<Booking>();

    public Travel() { }
    public Travel(Passenger passenger)
    {
        if (passenger is not null)
        {
            Passenger = passenger;
            PassengerId = passenger.PersonId;
        }
    }
    public Travel(Passenger passenger, ICollection<Booking> bookings) : this(passenger)
    {
        if (bookings is not null)
        {
            Bookings = new HashSet<Booking>(bookings);
            if (Bookings.Count > 0)
            {
                DepartureDateTime = Bookings.FirstOrDefault().Flight.DepartureDateTime;
                ArrivalDateTime = Bookings.LastOrDefault().Flight.ArrivalDateTime;
                TotalPrice = Bookings.Sum(x => x.Price);
            }
        }
    }

    public bool AddBooking(uint seat, Flight flight)
    {
        return AddBooking(new Booking(seat, flight));
    }
    public bool AddBooking(Booking booking)
    {
        if (Bookings.Add(booking))
        {
            ArrivalDateTime = Bookings.LastOrDefault().Flight.ArrivalDateTime;
            TotalPrice = Bookings.Sum(x => x.Price);

            return true;
        }

        return false;
    }
    */
}
