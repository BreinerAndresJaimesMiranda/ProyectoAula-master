using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aspirantes",
                columns: table => new
                {
                    Correo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    HorarioTrabajoPreferido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioTrabajoPreferido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirantes", x => x.Correo);
                });

            migrationBuilder.CreateTable(
                name: "HojasDeVida",
                columns: table => new
                {
                    HojaDeVidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspiranteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionPerfilLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojasDeVida", x => x.HojaDeVidaId);
                    table.ForeignKey(
                        name: "FK_HojasDeVida_Aspirantes_AspiranteId",
                        column: x => x.AspiranteId,
                        principalTable: "Aspirantes",
                        principalColumn: "Correo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatosAcademicos",
                columns: table => new
                {
                    DatoAcademicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCentroAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelEducativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HojaDeVidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosAcademicos", x => x.DatoAcademicoId);
                    table.ForeignKey(
                        name: "FK_DatosAcademicos_HojasDeVida_HojaDeVidaId",
                        column: x => x.HojaDeVidaId,
                        principalTable: "HojasDeVida",
                        principalColumn: "HojaDeVidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosLaborales",
                columns: table => new
                {
                    DatoLaboralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HojaDeVidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosLaborales", x => x.DatoLaboralId);
                    table.ForeignKey(
                        name: "FK_DatosLaborales_HojasDeVida_HojaDeVidaId",
                        column: x => x.HojaDeVidaId,
                        principalTable: "HojasDeVida",
                        principalColumn: "HojaDeVidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosAcademicos_HojaDeVidaId",
                table: "DatosAcademicos",
                column: "HojaDeVidaId");

            migrationBuilder.CreateIndex(
                name: "IX_DatosLaborales_HojaDeVidaId",
                table: "DatosLaborales",
                column: "HojaDeVidaId");

            migrationBuilder.CreateIndex(
                name: "IX_HojasDeVida_AspiranteId",
                table: "HojasDeVida",
                column: "AspiranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosAcademicos");

            migrationBuilder.DropTable(
                name: "DatosLaborales");

            migrationBuilder.DropTable(
                name: "HojasDeVida");

            migrationBuilder.DropTable(
                name: "Aspirantes");
        }
    }
}
