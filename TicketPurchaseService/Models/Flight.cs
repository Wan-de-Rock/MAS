﻿namespace TicketPurchaseService.Models;

public class Flight
{
    private int arrivalAirportId;
    private uint availableSeats;

    public int Id { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public decimal BasePrice { get; set; }
    public uint AvailableSeats { get => availableSeats; set => availableSeats = value; }

    public int DepartureAirportId { get; set; }
    public virtual Airport? DepartureAirport { get; set; }

    public int ArrivalAirportId
    {
        get => arrivalAirportId;
        set
        {
            if (value != DepartureAirportId) { arrivalAirportId = value; }
        }
    }
    public virtual Airport? ArrivalAirport { get; set; }

    public int AirlineId { get; set; }
    public virtual Airline? Airline { get; set; }

    public string AircraftId { get; set; }
    public virtual Aircraft Aircraft { get; set; }

    //public Flight(int id, DateTime departure, DateTime arrival, decimal price, uint seats, )
    //{
    //    if (Aircraft is not null)
    //    {
    //        AvailableSeats = Aircraft.SeatsNumber;
    //    }
    //}


}
