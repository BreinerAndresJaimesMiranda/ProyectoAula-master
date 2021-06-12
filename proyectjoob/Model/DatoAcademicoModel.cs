using System;
using Entity;
using HojaDeVidaModel.Model;

namespace DatoAcademicoModel.Model
{
    public class DatoAcademicoInputModel
    {
        public int DatoAcademicoId{get;set;}
        public string NombreCentroAcademico{get; set; }
        public string NivelEducativo{get; set; }
        public string AreaEstudio{get; set; }
        public string EstadoCurso{get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
        public string AspiranteId{get; set;}
    }

    public class DatoAcademicoViewModel
    {
        public int DatoAcademicoId{get;set;}
        public string NombreCentroAcademico{get; set; }
        public string NivelEducativo{get; set; }
        public string AreaEstudio{get; set; }
        public string EstadoCurso{get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }
        public InformacionHojaDeVidaViewModel HojaDeVida{get; set; }

        public DatoAcademicoViewModel(DatoAcademico datoAcademico)
        {
        DatoAcademicoId=datoAcademico.DatoAcademicoId;
        NombreCentroAcademico=datoAcademico.NombreCentroAcademico;
        NivelEducativo=datoAcademico.NivelEducativo;
        AreaEstudio=datoAcademico.AreaEstudio;
        EstadoCurso=datoAcademico.EstadoCurso;
        FechaInicio=datoAcademico.FechaInicio;
        FechaFinalizacion=datoAcademico.FechaFinalizacion;
        HojaDeVida=new InformacionHojaDeVidaViewModel(datoAcademico.HojaDeVida);
        }
    }

    public class InformacionDatoAcademicoViewModel
    {
        public int DatoAcademicoId{get;set;}
        public string NombreCentroAcademico{get; set; }
        public string NivelEducativo{get; set; }
        public string AreaEstudio{get; set; }
        public string EstadoCurso{get; set; }
        public DateTime FechaInicio{get; set; }
        public DateTime FechaFinalizacion{get; set; }

        public InformacionDatoAcademicoViewModel(DatoAcademico datoAcademico)
        {
        DatoAcademicoId=datoAcademico.DatoAcademicoId;
        NombreCentroAcademico=datoAcademico.NombreCentroAcademico;
        NivelEducativo=datoAcademico.NivelEducativo;
        AreaEstudio=datoAcademico.AreaEstudio;
        EstadoCurso=datoAcademico.EstadoCurso;
        FechaInicio=datoAcademico.FechaInicio;
        FechaFinalizacion=datoAcademico.FechaFinalizacion;
        }
    }
}
