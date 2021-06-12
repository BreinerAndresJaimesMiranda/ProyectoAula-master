using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class AspiranteService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public AspiranteService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarAspiranteResponse GuardarAspirante(Aspirante aspirante)
        {
            try
            {
                var _aspirante = _context.Aspirantes.Find(aspirante.Correo);
                if (_aspirante == null)
                {
                    _context.Aspirantes.Add(aspirante);
                    _context.SaveChanges();
                    return new GuardarAspiranteResponse(aspirante);
                }

                return new GuardarAspiranteResponse("El aspirante ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarAspiranteResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------
        public GuardarAspiranteResponse Modificar(Aspirante aspiranteNew)
        {
            try
            {
                var _aspiranteOld = _context.Aspirantes.Find(aspiranteNew.Correo);
                if (_aspiranteOld != null)
                {

                        _aspiranteOld.Correo=aspiranteNew.Correo;
                        _aspiranteOld.Identificacion = aspiranteNew.Identificacion;
                        _aspiranteOld.Contrasenia = aspiranteNew.Contrasenia;
                        _aspiranteOld.Nombres = aspiranteNew.Nombres;
                        _aspiranteOld.Apellidos = aspiranteNew.Apellidos;
                        _aspiranteOld.Edad = aspiranteNew.Edad;
                        _aspiranteOld.HorarioTrabajoPreferido = aspiranteNew.HorarioTrabajoPreferido;
                        _aspiranteOld.SalarioTrabajoPreferido = aspiranteNew.SalarioTrabajoPreferido;
                        _aspiranteOld.Telefono = aspiranteNew.Telefono;
                        _aspiranteOld.TipoDocumento = aspiranteNew.TipoDocumento;
                        _aspiranteOld.FechaNacimiento = aspiranteNew.FechaNacimiento;
                        _aspiranteOld.Genero = aspiranteNew.Genero;
                        _aspiranteOld.Pais = aspiranteNew.Pais;
                        _aspiranteOld.Departamento = aspiranteNew.Departamento;
                        _aspiranteOld.Ciudad = aspiranteNew.Ciudad;
                        _aspiranteOld.Nacionalidad = aspiranteNew.Nacionalidad;
                        _context.Aspirantes.Update(_aspiranteOld);
                        _context.SaveChanges();
                        return new GuardarAspiranteResponse(_aspiranteOld);

                }
                return new GuardarAspiranteResponse("El aspirante que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarAspiranteResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public ConsultarAspiranteResponse Consultar()
        {
            try
            {
                var aspirantes = _context.Aspirantes.ToList();
                return new ConsultarAspiranteResponse(aspirantes);

            }
            catch (Exception e)
            {
                return new ConsultarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarAspiranteResponse BuscarPorCorreo(string correo)
        {
            try
            {
                var aspirante = _context.Aspirantes.Find(correo);
                if (aspirante != null)
                {
                    return new BuscarAspiranteResponse(aspirante);
                }
                return new BuscarAspiranteResponse("El aspirante consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }



         public BuscarAspiranteResponse BuscarConPostulacionesPorCorreo(string correo)
        {
            try
            {
                var aspirante = _context.Aspirantes.Where(t => t.Correo == correo ).Include(t => t.Postulaciones).FirstOrDefault();
                if (aspirante != null)
                {
                    return new BuscarAspiranteResponse(aspirante);
                }
                return new BuscarAspiranteResponse("El aspirante consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }













    }



//----------------------------------------------------------------------------------------------------------------

    public class GuardarAspiranteResponse
    {
        public Aspirante Aspirante { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarAspiranteResponse(Aspirante aspirante)
        {
            Aspirante = aspirante;
            Error = false;
        }

        public GuardarAspiranteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarAspiranteResponse
    {
        public Aspirante Aspirante { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarAspiranteResponse(Aspirante aspirante)
        {
            Aspirante = aspirante;
            Error = false;
        }

        public BuscarAspiranteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarAspiranteResponse
    {
        public List<Aspirante> Aspirantes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarAspiranteResponse(List<Aspirante> aspirantes)
        {
            Aspirantes = aspirantes;
            Error = false;
        }

        public ConsultarAspiranteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
