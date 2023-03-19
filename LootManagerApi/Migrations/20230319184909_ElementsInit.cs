using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class ElementsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "LocationAddress", "Name", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, "Description of the element", "Location undifined", "element1", "Type undefined ", 1 },
                    { 2, "Description of the element", "Location undifined", "element2", "Type undefined ", 2 },
                    { 3, "Description of the element", "Location undifined", "element3", "Type undefined ", 3 },
                    { 4, "Description of the element", "Location undifined", "element4", "Type undefined ", 4 },
                    { 5, "Description of the element", "Location undifined", "element5", "Type undefined ", 5 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Elements_UserId",
                table: "Elements",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 7, 18, 29, 46, DateTimeKind.Utc).AddTicks(5720), "$2a$11$8cw6miPq.y9410.HdRfgNe/A7hRaBqE3wN8U9r6X6Oea2PC7bLbxq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 7, 18, 29, 210, DateTimeKind.Utc).AddTicks(4037), "$2a$11$ivRZ9Bm.YVBZYP3w/X106ejyTT5yb3OGjtRvl6svCZ8SyO2BFrlGG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 7, 18, 29, 369, DateTimeKind.Utc).AddTicks(7551), "$2a$11$Wqv1pwiucLVCGilHBApO/e8AmrgIGSEk5FQRS7YuphNuLXA3en7l2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 7, 18, 29, 533, DateTimeKind.Utc).AddTicks(188), "$2a$11$zkE2ClSYi1guBfnhDhcyg.jkOyVUddBXnQBjCtUBH8Yw8RcA6DzS." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 19, 7, 18, 29, 695, DateTimeKind.Utc).AddTicks(8199), "$2a$11$ncYGmTSNl723NLjuFjkII.NzasIPhqHLC4sL.Kzss8U3sjyrhykHu" });
        }
    }
}
