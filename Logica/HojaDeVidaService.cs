using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;


namespace Logica
{
    public class HojaDeVidaService
    {

        private readonly ProyectjoobContext _context;


//----------------------------------------------------------------------------------------------------------------
        public HojaDeVidaService(ProyectjoobContext context)
        {
            _context = context;
        }




//----------------------------------------------------------------------------------------------------------------
        public GuardarHojaDeVidaResponse GuardarHojaDeVida(HojaDeVida hojaDeVida)
        {
            try
            {
                var _hojaDeVida = _context.HojasDeVida.Find(hojaDeVida.HojaDeVidaId);
                if (_hojaDeVida == null)
                {
                    _context.HojasDeVida.Add(hojaDeVida);
                    _context.SaveChanges();
                    return new GuardarHojaDeVidaResponse(hojaDeVida);
                }

                return new GuardarHojaDeVidaResponse("La hojaDeVida ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarHojaDeVidaResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public GuardarHojaDeVidaResponse Modificar(HojaDeVida hojaDeVidaNew)
        {
            try
            {
                var _hojaDeVidaOld = _context.HojasDeVida.Find(hojaDeVidaNew.HojaDeVidaId);
                if (_hojaDeVidaOld != null)
                {

                        _hojaDeVidaOld.HojaDeVidaId = hojaDeVidaNew.HojaDeVidaId;
                        _hojaDeVidaOld.Nombre = hojaDeVidaNew.Nombre;
                        _hojaDeVidaOld.DescripcionPerfilLaboral = hojaDeVidaNew.DescripcionPerfilLaboral;
                        _context.HojasDeVida.Update(_hojaDeVidaOld);
                        _context.SaveChanges();
                        return new GuardarHojaDeVidaResponse(_hojaDeVidaOld);
                    
                }
                return new GuardarHojaDeVidaResponse("La HojaDeVida que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarHojaDeVidaResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }






//----------------------------------------------------------------------------------------------------------------
        public ConsultarHojaDeVidaResponse Consultar()
        {
            try
            {
                var HojasDeVida = _context.HojasDeVida.ToList();
                return new ConsultarHojaDeVidaResponse(HojasDeVida);

            }
            catch (Exception e)
            {
                return new ConsultarHojaDeVidaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




 

//----------------------------------------------------------------------------------------------------------------
        public BuscarHojaDeVidaResponse BuscarHojaDeVidaConDatoAcademicoDatoLaboralPorId(int id)
        {
            try
            {
                //REVISAR PARA AÑADIR LA OTRA PARTE
                var hojaDeVida = _context.HojasDeVida.Where(t => t.HojaDeVidaId == id).Include(t => t.DatosAcademicos).Include(t=> t.DatosLaborales).Include(t => t.Aspirante).FirstOrDefault();
                if (hojaDeVida != null)
                {
                    return new BuscarHojaDeVidaResponse(hojaDeVida);
                }
                return new BuscarHojaDeVidaResponse("la HojaDeVida consultada no existe");
            }
            catch (Exception e)
            {
                return new BuscarHojaDeVidaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }


//--------------------------------------------------------------------------------------------------------------------


        public BuscarHojaDeVidaResponse BuscarHojaDeVidaPorCorreoAspirante(string correo)
        {
            try
            {
                //REVISAR PARA AÑADIR LA OTRA PARTE
                var hojaDeVida = _context.HojasDeVida.Where(t => t.AspiranteId == correo).Include(t => t.Aspirante).Include(t => t.DatosAcademicos).Include(t => t.DatosLaborales).FirstOrDefault();
                if (hojaDeVida != null)
                {
                    return new BuscarHojaDeVidaResponse(hojaDeVida);
                }
                return new BuscarHojaDeVidaResponse("la HojaDeVida consultada no existe");
            }
            catch (Exception e)
            {
                return new BuscarHojaDeVidaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }



//----------------------------------------------------------------------------------------------------------------
         public BuscarHojaDeVidaResponse BuscarPorId(int Id)
        {
            try
            {
                var hojaDeVida = _context.HojasDeVida.Find(Id);
                if (hojaDeVida != null)
                {
                    return new BuscarHojaDeVidaResponse(hojaDeVida);
                }
                return new BuscarHojaDeVidaResponse("La hoja de vida consultada no existe");
            }
            catch (Exception e)
            {
                return new BuscarHojaDeVidaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }

    }






//----------------------------------------------------------------------------------------------------------------
        public class GuardarHojaDeVidaResponse
    {
        public HojaDeVida HojaDeVida { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarHojaDeVidaResponse(HojaDeVida hojaDeVida)
        {
            HojaDeVida = hojaDeVida;
            Error = false;
        }

        public GuardarHojaDeVidaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }





//----------------------------------------------------------------------------------------------------------------
    public class BuscarHojaDeVidaResponse
    {
        public HojaDeVida HojaDeVida { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarHojaDeVidaResponse(HojaDeVida hojaDeVida)
        {
            HojaDeVida = hojaDeVida;
            Error = false;
        }

        public BuscarHojaDeVidaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }







//----------------------------------------------------------------------------------------------------------------
    public class ConsultarHojaDeVidaResponse
    {
        public List<HojaDeVida> HojasDeVida { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarHojaDeVidaResponse(List<HojaDeVida> hojaDeVida)
        {
            HojasDeVida = hojaDeVida;
            Error = false;
        }

        public ConsultarHojaDeVidaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }


}