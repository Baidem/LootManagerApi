using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class userDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdateAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$rxpCvf8HIF7joH448JzzdOj8PAvVs6ZsLMrjH96sOeZTz2VafjFMm", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdateAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$tlhOMMnscikibGD8AZZhqezFxP80ombQnNKXU2Wd.GdebLu5hLDDC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdateAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$UaNaMRA7Qj1OxU/t9xUHAO0mF.f2kcc9t4sBEGko25WwrzAkkDYsa", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdateAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$rJ3i8Qbxy2zFMuDyl5SoSOv./yQ/MIxiwUHQF/JJ35Pc88RQfLoBK", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$YVqNWFz2sI3b.Oie3NQ76.1X31UF0vGw5/p38jPMmonRpmjuQ98cS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$jpHPAzk4g8CO.lBOLK8D6eBvLaSkad6Fz9rdgd54dB0Alqnd7VRE2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$dEd/XsjW4rEHwrEo4AB7f.ob.JnCSF7xhyKAcMZr2kdDtirNMyhDC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$KKeHQ4C/tFE2wCaixOryHe5HIuZIUFMj6/WwAsQz5K0TMFUZkYW7O");
        }
    }
}
