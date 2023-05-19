using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlineAuctionMarketing.Migrations
{
    public partial class gghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 17, 21, 55, 46, 277, DateTimeKind.Local).AddTicks(8467), new DateTime(2023, 5, 17, 21, 55, 46, 277, DateTimeKind.Local).AddTicks(8482), "$2b$10$EUnP4HygiCL5KOnpZ7fYKuxUP36PS4Uu.OrxwOBn2gEN8BbMxX6Xi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 5, 12, 19, 31, 899, DateTimeKind.Local).AddTicks(6545), new DateTime(2023, 5, 5, 12, 19, 31, 899, DateTimeKind.Local).AddTicks(6555), "$2b$10$SXzeZXjrtJU.cdWSdbUNYuj/LkDgiBu18jPp6O.mYem7PzDGDkZZC" });
        }
    }
}
