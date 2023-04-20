using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitLogistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AuthorSignature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiArticle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoSheets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageInfoSheet",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    InfoSheetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageInfoSheet", x => new { x.ImagesId, x.InfoSheetsId });
                    table.ForeignKey(
                        name: "FK_ImageInfoSheet_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageInfoSheet_InfoSheets_InfoSheetsId",
                        column: x => x.InfoSheetsId,
                        principalTable: "InfoSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    NumberOfShelves = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furnitures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    NumberOfPositions = table.Column<int>(type: "int", nullable: false),
                    FurnitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelves_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    FurnitureId = table.Column<int>(type: "int", nullable: true),
                    ShelfId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furnitures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    InfoSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_InfoSheets_InfoSheetId",
                        column: x => x.InfoSheetId,
                        principalTable: "InfoSheets",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "ElementImage",
                columns: table => new
                {
                    ElementsId = table.Column<int>(type: "int", nullable: false),
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementImage", x => new { x.ElementsId, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_ElementImage_Elements_ElementsId",
                        column: x => x.ElementsId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementImage_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthorSignature", "CreatedAt", "Email", "FullName", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 4, 20, 11, 2, 54, 691, DateTimeKind.Utc).AddTicks(4666), "admin@loot.com", "admin", "$2a$11$vikp0zo5YmKA3TSRhd.9ue4PMdMWXQ5mFn8jfYTNIS4r1slEk9J7e", 0, null },
                    { 2, null, new DateTime(2023, 4, 20, 11, 2, 54, 866, DateTimeKind.Utc).AddTicks(1730), "user@loot.com", "user", "$2a$11$tc3kJ3uefMXhNN1cnfil3.uSwD/nbtkLux2XmxuPhXtRQ0H1BhVCm", 1, null },
                    { 3, null, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7027), "contributor@loot.com", "contributor", "$2a$11$WabHDdpvtCr1/7OKVH89AOQbl8pWA/5azQj7FmIaGBzlIMIGH6MvG", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Indice", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Admin House", 1 },
                    { 2, 1, "User House", 2 },
                    { 3, 1, "Cont House", 3 }
                });

            migrationBuilder.InsertData(
                table: "InfoSheets",
                columns: new[] { "Id", "AuthorSignature", "BarCode", "CreatedAt", "Designation", "Reference", "UpdatedAt", "UserId", "WikiArticle" },
                values: new object[,]
                {
                    { 1, "The Contributor", "3 037920 02133 1", new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7756), "Figurine", "Fig-ref_01", null, 3, "Small statue depicting a popular culture character." },
                    { 2, "The Contributor", "3 037920 02133 1", new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7760), "Manga", "Man-ref_01", null, 3, "Japanese comic book." },
                    { 3, "The Contributor", "3 037920 02133 1", new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7761), "Comic", "Com-ref_01", null, 3, "Illustrated story in a book or magazine format, often featuring superheroes or humor." }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, null },
                    { 2, null, 2, null, null, null },
                    { 3, null, 3, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HouseId", "Indice", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Admin Room" },
                    { 2, 2, 1, "User Room" },
                    { 3, 3, 1, "Cont Room" }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "CreatedAt", "Description", "Grade", "InfoSheetId", "LocationId", "Name", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7788), "Description of the element", "An excellent condition.", 1, 1, "Admin Fig", "Figurine", null, 1 },
                    { 2, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7790), "Description of the element", "An excellent condition.", 1, 2, "User Fig", "Figurine", null, 2 },
                    { 3, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7792), "Description of the element", "An excellent condition.", 1, 3, "Cont Fig", "Figurine", null, 3 },
                    { 4, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7793), "Description of the element", "An excellent condition.", 2, 1, "Admin Manga", "Manga", null, 1 },
                    { 5, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7795), "Description of the element", "An excellent condition.", 2, 2, "User Manga", "Manga", null, 2 },
                    { 6, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7802), "Description of the element", "An excellent condition.", 2, 3, "Cont Manga3", "Manga", null, 3 },
                    { 7, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7803), "Description of the element", "An excellent condition.", 3, 1, "Admin Comic", "Comic", null, 1 },
                    { 8, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7805), "Description of the element", "An excellent condition.", 3, 2, "User Comic", "Comic", null, 2 },
                    { 9, new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7806), "Description of the element", "An excellent condition.", 3, 3, "Cont Comic", "Comic", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Furnitures",
                columns: new[] { "Id", "Indice", "Name", "NumberOfShelves", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, "Admin Furniture", 1, 1 },
                    { 2, 1, "User Furniture", 1, 2 },
                    { 3, 1, "Cont Furniture", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[,]
                {
                    { 4, null, 1, null, 1, null },
                    { 5, null, 2, null, 2, null },
                    { 6, null, 3, null, 3, null },
                    { 7, 1, 1, null, 1, null },
                    { 8, 2, 2, null, 2, null },
                    { 9, 3, 3, null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "FurnitureId", "Indice", "Name", "NumberOfPositions" },
                values: new object[,]
                {
                    { 1, 1, 1, "Admin Shelf", 1 },
                    { 2, 2, 1, "User Shelf", 1 },
                    { 3, 3, 1, "Cont Shelf", 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[,]
                {
                    { 10, 1, 1, null, 1, 1 },
                    { 11, 2, 2, null, 2, 2 },
                    { 12, 3, 3, null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Indice", "Name", "ShelfId" },
                values: new object[,]
                {
                    { 1, 1, "Admin Position", 1 },
                    { 2, 1, "User Position", 2 },
                    { 3, 1, "Cont Position", 3 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[,]
                {
                    { 13, 1, 1, 1, 1, 1 },
                    { 14, 2, 2, 2, 2, 2 },
                    { 15, 3, 3, 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementImage_ImagesId",
                table: "ElementImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_InfoSheetId",
                table: "Elements",
                column: "InfoSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LocationId",
                table: "Elements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_UserId",
                table: "Elements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_RoomId",
                table: "Furnitures",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_UserId",
                table: "Houses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfoSheet_InfoSheetsId",
                table: "ImageInfoSheet",
                column: "InfoSheetsId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSheets_UserId",
                table: "InfoSheets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_FurnitureId",
                table: "Locations",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HouseId",
                table: "Locations",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PositionId",
                table: "Locations",
                column: "PositionId",
                unique: true,
                filter: "[PositionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RoomId",
                table: "Locations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ShelfId",
                table: "Locations",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ShelfId",
                table: "Positions",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HouseId",
                table: "Rooms",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_FurnitureId",
                table: "Shelves",
                column: "FurnitureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementImage");

            migrationBuilder.DropTable(
                name: "ImageInfoSheet");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "InfoSheets");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
