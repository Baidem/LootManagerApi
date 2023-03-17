using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class userTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "test", "test", "$2a$11$RM2zY2Tc/fdAZetrZ5HCU.dalOs9Vu9icMEeq11tIXMvTApzuI3J6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "jerry@aol.com", "Jerry Seinfeld", "$2a$11$wVamX4LOjfVDcbek.V7rbe.bV9sye4paci/j1YswlPewYLHNasyVi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "George.Costanza@aol.com", "George Costanza", "$2a$11$6dLZn/Z3J.RVOoc1R79k2ehLgRfZCCWwmUOQrI6l4wqkalpqpQiMS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "Elaine.Benes@aol.com", "Elaine Benes", "$2a$11$O1ZhJPYLMYX5hgGkSIG56.ALQPUuypywLng6qdJZ5xWDMRohGSSjy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "UpdateAt" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmo.Kramer@aol.com", "Cosmo Kramer", "$2a$11$a.cPDT8gtYIhnf1kZLBRtOEmixO1zmDlURTYR7xl6ODNwLq1eup.a", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "jerry@aol.com", "Jerry Seinfeld", "$2a$11$nTEGYr.sC1RoZTpDbm8gIOTB8XpCBNl2gWKZaSIN.F1qVIboEX6RK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "George.Costanza@aol.com", "George Costanza", "$2a$11$FvKzjPNUjdszVI5dkFDRUejtTIk1Up8vQoYraZNNFULyXwb.5BYHC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "Elaine.Benes@aol.com", "Elaine Benes", "$2a$11$55zPFckSuQJ2Px00ql0Ll.XqRql6G47AT6KevJlAtUELIJ/zaVhMG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "Cosmo.Kramer@aol.com", "Cosmo Kramer", "$2a$11$3puzZC23wr94O8XrM2Q7N.3aF7/BXiHVGRvv05ypLW.jPY7dVAq7i" });
        }
    }
}
