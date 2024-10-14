using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrigemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrigem",
                table: "Plantas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrigemIdOrigem",
                table: "Plantas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Origens",
                columns: table => new
                {
                    IdOrigem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(type: "TEXT", nullable: true),
                    IdPlanta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origens", x => x.IdOrigem);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_OrigemIdOrigem",
                table: "Plantas",
                column: "OrigemIdOrigem");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Origens_OrigemIdOrigem",
                table: "Plantas",
                column: "OrigemIdOrigem",
                principalTable: "Origens",
                principalColumn: "IdOrigem",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Origens_OrigemIdOrigem",
                table: "Plantas");

            migrationBuilder.DropTable(
                name: "Origens");

            migrationBuilder.DropIndex(
                name: "IX_Plantas_OrigemIdOrigem",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "IdOrigem",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "OrigemIdOrigem",
                table: "Plantas");
        }
    }
}
