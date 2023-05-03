using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class DebugNumberOfPositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPositions",
                table: "Shelves");

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
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9514));

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
                columns: new[] { "CreatedAt", "Indice" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9732), 2 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Indice" },
                values: new object[] { new DateTime(2023, 5, 3, 12, 33, 47, 515, DateTimeKind.Utc).AddTicks(9733), 3 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfPositions",
                table: "Shelves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NumberOfPositions" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(870), 1 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Indice", "NumberOfPositions" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(873), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Indice", "NumberOfPositions" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(875), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 24, 876, DateTimeKind.Utc).AddTicks(4427), "$2a$11$Rynkn9zKmLah3kioQ0xeseh2ATp9Ky67dh7gK/7///887rOXpMHei" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 86, DateTimeKind.Utc).AddTicks(4866), "$2a$11$UYUMuTGj69gLh5OvbMlvKO4o4tgKYSZqRqEpdna/beA3DF7IvUJBy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 285, DateTimeKind.Utc).AddTicks(9671), "$2a$11$UvjA8imhhLgS2eo7HQW/sOAL8JVY/C/UNCj.O8xOhTtGyC/fXIyNO" });
        }
    }
}
