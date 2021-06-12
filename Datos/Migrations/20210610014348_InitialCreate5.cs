using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postulaciones",
                columns: table => new
                {
                    PostulacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspiranteCorreo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OfertaLaboralId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulaciones", x => x.PostulacionId);
                    table.ForeignKey(
                        name: "FK_Postulaciones_Aspirantes_AspiranteCorreo",
                        column: x => x.AspiranteCorreo,
                        principalTable: "Aspirantes",
                        principalColumn: "Correo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Postulaciones_OfertasLaborales_OfertaLaboralId",
                        column: x => x.OfertaLaboralId,
                        principalTable: "OfertasLaborales",
                        principalColumn: "OfertaLaboralId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_AspiranteCorreo",
                table: "Postulaciones",
                column: "AspiranteCorreo");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_OfertaLaboralId",
                table: "Postulaciones",
                column: "OfertaLaboralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postulaciones");
        }
    }
}
