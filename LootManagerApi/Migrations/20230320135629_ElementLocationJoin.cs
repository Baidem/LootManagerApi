using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class ElementLocationJoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElementLocationId",
                table: "Elements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Furniture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementsLocations",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementsLocations", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_ElementsLocations_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementsLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationUser",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationUser", x => new { x.LocationsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LocationUser_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "ElementLocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "ElementLocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "ElementLocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "ElementLocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "ElementLocationId",
                value: 0);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Furniture", "House", "Position", "Room", "Shelf" },
                values: new object[,]
                {
                    { 1, "Furniture1", "House1", 1, "Room1", "First Shelf" },
                    { 2, "Furniture1", "House2", 1, "Room1", "First Shelf" },
                    { 3, "Furniture1", "House3", 1, "Room1", "First Shelf" },
                    { 4, "Furniture1", "House4", 1, "Room1", "First Shelf" },
                    { 5, "Furniture1", "House5", 1, "Room1", "First Shelf" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 492, DateTimeKind.Utc).AddTicks(9168), "$2a$11$h9/FuPDuHQ.Vp38vaMtoX.ml5Zp7gmV1a1DSXBp5n9cSdS7rPijai" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 670, DateTimeKind.Utc).AddTicks(6680), "$2a$11$z9Wwan6wvahlifjzAEnqv.6uVnDoWGs2UG0znw2F6SbgmwUz7NXCu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 854, DateTimeKind.Utc).AddTicks(6266), "$2a$11$fZM5eA7sEp8LVsHq/xngw.asq/KLx2.dJOHrlHTNCCQxyhtWjjcbq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 29, 46, DateTimeKind.Utc).AddTicks(7216), "$2a$11$28fFidvCG7vcvPThQYleSeyiLlM03uxMABths2ogy9NR0wk89p7.e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 29, 210, DateTimeKind.Utc).AddTicks(8190), "$2a$11$DW/EuAKm95kEpkQJpMwfS.ZOrguuww4OY.ffruGpCp.2t.YF8nA7y" });

            migrationBuilder.CreateIndex(
                name: "IX_ElementsLocations_LocationId",
                table: "ElementsLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationUser_UsersId",
                table: "LocationUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementsLocations");

            migrationBuilder.DropTable(
                name: "LocationUser");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "ElementLocationId",
                table: "Elements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 18, 49, 8, 764, DateTimeKind.Utc).AddTicks(9175), "$2a$11$NPuYfchS20fQHeHHXoQrwO5IEGpxrliXBPqLRAfhHLsIYOH.aOoou" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 18, 49, 8, 927, DateTimeKind.Utc).AddTicks(6543), "$2a$11$KZ6Wlf8Rd22PQWv2vgoRDeNW3JU0rfLG0TGU4vi0IwpZ9MQEvqVJe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 18, 49, 9, 87, DateTimeKind.Utc).AddTicks(4033), "$2a$11$d31w9x3DrAeoVUsB52kQp./exXArkxCWGUz9QJ.wK2ebjQXRcLPFm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 18, 49, 9, 242, DateTimeKind.Utc).AddTicks(6302), "$2a$11$m.HgrKOyyBWxX.pisf4A8.KiVopMCT9awYLG4zb8Q8jReTe31d94m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 18, 49, 9, 403, DateTimeKind.Utc).AddTicks(9005), "$2a$11$mqBAvLZQhlhruiFW/82YcunWf/MDILam2d6rfOxKEC3xabTiI4Awi" });
        }
    }
}
