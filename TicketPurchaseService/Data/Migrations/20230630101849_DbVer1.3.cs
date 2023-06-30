using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseService.Data.Migrations
{
    public partial class DbVer13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 18, 48, 952, DateTimeKind.Local).AddTicks(3264), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 15, 18, 48, 952, DateTimeKind.Local).AddTicks(3279), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 22, 18, 48, 952, DateTimeKind.Local).AddTicks(3290), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 48, 48, 952, DateTimeKind.Local).AddTicks(3300), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 8, 18, 48, 952, DateTimeKind.Local).AddTicks(3310), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3305) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 18, 48, 952, DateTimeKind.Local).AddTicks(3320), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3316) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 18, 48, 952, DateTimeKind.Local).AddTicks(3330), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 18, 48, 952, DateTimeKind.Local).AddTicks(3341), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 21, 18, 48, 952, DateTimeKind.Local).AddTicks(3351), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3346) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 0, 18, 48, 952, DateTimeKind.Local).AddTicks(3361), new DateTime(2023, 6, 30, 12, 18, 48, 952, DateTimeKind.Local).AddTicks(3357) });

            migrationBuilder.InsertData(
                table: "Travel",
                columns: new[] { "Id", "ArrivalDateTime", "DepartureDateTime", "OrderId", "PassengerId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0m },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 0m },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 0m }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "FlightId", "Price", "Seat", "TiketClass", "TravelId" },
                values: new object[,]
                {
                    { 1, 2, 0m, 20L, 300, 1 },
                    { 2, 3, 0m, 20L, 300, 1 },
                    { 3, 2, 0m, 20L, 300, 2 },
                    { 4, 3, 0m, 20L, 300, 2 },
                    { 5, 4, 0m, 20L, 100, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 6, 6, 532, DateTimeKind.Local).AddTicks(1730), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 15, 6, 6, 532, DateTimeKind.Local).AddTicks(1744), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1739) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 22, 6, 6, 532, DateTimeKind.Local).AddTicks(1753), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1749) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 36, 6, 532, DateTimeKind.Local).AddTicks(1763), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 8, 6, 6, 532, DateTimeKind.Local).AddTicks(1773), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 6, 6, 532, DateTimeKind.Local).AddTicks(1784), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 6, 6, 532, DateTimeKind.Local).AddTicks(1793), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 6, 6, 532, DateTimeKind.Local).AddTicks(1803), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 21, 6, 6, 532, DateTimeKind.Local).AddTicks(1812), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 0, 6, 6, 532, DateTimeKind.Local).AddTicks(1822), new DateTime(2023, 6, 30, 12, 6, 6, 532, DateTimeKind.Local).AddTicks(1817) });
        }
    }
}
