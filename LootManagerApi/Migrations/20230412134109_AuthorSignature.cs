using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AuthorSignature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contributor",
                table: "InfoSheets",
                newName: "AuthorSignature");

            migrationBuilder.AddColumn<string>(
                name: "AuthorSignature",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorSignature", "CreatedAt", "PasswordHash" },
                values: new object[] { null, new DateTime(2023, 4, 12, 13, 41, 8, 877, DateTimeKind.Utc).AddTicks(9649), "$2a$11$z0NVRJKZnLPfmzptMzrkb.B7n1tSfI23XOu89cgGdLhVocesieMfq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorSignature", "CreatedAt", "PasswordHash" },
                values: new object[] { null, new DateTime(2023, 4, 12, 13, 41, 9, 38, DateTimeKind.Utc).AddTicks(363), "$2a$11$u5gaD8Ud/B4/C29lc61hBeVGDGx3nOQxnnN49wIBu5wNuugDJx78u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorSignature", "CreatedAt", "PasswordHash" },
                values: new object[] { null, new DateTime(2023, 4, 12, 13, 41, 9, 199, DateTimeKind.Utc).AddTicks(4330), "$2a$11$bYZ0l5JOsx.qnvxhlpcLo.FlM7M7COp1GxgUS5Z2wrXPHNANAZGxO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorSignature", "CreatedAt", "PasswordHash" },
                values: new object[] { null, new DateTime(2023, 4, 12, 13, 41, 9, 374, DateTimeKind.Utc).AddTicks(5931), "$2a$11$ODU410tAR1ZoEio1CsRDb.pzKoHt31UhhBpiXOEx17bdgtyqwOaIq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorSignature", "CreatedAt", "PasswordHash" },
                values: new object[] { null, new DateTime(2023, 4, 12, 13, 41, 9, 531, DateTimeKind.Utc).AddTicks(8937), "$2a$11$Prvzzkmc6uD34AmI.nLELuqRMVJmgjaBIdRb2DomQiOQxO0kAFjD." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorSignature",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AuthorSignature",
                table: "InfoSheets",
                newName: "Contributor");

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
    }
}
