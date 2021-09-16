using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class Status_Relacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Dispositivo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_StatusId",
                table: "Dispositivo",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_Status_StatusId",
                table: "Dispositivo",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_Status_StatusId",
                table: "Dispositivo");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivo_StatusId",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Dispositivo");
        }
    }
}
