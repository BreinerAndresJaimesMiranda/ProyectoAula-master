using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using DatoLaboralModel.Model;

namespace proyectjoob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatoLaboralController : ControllerBase
    {
        private readonly DatoLaboralService datoLaboralService;
        private readonly HojaDeVidaService hojaDeVidaService;

        public DatoLaboralController(ProyectjoobContext context)
        {
            datoLaboralService = new DatoLaboralService(context);

            hojaDeVidaService = new HojaDeVidaService(context);
        }









        [HttpPost]
        public ActionResult<InformacionDatoLaboralViewModel> PostDatoLaboral(DatoLaboralInputModel DatoLaboralInput)
        {
        var buscarHojaDeVidaResponse = hojaDeVidaService.BuscarHojaDeVidaPorCorreoAspirante(DatoLaboralInput.AspiranteId);

        if(buscarHojaDeVidaResponse.HojaDeVida==null){
                        return BadRequest("No se encuentra registrada la hoja de vida en la que desea ingresar los datos");
                }else{
            var datoLaboral = MapearDatoLaboral(DatoLaboralInput);
            datoLaboral.HojaDeVida= buscarHojaDeVidaResponse.HojaDeVida;
            var response = datoLaboralService.GuardarDatoLaboral(datoLaboral);
            if (!response.Error)
            {
                var informacionDatoLaboralViewModel = new InformacionDatoLaboralViewModel(datoLaboral);
                return Ok(informacionDatoLaboralViewModel);
            }
            ModelState.AddModelError("Guardar Dato Laboral", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
            }
        }





        [HttpPost("api/ModificarDatoLaboral")]
        public ActionResult<InformacionDatoLaboralViewModel> PostModificarDatoLaboral(DatoLaboralInputModel datoLaboralNewInput)
        {

            var datoLaboral = MapearDatoLaboral(datoLaboralNewInput);
            datoLaboral.DatoLaboralId=datoLaboralNewInput.DatoLaboralId;
            var response = datoLaboralService.Modificar(datoLaboral);
            if (!response.Error)
            {
                var informacionDatoLaboralViewModel = new InformacionDatoLaboralViewModel(datoLaboral);
                return Ok(informacionDatoLaboralViewModel);
            }
            ModelState.AddModelError("Modificar Dato Laboral", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
        }







        [HttpGet("{Id}")]
        public ActionResult<InformacionDatoLaboralViewModel> GetDatoLaboralId(int Id)
        {
            var response = datoLaboralService.BuscarPorId(Id);
            if (!response.Error)
            {
                var informacionDatoLaboralViewModel = new InformacionDatoLaboralViewModel(response.DatoLaboral);
                return Ok(informacionDatoLaboralViewModel);
            }
            return BadRequest(response.Mensaje);
        }








        [HttpGet("api/Eliminar/{Id}")]
        public ActionResult<string> EliminarDatoLaboralId(int Id)
        { 
            return Ok(datoLaboralService.Eliminar(Id));
        }





        [HttpGet]
        public ActionResult<IEnumerable<InformacionDatoLaboralViewModel>> GetDatoLaboral()
        {
            var response = datoLaboralService.Consultar();
            if (!response.Error)
            {
                var informacionDatoLaboralViewModels = response.DatosLaborales.Select(p => new InformacionDatoLaboralViewModel(p));
                return Ok(informacionDatoLaboralViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private DatoLaboral MapearDatoLaboral(DatoLaboralInputModel datoLaboralInput)
        {
            var datoLaboral = new DatoLaboral()
            {

        NombreEmpresa=datoLaboralInput.NombreEmpresa,
        Cargo=datoLaboralInput.Cargo,
        Area=datoLaboralInput.Area,
        FechaInicio=datoLaboralInput.FechaInicio,
        FechaFinalizacion=datoLaboralInput.FechaFinalizacion,

            };
            return datoLaboral;
        }



    }
}
