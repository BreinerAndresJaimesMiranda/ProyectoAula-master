using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using OfertaLaboralModel.Model;
using AspiranteModel.Model;
using System.ComponentModel.DataAnnotations;



namespace PostulacionModel.Model
{
    public class PostulacionInputModel
    { 
        [Required(ErrorMessage = "El id del aspirante requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
        public string AspiranteId{get;set;}

        [Required(ErrorMessage = "El id de la oferta laboral es requerido")]
        public int OfertaLaboralId{get;set;}
        
    }

    public class PostulacionViewModel
    {
        public int PostulacionId{get;set;}
        public InformacionOfertaLaboralViewModel OfertaLaboral{get;set;}
        public InformacionAspiranteViewModel Aspirante { get; set; }
        
        public PostulacionViewModel(Postulacion postulacion)
        {
        PostulacionId=postulacion.PostulacionId;
        Aspirante=new InformacionAspiranteViewModel(postulacion.Aspirante);
        OfertaLaboral= new InformacionOfertaLaboralViewModel(postulacion.OfertaLaboral);

        }
    }

    public class InformacionPostulacionViewModel
    {
        public int PostulacionId{get;set;}

        public InformacionPostulacionViewModel(Postulacion postulacion)
        {

        PostulacionId=postulacion.PostulacionId;
        
        }
    }

}
