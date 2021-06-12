using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class DatoLaboral
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DatoLaboralId { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cargo{get;set; }
        public string Area { get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
        public int HojaDeVidaId { get;set;}
        public HojaDeVida HojaDeVida{get; set; }

    }
}
