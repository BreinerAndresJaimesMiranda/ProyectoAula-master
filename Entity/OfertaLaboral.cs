using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class OfertaLaboral
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaLaboralId{get;set;}
        public string Descripcion{get;set;}
        public int Salario{get;set;}
        public string Cargo{get;set;}
        public string Horario{get;set;}
        public Empresa Empresa{get;set;}

        public List<Postulacion> Postulaciones{get;set;}
    }
}
