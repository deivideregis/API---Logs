using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Identity : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Log_MaquinaId",
                table: "Log",
                column: "MaquinaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Maquina");
        }
    }
}
