using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class DatoLaboralService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public DatoLaboralService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarDatoLaboralResponse GuardarDatoLaboral(DatoLaboral datoLaboral)
        {
            try
            {
                var _datoLaboral = _context.DatosLaborales.Find(datoLaboral.DatoLaboralId);
                if (_datoLaboral == null)
                {
                    _context.DatosLaborales.Add(datoLaboral);
                    _context.SaveChanges();
                    return new GuardarDatoLaboralResponse(datoLaboral);
                }

                return new GuardarDatoLaboralResponse("El Dato Laboral ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarDatoLaboralResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------
        public GuardarDatoLaboralResponse Modificar(DatoLaboral datoLaboralNew)
        {
            try
            {
                var _datoLaboralOld = _context.DatosLaborales.Find(datoLaboralNew.DatoLaboralId);
                if (_datoLaboralOld != null)
                {

                        _datoLaboralOld.DatoLaboralId = datoLaboralNew.DatoLaboralId;
                        _datoLaboralOld.NombreEmpresa = datoLaboralNew.NombreEmpresa;
                        _datoLaboralOld.Cargo = datoLaboralNew.Cargo;
                        _datoLaboralOld.Area = datoLaboralNew.Area;
                        _datoLaboralOld.FechaInicio = datoLaboralNew.FechaInicio;
                        _datoLaboralOld.FechaFinalizacion = datoLaboralNew.FechaFinalizacion;
                        _context.DatosLaborales.Update(_datoLaboralOld);
                        _context.SaveChanges();
                        return new GuardarDatoLaboralResponse(_datoLaboralOld);
                   
                }
                return new GuardarDatoLaboralResponse("El Dato Laboral que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarDatoLaboralResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public ConsultarDatoLaboralResponse Consultar()
        {
            try
            {
                var datosLaborales = _context.DatosLaborales.ToList();
                return new ConsultarDatoLaboralResponse(datosLaborales);

            }
            catch (Exception e)
            {
                return new ConsultarDatoLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarDatoLaboralResponse BuscarPorId(int Id)
        {
            try
            {
                var datoLaboral = _context.DatosLaborales.Find(Id);
                if (datoLaboral != null)
                {
                    return new BuscarDatoLaboralResponse(datoLaboral);
                }
                return new BuscarDatoLaboralResponse("El Dato Laboral consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarDatoLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }


//----------------------------------------------------------------------------------------------------------------

        public BuscarDatoLaboralResponse BuscarDatoLaboralConHojaDeVidaPorId(int id)
        {
            try
            {
                //REVISAR PARA AÑADIR LA OTRA PARTE
                var datoLaboral = _context.DatosLaborales.Where(t => t.DatoLaboralId == id).Include(t => t.HojaDeVida).FirstOrDefault();
                if (datoLaboral != null)
                {
                    return new BuscarDatoLaboralResponse(datoLaboral);
                }
                return new BuscarDatoLaboralResponse("el datoLaboral consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarDatoLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }







        public string Eliminar(int datoLaboralId)
        {
            try
            {
                var datoLaboral = _context.DatosLaborales.Find(datoLaboralId);
                if(datoLaboral != null)
                {
                    _context.DatosLaborales.Remove(datoLaboral);
                    _context.SaveChanges();
                    return ($"El dato laboral { datoLaboral.DatoLaboralId } se ha eliminado satisfactoriamente");
                }
                else
                {
                    return ($"El dato laboral { datoLaboral.DatoLaboralId } no se encuentra registrado");
                }
            }
            catch(Exception e)
            {
                return ($"Error de la aplicacion: {e.Message}");
            }
        }





    }







//----------------------------------------------------------------------------------------------------------------

    public class GuardarDatoLaboralResponse
    {
        public DatoLaboral DatoLaboral { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarDatoLaboralResponse(DatoLaboral datoLaboral)
        {
            DatoLaboral = datoLaboral;
            Error = false;
        }

        public GuardarDatoLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarDatoLaboralResponse
    {
        public DatoLaboral DatoLaboral { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarDatoLaboralResponse(DatoLaboral datoLaboral)
        {
            DatoLaboral = datoLaboral;
            Error = false;
        }

        public BuscarDatoLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarDatoLaboralResponse
    {
        public List<DatoLaboral> DatosLaborales { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarDatoLaboralResponse(List<DatoLaboral> datosLaborales)
        {
            DatosLaborales = datosLaborales;
            Error = false;
        }

        public ConsultarDatoLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
