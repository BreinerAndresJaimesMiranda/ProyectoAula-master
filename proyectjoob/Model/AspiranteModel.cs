using System;
using System.ComponentModel.DataAnnotations;
using Entity;
using PostulacionModel.Model;
using System.Collections.Generic;
using System.Linq;


namespace AspiranteModel.Model
{
    public class AspiranteInputModel
    {
        [Required(ErrorMessage = "El Correo es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo no es valido")]
        public string Correo{get;set;}

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia{get;set;}

        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion{get;set;}

        [Required(ErrorMessage = "Los nombres son requeridos")]
        public string Nombres{get;set;}

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        public string Apellidos{get;set;}

        [Required(ErrorMessage = "La edad es requerida")]
        [Range(13,99,ErrorMessage ="La edad debe ser entre 13 y 99 años")]
        public int Edad{get;set;}

        [Required(ErrorMessage = "El Horario de trabajo preferido es requerido")]
        public string HorarioTrabajoPreferido{get;set;}

        [Required(ErrorMessage = "El salario de trabajo preferido es requerido")]
        public string SalarioTrabajoPreferido{get;set;}

        [Required(ErrorMessage = "El Telefono es requerido")]
        public string Telefono{get;set;}

        [Required(ErrorMessage = "El Tipo de documento es requerido")]
        public string TipoDocumento{get;set;}

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento{get;set;}

        [Required(ErrorMessage = "El Genero es requerido")]
        [SexoValidacion( ErrorMessage="El Sexo de ser Femenino o Masculino")]
        public string Genero{get;set;}

        [Required(ErrorMessage = "El Pais es requerido")]
        public string Pais{get;set;}

        [Required(ErrorMessage = "El Departamento es requerido")]
        public string Departamento{get;set;}

        [Required(ErrorMessage = "La ciudad es requerida")]
        public string Ciudad{get;set;}

        [Required(ErrorMessage = "La nacionalidad es requerida")]
        public string Nacionalidad{get;set;}
    }

    public class AspiranteViewModel
    {

        public string Correo{get;set;}
        public string Contrasenia{get;set;}
        public string Identificacion{get;set;}
        public string Nombres{get;set;}
        public string Apellidos{get;set;}
        public int Edad{get;set;}
        public string HorarioTrabajoPreferido{get;set;}
        public string SalarioTrabajoPreferido{get;set;}
        public string Telefono{get;set;}
        public string TipoDocumento{get;set;}
        public DateTime FechaNacimiento{get;set;}
        public string Genero{get;set;}
        public string Pais{get;set;}
        public string Departamento{get;set;}
        public string Ciudad{get;set;}
        public string Nacionalidad{get;set;}
        public List<InformacionPostulacionViewModel> Postulaciones{get;set;}


        public AspiranteViewModel(Aspirante aspirante)
        {
            Correo=aspirante.Correo;
            Contrasenia=aspirante.Contrasenia;
            Identificacion=aspirante.Identificacion;
            Nombres=aspirante.Nombres;
            Apellidos=aspirante.Apellidos;
            Edad=aspirante.Edad;
            HorarioTrabajoPreferido=aspirante.HorarioTrabajoPreferido;
            SalarioTrabajoPreferido=aspirante.SalarioTrabajoPreferido;
            Telefono=aspirante.Telefono;
            TipoDocumento=aspirante.TipoDocumento;
            FechaNacimiento=aspirante.FechaNacimiento;
            Genero=aspirante.Genero;
            Pais=aspirante.Pais;
            Departamento=aspirante.Departamento;
            Ciudad=aspirante.Ciudad;
            Nacionalidad=aspirante.Nacionalidad;
            Postulaciones=aspirante.Postulaciones.Select(p=>new InformacionPostulacionViewModel(p)).ToList();
        }
    }

    public class InformacionAspiranteViewModel
    {

        public string Correo{get;set;}
        public string Contrasenia{get;set;}
        public string Identificacion{get;set;}
        public string Nombres{get;set;}
        public string Apellidos{get;set;}
        public int Edad{get;set;}
        public string HorarioTrabajoPreferido{get;set;}
        public string SalarioTrabajoPreferido{get;set;}
        public string Telefono{get;set;}
        public string TipoDocumento{get;set;}
        public DateTime FechaNacimiento{get;set;}
        public string Genero{get;set;}
        public string Pais{get;set;}
        public string Departamento{get;set;}
        public string Ciudad{get;set;}
        public string Nacionalidad{get;set;}

        public InformacionAspiranteViewModel(Aspirante aspirante)
        {
            Correo=aspirante.Correo;
            Contrasenia=aspirante.Contrasenia;
            Identificacion=aspirante.Identificacion;
            Nombres=aspirante.Nombres;
            Apellidos=aspirante.Apellidos;
            Edad=aspirante.Edad;
            HorarioTrabajoPreferido=aspirante.HorarioTrabajoPreferido;
            SalarioTrabajoPreferido=aspirante.SalarioTrabajoPreferido;
            Telefono=aspirante.Telefono;
            TipoDocumento=aspirante.TipoDocumento;
            FechaNacimiento=aspirante.FechaNacimiento;
            Genero=aspirante.Genero;
            Pais=aspirante.Pais;
            Departamento=aspirante.Departamento;
            Ciudad=aspirante.Ciudad;
            Nacionalidad=aspirante.Nacionalidad;

        }
    }


    public class SexoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "MASCULINO") || (value.ToString().ToUpper() == "FEMENINO"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }


























}
