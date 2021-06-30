using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DatoLaboralModel.Model;
using DatoAcademicoModel.Model;
using AspiranteModel.Model;


namespace HojaDeVidaModel.Model
{
    public class HojaDeVidaInputModel
    { 
        public int HojaDeVidaId { get; set;}

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre{ get; set; }

        [Required(ErrorMessage = "La descripcion laboral es requerida")]
        public string DescripcionPerfilLaboral{ get; set; }

        [Required(ErrorMessage = "El id del aspirante es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
        public string AspiranteId{ get; set; }
        
    }

    public class HojaDeVidaViewModel
    {
        public int HojaDeVidaId{ get; set; }
        public string Nombre{ get; set; }
        public string DescripcionPerfilLaboral{ get; set; }
        public InformacionAspiranteViewModel Aspirante { get; set; }
        public List<InformacionDatoAcademicoViewModel> DatosAcademicos{get; set; }
        public List<InformacionDatoLaboralViewModel> DatosLaborales{get; set; }
        
        public HojaDeVidaViewModel(HojaDeVida hojaDeVida)
        {
        Nombre=hojaDeVida.Nombre;
        DescripcionPerfilLaboral=hojaDeVida.DescripcionPerfilLaboral;
        HojaDeVidaId=hojaDeVida.HojaDeVidaId;
        Aspirante=new InformacionAspiranteViewModel(hojaDeVida.Aspirante);
        DatosAcademicos=hojaDeVida.DatosAcademicos.Select(p=>new InformacionDatoAcademicoViewModel(p)).ToList();
        DatosLaborales=hojaDeVida.DatosLaborales.Select(p=>new InformacionDatoLaboralViewModel(p)).ToList();
        }
    }

    public class InformacionHojaDeVidaViewModel
    {
        public int HojaDeVidaId{ get; set; }
        public string Nombre{ get; set; }
        public string DescripcionPerfilLaboral{ get; set; }


        public InformacionHojaDeVidaViewModel(HojaDeVida hojaDeVida)
        {
        HojaDeVidaId=hojaDeVida.HojaDeVidaId;
        Nombre=hojaDeVida.Nombre;
        DescripcionPerfilLaboral=hojaDeVida.DescripcionPerfilLaboral;
        }
    }

}
