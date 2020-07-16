using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperTest.Migrations
{
    public partial class CustomerFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name", "Type" },
                values: new object[] { 1, "Deloitte", "Large" });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 7, 16, 0, 38, 48, 909, DateTimeKind.Local).AddTicks(4853));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 7, 15, 22, 30, 42, 722, DateTimeKind.Local).AddTicks(9023));
        }
    }
}
