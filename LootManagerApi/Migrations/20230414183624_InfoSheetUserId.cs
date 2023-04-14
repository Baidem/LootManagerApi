using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class InfoSheetUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InfoSheetId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "InfoSheetId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "InfoSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "InfoSheetId1", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 14, 18, 36, 23, 690, DateTimeKind.Utc).AddTicks(4166), null, "$2a$11$JqReHOoefJS/lnoqyW2LB.U2qerSJ3De8WkKJN8ytASEsP7A8hWxW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "InfoSheetId1", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 14, 18, 36, 23, 861, DateTimeKind.Utc).AddTicks(331), null, "$2a$11$pZB.ndraDFEk6EDhOVBSKO8BSgHK0M4LJhQOyIso7anBE.XV/seK6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "InfoSheetId1", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 14, 18, 36, 24, 33, DateTimeKind.Utc).AddTicks(71), null, "$2a$11$XETr0pY0faU1fib02jINZOKTu3poa9W/GGFxa3FsejKLHPD5XydEG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "InfoSheetId1", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 14, 18, 36, 24, 200, DateTimeKind.Utc).AddTicks(2709), null, "$2a$11$yOUJ9HufMp/yN1nrB1xnj.2ML8MbJwRJJzIMZeZwoUd9YiYm05N0G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "InfoSheetId1", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 14, 18, 36, 24, 367, DateTimeKind.Utc).AddTicks(5297), null, "$2a$11$2ayQnaiRxXCWfEVPee6zrObEhsR/L91hXlLiFVx14ptOsYKLleMvm" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InfoSheetId1",
                table: "Users",
                column: "InfoSheetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId1",
                table: "Users",
                column: "InfoSheetId1",
                principalTable: "InfoSheets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InfoSheetId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InfoSheetId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InfoSheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 12, 13, 41, 8, 877, DateTimeKind.Utc).AddTicks(9649), "$2a$11$z0NVRJKZnLPfmzptMzrkb.B7n1tSfI23XOu89cgGdLhVocesieMfq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 12, 13, 41, 9, 38, DateTimeKind.Utc).AddTicks(363), "$2a$11$u5gaD8Ud/B4/C29lc61hBeVGDGx3nOQxnnN49wIBu5wNuugDJx78u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 12, 13, 41, 9, 199, DateTimeKind.Utc).AddTicks(4330), "$2a$11$bYZ0l5JOsx.qnvxhlpcLo.FlM7M7COp1GxgUS5Z2wrXPHNANAZGxO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 12, 13, 41, 9, 374, DateTimeKind.Utc).AddTicks(5931), "$2a$11$ODU410tAR1ZoEio1CsRDb.pzKoHt31UhhBpiXOEx17bdgtyqwOaIq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 12, 13, 41, 9, 531, DateTimeKind.Utc).AddTicks(8937), "$2a$11$Prvzzkmc6uD34AmI.nLELuqRMVJmgjaBIdRb2DomQiOQxO0kAFjD." });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InfoSheetId",
                table: "Users",
                column: "InfoSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId",
                table: "Users",
                column: "InfoSheetId",
                principalTable: "InfoSheets",
                principalColumn: "Id");
        }
    }
}
