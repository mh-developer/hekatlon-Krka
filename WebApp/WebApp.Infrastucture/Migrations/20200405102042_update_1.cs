using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Infrastructure.Migrations
{
    public partial class update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_WarehouseId",
                table: "User",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Warehouse_WarehouseId",
                table: "User",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Warehouse_WarehouseId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_WarehouseId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "User");
        }
    }
}
