using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity
{
    public class HojaDeVida
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HojaDeVidaId { get; set;}
        public string AspiranteId{ get; set;}
        public string Nombre { get; set; }
        public string DescripcionPerfilLaboral{ get; set;}
        public Aspirante Aspirante { get; set; }
        public List<DatoAcademico> DatosAcademicos{get; set; }
        public List<DatoLaboral> DatosLaborales{get; set; }
    }
}
