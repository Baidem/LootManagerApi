using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    Position = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Role", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 30, 21, 23, 30, 371, DateTimeKind.Utc).AddTicks(2152), "admin@loot.com", "admin", "$2a$11$e1bjul77PytOwoxwx/.CxOIReTxEsOWx5LyT2ff0if8O8p4bUWSD6", 0, null },
                    { 2, new DateTime(2023, 3, 30, 21, 23, 30, 549, DateTimeKind.Utc).AddTicks(5876), "user@loot.com", "user", "$2a$11$ZVQsXweagD/OfVscFFtJS.csoW.k42MXNWhjFFsFLoILFTX8GzS3K", 1, null },
                    { 3, new DateTime(2023, 3, 30, 21, 23, 30, 714, DateTimeKind.Utc).AddTicks(8780), "contributor@loot.com", "contributor", "$2a$11$av5Qnmr/UCYEnfU4ghTzY.tPztboyyJ4YLIiGToFhVo4AmRg2rCnq", 2, null },
                    { 4, new DateTime(2023, 3, 30, 21, 23, 30, 878, DateTimeKind.Utc).AddTicks(8304), "user4@loot.com", "user4", "$2a$11$uOuXWNuf2RNBPbg0ee.7z.IHGU9rLcO79VJmZLwMi8XQ83iy9y.Ey", 1, null },
                    { 5, new DateTime(2023, 3, 30, 21, 23, 31, 48, DateTimeKind.Utc).AddTicks(733), "user5", "user5", "$2a$11$EBzaVUZRf8vGB2FwGaGnAOLaay.M/0vIoxHUJKtUeQxodjrjF.doO", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "LocationId", "Name", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, "Description of the element", null, "figurine1", "Figurine ", 1 },
                    { 2, "Description of the element", null, "figurine2", "Figurine ", 2 },
                    { 3, "Description of the element", null, "figurine3", "Figurine ", 3 },
                    { 4, "Description of the element", null, "figurine4", "Figurine ", 4 },
                    { 5, "Description of the element", null, "figurine5", "Figurine ", 5 },
                    { 6, "Description of the element", null, "manga1", "Manga", 1 },
                    { 7, "Description of the element", null, "manga2", "Manga", 2 },
                    { 8, "Description of the element", null, "manga3", "Manga", 3 },
                    { 9, "Description of the element", null, "manga4", "Manga", 4 },
                    { 10, "Description of the element", null, "manga5", "Manga", 5 },
                    { 11, "Description of the element", null, "comic1", "Comic", 1 },
                    { 12, "Description of the element", null, "comic2", "Comic", 2 },
                    { 13, "Description of the element", null, "comic3", "Comic", 3 },
                    { 14, "Description of the element", null, "comic4", "Comic", 4 },
                    { 15, "Description of the element", null, "comic5", "Comic", 5 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Furniture", "House", "Position", "Room", "Shelf", "UserId" },
                values: new object[,]
                {
                    { 1, "Furniture1", "House1", 1, "Room1", "First Shelf", 1 },
                    { 2, "Furniture1", "House1", 1, "Room2", "First Shelf", 1 },
                    { 3, "Furniture1", "House1", 1, "Room3", "First Shelf", 1 },
                    { 4, "Furniture1", "House2", 1, "Room1", "First Shelf", 2 },
                    { 5, "Furniture1", "House2", 1, "Room2", "First Shelf", 2 },
                    { 6, "Furniture1", "House2", 1, "Room3", "First Shelf", 2 },
                    { 7, "Furniture1", "House3", 1, "Room1", "First Shelf", 3 },
                    { 8, "Furniture1", "House3", 1, "Room2", "First Shelf", 3 },
                    { 9, "Furniture1", "House3", 1, "Room3", "First Shelf", 3 },
                    { 10, "Furniture1", "House4", 1, "Room1", "First Shelf", 4 },
                    { 11, "Furniture1", "House4", 1, "Room2", "First Shelf", 4 },
                    { 12, "Furniture1", "House4", 1, "Room3", "First Shelf", 4 },
                    { 13, "Furniture1", "House5", 1, "Room1", "First Shelf", 5 },
                    { 14, "Furniture1", "House5", 1, "Room2", "First Shelf", 5 },
                    { 15, "Furniture1", "House5", 1, "Room3", "First Shelf", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LocationId",
                table: "Elements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_UserId",
                table: "Elements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
