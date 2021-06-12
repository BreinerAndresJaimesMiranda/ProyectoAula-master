using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class DatoAcademicoService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public DatoAcademicoService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarDatoAcademicoResponse GuardarDatoAcademico(DatoAcademico datoAcademico)
        {
            try
            {
                var _datoAcademico = _context.DatosAcademicos.Find(datoAcademico.DatoAcademicoId);
                if (_datoAcademico == null)
                {
                    _context.DatosAcademicos.Add(datoAcademico);
                    _context.SaveChanges();
                    return new GuardarDatoAcademicoResponse(datoAcademico);
                }

                return new GuardarDatoAcademicoResponse("El Dato Academico ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarDatoAcademicoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------
        public GuardarDatoAcademicoResponse Modificar(DatoAcademico datoAcademicoNew)
        {
            try
            {
                var _datoAcademicoOld = _context.DatosAcademicos.Find(datoAcademicoNew.DatoAcademicoId);
                if (_datoAcademicoOld != null)
                {

                        _datoAcademicoOld.DatoAcademicoId = datoAcademicoNew.DatoAcademicoId;
                        _datoAcademicoOld.NombreCentroAcademico = datoAcademicoNew.NombreCentroAcademico;
                        _datoAcademicoOld.NivelEducativo = datoAcademicoNew.NivelEducativo;
                        _datoAcademicoOld.AreaEstudio = datoAcademicoNew.AreaEstudio;
                        _datoAcademicoOld.EstadoCurso = datoAcademicoNew.EstadoCurso;
                        _datoAcademicoOld.FechaInicio = datoAcademicoNew.FechaInicio;
                        _datoAcademicoOld.FechaFinalizacion = datoAcademicoNew.FechaFinalizacion;
                        _context.DatosAcademicos.Update(_datoAcademicoOld);
                        _context.SaveChanges();
                        return new GuardarDatoAcademicoResponse(_datoAcademicoOld);

                }
                return new GuardarDatoAcademicoResponse("El Dato Academico que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarDatoAcademicoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public ConsultarDatoAcademicoResponse Consultar()
        {
            try
            {
                var datosAcademicos = _context.DatosAcademicos.ToList();
                return new ConsultarDatoAcademicoResponse(datosAcademicos);

            }
            catch (Exception e)
            {
                return new ConsultarDatoAcademicoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarDatoAcademicoResponse BuscarPorId(int Id)
        {
            try
            {
                var datoAcademico = _context.DatosAcademicos.Find(Id);
                if (datoAcademico != null)
                {
                    return new BuscarDatoAcademicoResponse(datoAcademico);
                }
                return new BuscarDatoAcademicoResponse("El Dato Academico consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarDatoAcademicoResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }


//----------------------------------------------------------------------------------------------------------------

        public BuscarDatoAcademicoResponse BuscarDatoAcademicoConHojaDeVidaPorId(int id)
        {
            try
            {
                //REVISAR PARA AÑADIR LA OTRA PARTE
                var datoAcademico = _context.DatosAcademicos.Where(t => t.DatoAcademicoId == id).Include(t => t.HojaDeVida).FirstOrDefault();
                if (datoAcademico != null)
                {
                    return new BuscarDatoAcademicoResponse(datoAcademico);
                }
                return new BuscarDatoAcademicoResponse("el datoAcademico consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarDatoAcademicoResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }




        public string Eliminar(int datoAcademicoId)
        {
            try
            {
                var datoAcademico = _context.DatosAcademicos.Find(datoAcademicoId);
                if(datoAcademico != null)
                {
                    _context.DatosAcademicos.Remove(datoAcademico);
                    _context.SaveChanges();
                    return ($"El dato academico { datoAcademico.DatoAcademicoId } se ha eliminado satisfactoriamente");
                }
                else
                {
                    return ($"El dato academico { datoAcademico.DatoAcademicoId } no se encuentra registrado");
                }
            }
            catch(Exception e)
            {
                return ($"Error de la aplicacion: {e.Message}");
            }    
        }










    }



//----------------------------------------------------------------------------------------------------------------

    public class GuardarDatoAcademicoResponse
    {
        public DatoAcademico DatoAcademico { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarDatoAcademicoResponse(DatoAcademico datoAcademico)
        {
            DatoAcademico = datoAcademico;
            Error = false;
        }

        public GuardarDatoAcademicoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarDatoAcademicoResponse
    {
        public DatoAcademico DatoAcademico { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarDatoAcademicoResponse(DatoAcademico datoAcademico)
        {
            DatoAcademico = datoAcademico;
            Error = false;
        }

        public BuscarDatoAcademicoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarDatoAcademicoResponse
    {
        public List<DatoAcademico> DatosAcademicos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarDatoAcademicoResponse(List<DatoAcademico> datosAcademicos)
        {
            DatosAcademicos = datosAcademicos;
            Error = false;
        }

        public ConsultarDatoAcademicoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
