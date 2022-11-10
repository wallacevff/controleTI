using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class UsuarioResponsavel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuRespId",
                table: "contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "contrato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contrato_UsuarioId",
                table: "contrato",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_usuario_UsuarioId",
                table: "contrato",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_usuario_UsuarioId",
                table: "contrato");

            migrationBuilder.DropIndex(
                name: "IX_contrato_UsuarioId",
                table: "contrato");

            migrationBuilder.DropColumn(
                name: "UsuRespId",
                table: "contrato");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "contrato");
        }
    }
}
