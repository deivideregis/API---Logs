using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeMaquina = table.Column<string>(type: "varchar(150)", nullable: false),
                    IP = table.Column<string>(type: "varchar(20)", nullable: false),
                    MAC = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaquinaId = table.Column<Guid>(nullable: false),
                    TipoLogs = table.Column<int>(nullable: false),
                    Detalhe = table.Column<string>(type: "varchar(500)", nullable: false),
                    Acao = table.Column<string>(type: "varchar(150)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoSistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaquinaId = table.Column<Guid>(nullable: false),
                    NumeroSistema = table.Column<string>(type: "varchar(3)", nullable: false),
                    NomeSistema = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSistema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoSistema_Maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_MaquinaId",
                table: "Log",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoSistema_MaquinaId",
                table: "TipoSistema",
                column: "MaquinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "TipoSistema");

            migrationBuilder.DropTable(
                name: "Maquina");
        }
    }
}
