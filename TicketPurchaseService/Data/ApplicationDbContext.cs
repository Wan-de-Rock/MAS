using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;
using TicketPurchaseService.Models;

namespace TicketPurchaseService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var countries = new List<Country>();
            var countriesNames = new HashSet<string>();
            int countryId = 1;

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var ri = new RegionInfo(ci.LCID);
                if (countriesNames.Add(ri.EnglishName))
                {
                    countries.Add(new Country
                    {
                        //Id = ri.GeoId,
                        Id = countryId++,
                        Name = ri.EnglishName,
                        TwoLetterISOCountryCode = ri.TwoLetterISORegionName,
                        ThreeLetterISOCountryCode = ri.ThreeLetterISORegionName
                    }
                    );
                }
            }

            builder.Entity<Country>().HasData(countries);

            builder.Entity<Airport>().HasMany(x => x.Flights).WithOne(y => y.ArrivalAirport).HasForeignKey(z => z.ArrivalAirportId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Airline>().HasMany(x => x.Flights).WithOne(y => y.Airline).HasForeignKey(z => z.AirlineId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Airline>().HasMany(x => x.Aircrafts).WithOne(y => y.Airline).HasForeignKey(z => z.AirlineId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Travel>().HasMany(x => x.Bookings).WithOne(y => y.Travel).HasForeignKey(z => z.TravelId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Order>().HasMany(x => x.Travels).WithOne(y => y.Order).HasForeignKey(z => z.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
            //builder.Entity<Airport>().HasMany(x => x.Flights).WithOne(y => y.DepartureAirport).HasForeignKey(z => z.DepartureAirportId).OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Ali", LastName = "Baba" },
                new Person { Id = 2, FirstName = "Albert", LastName = "Sohlmann" },
                new Person { Id = 3, FirstName = "Odin", LastName = "Hale" },
                new Person { Id = 4, FirstName = "Ivor", LastName = "Watkins" },
                new Person { Id = 5, FirstName = "Zena", LastName = "Ellis" },
                new Person { Id = 6, FirstName = "Isac", LastName = "Ericsson" },
                new Person { Id = 7, FirstName = "Max", LastName = "Sundqvist" },
                new Person { Id = 8, FirstName = "Edward", LastName = "Johansson" },
                new Person { Id = 9, FirstName = "Arne", LastName = "Akerman" },
                new Person { Id = 10, FirstName = "Amund", LastName = "Erling" }
            );

            builder.Entity<Passenger>().HasData(
                new Passenger { Id = 1, PassportNumber = "FV679780", PersonId = 1, CountryId = 12 },
                new Passenger { Id = 2, PassportNumber = "KF784839", PersonId = 3, CountryId = 9 },
                new Passenger { Id = 3, PassportNumber = "FH567478", PersonId = 7, CountryId = 23 },
                new Passenger { Id = 4, PassportNumber = "NF547849", PersonId = 5, CountryId = 68 },
                new Passenger { Id = 5, PassportNumber = "BJ564700", PersonId = 10, CountryId = 5 }
            );

            builder.Entity<User>().HasData(
                new User { Id = 1, PassengerId = 1, Email = "some1@mail.com", Password = "3ygr3g8" },
                new User { Id = 2, PassengerId = 2, Email = "some2@mail.com", Password = "siejfei" },
                new User { Id = 3, PassengerId = 3, Email = "some3@mail.com", Password = "3298hfw" },
                new User { Id = 4, PassengerId = 4, Email = "some4@mail.com", Password = "34u9g2" },
                new User { Id = 5, Email = "some5@mail.com", Password = "3209rfh" }
            );

            builder.Entity<Airport>().HasData(
                new Airport { Id = 1, CountryId = 16, Name = "Airport1", City = "City1", Address = "Hulveien 57" },
                new Airport { Id = 2, CountryId = 11, Name = "Airport2", City = "City2", Address = "Ole Tobias Olsens gate 247" },
                new Airport { Id = 3, CountryId = 31, Name = "Airport3", City = "City3", Address = "Skjønnhaugveien 129" },
                new Airport { Id = 4, CountryId = 78, Name = "Airport4", City = "City4", Address = "Gangsåsvegen 10" },
                new Airport { Id = 5, CountryId = 55, Name = "Airport5", City = "City5", Address = "Einar Røds gate 249" },
                new Airport { Id = 6, CountryId = 45, Name = "Airport6", City = "City6", Address = "Lars Onsagers veg 227" },
                new Airport { Id = 7, CountryId = 87, Name = "Airport7", City = "City7", Address = "Tokerudberget 39" },
                new Airport { Id = 8, CountryId = 89, Name = "Airport8", City = "City8", Address = "Sunnlandsstien 207" },
                new Airport { Id = 9, CountryId = 15, Name = "Airport9", City = "City9", Address = "Lollandveien 5" },
                new Airport { Id = 10, CountryId = 2, Name = "Airport0", City = "City10", Address = "Erling Smiths veg 123" }
            );

            builder.Entity<Airline>().HasData(
                new Airline { Id = 1, Name = "LOT" },
                new Airline { Id = 2, Name = "Wizz Air" },
                new Airline { Id = 3, Name = "Lufthansa" },
                new Airline { Id = 4, Name = "MAU" },
                new Airline { Id = 5, Name = "Airfrance" }
            );

            builder.Entity<Aircraft>().HasData(
                new Aircraft { Number = "327senj", SeatsNumber = 300, AirlineId = 1 },
                new Aircraft { Number = "weuihf7", SeatsNumber = 100, AirlineId = 1 },
                new Aircraft { Number = "398f733", SeatsNumber = 46, AirlineId = 1 },
                new Aircraft { Number = "838f823", SeatsNumber = 747, AirlineId = 3 },
                new Aircraft { Number = "34984f", SeatsNumber = 611, AirlineId = 5 },
                new Aircraft { Number = "34u4ff7", SeatsNumber = 454, AirlineId = 5 },
                new Aircraft { Number = "3298f7", SeatsNumber = 78, AirlineId = 2 },
                new Aircraft { Number = "3408fj8", SeatsNumber = 300, AirlineId = 4 }
            );

            builder.Entity<Flight>().HasData(
                new Flight { Id = 1, AirlineId = 1, AircraftId = "327senj", DepartureAirportId = 2, ArrivalAirportId = 1, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1000 },
                new Flight { Id = 2, AirlineId = 2, AircraftId = "3298f7", DepartureAirportId = 1, ArrivalAirportId = 4, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(3), BasePrice = 100 },
                new Flight { Id = 3, AirlineId = 1, AircraftId = "weuihf7", DepartureAirportId = 4, ArrivalAirportId = 10, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(10), BasePrice = 500 },
                new Flight { Id = 4, AirlineId = 5, AircraftId = "34984f", DepartureAirportId = 5, ArrivalAirportId = 4, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(1.5), BasePrice = 2100 },
                new Flight { Id = 5, AirlineId = 3, AircraftId = "838f823", DepartureAirportId = 7, ArrivalAirportId = 2, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(20), BasePrice = 540 },
                new Flight { Id = 6, AirlineId = 5, AircraftId = "34u4ff7", DepartureAirportId = 5, ArrivalAirportId = 7, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(1), BasePrice = 1200 },
                new Flight { Id = 7, AirlineId = 4, AircraftId = "3408fj8", DepartureAirportId = 6, ArrivalAirportId = 1, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1050 },
                new Flight { Id = 8, AirlineId = 1, AircraftId = "398f733", DepartureAirportId = 9, ArrivalAirportId = 10, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1007 },
                new Flight { Id = 9, AirlineId = 4, AircraftId = "3408fj8", DepartureAirportId = 3, ArrivalAirportId = 2, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(9), BasePrice = 450 },
                new Flight { Id = 10, AirlineId = 1, AircraftId = "398f733", DepartureAirportId = 8, ArrivalAirportId = 9, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(12), BasePrice = 7100 }
            );




            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1/*,
                    Travels = new HashSet<Travel> {
                        travel1,
                        travel2
                    }
                    */

                },
                new Order
                {
                    Id = 2,
                    UserId = 1/*,
                    Travels = new HashSet<Travel> {
                        travel3
                    }
                    */
                }
            );

            builder.Entity<Travel>().HasData(
                new Travel
                {
                    Id = 1,
                    OrderId = 1,
                    PassengerId = 1
                },
                new Travel
                {
                    Id = 2,
                    OrderId = 1,
                    PassengerId = 2
                },
                new Travel
                {
                    Id = 3,
                    OrderId = 2,
                    PassengerId = 2
                }
            );

            builder.Entity<Booking>().HasData(
                new Booking { Id = 1, FlightId = 2, TravelId = 1, Seat = 20, TiketClass = TiketClass.First },
                new Booking { Id = 2, FlightId = 3, TravelId = 1, Seat = 20, TiketClass = TiketClass.First },
                new Booking { Id = 3, FlightId = 2, TravelId = 2, Seat = 20, TiketClass = TiketClass.First },
                new Booking { Id = 4, FlightId = 3, TravelId = 2, Seat = 20, TiketClass = TiketClass.First },
                new Booking { Id = 5, FlightId = 4, TravelId = 3, Seat = 20, TiketClass = TiketClass.Economy }
             );




            //var travel1 = new Travel
            //{
            //    Id = 1,
            //    OrderId = 1,
            //    PassengerId = 1/*
            //    Bookings = new HashSet<Booking> {
            //                   booking1, booking2
            //    }
            //    */
            //};
            //var travel2 = new Travel
            //{
            //    Id = 2,
            //    OrderId = 1,
            //    PassengerId = 2/*
            //    Bookings = new HashSet<Booking> {
            //                    booking3, booking4
            //                }
            //    */
            //};
            //var travel3 = new Travel
            //{
            //    Id = 3,
            //    OrderId = 2,
            //    PassengerId = 2/*
            //    Bookings = new HashSet<Booking> {
            //                    booking5
            //                }
            //    */
            //};
            //builder.Entity<Travel>().HasData(travel1, travel2);
            //var booking1 = new Booking { Id = 1, FlightId = 2, TravelId = 1, Seat = 20, TiketClass = TiketClass.First };
            //var booking2 = new Booking { Id = 2, FlightId = 3, TravelId = 1, Seat = 20, TiketClass = TiketClass.First };
            //var booking3 = new Booking { Id = 3, FlightId = 2, TravelId = 2, Seat = 20, TiketClass = TiketClass.First };
            //var booking4 = new Booking { Id = 4, FlightId = 3, TravelId = 2, Seat = 20, TiketClass = TiketClass.First };
            //var booking5 = new Booking { Id = 5, FlightId = 4, TravelId = 3, Seat = 20, TiketClass = TiketClass.Economy };
            //builder.Entity<Booking>().HasData(booking1, booking2, booking3, booking4, booking5);


        }

        public DbSet<TicketPurchaseService.Models.Order>? Order { get; set; }

        public DbSet<TicketPurchaseService.Models.Booking>? Booking { get; set; }

        public DbSet<TicketPurchaseService.Models.Travel>? Travel { get; set; }

        public DbSet<TicketPurchaseService.Models.Flight>? Flight { get; set; }

        public DbSet<TicketPurchaseService.Models.Passenger>? Passenger { get; set; }

        public DbSet<TicketPurchaseService.Models.Person>? Person { get; set; }

        public DbSet<TicketPurchaseService.Models.User>? User { get; set; }

        public DbSet<TicketPurchaseService.Models.Airline>? Airline { get; set; }

        public DbSet<TicketPurchaseService.Models.Airport>? Airport { get; set; }

        public DbSet<TicketPurchaseService.Models.Aircraft>? Aircraft { get; set; }
    }
}