using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LootManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class InfoSheets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InfoSheetId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoSheetId",
                table: "Elements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InfoSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiArticle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSheets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 1,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 2,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 3,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 4,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 5,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 6,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 7,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 8,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 9,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 10,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 11,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 12,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 13,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 14,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: 15,
                column: "InfoSheetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "InfoSheetId", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 531, DateTimeKind.Utc).AddTicks(6514), null, "$2a$11$50u5L.41jSCBiYFVawOsKOhA1KaZlFRnbOKi.yMM3tzot/tNovKmq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "InfoSheetId", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 726, DateTimeKind.Utc).AddTicks(3309), null, "$2a$11$5jOjJcKvB.xzp38fimC6GOZwnN2SRcuwT.9MDxQe14PhdhyD8XwGO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "InfoSheetId", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 34, 906, DateTimeKind.Utc).AddTicks(8303), null, "$2a$11$Q4gBCIfASpj4Igk7WNrI8uwNgLg.3O1Xn/fOU1tVdFRq3s0XXQoJu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "InfoSheetId", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 35, 95, DateTimeKind.Utc).AddTicks(7100), null, "$2a$11$ck0ZFbyq5j5sTFnGgUELPOT.rYttDCCIe0Gp.e9/77QPmIhca6Biu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "InfoSheetId", "PasswordHash" },
                values: new object[] { new DateTime(2023, 4, 7, 15, 43, 35, 307, DateTimeKind.Utc).AddTicks(5433), "user5@loot.com", null, "$2a$11$ebRVV8seLg9cTUuua54Vku/JZhENUCGZy5uvI8sUJZ.MpB80EDeby" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InfoSheetId",
                table: "Users",
                column: "InfoSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_InfoSheetId",
                table: "Elements",
                column: "InfoSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_InfoSheets_InfoSheetId",
                table: "Elements",
                column: "InfoSheetId",
                principalTable: "InfoSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId",
                table: "Users",
                column: "InfoSheetId",
                principalTable: "InfoSheets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_InfoSheets_InfoSheetId",
                table: "Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_InfoSheets_InfoSheetId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "InfoSheets");

            migrationBuilder.DropIndex(
                name: "IX_Users_InfoSheetId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Elements_InfoSheetId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "InfoSheetId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InfoSheetId",
                table: "Elements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 30, 21, 23, 30, 371, DateTimeKind.Utc).AddTicks(2152), "$2a$11$e1bjul77PytOwoxwx/.CxOIReTxEsOWx5LyT2ff0if8O8p4bUWSD6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 30, 21, 23, 30, 549, DateTimeKind.Utc).AddTicks(5876), "$2a$11$ZVQsXweagD/OfVscFFtJS.csoW.k42MXNWhjFFsFLoILFTX8GzS3K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 30, 21, 23, 30, 714, DateTimeKind.Utc).AddTicks(8780), "$2a$11$av5Qnmr/UCYEnfU4ghTzY.tPztboyyJ4YLIiGToFhVo4AmRg2rCnq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 30, 21, 23, 30, 878, DateTimeKind.Utc).AddTicks(8304), "$2a$11$uOuXWNuf2RNBPbg0ee.7z.IHGU9rLcO79VJmZLwMi8XQ83iy9y.Ey" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 30, 21, 23, 31, 48, DateTimeKind.Utc).AddTicks(733), "user5", "$2a$11$EBzaVUZRf8vGB2FwGaGnAOLaay.M/0vIoxHUJKtUeQxodjrjF.doO" });
        }
    }
}
