using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketPurchaseService.Data.Migrations
{
    public partial class DbVer11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Passenger");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Passenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TwoLetterISOCountryCode",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ThreeLetterISOCountryCode",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airport_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeatsNumber = table.Column<long>(type: "bigint", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Aircraft_Airline_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airline",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableSeats = table.Column<long>(type: "bigint", nullable: false),
                    DepartureAirportId = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "int", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false),
                    AircraftId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airline",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "LOT" },
                    { 2, "Wizz Air" },
                    { 3, "Lufthansa" },
                    { 4, "MAU" },
                    { 5, "Airfrance" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "ThreeLetterISOCountryCode", "TwoLetterISOCountryCode" },
                values: new object[,]
                {
                    { 1, "Ethiopia", "ETH", "ET" },
                    { 2, "South Africa", "ZAF", "ZA" },
                    { 3, "United Arab Emirates", "ARE", "AE" },
                    { 4, "Bahrain", "BHR", "BH" },
                    { 5, "Algeria", "DZA", "DZ" },
                    { 6, "Egypt", "EGY", "EG" },
                    { 7, "Iraq", "IRQ", "IQ" },
                    { 8, "Jordan", "JOR", "JO" },
                    { 9, "Kuwait", "KWT", "KW" },
                    { 10, "Lebanon", "LBN", "LB" },
                    { 11, "Libya", "LBY", "LY" },
                    { 12, "Morocco", "MAR", "MA" },
                    { 13, "Oman", "OMN", "OM" },
                    { 14, "Qatar", "QAT", "QA" },
                    { 15, "Saudi Arabia", "SAU", "SA" },
                    { 16, "Syria", "SYR", "SY" },
                    { 17, "Tunisia", "TUN", "TN" },
                    { 18, "Yemen", "YEM", "YE" },
                    { 19, "Chile", "CHL", "CL" },
                    { 20, "India", "IND", "IN" },
                    { 21, "Azerbaijan", "AZE", "AZ" },
                    { 22, "Russia", "RUS", "RU" },
                    { 23, "Belarus", "BLR", "BY" },
                    { 24, "Bulgaria", "BGR", "BG" },
                    { 25, "Nigeria", "NGA", "NG" },
                    { 26, "Bangladesh", "BGD", "BD" },
                    { 27, "China", "CHN", "CN" },
                    { 28, "France", "FRA", "FR" },
                    { 29, "Bosnia & Herzegovina", "BIH", "BA" },
                    { 30, "Spain", "ESP", "ES" },
                    { 31, "Czechia", "CZE", "CZ" },
                    { 32, "United Kingdom", "GBR", "GB" },
                    { 33, "Denmark", "DNK", "DK" },
                    { 34, "Austria", "AUT", "AT" },
                    { 35, "Switzerland", "CHE", "CH" },
                    { 36, "Germany", "DEU", "DE" },
                    { 37, "Liechtenstein", "LIE", "LI" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "ThreeLetterISOCountryCode", "TwoLetterISOCountryCode" },
                values: new object[,]
                {
                    { 38, "Luxembourg", "LUX", "LU" },
                    { 39, "Maldives", "MDV", "MV" },
                    { 40, "Bhutan", "BTN", "BT" },
                    { 41, "Greece", "GRC", "GR" },
                    { 42, "Caribbean", "", "029" },
                    { 43, "Australia", "AUS", "AU" },
                    { 44, "Belize", "BLZ", "BZ" },
                    { 45, "Canada", "CAN", "CA" },
                    { 46, "Hong Kong SAR", "HKG", "HK" },
                    { 47, "Indonesia", "IDN", "ID" },
                    { 48, "Ireland", "IRL", "IE" },
                    { 49, "Jamaica", "JAM", "JM" },
                    { 50, "Malaysia", "MYS", "MY" },
                    { 51, "New Zealand", "NZL", "NZ" },
                    { 52, "Philippines", "PHL", "PH" },
                    { 53, "Singapore", "SGP", "SG" },
                    { 54, "Trinidad & Tobago", "TTO", "TT" },
                    { 55, "United States", "USA", "US" },
                    { 56, "Zimbabwe", "ZWE", "ZW" },
                    { 57, "Latin America", "", "419" },
                    { 58, "Argentina", "ARG", "AR" },
                    { 59, "Bolivia", "BOL", "BO" },
                    { 60, "Colombia", "COL", "CO" },
                    { 61, "Costa Rica", "CRI", "CR" },
                    { 62, "Cuba", "CUB", "CU" },
                    { 63, "Dominican Republic", "DOM", "DO" },
                    { 64, "Ecuador", "ECU", "EC" },
                    { 65, "Guatemala", "GTM", "GT" },
                    { 66, "Honduras", "HND", "HN" },
                    { 67, "Mexico", "MEX", "MX" },
                    { 68, "Nicaragua", "NIC", "NI" },
                    { 69, "Panama", "PAN", "PA" },
                    { 70, "Peru", "PER", "PE" },
                    { 71, "Puerto Rico", "PRI", "PR" },
                    { 72, "Paraguay", "PRY", "PY" },
                    { 73, "El Salvador", "SLV", "SV" },
                    { 74, "Uruguay", "URY", "UY" },
                    { 75, "Venezuela", "VEN", "VE" },
                    { 76, "Estonia", "EST", "EE" },
                    { 77, "Iran", "IRN", "IR" },
                    { 78, "Senegal", "SEN", "SN" },
                    { 79, "Finland", "FIN", "FI" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "ThreeLetterISOCountryCode", "TwoLetterISOCountryCode" },
                values: new object[,]
                {
                    { 80, "Faroe Islands", "FRO", "FO" },
                    { 81, "Belgium", "BEL", "BE" },
                    { 82, "Congo (DRC)", "COD", "CD" },
                    { 83, "Côte d’Ivoire", "CIV", "CI" },
                    { 84, "Cameroon", "CMR", "CM" },
                    { 85, "Haiti", "HTI", "HT" },
                    { 86, "Monaco", "MCO", "MC" },
                    { 87, "Mali", "MLI", "ML" },
                    { 88, "Réunion", "REU", "RE" },
                    { 89, "Netherlands", "NLD", "NL" },
                    { 90, "Israel", "ISR", "IL" },
                    { 91, "Croatia", "HRV", "HR" },
                    { 92, "Hungary", "HUN", "HU" },
                    { 93, "Armenia", "ARM", "AM" },
                    { 94, "Iceland", "ISL", "IS" },
                    { 95, "Italy", "ITA", "IT" },
                    { 96, "Japan", "JPN", "JP" },
                    { 97, "Georgia", "GEO", "GE" },
                    { 98, "Kazakhstan", "KAZ", "KZ" },
                    { 99, "Greenland", "GRL", "GL" },
                    { 100, "Cambodia", "KHM", "KH" },
                    { 101, "Korea", "KOR", "KR" },
                    { 102, "Kyrgyzstan", "KGZ", "KG" },
                    { 103, "Laos", "LAO", "LA" },
                    { 104, "Lithuania", "LTU", "LT" },
                    { 105, "Latvia", "LVA", "LV" },
                    { 106, "North Macedonia", "MKD", "MK" },
                    { 107, "Mongolia", "MNG", "MN" },
                    { 108, "Brunei", "BRN", "BN" },
                    { 109, "Malta", "MLT", "MT" },
                    { 110, "Myanmar", "MMR", "MM" },
                    { 111, "Norway", "NOR", "NO" },
                    { 112, "Nepal", "NPL", "NP" },
                    { 113, "Pakistan", "PAK", "PK" },
                    { 114, "Poland", "POL", "PL" },
                    { 115, "Afghanistan", "AFG", "AF" },
                    { 116, "Brazil", "BRA", "BR" },
                    { 117, "Portugal", "PRT", "PT" },
                    { 118, "Moldova", "MDA", "MD" },
                    { 119, "Romania", "ROU", "RO" },
                    { 120, "Rwanda", "RWA", "RW" },
                    { 121, "Sweden", "SWE", "SE" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "ThreeLetterISOCountryCode", "TwoLetterISOCountryCode" },
                values: new object[,]
                {
                    { 122, "Sri Lanka", "LKA", "LK" },
                    { 123, "Slovakia", "SVK", "SK" },
                    { 124, "Slovenia", "SVN", "SI" },
                    { 125, "Somalia", "SOM", "SO" },
                    { 126, "Albania", "ALB", "AL" },
                    { 127, "Montenegro", "MNE", "ME" },
                    { 128, "Serbia", "SRB", "RS" },
                    { 129, "Kenya", "KEN", "KE" },
                    { 130, "Thailand", "THA", "TH" },
                    { 131, "Eritrea", "ERI", "ER" },
                    { 132, "Turkmenistan", "TKM", "TM" },
                    { 133, "Botswana", "BWA", "BW" },
                    { 134, "Turkey", "TUR", "TR" },
                    { 135, "Ukraine", "UKR", "UA" },
                    { 136, "Uzbekistan", "UZB", "UZ" },
                    { 137, "Vietnam", "VNM", "VN" },
                    { 138, "World", "", "001" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ali", "Baba" },
                    { 2, "Albert", "Sohlmann" },
                    { 3, "Odin", "Hale" },
                    { 4, "Ivor", "Watkins" },
                    { 5, "Zena", "Ellis" },
                    { 6, "Isac", "Ericsson" },
                    { 7, "Max", "Sundqvist" },
                    { 8, "Edward", "Johansson" },
                    { 9, "Arne", "Akerman" },
                    { 10, "Amund", "Erling" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PassengerId", "Password" },
                values: new object[] { 5, "some5@mail.com", null, "3209rfh" });

            migrationBuilder.InsertData(
                table: "Aircraft",
                columns: new[] { "Number", "AirlineId", "SeatsNumber" },
                values: new object[,]
                {
                    { "327senj", 1, 300L },
                    { "3298f7", 2, 78L },
                    { "3408fj8", 4, 300L },
                    { "34984f", 5, 611L },
                    { "34u4ff7", 5, 454L },
                    { "398f733", 1, 46L },
                    { "838f823", 3, 747L },
                    { "weuihf7", 1, 100L }
                });

            migrationBuilder.InsertData(
                table: "Airport",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Hulveien 57", "City1", 16, "Airport1" },
                    { 2, "Ole Tobias Olsens gate 247", "City2", 11, "Airport2" },
                    { 3, "Skjønnhaugveien 129", "City3", 31, "Airport3" },
                    { 4, "Gangsåsvegen 10", "City4", 78, "Airport4" },
                    { 5, "Einar Røds gate 249", "City5", 55, "Airport5" },
                    { 6, "Lars Onsagers veg 227", "City6", 45, "Airport6" },
                    { 7, "Tokerudberget 39", "City7", 87, "Airport7" },
                    { 8, "Sunnlandsstien 207", "City8", 89, "Airport8" },
                    { 9, "Lollandveien 5", "City9", 15, "Airport9" },
                    { 10, "Erling Smiths veg 123", "City10", 2, "Airport0" }
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "CountryId", "PassportNumber", "PersonId" },
                values: new object[,]
                {
                    { 1, 12, "FV679780", 1 },
                    { 2, 9, "KF784839", 3 },
                    { 3, 23, "FH567478", 7 },
                    { 4, 68, "NF547849", 5 },
                    { 5, 5, "BJ564700", 10 }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "AircraftId", "AirlineId", "ArrivalAirportId", "ArrivalDateTime", "AvailableSeats", "BasePrice", "DepartureAirportId", "DepartureDateTime" },
                values: new object[,]
                {
                    { 1, "327senj", 1, 1, new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2090), 0L, 1000m, 2, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2044) },
                    { 2, "3298f7", 2, 4, new DateTime(2023, 6, 30, 13, 25, 25, 326, DateTimeKind.Local).AddTicks(2104), 0L, 100m, 1, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2099) },
                    { 3, "weuihf7", 1, 10, new DateTime(2023, 6, 30, 20, 25, 25, 326, DateTimeKind.Local).AddTicks(2115), 0L, 500m, 4, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2110) },
                    { 4, "34984f", 5, 4, new DateTime(2023, 6, 30, 11, 55, 25, 326, DateTimeKind.Local).AddTicks(2125), 0L, 2100m, 5, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2120) },
                    { 5, "838f823", 3, 2, new DateTime(2023, 7, 1, 6, 25, 25, 326, DateTimeKind.Local).AddTicks(2135), 0L, 540m, 7, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2130) },
                    { 6, "34u4ff7", 5, 7, new DateTime(2023, 6, 30, 11, 25, 25, 326, DateTimeKind.Local).AddTicks(2145), 0L, 1200m, 5, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2140) },
                    { 7, "3408fj8", 4, 1, new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2155), 0L, 1050m, 6, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2150) },
                    { 8, "398f733", 1, 10, new DateTime(2023, 6, 30, 12, 25, 25, 326, DateTimeKind.Local).AddTicks(2165), 0L, 1007m, 9, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2160) },
                    { 9, "3408fj8", 4, 2, new DateTime(2023, 6, 30, 19, 25, 25, 326, DateTimeKind.Local).AddTicks(2175), 0L, 450m, 3, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2170) },
                    { 10, "398f733", 1, 9, new DateTime(2023, 6, 30, 22, 25, 25, 326, DateTimeKind.Local).AddTicks(2185), 0L, 7100m, 8, new DateTime(2023, 6, 30, 10, 25, 25, 326, DateTimeKind.Local).AddTicks(2181) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PassengerId", "Password" },
                values: new object[,]
                {
                    { 1, "some1@mail.com", 1, "3ygr3g8" },
                    { 2, "some2@mail.com", 2, "siejfei" },
                    { 3, "some3@mail.com", 3, "3298hfw" },
                    { 4, "some4@mail.com", 4, "34u9g2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_PersonId",
                table: "Passenger",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_AirlineId",
                table: "Aircraft",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CountryId",
                table: "Airport",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftId",
                table: "Flight",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalAirportId",
                table: "Flight",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Person_PersonId",
                table: "Passenger",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Person_PersonId",
                table: "Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropIndex(
                name: "IX_Passenger_PersonId",
                table: "Passenger");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Passenger");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Passenger",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Passenger",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TwoLetterISOCountryCode",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThreeLetterISOCountryCode",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Passenger_PassengerId",
                table: "User",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
