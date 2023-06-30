using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseService.Data.Migrations
{
    public partial class DbVer14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7833), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 15, 27, 4, 580, DateTimeKind.Local).AddTicks(7853), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 22, 27, 4, 580, DateTimeKind.Local).AddTicks(7866), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 57, 4, 580, DateTimeKind.Local).AddTicks(7882), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 8, 27, 4, 580, DateTimeKind.Local).AddTicks(7895), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 13, 27, 4, 580, DateTimeKind.Local).AddTicks(7909), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7923), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 14, 27, 4, 580, DateTimeKind.Local).AddTicks(7939), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 6, 30, 21, 27, 4, 580, DateTimeKind.Local).AddTicks(7954), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7947) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDateTime", "DepartureDateTime" },
                values: new object[] { new DateTime(2023, 7, 1, 0, 27, 4, 580, DateTimeKind.Local).AddTicks(7971), new DateTime(2023, 6, 30, 12, 27, 4, 580, DateTimeKind.Local).AddTicks(7962) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
