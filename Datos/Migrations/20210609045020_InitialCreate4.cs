using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfertasLaborales",
                columns: table => new
                {
                    OfertaLaboralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaNit = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasLaborales", x => x.OfertaLaboralId);
                    table.ForeignKey(
                        name: "FK_OfertasLaborales_Empresas_EmpresaNit",
                        column: x => x.EmpresaNit,
                        principalTable: "Empresas",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertasLaborales_EmpresaNit",
                table: "OfertasLaborales",
                column: "EmpresaNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertasLaborales");
        }
    }
}
