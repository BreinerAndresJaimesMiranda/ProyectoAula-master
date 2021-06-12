using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PostulacionService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public PostulacionService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarPostulacionResponse GuardarPostulacion(Postulacion postulacion)
        {
            try
            {
                var _postulacion = _context.Postulaciones.Find(postulacion.PostulacionId);
                if (_postulacion == null)
                {
                    _context.Postulaciones.Add(postulacion);
                    _context.SaveChanges();
                    return new GuardarPostulacionResponse(postulacion);
                }

                return new GuardarPostulacionResponse("El postulacion ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarPostulacionResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------





//----------------------------------------------------------------------------------------------------------------
        public ConsultarPostulacionResponse Consultar()
        {
            try
            {
                var postulaciones = _context.Postulaciones.ToList();
                return new ConsultarPostulacionResponse(postulaciones);

            }
            catch (Exception e)
            {
                return new ConsultarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarPostulacionResponse BuscarPorId(int Id)
        {
            try
            {
                var postulacion = _context.Postulaciones.Find(Id);
                if (postulacion != null)
                {
                    return new BuscarPostulacionResponse(postulacion);
                }
                return new BuscarPostulacionResponse("la postulacion consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }





         public BuscarPostulacionResponse BuscarConAspiranteOfertaLaboralPorId(int Id)
        {
            try
            {
                var postulacion = _context.Postulaciones.Where(t => t.PostulacionId == Id).Include(t => t.Aspirante).Include(t => t.OfertaLaboral).FirstOrDefault();
                if (postulacion != null)
                {
                    return new BuscarPostulacionResponse(postulacion);
                }
                return new BuscarPostulacionResponse("la postulacion consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }





    









    }



    



//----------------------------------------------------------------------------------------------------------------

    public class GuardarPostulacionResponse
    {
        public Postulacion Postulacion { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarPostulacionResponse(Postulacion postulacion)
        {
            Postulacion = postulacion;
            Error = false;
        }

        public GuardarPostulacionResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarPostulacionResponse
    {
        public Postulacion Postulacion { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarPostulacionResponse(Postulacion postulacion)
        {
            Postulacion = postulacion;
            Error = false;
        }

        public BuscarPostulacionResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarPostulacionResponse
    {
        public List<Postulacion> Postulaciones { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarPostulacionResponse(List<Postulacion> postulaciones)
        {
            Postulaciones = postulaciones;
            Error = false;
        }

        public ConsultarPostulacionResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}