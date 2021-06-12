using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class DatoAcademico
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DatoAcademicoId { get; set;}
        public string NombreCentroAcademico{get; set; }
        public string NivelEducativo{get; set; }
        public string AreaEstudio{ get; set; }
        public string EstadoCurso{get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
        public int HojaDeVidaId { get; set; }
        public HojaDeVida HojaDeVida{get; set; }
    }
}
