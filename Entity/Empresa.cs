using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Empresa
    {
        [Key]
        public string Nit {get;set; }
        public string Correo {get;set; }
        public string Nombre {get;set; }
        public string Contrasenia {get;set; }
        public string TipoServicio {get;set; }
        public List<OfertaLaboral> OfertasLaborales{get; set; }
    }
}
