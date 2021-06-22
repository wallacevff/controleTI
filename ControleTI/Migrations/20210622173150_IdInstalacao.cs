using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class IdInstalacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInstalacao",
                table: "SerialKey");

            migrationBuilder.AddColumn<string>(
                name: "IdInstalacao",
                table: "DispositivoSoftware",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInstalacao",
                table: "DispositivoSoftware");

            migrationBuilder.AddColumn<string>(
                name: "IdInstalacao",
                table: "SerialKey",
                nullable: true);
        }
    }
}
