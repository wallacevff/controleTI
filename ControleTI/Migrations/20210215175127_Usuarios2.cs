using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class Usuarios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Filial_FilialId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Setor_SetorId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilialId",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Filial_FilialId",
                table: "Usuario",
                column: "FilialId",
                principalTable: "Filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Setor_SetorId",
                table: "Usuario",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Filial_FilialId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Setor_SetorId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilialId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Filial_FilialId",
                table: "Usuario",
                column: "FilialId",
                principalTable: "Filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Setor_SetorId",
                table: "Usuario",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
