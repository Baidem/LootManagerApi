using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultLocationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefaultLocations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DefaultLocations",
                columns: new[] { "Id", "LocationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2303), "Admin's Main House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2304), "User's Main House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2305), "Cont's Main House" });

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 110, DateTimeKind.Utc).AddTicks(4856), "$2a$11$Jmf2G69m.ef7cIi3nXq6oe3wTPCVWI.y19/W5DhjnYysfOijE823e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 276, DateTimeKind.Utc).AddTicks(7566), "$2a$11$K/t/vXhuw8nhhKIGW8m80.prNb04ToV3srUVO0ic2vI28Yvqwa/Le" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(1738), "$2a$11$4tk9YWWIlFpZbdJVHZWmauTVeyoVEEJ2YqgmSgAcmrcP0EwvpBPRO" });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultLocations_LocationId",
                table: "DefaultLocations",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultLocations_UserId",
                table: "DefaultLocations",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultLocations");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6278), "Admin House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6280), "User House" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6284), "Cont House" });

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 20, 788, DateTimeKind.Utc).AddTicks(9860), "$2a$11$bSHpQYsLT82itvYQyQezBO4TPuwcUm4QRTeFSE6Xgm.XFy03rTYUy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 20, 960, DateTimeKind.Utc).AddTicks(4517), "$2a$11$go5GdsB1tXQ1ZwElav35xuquF0Y8nonWXjuOHe5eVhBxW2akFOMQe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(5635), "$2a$11$qNR3PwIJfbMh5Z9V/6qINutWms70I7TFfwk3Nsg0dpPITBj14.7nm" });
        }
    }
}
