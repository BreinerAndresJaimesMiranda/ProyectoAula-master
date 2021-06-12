using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Postulacion
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostulacionId{get;set;}
        public Aspirante Aspirante{get;set;}
        public OfertaLaboral OfertaLaboral{get;set;}

    }
}
