using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogisticsUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Shelves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Furnitures",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6513), 1 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6514), 2 });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6516), 3 });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6862), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6863), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6864), 3 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6902), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6903), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6905), 3 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6923), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6925), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6927), 3 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6936), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6937), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6939), 3 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6949), 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6951), 2 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6952), 3 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6603), 1 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6697), 2 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6699), 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6454), 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6456), 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6457), 3 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6559), 1 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6560), 2 });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(6562), 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 20, 788, DateTimeKind.Utc).AddTicks(9860), "$2a$11$bSHpQYsLT82itvYQyQezBO4TPuwcUm4QRTeFSE6Xgm.XFy03rTYUy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 20, 960, DateTimeKind.Utc).AddTicks(4517), "$2a$11$go5GdsB1tXQ1ZwElav35xuquF0Y8nonWXjuOHe5eVhBxW2akFOMQe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 23, 10, 18, 21, 121, DateTimeKind.Utc).AddTicks(5635), "$2a$11$qNR3PwIJfbMh5Z9V/6qINutWms70I7TFfwk3Nsg0dpPITBj14.7nm" });

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_UserId",
                table: "Shelves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UserId",
                table: "Positions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_UserId",
                table: "Furnitures",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Users_UserId",
                table: "Furnitures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UserId",
                table: "Positions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Users_UserId",
                table: "Shelves",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Users_UserId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UserId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Users_UserId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_UserId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Positions_UserId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_UserId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Furnitures");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 42, DateTimeKind.Utc).AddTicks(9232), "$2a$11$Rl27r4Rwfmg4o9.RrT78MuhEpku/8mZ2ZFXhazCbV9YNvo6PuGqOq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 225, DateTimeKind.Utc).AddTicks(1080), "$2a$11$VA.C912a7xUsKVgDoKSfy.tQbx2yQC27Ru2uFDig5sFWeacIZmtCa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(3605), "$2a$11$jcNgyE6dX/YXOYXiKQgfwOILc96iZP4xXNkMh5cLrwLl02sJFev4i" });
        }
    }
}
