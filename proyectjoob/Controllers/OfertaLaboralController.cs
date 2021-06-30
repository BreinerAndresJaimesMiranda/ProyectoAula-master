using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using OfertaLaboralModel.Model;
using Microsoft.AspNetCore.SignalR;
using proyectjoob.Hubs;
using System.Threading.Tasks;

namespace proyectjoob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OfertaLaboralController : ControllerBase
    {
        private readonly OfertaLaboralService ofertaLaboralService;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly EmpresaService empresaService;
        public OfertaLaboralController(ProyectjoobContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext=hubContext;
            ofertaLaboralService = new OfertaLaboralService(context);
            empresaService=new EmpresaService(context);
        }









        [HttpPost]
        public async Task<ActionResult<InformacionOfertaLaboralViewModel>> PostOfertaLaboral(OfertaLaboralInputModel OfertaLaboralInput)
        {
            var buscarEmpresaResponse=empresaService.BuscarPorCorreo(OfertaLaboralInput.CorreoEmpresa);
            if(buscarEmpresaResponse.Empresa==null){
                return BadRequest("El empresa no se encuentra registrado");
            }else{
                var ofertaLaboral = MapearOfertaLaboral(OfertaLaboralInput);
                ofertaLaboral.Empresa=buscarEmpresaResponse.Empresa;
                var response = ofertaLaboralService.GuardarOfertaLaboral(ofertaLaboral);
                if (!response.Error)
                {
                    var informacionOfertaLaboralViewModel = new InformacionOfertaLaboralViewModel(ofertaLaboral);
                    await _hubContext.Clients.All.SendAsync("PostOfertaLaboral",OfertaLaboralInput);
                    return Ok(informacionOfertaLaboralViewModel);
                }
            
            ModelState.AddModelError("Guardar Oferta Laboral", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
            }


        } 







        [HttpPost("api/ModificarOfertaLaboral")]
        public async Task<ActionResult<InformacionOfertaLaboralViewModel>> PostModificarOfertaLaboral(OfertaLaboralInputModel OfertaLaboralNewInput)
        {

            var ofertaLaboral = MapearOfertaLaboral(OfertaLaboralNewInput);
            ofertaLaboral.OfertaLaboralId=OfertaLaboralNewInput.OfertaLaboralId;
            var response = ofertaLaboralService.Modificar(ofertaLaboral);
            if (!response.Error)
            {
                var informacionOfertaLaboralViewModel = new InformacionOfertaLaboralViewModel(ofertaLaboral);
                await _hubContext.Clients.All.SendAsync("ModificarOfertaLaboral",OfertaLaboralNewInput);
                return Ok(informacionOfertaLaboralViewModel);
            }
            ModelState.AddModelError("Modificar Oferta Laboral", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
        }






        [HttpGet("api/OfertaLaboralId/{Id}")]
        public ActionResult<OfertaLaboralViewModel> GetOfertaLaboralId(int Id)
        {
            var response = ofertaLaboralService.BuscarConEmpresaPostulacionesPorId(Id);
            if (!response.Error)
            {
                var informacionOfertaLaboralViewModel = new OfertaLaboralViewModel(response.OfertaLaboral);
                return Ok(informacionOfertaLaboralViewModel);
            }
            return BadRequest(response.Mensaje);
        }














        [HttpGet]
        public ActionResult<IEnumerable<InformacionOfertaLaboralViewModel>> GetOfertaLaboral()
        {
            var response = ofertaLaboralService.Consultar();
            if (!response.Error)
            {
                var informacionOfertaLaboralViewModels = response.OfertasLaborales.Select(p => new InformacionOfertaLaboralViewModel(p));
                return Ok(informacionOfertaLaboralViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private OfertaLaboral MapearOfertaLaboral(OfertaLaboralInputModel ofertaLaboralInput)
        {
            var ofertaLaboral = new OfertaLaboral()
            {
            Descripcion=ofertaLaboralInput.Descripcion,
            Salario=ofertaLaboralInput.Salario,
            Cargo=ofertaLaboralInput.Cargo,
            Horario=ofertaLaboralInput.Horario,
            };
            return ofertaLaboral;
        }
    }
}
