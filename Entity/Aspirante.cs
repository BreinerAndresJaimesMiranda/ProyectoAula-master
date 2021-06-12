using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Entity
{
    public class Aspirante
    {
        [Key]
        public string Correo{get;set;}
        //public string Contraseña{get;set;}
        public string Identificacion{get;set;}
        public string Contrasenia{get;set;}
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
        public List<Postulacion> Postulaciones{get;set;}

    }
}
