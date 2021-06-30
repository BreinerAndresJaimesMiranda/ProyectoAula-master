using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using EmpresaModel.Model;

namespace proyectjoob.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService empresaService;
        public EmpresaController(ProyectjoobContext context)
        {
            empresaService = new EmpresaService(context);
        }









        [HttpPost]
        public ActionResult<InformacionEmpresaViewModel> PostEmpresa(EmpresaInputModel EmpresaInput)
        {

            var empresa = MapearEmpresa(EmpresaInput);
            var response = empresaService.GuardarEmpresa(empresa);
            if (!response.Error)
            {
                var EmpresaViewModel = new InformacionEmpresaViewModel(empresa);
                return Ok(EmpresaViewModel);
            }
            ModelState.AddModelError("Guardar Empresa", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
        }




        [HttpPost("api/ModificarEmpresa")]
        public ActionResult<InformacionEmpresaViewModel> PostModificarEmpresa(EmpresaInputModel EmpresaNewInput)
        {

            var empresa = MapearEmpresa(EmpresaNewInput);
            var response = empresaService.Modificar(empresa);
            if (!response.Error)
            {
                var informacionEmpresaViewModel = new InformacionEmpresaViewModel(empresa);
                return Ok(informacionEmpresaViewModel);
            }
            ModelState.AddModelError("Modificar Empresa", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
        }







        [HttpGet("api/EmpresaCorreo/{Correo}")]
        public ActionResult<EmpresaViewModel> GetEmpresaCorreo(string Correo)
        {
            var response = empresaService.BuscarConOfertasLaboralesPorCorreo(Correo);
            if (!response.Error)
            {
                var EmpresaViewModel = new InformacionEmpresaViewModel(response.Empresa);
                return Ok(EmpresaViewModel);
            }

            return BadRequest(response.Mensaje);
        }



        [HttpGet("api/EmpresaNit/{Nit}")]
        public ActionResult<EmpresaViewModel> GetEmpresaNit(string Nit)
        {
            var response = empresaService.BuscarConOfertasLaboralesPorNit(Nit);
            if (!response.Error)
            {
                var EmpresaViewModel = new EmpresaViewModel(response.Empresa);
                return Ok(EmpresaViewModel);
            }
            return BadRequest(response.Mensaje);            
        }











        [HttpGet]
        public ActionResult<IEnumerable<InformacionEmpresaViewModel>> GetEmpresa()
        {
            var response = empresaService.Consultar();
            if (!response.Error)
            {
                var empresaViewModels = response.Empresas.Select(p => new InformacionEmpresaViewModel(p));
                return Ok(empresaViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private Empresa MapearEmpresa(EmpresaInputModel empresaInput)
        {
            var empresa = new Empresa()
            {

            Correo=empresaInput.Correo,
            Contrasenia=empresaInput.Contrasenia,
            TipoServicio=empresaInput.TipoServicio,
            Nombre=empresaInput.Nombre,
            Nit=empresaInput.Nit,


            };
            return empresa;
        }
    }


    
}
