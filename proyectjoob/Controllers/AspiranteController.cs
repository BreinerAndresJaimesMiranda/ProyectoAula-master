using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using AspiranteModel.Model;

namespace proyectjoob.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class AspiranteController : ControllerBase
    {
        private readonly AspiranteService aspiranteService;
        public AspiranteController(ProyectjoobContext context)
        {
            aspiranteService = new AspiranteService(context);
        }









        [HttpPost]
        public ActionResult<InformacionAspiranteViewModel> PostAspirante(AspiranteInputModel AspiranteInput)
        {

            var aspirante = MapearAspirante(AspiranteInput);
            var response = aspiranteService.GuardarAspirante(aspirante);
            if (!response.Error)
            {
                var informacionAspiranteViewModel = new InformacionAspiranteViewModel(aspirante);
                return Ok(informacionAspiranteViewModel);
            }
            return BadRequest(response.Mensaje);
        }





        [HttpPost("api/ModificarAspirante")]
        public ActionResult<InformacionAspiranteViewModel> PostModificarAspirante(AspiranteInputModel AspiranteNewInput)
        {

            var aspirante = MapearAspirante(AspiranteNewInput);
            var response = aspiranteService.Modificar(aspirante);
            if (!response.Error)
            {
                var informacionAspiranteViewModel = new InformacionAspiranteViewModel(aspirante);
                return Ok(informacionAspiranteViewModel);
            }
            return BadRequest(response.Mensaje);
        }








        [HttpGet("{Correo}")]
        public ActionResult<AspiranteViewModel> GetAspiranteCorreo(string Correo)
        {
            var response = aspiranteService.BuscarConPostulacionesPorCorreo(Correo);
            if (!response.Error)
            {
                var aspiranteViewModel = new AspiranteViewModel(response.Aspirante);
                return Ok(aspiranteViewModel);
            }
            return BadRequest(response.Mensaje);
        }














        [HttpGet]
        public ActionResult<IEnumerable<InformacionAspiranteViewModel>> GetAspirante()
        {
            var response = aspiranteService.Consultar();
            if (!response.Error)
            {
                var aspiranteViewModels = response.Aspirantes.Select(p => new InformacionAspiranteViewModel(p));
                return Ok(aspiranteViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private Aspirante MapearAspirante(AspiranteInputModel aspiranteInput)
        {
            var aspirante = new Aspirante()
            {

            Correo=aspiranteInput.Correo,
            Contrasenia=aspiranteInput.Contrasenia,
            Identificacion=aspiranteInput.Identificacion,
            Nombres=aspiranteInput.Nombres,
            Apellidos=aspiranteInput.Apellidos,
            Edad=aspiranteInput.Edad,
            HorarioTrabajoPreferido=aspiranteInput.HorarioTrabajoPreferido,
            SalarioTrabajoPreferido=aspiranteInput.SalarioTrabajoPreferido,
            Telefono=aspiranteInput.Telefono,
            TipoDocumento=aspiranteInput.TipoDocumento,
            FechaNacimiento=aspiranteInput.FechaNacimiento,
            Genero=aspiranteInput.Genero,
            Pais=aspiranteInput.Pais,
            Departamento=aspiranteInput.Departamento,
            Ciudad=aspiranteInput.Ciudad,
            Nacionalidad=aspiranteInput.Nacionalidad,

            };
            return aspirante;
        }
    }


    
}
