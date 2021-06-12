using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using OfertaLaboralModel.Model;
using AspiranteModel.Model;



namespace PostulacionModel.Model
{
    public class PostulacionInputModel
    { 
        public string AspiranteId{get;set;}
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
