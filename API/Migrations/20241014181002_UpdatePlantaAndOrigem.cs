using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlantaAndOrigem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Origens_OrigemIdOrigem",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "IdOrigem",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "IdPlanta",
                table: "Origens");

            migrationBuilder.RenameColumn(
                name: "OrigemIdOrigem",
                table: "Plantas",
                newName: "OrigemId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantas_OrigemIdOrigem",
                table: "Plantas",
                newName: "IX_Plantas_OrigemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Origens_OrigemId",
                table: "Plantas",
                column: "OrigemId",
                principalTable: "Origens",
                principalColumn: "IdOrigem",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Origens_OrigemId",
                table: "Plantas");

            migrationBuilder.RenameColumn(
                name: "OrigemId",
                table: "Plantas",
                newName: "OrigemIdOrigem");

            migrationBuilder.RenameIndex(
                name: "IX_Plantas_OrigemId",
                table: "Plantas",
                newName: "IX_Plantas_OrigemIdOrigem");

            migrationBuilder.AddColumn<int>(
                name: "IdOrigem",
                table: "Plantas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPlanta",
                table: "Origens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Origens_OrigemIdOrigem",
                table: "Plantas",
                column: "OrigemIdOrigem",
                principalTable: "Origens",
                principalColumn: "IdOrigem",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
