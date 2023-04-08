using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationInfoSheetUpdateProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contributor",
                table: "InfoSheets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InfoSheets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "InfoSheets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 54, 53, 346, DateTimeKind.Utc).AddTicks(6134), "$2a$11$oz9KugrVVuQMD0XS5Oe0MuOhu87bxDWxwV1ck4UV8J7bJJYRBYIki" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 54, 53, 538, DateTimeKind.Utc).AddTicks(2269), "$2a$11$rt/i/kE2zeom5L2IdQpGReXG.5f8LR32HzlF6wWQB2l8a7LzDbAIO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 54, 53, 723, DateTimeKind.Utc).AddTicks(4601), "$2a$11$pPoW6NwuFWvA1DZn.7tN4uBUgMaqFztoiwBfZGe8EOhfo8dji4Bha" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 54, 53, 913, DateTimeKind.Utc).AddTicks(7613), "$2a$11$mXxTJJ2uyWn45PEJPP3oWegcmVHsItjVDmwYWl6D5Xpb7AaEUpnd." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 8, 14, 54, 54, 103, DateTimeKind.Utc).AddTicks(6612), "$2a$11$k1bfwOCT2nzkcC49Gj/3Hu23aktMuE5TiIQDzqJyCYFq3ffvbz1ky" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contributor",
                table: "InfoSheets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InfoSheets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "InfoSheets");

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
        }
    }
}
