using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Identity02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaSistema");

            migrationBuilder.DropColumn(
                name: "Sistema",
                table: "Maquina");

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
                name: "IX_TipoSistema_MaquinaId",
                table: "TipoSistema",
                column: "MaquinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoSistema");

            migrationBuilder.AddColumn<int>(
                name: "Sistema",
                table: "Maquina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ListaSistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeSistema = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroSistema = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaSistema", x => x.Id);
                });
        }
    }
}
