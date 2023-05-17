using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlineAuctionMarketing.Migrations
{
    public partial class ola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionEndsTime",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "NumberOfBidder",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "TimeLeft",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 5, 12, 19, 31, 899, DateTimeKind.Local).AddTicks(6545), new DateTime(2023, 5, 5, 12, 19, 31, 899, DateTimeKind.Local).AddTicks(6555), "$2b$10$SXzeZXjrtJU.cdWSdbUNYuj/LkDgiBu18jPp6O.mYem7PzDGDkZZC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuctionEndsTime",
                table: "Bids",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Bids",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBidder",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Bids",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeLeft",
                table: "Bids",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 5, 9, 10, 23, 670, DateTimeKind.Local).AddTicks(9259), new DateTime(2023, 5, 5, 9, 10, 23, 670, DateTimeKind.Local).AddTicks(9272), "$2b$10$vT8YhJxeoJzT5Ad5BayB0uxvWeHLJsfVhI4Ni0C3c6j69z0MuX0PO" });
        }
    }
}
