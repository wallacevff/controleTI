using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTI.Migrations
{
    public partial class softkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Dispositivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DispositivoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Software_Dispositivo_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SerialKey",
                columns: table => new
                {
                    SoftwareId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialKey", x => new { x.SoftwareId, x.Key });
                    table.UniqueConstraint("AK_SerialKey_Key_SoftwareId", x => new { x.Key, x.SoftwareId });
                    table.ForeignKey(
                        name: "FK_SerialKey_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Software_DispositivoId",
                table: "Software",
                column: "DispositivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialKey");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Dispositivo");
        }
    }
}
