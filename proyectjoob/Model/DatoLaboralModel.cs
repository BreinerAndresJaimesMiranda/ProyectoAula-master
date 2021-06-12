using System;
using Entity;
using HojaDeVidaModel.Model;

namespace DatoLaboralModel.Model
{
public class DatoLaboralInputModel
    {
        public int DatoLaboralId{get;set;}
        public string NombreEmpresa { get; set; }
        public string Cargo{get;set; }
        public string Area { get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
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
