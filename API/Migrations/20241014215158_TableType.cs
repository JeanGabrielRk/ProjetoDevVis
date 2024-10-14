using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class TableType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Plantas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoId1",
                table: "Plantas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CrriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoId",
                table: "Plantas",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoId1",
                table: "Plantas",
                column: "TipoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Tipo_TipoId",
                table: "Plantas",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Tipo_TipoId1",
                table: "Plantas",
                column: "TipoId1",
                principalTable: "Tipo",
                principalColumn: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Tipo_TipoId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Tipo_TipoId1",
                table: "Plantas");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_TipoId",
                table: "Plantas");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_TipoId1",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "TipoId1",
                table: "Plantas");
        }
    }
}
