using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class webappsrvDB : Migration
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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilialId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
                table: "Dispositivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDispositivoId",
                table: "Dispositivo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoDispositivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDispositivo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_tipoDispositivoId",
                table: "Dispositivo",
                column: "tipoDispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_tipoDispositivoId",
                table: "Dispositivo",
                column: "tipoDispositivoId",
                principalTable: "TipoDispositivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_tipoDispositivoId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Filial_FilialId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Setor_SetorId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoDispositivo");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivo_tipoDispositivoId",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "tipoDispositivoId",
                table: "Dispositivo");

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
    }
}
