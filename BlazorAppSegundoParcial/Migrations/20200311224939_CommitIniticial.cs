using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAppSegundoParcial.Migrations
{
    public partial class CommitIniticial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    LlamadasId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.LlamadasId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadasDetalle",
                columns: table => new
                {
                    LlamadaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LlamadaId = table.Column<int>(nullable: false),
                    Problema = table.Column<string>(nullable: true),
                    solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadasDetalle", x => x.LlamadaDetalleId);
                    table.ForeignKey(
                        name: "FK_LlamadasDetalle_Llamadas_LlamadaId",
                        column: x => x.LlamadaId,
                        principalTable: "Llamadas",
                        principalColumn: "LlamadasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadasDetalle_LlamadaId",
                table: "LlamadasDetalle",
                column: "LlamadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadasDetalle");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
