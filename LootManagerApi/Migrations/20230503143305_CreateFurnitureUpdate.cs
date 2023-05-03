using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateFurnitureUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfShelves",
                table: "Furnitures");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 14, 33, 4, 408, DateTimeKind.Utc).AddTicks(6611), "$2a$11$F002xPJ7NU6KirtgNIzl9ePSKaWzQUm0vVxzG4ankE0qNEVMQPohS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 14, 33, 4, 580, DateTimeKind.Utc).AddTicks(1623), "$2a$11$LcYcK3MXX2RTddoOjNCzTOPUcBVHQL5h3eNSF686FRiH5ARC/KXTu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 14, 33, 4, 754, DateTimeKind.Utc).AddTicks(4998), "$2a$11$kaST87AOv9z01S7oq/tnJOtgiJSHh9Xopy1LC30FKVNO6Q1QCc.uO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfShelves",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NumberOfShelves" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9510), 1 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "NumberOfShelves" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9512), 1 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "NumberOfShelves" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9514), 1 });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 516, DateTimeKind.Utc).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 164, DateTimeKind.Utc).AddTicks(5431), "$2a$11$rgMKgG8tnqA4K4nTurXMrOpZgO9fnb5.YGE1OKj50mjp0hGvsm65S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 343, DateTimeKind.Utc).AddTicks(1641), "$2a$11$Cf1.gRAVk6/oU43pJvQQSeMoc1RTQVMj2C2wXUgI8sA6Q.kIEc88O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(8888), "$2a$11$DZTUdOm6Kb6bVP3Yv5ex/OtnJY.fwyHDpNcfCWJ3U190X3Ji08FXq" });
        }
    }
}
