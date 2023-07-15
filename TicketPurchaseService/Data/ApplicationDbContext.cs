using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TicketPurchaseService.Models;

namespace TicketPurchaseService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Set countries
            var countries = new List<Country>();
            var countriesNames = new HashSet<string>();
            int countryId = 1;

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var ri = new RegionInfo(ci.LCID);
                if (countriesNames.Add(ri.EnglishName))
                {
                    countries.Add(
                        new Country
                        {
                            //Id = countryId++,
                            Name = ri.EnglishName,
                            TwoLetterISOCountryCode = ri.TwoLetterISORegionName,
                            ThreeLetterISOCountryCode = ri.ThreeLetterISORegionName
                        }
                    );
                }
            }

            countries.Sort();

            foreach (var country in countries) { country.Id = countryId++; }

            builder.Entity<Country>().HasData(countries);
            #endregion

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

            var aircrafts = new Aircraft[]
            {
                new Aircraft { Number = "327senj", SeatsNumber = 300, AirlineId = 1 },
                new Aircraft { Number = "weuihf7", SeatsNumber = 100, AirlineId = 1 },
                new Aircraft { Number = "398f733", SeatsNumber = 46, AirlineId = 1 },
                new Aircraft { Number = "838f823", SeatsNumber = 747, AirlineId = 3 },
                new Aircraft { Number = "34984f", SeatsNumber = 611, AirlineId = 5 },
                new Aircraft { Number = "34u4ff7", SeatsNumber = 454, AirlineId = 5 },
                new Aircraft { Number = "3298f7", SeatsNumber = 78, AirlineId = 2 },
                new Aircraft { Number = "3408fj8", SeatsNumber = 300, AirlineId = 4 }
            };

            var flights = new Flight[]
            {
                new Flight { Id = 1, AirlineId = aircrafts[0].AirlineId, AircraftId = aircrafts[0].Number, AvailableSeats = aircrafts[0].SeatsNumber, DepartureAirportId = 2, ArrivalAirportId = 1, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1000 },
                new Flight { Id = 2, AirlineId = aircrafts[5].AirlineId, AircraftId = aircrafts[5].Number, AvailableSeats = aircrafts[5].SeatsNumber, DepartureAirportId = 1, ArrivalAirportId = 4, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(3), BasePrice = 100 },
                new Flight { Id = 3, AirlineId = aircrafts[2].AirlineId, AircraftId = aircrafts[2].Number, AvailableSeats = aircrafts[2].SeatsNumber, DepartureAirportId = 4, ArrivalAirportId = 10, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(10), BasePrice = 500 },
                new Flight { Id = 4, AirlineId = aircrafts[3].AirlineId, AircraftId = aircrafts[3].Number, AvailableSeats = aircrafts[3].SeatsNumber, DepartureAirportId = 5, ArrivalAirportId = 4, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(1.5), BasePrice = 2100 },
                new Flight { Id = 5, AirlineId = aircrafts[5].AirlineId, AircraftId = aircrafts[5].Number, AvailableSeats = aircrafts[5].SeatsNumber, DepartureAirportId = 7, ArrivalAirportId = 2, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(20), BasePrice = 540 },
                new Flight { Id = 6, AirlineId = aircrafts[1].AirlineId, AircraftId = aircrafts[1].Number, AvailableSeats = aircrafts[1].SeatsNumber, DepartureAirportId = 5, ArrivalAirportId = 7, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(1), BasePrice = 1200 },
                new Flight { Id = 7, AirlineId = aircrafts[6].AirlineId, AircraftId = aircrafts[6].Number, AvailableSeats = aircrafts[6].SeatsNumber, DepartureAirportId = 6, ArrivalAirportId = 1, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1050 },
                new Flight { Id = 8, AirlineId = aircrafts[4].AirlineId, AircraftId = aircrafts[4].Number, AvailableSeats = aircrafts[4].SeatsNumber, DepartureAirportId = 9, ArrivalAirportId = 10, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(2), BasePrice = 1007 },
                new Flight { Id = 9, AirlineId = aircrafts[7].AirlineId, AircraftId = aircrafts[7].Number, AvailableSeats = aircrafts[7].SeatsNumber, DepartureAirportId = 3, ArrivalAirportId = 2, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(9), BasePrice = 450 },
                new Flight { Id = 10, AirlineId = aircrafts[1].AirlineId, AircraftId = aircrafts[1].Number, AvailableSeats = aircrafts[1].SeatsNumber, DepartureAirportId = 8, ArrivalAirportId = 9, DepartureDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now.AddHours(12), BasePrice = 7100 }
            };

            var bookings = new Booking[]
            {
                new Booking { Id = 1, FlightId = 2, TravelId = 1, Seat = 2, TiketClass = TiketClass.First, Price = flights[1].BasePrice + (int)TiketClass.First },
                new Booking { Id = 2, FlightId = 3, TravelId = 1, Seat = 25, TiketClass = TiketClass.First, Price = flights[2].BasePrice + (int)TiketClass.First },
                new Booking { Id = 3, FlightId = 2, TravelId = 2, Seat = 10, TiketClass = TiketClass.First, Price = flights[1].BasePrice + (int)TiketClass.First },
                new Booking { Id = 4, FlightId = 3, TravelId = 2, Seat = 17, TiketClass = TiketClass.First, Price = flights[2].BasePrice + (int)TiketClass.First },
                new Booking { Id = 5, FlightId = 4, TravelId = 3, Seat = 20, TiketClass = TiketClass.Economy, Price = flights[3].BasePrice + (int)TiketClass.Economy }
            };

            var travels = new Travel[]
            {
                new Travel
                {
                    Id = 1,
                    OrderId = 1,
                    PassengerId = 1,
                    Price = bookings[0].Price + bookings[1].Price
                },
                new Travel
                {
                    Id = 2,
                    OrderId = 1,
                    PassengerId = 2,
                    Price = bookings[2].Price + bookings[3].Price
                },
                new Travel
                {
                    Id = 3,
                    OrderId = 2,
                    PassengerId = 2,
                    Price = bookings[4].Price
                }
            };

            builder.Entity<Aircraft>().HasData(aircrafts);

            builder.Entity<Flight>().HasData(flights);

            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    TotalPrice = travels[0].Price + travels[1].Price
                },
                new Order
                {
                    Id = 2,
                    UserId = 1,
                    TotalPrice = travels[2].Price
                }
            );

            builder.Entity<Travel>().HasData(travels);

            builder.Entity<Booking>().HasData(bookings);
        }

        #region DbSets
        public DbSet<Order>? Orders { get; set; }

        public DbSet<Booking>? Bookings { get; set; }

        public DbSet<Travel>? Travels { get; set; }

        public DbSet<Flight>? Flights { get; set; }

        public DbSet<Passenger>? Passengers { get; set; }

        public DbSet<Person>? Persons { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Airline>? Airlines { get; set; }

        public DbSet<Airport>? Airports { get; set; }

        public DbSet<Aircraft>? Aircrafts { get; set; }
        #endregion
    }
}