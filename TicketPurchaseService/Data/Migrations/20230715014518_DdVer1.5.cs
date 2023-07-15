using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseService.Data.Migrations
{
    public partial class DdVer15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircraft_Airline_AirlineId",
                table: "Aircraft");

            migrationBuilder.DropForeignKey(
                name: "FK_Airport_Country_CountryId",
                table: "Airport");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Travel_TravelId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Aircraft_AircraftId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airline_AirlineId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_ArrivalAirportId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Country_CountryId",
                table: "Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Person_PersonId",
                table: "Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Travel_Order_OrderId",
                table: "Travel");

            migrationBuilder.DropForeignKey(
                name: "FK_Travel_Passenger_PassengerId",
                table: "Travel");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travel",
                table: "Travel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airport",
                table: "Airport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airline",
                table: "Airline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Travel",
                newName: "Travels");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Passenger",
                newName: "Passengers");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flights");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "Airport",
                newName: "Airports");

            migrationBuilder.RenameTable(
                name: "Airline",
                newName: "Airlines");

            migrationBuilder.RenameTable(
                name: "Aircraft",
                newName: "Aircrafts");

            migrationBuilder.RenameIndex(
                name: "IX_User_PassengerId",
                table: "Users",
                newName: "IX_Users_PassengerId");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Travels",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Travel_PassengerId",
                table: "Travels",
                newName: "IX_Travels_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Travel_OrderId",
                table: "Travels",
                newName: "IX_Travels_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Passenger_PersonId",
                table: "Passengers",
                newName: "IX_Passengers_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Passenger_CountryId",
                table: "Passengers",
                newName: "IX_Passengers_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flights",
                newName: "IX_Flights_DepartureAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_ArrivalAirportId",
                table: "Flights",
                newName: "IX_Flights_ArrivalAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_AirlineId",
                table: "Flights",
                newName: "IX_Flights_AirlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_AircraftId",
                table: "Flights",
                newName: "IX_Flights_AircraftId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TravelId",
                table: "Bookings",
                newName: "IX_Bookings_TravelId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_FlightId",
                table: "Bookings",
                newName: "IX_Bookings_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Airport_CountryId",
                table: "Airports",
                newName: "IX_Airports_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircraft_AirlineId",
                table: "Aircrafts",
                newName: "IX_Aircrafts_AirlineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travels",
                table: "Travels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airports",
                table: "Airports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts",
                column: "Number");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 400m, 2L });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 800m, 25L });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 400m, 10L });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 800m, 17L });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 2200m);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 15, 5, 45, 3, 948, DateTimeKind.Local).AddTicks(6728), 300L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6659) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "34u4ff7", 5, new DateTime(2023, 7, 15, 6, 45, 3, 948, DateTimeKind.Local).AddTicks(6753), 454L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6744) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AircraftId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "398f733", new DateTime(2023, 7, 15, 13, 45, 3, 948, DateTimeKind.Local).AddTicks(6793), 46L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "838f823", 3, new DateTime(2023, 7, 15, 5, 15, 3, 948, DateTimeKind.Local).AddTicks(6818), 747L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "34u4ff7", 5, new DateTime(2023, 7, 15, 23, 45, 3, 948, DateTimeKind.Local).AddTicks(6835), 454L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6828) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "weuihf7", 1, new DateTime(2023, 7, 15, 4, 45, 3, 948, DateTimeKind.Local).AddTicks(6861), 100L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "3298f7", 2, new DateTime(2023, 7, 15, 5, 45, 3, 948, DateTimeKind.Local).AddTicks(6889), 78L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "34984f", 5, new DateTime(2023, 7, 15, 5, 45, 3, 948, DateTimeKind.Local).AddTicks(6924), 611L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 15, 12, 45, 3, 948, DateTimeKind.Local).AddTicks(6943), 300L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AircraftId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "weuihf7", new DateTime(2023, 7, 15, 15, 45, 3, 948, DateTimeKind.Local).AddTicks(6961), 100L, new DateTime(2023, 7, 15, 3, 45, 3, 948, DateTimeKind.Local).AddTicks(6953) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalPrice",
                value: 2400m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalPrice",
                value: 2200m);

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 2200m);

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Airlines_AirlineId",
                table: "Aircrafts",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Country_CountryId",
                table: "Airports",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Travels_TravelId",
                table: "Bookings",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_ArrivalAirportId",
                table: "Flights",
                column: "ArrivalAirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Country_CountryId",
                table: "Passengers",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Persons_PersonId",
                table: "Passengers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Orders_OrderId",
                table: "Travels",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Passengers_PassengerId",
                table: "Travels",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passengers_PassengerId",
                table: "Users",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Airlines_AirlineId",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Country_CountryId",
                table: "Airports");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Travels_TravelId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_ArrivalAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Country_CountryId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Persons_PersonId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Orders_OrderId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Passengers_PassengerId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passengers_PassengerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travels",
                table: "Travels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airports",
                table: "Airports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Travels",
                newName: "Travel");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passenger");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "Airports",
                newName: "Airport");

            migrationBuilder.RenameTable(
                name: "Airlines",
                newName: "Airline");

            migrationBuilder.RenameTable(
                name: "Aircrafts",
                newName: "Aircraft");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PassengerId",
                table: "User",
                newName: "IX_User_PassengerId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Travel",
                newName: "TotalPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Travels_PassengerId",
                table: "Travel",
                newName: "IX_Travel_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Travels_OrderId",
                table: "Travel",
                newName: "IX_Travel_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PersonId",
                table: "Passenger",
                newName: "IX_Passenger_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_CountryId",
                table: "Passenger",
                newName: "IX_Passenger_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flight",
                newName: "IX_Flight_DepartureAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_ArrivalAirportId",
                table: "Flight",
                newName: "IX_Flight_ArrivalAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirlineId",
                table: "Flight",
                newName: "IX_Flight_AirlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AircraftId",
                table: "Flight",
                newName: "IX_Flight_AircraftId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TravelId",
                table: "Booking",
                newName: "IX_Booking_TravelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_FlightId",
                table: "Booking",
                newName: "IX_Booking_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Airports_CountryId",
                table: "Airport",
                newName: "IX_Airport_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircrafts_AirlineId",
                table: "Aircraft",
                newName: "IX_Aircraft_AirlineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travel",
                table: "Travel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airport",
                table: "Airport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airline",
                table: "Airline",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft",
                column: "Number");

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 0m, 20L });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 0m, 20L });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 0m, 20L });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "Seat" },
                values: new object[] { 0m, 20L });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7833), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "3298f7", 2, new DateTime(2023, 6, 30, 15, 27, 4, 580, DateTimeKind.Local).AddTicks(7853), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AircraftId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "weuihf7", new DateTime(2023, 6, 30, 22, 27, 4, 580, DateTimeKind.Local).AddTicks(7866), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "34984f", 5, new DateTime(2023, 6, 30, 13, 57, 4, 580, DateTimeKind.Local).AddTicks(7882), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "838f823", 3, new DateTime(2023, 7, 1, 8, 27, 4, 580, DateTimeKind.Local).AddTicks(7895), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "34u4ff7", 5, new DateTime(2023, 6, 30, 13, 27, 4, 580, DateTimeKind.Local).AddTicks(7909), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "3408fj8", 4, new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7923), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AircraftId", "AirlineId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "398f733", 1, new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7939), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 21, 27, 4, 580, DateTimeKind.Local).AddTicks(7954), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7947) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AircraftId", "ArrivalDateTime", "AvailableSeats", "DepartureDateTime" },
                values: new object[] { "398f733", new DateTime(2023, 7, 1, 0, 27, 4, 580, DateTimeKind.Local).AddTicks(7971), 0L, new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Aircraft_Airline_AirlineId",
                table: "Aircraft",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airport_Country_CountryId",
                table: "Airport",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Flight_FlightId",
                table: "Booking",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Travel_TravelId",
                table: "Booking",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Aircraft_AircraftId",
                table: "Flight",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airline_AirlineId",
                table: "Flight",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_ArrivalAirportId",
                table: "Flight",
                column: "ArrivalAirportId",
                principalTable: "Airport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Country_CountryId",
                table: "Passenger",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Person_PersonId",
                table: "Passenger",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travel_Order_OrderId",
                table: "Travel",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travel_Passenger_PassengerId",
                table: "Travel",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id");
        }
    }
}
