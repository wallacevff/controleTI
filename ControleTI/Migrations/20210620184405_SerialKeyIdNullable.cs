using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class SerialKeyIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_TipoDispositivoId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_Usuario_UsuarioId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_DispositivoSoftware_SerialKey_SerialKeyId",
                table: "DispositivoSoftware");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Dispositivo");

            migrationBuilder.AlterColumn<int>(
                name: "SerialKeyId",
                table: "DispositivoSoftware",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Dispositivo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoDispositivoId",
                table: "Dispositivo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_TipoDispositivoId",
                table: "Dispositivo",
                column: "TipoDispositivoId",
                principalTable: "TipoDispositivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_Usuario_UsuarioId",
                table: "Dispositivo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DispositivoSoftware_SerialKey_SerialKeyId",
                table: "DispositivoSoftware",
                column: "SerialKeyId",
                principalTable: "SerialKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_TipoDispositivoId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_Usuario_UsuarioId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_DispositivoSoftware_SerialKey_SerialKeyId",
                table: "DispositivoSoftware");

            migrationBuilder.AlterColumn<int>(
                name: "SerialKeyId",
                table: "DispositivoSoftware",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Dispositivo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TipoDispositivoId",
                table: "Dispositivo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
                table: "Dispositivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Dispositivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_TipoDispositivo_TipoDispositivoId",
                table: "Dispositivo",
                column: "TipoDispositivoId",
                principalTable: "TipoDispositivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_Usuario_UsuarioId",
                table: "Dispositivo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DispositivoSoftware_SerialKey_SerialKeyId",
                table: "DispositivoSoftware",
                column: "SerialKeyId",
                principalTable: "SerialKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
