using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultDataAddCreatedAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$2GOwqjM8vRhLdvIjArKTOehY1b.V/8axx15plAbjS/efBTwz6L4Sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$NQOxywh5yZwaQ/HctbPaz.S8ZE76fHeUyNFTApdz2eZRDwGgLSP1S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$lM.ghXA75j3V82pf603rpe8kXq2lsnpF8/uGRrqKnFQuDM.cT8una" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$Q092w9s83T4cGZEVDukUSeYxvS3viKxLw.KrEcQ0hsjZKrasewQqO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$1WH6aCIz7/QYcbyfu3j1gOf/PGOCtzf4/yokygs3MVahIaIjbz1l." });
        }
    }
}
