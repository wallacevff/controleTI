using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class Hardware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hd",
                table: "Dispositivo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memoria",
                table: "Dispositivo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processador",
                table: "Dispositivo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hd",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "Memoria",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "Processador",
                table: "Dispositivo");
        }
    }
}
