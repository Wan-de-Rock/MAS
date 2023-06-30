using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseService.Data.Migrations
{
    public partial class DbVer12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travel_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Travel_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat = table.Column<long>(type: "bigint", nullable: false),
                    TiketClass = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, 0m, 1 },
                    { 2, 0m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FlightId",
                table: "Booking",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TravelId",
                table: "Booking",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_OrderId",
                table: "Travel",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_PassengerId",
                table: "Travel",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Travel");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2090), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2044) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 25, 25, 326, DateTimeKind.Local).AddTicks(2104), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2099) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 20, 25, 25, 326, DateTimeKind.Local).AddTicks(2115), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2110) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 11, 55, 25, 326, DateTimeKind.Local).AddTicks(2125), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 6, 25, 25, 326, DateTimeKind.Local).AddTicks(2135), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 11, 25, 25, 326, DateTimeKind.Local).AddTicks(2145), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2155), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2165), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 19, 25, 25, 326, DateTimeKind.Local).AddTicks(2175), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 22, 25, 25, 326, DateTimeKind.Local).AddTicks(2185), new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2181) });
        }
    }
}
