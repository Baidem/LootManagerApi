using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 40, 47, 457, DateTimeKind.Utc).AddTicks(2916), "$2a$11$GbWA34nNgrtzJTtB9XxJeu4CBS4kTBL8CZ6SzqqP.G4TW5cH10cWu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 40, 47, 629, DateTimeKind.Utc).AddTicks(456), "$2a$11$GNo.0D9juwlUDB1bWTDSTuHKg3GND/D/O.E4pDQjEvnYG7U8.LRD2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 40, 47, 804, DateTimeKind.Utc).AddTicks(6024), "$2a$11$f9l6kY3Ejkd5jwh.47D7gOFaqwkcSkenWGbSARG2gxeSGdW68QOnO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 40, 47, 984, DateTimeKind.Utc).AddTicks(2424), "$2a$11$Gg8GJiUqLMtf1nQ.VTEKZebvgt.NfxnUMdNusyvKB79Z/3mH3txjm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 40, 48, 149, DateTimeKind.Utc).AddTicks(3005), "$2a$11$wdq6UG/zDK4dTZ4cwzFScOxp4Iloh2faV6uZWpoBxYs8/EhRq6eQu" });

            migrationBuilder.CreateIndex(
                name: "IX_ElementImage_ImagesId",
                table: "ElementImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfoSheet_InfoSheetsId",
                table: "ImageInfoSheet",
                column: "InfoSheetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementImage");

            migrationBuilder.DropTable(
                name: "ImageInfoSheet");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 531, DateTimeKind.Utc).AddTicks(6514), "$2a$11$50u5L.41jSCBiYFVawOsKOhA1KaZlFRnbOKi.yMM3tzot/tNovKmq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 726, DateTimeKind.Utc).AddTicks(3309), "$2a$11$5jOjJcKvB.xzp38fimC6GOZwnN2SRcuwT.9MDxQe14PhdhyD8XwGO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 906, DateTimeKind.Utc).AddTicks(8303), "$2a$11$Q4gBCIfASpj4Igk7WNrI8uwNgLg.3O1Xn/fOU1tVdFRq3s0XXQoJu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 35, 95, DateTimeKind.Utc).AddTicks(7100), "$2a$11$ck0ZFbyq5j5sTFnGgUELPOT.rYttDCCIe0Gp.e9/77QPmIhca6Biu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 35, 307, DateTimeKind.Utc).AddTicks(5433), "$2a$11$ebRVV8seLg9cTUuua54Vku/JZhENUCGZy5uvI8sUJZ.MpB80EDeby" });
        }
    }
}
