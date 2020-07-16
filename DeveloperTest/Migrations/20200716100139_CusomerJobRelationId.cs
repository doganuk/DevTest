using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperTest.Migrations
{
    public partial class CusomerJobRelationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 7, 16, 11, 1, 39, 68, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2020, 7, 16, 0, 38, 48, 909, DateTimeKind.Local).AddTicks(4853));
        }
    }
}
