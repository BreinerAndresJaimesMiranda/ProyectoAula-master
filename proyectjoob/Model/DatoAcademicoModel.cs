using System;
using System.ComponentModel.DataAnnotations;
using Entity;
using HojaDeVidaModel.Model;

namespace DatoAcademicoModel.Model
{
    public class DatoAcademicoInputModel
    {
        public int DatoAcademicoId{get;set;}

        [Required(ErrorMessage = "El nombre del centro academico es requerido")]
        public string NombreCentroAcademico{get; set; }

        [Required(ErrorMessage = "El nivel educativo es requerido")]
        public string NivelEducativo{get; set; }

        [Required(ErrorMessage = "El area de estudio es requerida")]
        public string AreaEstudio{get; set; }

        [Required(ErrorMessage = "El estado del curso es requerido")]
        public string EstadoCurso{get; set; }

        [Required(ErrorMessage = "La fecha de inicio del curso es requerida")]
        public DateTime FechaInicio{get; set; }

        [Required(ErrorMessage = "La fecha de finalizacion del curso es requerida")]
        public DateTime FechaFinalizacion{get; set; }

        [Required(ErrorMessage = "El id del aspirante es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
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
