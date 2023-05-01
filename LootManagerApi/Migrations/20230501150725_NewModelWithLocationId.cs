using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class NewModelWithLocationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Furnitures_FurnitureId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Houses_HouseId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Positions_PositionId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Rooms_RoomId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Shelves_ShelfId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_FurnitureId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_HouseId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_PositionId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RoomId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ShelfId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FurnitureId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ShelfId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Shelves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Houses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Furnitures",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(659), 7 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(663), 8 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(665), 9 });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(521), 1 });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(524), 2 });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(525), 3 });

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
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(956), 13 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(960), 14 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(962), 15 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(587), 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(589), 5 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(592), 6 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(870), 10 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(873), 11 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LocationId" },
                values: new object[] { new DateTime(2023, 5, 1, 15, 7, 25, 286, DateTimeKind.Utc).AddTicks(875), 12 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_LocationId",
                table: "Shelves",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LocationId",
                table: "Rooms",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_LocationId",
                table: "Positions",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_LocationId",
                table: "Houses",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_LocationId",
                table: "Furnitures",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Locations_LocationId",
                table: "Furnitures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Locations_LocationId",
                table: "Houses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Locations_LocationId",
                table: "Positions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Locations_LocationId",
                table: "Shelves",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Locations_LocationId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Locations_LocationId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Locations_LocationId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Locations_LocationId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_LocationId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LocationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Positions_LocationId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Houses_LocationId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_LocationId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Furnitures");

            migrationBuilder.AddColumn<int>(
                name: "FurnitureId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2549), null, 1, null, null, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2550), null, 2, null, null, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2551), null, 3, null, null, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2594), null, 1, null, 1, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2595), null, 2, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2597), null, 3, null, 3, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2694), 1, 1, null, 1, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2696), 2, 2, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2697), 3, 3, null, 3, null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2711), 1, 1, null, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2713), 2, 2, null, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2714), 3, 3, null, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2735), 1, 1, 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2736), 2, 2, 2, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "FurnitureId", "HouseId", "PositionId", "RoomId", "ShelfId" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2738), 3, 3, 3, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 110, DateTimeKind.Utc).AddTicks(4856), "$2a$11$Jmf2G69m.ef7cIi3nXq6oe3wTPCVWI.y19/W5DhjnYysfOijE823e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 276, DateTimeKind.Utc).AddTicks(7566), "$2a$11$K/t/vXhuw8nhhKIGW8m80.prNb04ToV3srUVO0ic2vI28Yvqwa/Le" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 31, 2, 440, DateTimeKind.Utc).AddTicks(1738), "$2a$11$4tk9YWWIlFpZbdJVHZWmauTVeyoVEEJ2YqgmSgAcmrcP0EwvpBPRO" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_FurnitureId",
                table: "Locations",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HouseId",
                table: "Locations",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PositionId",
                table: "Locations",
                column: "PositionId",
                unique: true,
                filter: "[PositionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RoomId",
                table: "Locations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ShelfId",
                table: "Locations",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Furnitures_FurnitureId",
                table: "Locations",
                column: "FurnitureId",
                principalTable: "Furnitures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Houses_HouseId",
                table: "Locations",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Positions_PositionId",
                table: "Locations",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Rooms_RoomId",
                table: "Locations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Shelves_ShelfId",
                table: "Locations",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id");
        }
    }
}
