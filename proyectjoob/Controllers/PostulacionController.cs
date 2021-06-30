using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using PostulacionModel.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using proyectjoob.Hubs;

namespace proyectjoob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostulacionController : ControllerBase
    {
        private readonly PostulacionService postulacionService;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly OfertaLaboralService ofertaLaboralService;
        private readonly AspiranteService aspiranteService;

        public PostulacionController(ProyectjoobContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext=hubContext;
            postulacionService = new PostulacionService(context);
            ofertaLaboralService = new OfertaLaboralService(context);
            aspiranteService=new AspiranteService(context);
        }









        [HttpPost]
        public async Task<ActionResult<InformacionPostulacionViewModel>> PostPostulacion(PostulacionInputModel PostulacionInput)
        {
            var buscarOfertaLaboralResponse=ofertaLaboralService.BuscarPorId(PostulacionInput.OfertaLaboralId);
            var buscarAspiranteResponse=aspiranteService.BuscarPorCorreo(PostulacionInput.AspiranteId);
            if(buscarOfertaLaboralResponse.OfertaLaboral == null || buscarAspiranteResponse.Aspirante == null){
                return BadRequest("La oferta Laboral o el aspirante no se encuentra registrado");
            }else{
                var postulacion = new Postulacion();
                postulacion.OfertaLaboral=buscarOfertaLaboralResponse.OfertaLaboral;
                postulacion.Aspirante = buscarAspiranteResponse.Aspirante;
                var response = postulacionService.GuardarPostulacion(postulacion);
                if (!response.Error)
                {
                    var informacionPostulacionViewModel = new InformacionPostulacionViewModel(postulacion);
                    await _hubContext.Clients.All.SendAsync("PostPostulacion",PostulacionInput);
                    return Ok(informacionPostulacionViewModel);
                }
            
            ModelState.AddModelError("Guardar Postulacion", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
            }


        } 










        [HttpGet("api/PostulacionId/{Id}")]
        public ActionResult<PostulacionViewModel> GetPostulacionId(int Id)
        {
            var response = postulacionService.BuscarConAspiranteOfertaLaboralPorId(Id);
            if (!response.Error)
            {
                var informacionPostulacionViewModel = new PostulacionViewModel(response.Postulacion);
                return Ok(informacionPostulacionViewModel);
            }
            return BadRequest(response.Mensaje);
        }














        [HttpGet]
        public ActionResult<IEnumerable<InformacionPostulacionViewModel>> GetPostulacion()
        {
            var response = postulacionService.Consultar();
            if (!response.Error)
            {
                var informacionPostulacionViewModels = response.Postulaciones.Select(p => new InformacionPostulacionViewModel(p));
                return Ok(informacionPostulacionViewModels);
            }
            return BadRequest(response.Mensaje);
        }







    }
}

