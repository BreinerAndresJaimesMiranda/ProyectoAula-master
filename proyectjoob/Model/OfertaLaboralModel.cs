using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using EmpresaModel.Model;
using PostulacionModel.Model;


namespace OfertaLaboralModel.Model
{
    public class OfertaLaboralInputModel
    { 
        public int OfertaLaboralId{get;set;}
        public string Descripcion{get;set;}
        public int Salario{get;set;}
        public string Cargo{get;set;}
        public string Horario{get;set;}
        public string CorreoEmpresa{ get; set; }
        
    }

    public class OfertaLaboralViewModel
    {
        public int OfertaLaboralId{get;set;}
        public string Descripcion{get;set;}
        public int Salario{get;set;}
        public string Cargo{get;set;}
        public string Horario{get;set;}
        public InformacionEmpresaViewModel Empresa{get;set;}
        public List<InformacionPostulacionViewModel> Postulaciones{get;set;}
        
        public OfertaLaboralViewModel(OfertaLaboral ofertaLaboral)
        {
        OfertaLaboralId=ofertaLaboral.OfertaLaboralId;
        Descripcion=ofertaLaboral.Descripcion;
        Salario=ofertaLaboral.Salario;
        Cargo=ofertaLaboral.Cargo;
        Horario=ofertaLaboral.Horario;
        Empresa=new InformacionEmpresaViewModel(ofertaLaboral.Empresa);
        Postulaciones=ofertaLaboral.Postulaciones.Select(p=>new InformacionPostulacionViewModel(p)).ToList();
        }
    }

    public class InformacionOfertaLaboralViewModel
    {
        public int OfertaLaboralId{get;set;}
        public string Descripcion{get;set;}
        public int Salario{get;set;}
        public string Cargo{get;set;}
        public string Horario{get;set;}


        public InformacionOfertaLaboralViewModel(OfertaLaboral ofertaLaboral)
        {
        OfertaLaboralId=ofertaLaboral.OfertaLaboralId;
        Descripcion=ofertaLaboral.Descripcion;
        Salario=ofertaLaboral.Salario;
        Cargo=ofertaLaboral.Cargo;
        Horario=ofertaLaboral.Horario;
        }
    }

}