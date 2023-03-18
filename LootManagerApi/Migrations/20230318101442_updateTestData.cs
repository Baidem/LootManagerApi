using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class updateTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "test@test.com", "$2a$11$2GOwqjM8vRhLdvIjArKTOehY1b.V/8axx15plAbjS/efBTwz6L4Sy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$NQOxywh5yZwaQ/HctbPaz.S8ZE76fHeUyNFTApdz2eZRDwGgLSP1S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$lM.ghXA75j3V82pf603rpe8kXq2lsnpF8/uGRrqKnFQuDM.cT8una");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$Q092w9s83T4cGZEVDukUSeYxvS3viKxLw.KrEcQ0hsjZKrasewQqO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$1WH6aCIz7/QYcbyfu3j1gOf/PGOCtzf4/yokygs3MVahIaIjbz1l.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "test", "$2a$11$RM2zY2Tc/fdAZetrZ5HCU.dalOs9Vu9icMEeq11tIXMvTApzuI3J6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$wVamX4LOjfVDcbek.V7rbe.bV9sye4paci/j1YswlPewYLHNasyVi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$6dLZn/Z3J.RVOoc1R79k2ehLgRfZCCWwmUOQrI6l4wqkalpqpQiMS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$O1ZhJPYLMYX5hgGkSIG56.ALQPUuypywLng6qdJZ5xWDMRohGSSjy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$a.cPDT8gtYIhnf1kZLBRtOEmixO1zmDlURTYR7xl6ODNwLq1eup.a");
        }
    }
}
