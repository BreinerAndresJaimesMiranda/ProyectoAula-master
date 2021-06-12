using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class OfertaLaboralService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public OfertaLaboralService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarOfertaLaboralResponse GuardarOfertaLaboral(OfertaLaboral ofertaLaboral)
        {
            try
            {
                var _ofertaLaboral = _context.OfertasLaborales.Find(ofertaLaboral.OfertaLaboralId);
                if (_ofertaLaboral == null)
                {
                    _context.OfertasLaborales.Add(ofertaLaboral);
                    _context.SaveChanges();
                    return new GuardarOfertaLaboralResponse(ofertaLaboral);
                }

                return new GuardarOfertaLaboralResponse("El ofertaLaboral ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarOfertaLaboralResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------
        public GuardarOfertaLaboralResponse Modificar(OfertaLaboral ofertaLaboralNew)
        {
            try
            {
                var _ofertaLaboralOld = _context.OfertasLaborales.Find(ofertaLaboralNew.OfertaLaboralId);
                if (_ofertaLaboralOld != null)
                {

                        _ofertaLaboralOld.OfertaLaboralId = ofertaLaboralNew.OfertaLaboralId;
                        _ofertaLaboralOld.Descripcion = ofertaLaboralNew.Descripcion;
                        _ofertaLaboralOld.Salario = ofertaLaboralNew.Salario;
                        _ofertaLaboralOld.Cargo = ofertaLaboralNew.Cargo;
                        _ofertaLaboralOld.Horario = ofertaLaboralNew.Horario; 
                        //_context.OfertasLaborales.Add(ofertaLaboralNew);
                        _context.OfertasLaborales.Update(_ofertaLaboralOld);
                        _context.SaveChanges();
                        return new GuardarOfertaLaboralResponse(_ofertaLaboralOld);
                    
                }
                return new GuardarOfertaLaboralResponse("El ofertaLaboral que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarOfertaLaboralResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public ConsultarOfertaLaboralResponse Consultar()
        {
            try
            {
                var ofertasLaborales = _context.OfertasLaborales.ToList();
                return new ConsultarOfertaLaboralResponse(ofertasLaborales);

            }
            catch (Exception e)
            {
                return new ConsultarOfertaLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarOfertaLaboralResponse BuscarPorId(int Id)
        {
            try
            {
                var ofertaLaboral = _context.OfertasLaborales.Find(Id);
                if (ofertaLaboral != null)
                {
                    return new BuscarOfertaLaboralResponse(ofertaLaboral);
                }
                return new BuscarOfertaLaboralResponse("la ofertaLaboral consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarOfertaLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }




    




        public BuscarOfertaLaboralResponse BuscarConEmpresaPostulacionesPorId(int Id)
        {
            try
            {
                var ofertaLaboral = _context.OfertasLaborales.Where(t => t.OfertaLaboralId == Id).Include(t => t.Empresa).Include(t => t.Postulaciones).FirstOrDefault();
                if (ofertaLaboral != null)
                {
                    return new BuscarOfertaLaboralResponse(ofertaLaboral);
                }
                return new BuscarOfertaLaboralResponse("la ofertaLaboral consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarOfertaLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }














    }



    



//----------------------------------------------------------------------------------------------------------------

    public class GuardarOfertaLaboralResponse
    {
        public OfertaLaboral OfertaLaboral { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarOfertaLaboralResponse(OfertaLaboral ofertaLaboral)
        {
            OfertaLaboral = ofertaLaboral;
            Error = false;
        }

        public GuardarOfertaLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarOfertaLaboralResponse
    {
        public OfertaLaboral OfertaLaboral { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarOfertaLaboralResponse(OfertaLaboral ofertaLaboral)
        {
            OfertaLaboral = ofertaLaboral;
            Error = false;
        }

        public BuscarOfertaLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarOfertaLaboralResponse
    {
        public List<OfertaLaboral> OfertasLaborales { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarOfertaLaboralResponse(List<OfertaLaboral> ofertasLaborales)
        {
            OfertasLaborales = ofertasLaborales;
            Error = false;
        }

        public ConsultarOfertaLaboralResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}