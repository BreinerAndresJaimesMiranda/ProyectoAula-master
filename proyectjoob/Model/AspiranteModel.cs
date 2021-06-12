using System;
using Entity;
using PostulacionModel.Model;
using System.Collections.Generic;
using System.Linq;


namespace AspiranteModel.Model
{
    public class AspiranteInputModel
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
}
