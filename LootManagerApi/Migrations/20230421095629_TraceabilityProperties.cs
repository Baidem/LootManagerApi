using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class TraceabilityProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Shelves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Shelves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Positions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Houses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Furnitures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Furnitures",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4601), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4603), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4604), null });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4435), null });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4437), null });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4439), null });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4771), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4773), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4774), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4820), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4821), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4822), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4843), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4844), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4846), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4859), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4861), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4862), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4874), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4875), null });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4877), null });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4715), null });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4717), null });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4718), null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4537), null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4539), null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4540), null });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4662), null });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4664), null });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 21, 9, 56, 29, 405, DateTimeKind.Utc).AddTicks(4665), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Furnitures");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "InfoSheets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 20, 11, 2, 54, 691, DateTimeKind.Utc).AddTicks(4666), "$2a$11$vikp0zo5YmKA3TSRhd.9ue4PMdMWXQ5mFn8jfYTNIS4r1slEk9J7e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 20, 11, 2, 54, 866, DateTimeKind.Utc).AddTicks(1730), "$2a$11$tc3kJ3uefMXhNN1cnfil3.uSwD/nbtkLux2XmxuPhXtRQ0H1BhVCm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 20, 11, 2, 55, 50, DateTimeKind.Utc).AddTicks(7027), "$2a$11$WabHDdpvtCr1/7OKVH89AOQbl8pWA/5azQj7FmIaGBzlIMIGH6MvG" });
        }
    }
}
