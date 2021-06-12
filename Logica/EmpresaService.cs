using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class EmpresaService
    {
        private readonly ProyectjoobContext _context;
//----------------------------------------------------------------------------------------------------------------
        public EmpresaService(ProyectjoobContext context)
        {
            _context = context;
        }

//----------------------------------------------------------------------------------------------------------------

        public GuardarEmpresaResponse GuardarEmpresa(Empresa empresa)
        {
            try
            {
                var _empresa = _context.Empresas.Find(empresa.Nit);
                if (_empresa == null)
                {
                    _context.Empresas.Add(empresa);
                    _context.SaveChanges();
                    return new GuardarEmpresaResponse(empresa);
                }

                return new GuardarEmpresaResponse("El empresa ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarEmpresaResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }



//----------------------------------------------------------------------------------------------------------------
        public GuardarEmpresaResponse Modificar(Empresa empresaNew)
        {
            try
            {
                var _empresaOld = _context.Empresas.Find(empresaNew.Nit);
                if (_empresaOld != null)
                {

                        _empresaOld.Nit = empresaNew.Nit;
                        _empresaOld.Contrasenia = empresaNew.Contrasenia;
                        _empresaOld.Nombre = empresaNew.Nombre;
                        _empresaOld.Correo = empresaNew.Correo;
                        _empresaOld.TipoServicio = empresaNew.TipoServicio; 
                        //_context.Empresas.Add(empresaNew);
                        _context.Empresas.Update(_empresaOld);
                        _context.SaveChanges();
                        return new GuardarEmpresaResponse(_empresaOld);
                    
                }
                return new GuardarEmpresaResponse("El empresa que intenta modificar no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarEmpresaResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
        public ConsultarEmpresaResponse Consultar()
        {
            try
            {
                var empresas = _context.Empresas.ToList();
                return new ConsultarEmpresaResponse(empresas);

            }
            catch (Exception e)
            {
                return new ConsultarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }




//----------------------------------------------------------------------------------------------------------------
         public BuscarEmpresaResponse BuscarPorNit(string Nit)
        {
            try
            {
                var empresa = _context.Empresas.Find(Nit);
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("la empresa consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }





         public BuscarEmpresaResponse BuscarConOfertasLaboralesPorNit(string Nit)
        {
            try
            {
                var empresa = _context.Empresas.Where(t => t.Nit == Nit).Include(t => t.OfertasLaborales).FirstOrDefault();
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("la empresa consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }





         public BuscarEmpresaResponse BuscarPorCorreo(string Correo)
        {
            try
            {
                var empresa = _context.Empresas.Where(t => t.Correo == Correo).FirstOrDefault();
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("la empresa consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }
    


        public BuscarEmpresaResponse BuscarConOfertasLaboralesPorCorreo(string Correo)
        {
            try
            {
                var empresa = _context.Empresas.Where(t => t.Correo == Correo).Include(t => t.OfertasLaborales).FirstOrDefault();
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("la empresa consultado no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }






    }



    



//----------------------------------------------------------------------------------------------------------------

    public class GuardarEmpresaResponse
    {
        public Empresa Empresa { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarEmpresaResponse(Empresa empresa)
        {
            Empresa = empresa;
            Error = false;
        }

        public GuardarEmpresaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }




//----------------------------------------------------------------------------------------------------------------
    public class BuscarEmpresaResponse
    {
        public Empresa Empresa { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarEmpresaResponse(Empresa empresa)
        {
            Empresa = empresa;
            Error = false;
        }

        public BuscarEmpresaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }



//----------------------------------------------------------------------------------------------------------------
    public class ConsultarEmpresaResponse
    {
        public List<Empresa> Empresas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarEmpresaResponse(List<Empresa> empresas)
        {
            Empresas = empresas;
            Error = false;
        }

        public ConsultarEmpresaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}