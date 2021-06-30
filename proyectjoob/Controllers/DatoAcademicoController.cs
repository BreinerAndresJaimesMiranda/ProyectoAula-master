using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using DatoAcademicoModel.Model;

namespace proyectjoob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatoAcademicoController : ControllerBase
    {
        private readonly DatoAcademicoService datoAcademicoService;
        private readonly HojaDeVidaService hojaDeVidaService;
        public DatoAcademicoController(ProyectjoobContext context)
        {
            datoAcademicoService = new DatoAcademicoService(context);
            hojaDeVidaService = new HojaDeVidaService(context);
        }









        [HttpPost]
        public ActionResult<InformacionDatoAcademicoViewModel> PostDatoAcademico(DatoAcademicoInputModel DatoAcademicoInput)
        {
            var buscarHojaDeVidaResponse = hojaDeVidaService.BuscarHojaDeVidaPorCorreoAspirante(DatoAcademicoInput.AspiranteId);

                if(buscarHojaDeVidaResponse.HojaDeVida==null){
                        return BadRequest("No se encuentra registrada la hoja de vida en la que desea ingresar los datos");
                }else{

            var datoAcademico = MapearDatoAcademico(DatoAcademicoInput);
            datoAcademico.HojaDeVida= buscarHojaDeVidaResponse.HojaDeVida;
            var response = datoAcademicoService.GuardarDatoAcademico(datoAcademico);
            if (!response.Error)
            {
                var informacionDatoAcademicoViewModel = new InformacionDatoAcademicoViewModel(datoAcademico);
                return Ok(informacionDatoAcademicoViewModel);
            }

            ModelState.AddModelError("Guardar Dato Academico", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);

            }
            
        }




        [HttpPost("api/ModificarDatoAcademico")]
        public ActionResult<InformacionDatoAcademicoViewModel> PostModificarDatoAcademico(DatoAcademicoInputModel datoAcademicoNewInput)
        {

            var datoAcademico = MapearDatoAcademico(datoAcademicoNewInput);
            datoAcademico.DatoAcademicoId=datoAcademicoNewInput.DatoAcademicoId;
            var response = datoAcademicoService.Modificar(datoAcademico);
            if (!response.Error)
            {
                var informacionDatoAcademicoViewModel = new InformacionDatoAcademicoViewModel(datoAcademico);
                return Ok(informacionDatoAcademicoViewModel);
            }
            ModelState.AddModelError("Modificar Dato Academico", response.Mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState);
            problemDetails.Status= 400;
            return BadRequest(problemDetails);
        }










        [HttpGet("{Id}")]
        public ActionResult<InformacionDatoAcademicoViewModel> GetDatoAcademicoId(int Id)
        { 
            var response = datoAcademicoService.BuscarPorId(Id);
            if (!response.Error)
            {
                var informacionDatoAcademicoViewModel = new InformacionDatoAcademicoViewModel(response.DatoAcademico);
                return Ok(informacionDatoAcademicoViewModel);
            }
            return BadRequest(response.Mensaje);
        }





        [HttpGet("api/Eliminar/{Id}")]
        public ActionResult<string> EliminarDatoAcademicoId(int Id)
        { 
            return Ok(datoAcademicoService.Eliminar(Id));
        }








        [HttpGet]
        public ActionResult<IEnumerable<InformacionDatoAcademicoViewModel>> GetDatoAcademico()
        {
            var response = datoAcademicoService.Consultar();
            if (!response.Error)
            {
                var informacionDatoAcademicoViewModels = response.DatosAcademicos.Select(p => new InformacionDatoAcademicoViewModel(p));
                return Ok(informacionDatoAcademicoViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private DatoAcademico MapearDatoAcademico(DatoAcademicoInputModel datoAcademicoInput)
        {
            var datoAcademico = new DatoAcademico()
            {

        NombreCentroAcademico=datoAcademicoInput.NombreCentroAcademico,
        NivelEducativo=datoAcademicoInput.NivelEducativo,
        AreaEstudio=datoAcademicoInput.AreaEstudio,
        EstadoCurso=datoAcademicoInput.EstadoCurso,
        FechaInicio=datoAcademicoInput.FechaInicio,
        FechaFinalizacion=datoAcademicoInput.FechaFinalizacion,
            };
            return datoAcademico;
        }



    }
}
