using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class ElementLocationAddId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ElementsLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ElementsLocations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 492, DateTimeKind.Utc).AddTicks(9168), "$2a$11$h9/FuPDuHQ.Vp38vaMtoX.ml5Zp7gmV1a1DSXBp5n9cSdS7rPijai" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 670, DateTimeKind.Utc).AddTicks(6680), "$2a$11$z9Wwan6wvahlifjzAEnqv.6uVnDoWGs2UG0znw2F6SbgmwUz7NXCu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 28, 854, DateTimeKind.Utc).AddTicks(6266), "$2a$11$fZM5eA7sEp8LVsHq/xngw.asq/KLx2.dJOHrlHTNCCQxyhtWjjcbq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 29, 46, DateTimeKind.Utc).AddTicks(7216), "$2a$11$28fFidvCG7vcvPThQYleSeyiLlM03uxMABths2ogy9NR0wk89p7.e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 20, 13, 56, 29, 210, DateTimeKind.Utc).AddTicks(8190), "$2a$11$DW/EuAKm95kEpkQJpMwfS.ZOrguuww4OY.ffruGpCp.2t.YF8nA7y" });
        }
    }
}
