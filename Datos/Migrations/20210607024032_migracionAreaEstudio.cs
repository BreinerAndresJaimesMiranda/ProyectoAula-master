using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class migracionAreaEstudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaEstudio",
                table: "DatosAcademicos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaEstudio",
                table: "DatosAcademicos");
        }
    }
}
