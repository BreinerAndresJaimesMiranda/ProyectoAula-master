using System;
using Entity;
using OfertaLaboralModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace EmpresaModel.Model
{
    public class EmpresaInputModel
    {
        public string Correo{get;set;}
        public string Contrasenia{get;set;}
        public string TipoServicio{get;set;}
        public string Nombre{get;set;}
        public string Nit{get;set;}
    }

    public class EmpresaViewModel
    {

        public string Correo{get;set;}
        public string Contrasenia{get;set;}
        public string TipoServicio{get;set;}
        public string Nombre{get;set;}
        public string Nit{get;set;}
        public List<InformacionOfertaLaboralViewModel> OfertasLaborales{get;set;}


        public EmpresaViewModel(Empresa empresa)
        {
            Correo=empresa.Correo;
            Contrasenia=empresa.Contrasenia;
            TipoServicio=empresa.TipoServicio;
            Nombre=empresa.Nombre;
            Nit=empresa.Nit;
            OfertasLaborales=empresa.OfertasLaborales.Select(p=>new InformacionOfertaLaboralViewModel(p)).ToList();
        }
    }

    public class InformacionEmpresaViewModel
    {

        public string Correo{get;set;}
        public string Contrasenia{get;set;}
        public string TipoServicio{get;set;}
        public string Nombre{get;set;}
        public string Nit{get;set;}


        public InformacionEmpresaViewModel(Empresa empresa)
        {

            Correo=empresa.Correo;
            Contrasenia=empresa.Contrasenia;
            TipoServicio=empresa.TipoServicio;
            Nombre=empresa.Nombre;
            Nit=empresa.Nit;
        }
    }
}
