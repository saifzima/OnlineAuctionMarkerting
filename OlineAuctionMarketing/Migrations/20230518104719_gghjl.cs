using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlineAuctionMarketing.Migrations
{
    public partial class gghjl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password", "ProfilePicture", "UserName" },
                values: new object[] { new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3313), new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3330), "$2b$10$rVqWBhJneyf3Bxx1dqxcnOVkXdV9Mm3OWfrLw7oD2HJTBugJe.lgi", "logo.jpg", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 17, 21, 55, 46, 277, DateTimeKind.Local).AddTicks(8467), new DateTime(2023, 5, 17, 21, 55, 46, 277, DateTimeKind.Local).AddTicks(8482), "$2b$10$EUnP4HygiCL5KOnpZ7fYKuxUP36PS4Uu.OrxwOBn2gEN8BbMxX6Xi" });
        }
    }
}
