using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Identity01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Log_MaquinaId",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "Sistema",
                table: "Maquina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ListaSistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroSistema = table.Column<string>(type: "varchar(3)", nullable: false),
                    NomeSistema = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaSistema", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_MaquinaId",
                table: "Log",
                column: "MaquinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaSistema");

            migrationBuilder.DropIndex(
                name: "IX_Log_MaquinaId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Sistema",
                table: "Maquina");

            migrationBuilder.CreateIndex(
                name: "IX_Log_MaquinaId",
                table: "Log",
                column: "MaquinaId",
                unique: true);
        }
    }
}
