using System;
using Entity;
using OfertaLaboralModel.Model;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace EmpresaModel.Model
{
    public class EmpresaInputModel
    {
        [Required(ErrorMessage = "El Correo es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
        public string Correo{get;set;}

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia{get;set;}

        [Required(ErrorMessage = "El tipo de servicio es requerido")]
        public string TipoServicio{get;set;}

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre{get;set;}

        [Required(ErrorMessage = "El nit es requerido")]
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
