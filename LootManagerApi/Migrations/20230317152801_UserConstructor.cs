using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UserConstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$nTEGYr.sC1RoZTpDbm8gIOTB8XpCBNl2gWKZaSIN.F1qVIboEX6RK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$FvKzjPNUjdszVI5dkFDRUejtTIk1Up8vQoYraZNNFULyXwb.5BYHC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$55zPFckSuQJ2Px00ql0Ll.XqRql6G47AT6KevJlAtUELIJ/zaVhMG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$3puzZC23wr94O8XrM2Q7N.3aF7/BXiHVGRvv05ypLW.jPY7dVAq7i");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rxpCvf8HIF7joH448JzzdOj8PAvVs6ZsLMrjH96sOeZTz2VafjFMm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$tlhOMMnscikibGD8AZZhqezFxP80ombQnNKXU2Wd.GdebLu5hLDDC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$UaNaMRA7Qj1OxU/t9xUHAO0mF.f2kcc9t4sBEGko25WwrzAkkDYsa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$rJ3i8Qbxy2zFMuDyl5SoSOv./yQ/MIxiwUHQF/JJ35Pc88RQfLoBK");
        }
    }
}
