using System;
using Entity;
using System.ComponentModel.DataAnnotations;
using HojaDeVidaModel.Model;

namespace DatoLaboralModel.Model
{
public class DatoLaboralInputModel
    {
        public int DatoLaboralId{get;set;}

        [Required(ErrorMessage = "El nombre de la empresa es requerido")]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "El cargo es requerido")]
        public string Cargo{get;set; }

        [Required(ErrorMessage = "El area es requerida")]
        public string Area { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio{get; set; }

        [Required(ErrorMessage = "La fecha de finalizacion es requerida")]
        public DateTime FechaFinalizacion{get; set; }

        [Required(ErrorMessage = "El id del aspirante es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
        public string AspiranteId{get; set; }
    }

    public class DatoLaboralViewModel
    {
        public int DatoLaboralId{get;set;}
        public string NombreEmpresa { get; set; }
        public string Cargo{get;set; }
        public string Area { get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
        public InformacionHojaDeVidaViewModel HojaDeVida{get; set; }

        public DatoLaboralViewModel(DatoLaboral datoLaboral)
        {
        DatoLaboralId=datoLaboral.DatoLaboralId;
        NombreEmpresa=datoLaboral.NombreEmpresa;
        Cargo=datoLaboral.Cargo;
        Area=datoLaboral.Area;
        FechaInicio=datoLaboral.FechaInicio;
        FechaFinalizacion=datoLaboral.FechaFinalizacion;
        HojaDeVida=new InformacionHojaDeVidaViewModel(datoLaboral.HojaDeVida);
        }
    }

    public class InformacionDatoLaboralViewModel
    {
        public int DatoLaboralId{get;set;}
        public string NombreEmpresa { get; set; }
        public string Cargo{get;set; }
        public string Area { get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }

        public InformacionDatoLaboralViewModel(DatoLaboral datoLaboral)
        {
        DatoLaboralId=datoLaboral.DatoLaboralId;
        NombreEmpresa=datoLaboral.NombreEmpresa;
        Cargo=datoLaboral.Cargo;
        Area=datoLaboral.Area;
        FechaInicio=datoLaboral.FechaInicio;
        FechaFinalizacion=datoLaboral.FechaFinalizacion;
        }
    }



    
}
