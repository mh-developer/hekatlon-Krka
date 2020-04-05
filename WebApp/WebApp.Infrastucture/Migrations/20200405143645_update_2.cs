using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Infrastructure.Migrations
{
    public partial class update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DeliveryPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "DeliveryPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DeliveryPoint");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DeliveryPoint");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Company");
        }
    }
}
