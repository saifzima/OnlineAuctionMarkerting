using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlineAuctionMarketing.Migrations
{
    public partial class thenwewdat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 19, 10, 0, 8, 134, DateTimeKind.Local).AddTicks(7129), new DateTime(2023, 5, 19, 10, 0, 8, 134, DateTimeKind.Local).AddTicks(7140), "$2b$10$WzP4MDUnjgqUU5z44cGrTOVIbvgi5NYfYpFfyh/4u4oTqxgQ0kpSK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3313), new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3330), "$2b$10$rVqWBhJneyf3Bxx1dqxcnOVkXdV9Mm3OWfrLw7oD2HJTBugJe.lgi" });
        }
    }
}
