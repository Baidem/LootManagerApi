using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class ElementModif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationAddress",
                table: "Elements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 0, 36, 557, DateTimeKind.Utc).AddTicks(7735), "$2a$11$ZpArvqIefWH5rn63DLe6G.kAXrcHD/lWDUsSaYgul8DTv6YVUzFW6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 0, 36, 721, DateTimeKind.Utc).AddTicks(9763), "$2a$11$dYpVb6AHVReh9E.Y/gdKU.8A7ZIy5kVUJWbR3u/XzQ9ZgJ7/kZLHK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 0, 36, 891, DateTimeKind.Utc).AddTicks(2225), "$2a$11$jvR0jChKOz2ezwkZpYfo8.SU9LOZSvJUS20/8wgw9pyXTH//s71qa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 0, 37, 82, DateTimeKind.Utc).AddTicks(732), "$2a$11$sGpQFmZSiUdE/IuqUwOpWeQgkt66D6Pt25W4Hp3BKdKoBMupQ3/n2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 0, 37, 258, DateTimeKind.Utc).AddTicks(3621), "$2a$11$FZ.Txoy9Cuu.6XRyR3gZPOn/F36lo86wcYU9l8ZgvY8/wk37JY9jq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationAddress",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocationAddress",
                value: "Location undifined");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocationAddress",
                value: "Location undifined");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocationAddress",
                value: "Location undifined");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocationAddress",
                value: "Location undifined");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocationAddress",
                value: "Location undifined");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 13, 10, 800, DateTimeKind.Utc).AddTicks(7590), "$2a$11$0faHZcIDiHhlPm1UX9KCnez07WWJJKJzfaJbYnA4AL67MjFA37reS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 13, 10, 990, DateTimeKind.Utc).AddTicks(198), "$2a$11$c8SYrEgCr09GR.tmNXMxxOMnPIy0Di5m2YE..y0JqIOWCe/cOLAsi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 13, 11, 156, DateTimeKind.Utc).AddTicks(8831), "$2a$11$CXnjVCIcdJy4k0ovEBsjbOEVWe1TZMef7/Zd5sDN6lZgp7OgbN4Um" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 13, 11, 324, DateTimeKind.Utc).AddTicks(8691), "$2a$11$qhXGoQ9JdQKU.uQCkCodPuV5AaCkrcsZhjvje8TpQhNUeItY0ibEe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 13, 11, 482, DateTimeKind.Utc).AddTicks(3342), "$2a$11$Yg5Pg4S48d9yj49T8LlIFOReMOCMbqPabR/7Q0yswjUeJzBR8YSFi" });
        }
    }
}
