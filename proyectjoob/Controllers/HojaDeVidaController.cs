using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using HojaDeVidaModel.Model;

namespace proyectjoob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HojaDeVidaController : ControllerBase
    {
        private readonly HojaDeVidaService hojaDeVidaService;
        private readonly AspiranteService aspiranteService;
        public HojaDeVidaController(ProyectjoobContext context)
        {
            hojaDeVidaService = new HojaDeVidaService(context);
            aspiranteService=new AspiranteService(context);
        }









        [HttpPost]
        public ActionResult<InformacionHojaDeVidaViewModel> PostHojaDeVida(HojaDeVidaInputModel HojaDeVidaInput)
        {
            var buscarAspiranteResponse=aspiranteService.BuscarPorCorreo(HojaDeVidaInput.AspiranteId);
            if(buscarAspiranteResponse.Aspirante==null){
                return BadRequest("El aspirante no se encuentra registrado");
            }else{
                var hojaDeVida = MapearHojaDeVida(HojaDeVidaInput);
                hojaDeVida.Aspirante=buscarAspiranteResponse.Aspirante;
                var response = hojaDeVidaService.GuardarHojaDeVida(hojaDeVida);
                if (!response.Error)
                {
                    var informacionHojaDeVidaViewModel = new InformacionHojaDeVidaViewModel(hojaDeVida);
                    return Ok(informacionHojaDeVidaViewModel);
                }
            
            return BadRequest(response.Mensaje);
            }


        } 





        [HttpPost("api/ModificarHojaDeVida")]
        public ActionResult<InformacionHojaDeVidaViewModel> PostModificarHojaDeVida(HojaDeVidaInputModel HojaDeVidaNewInput)
        {

            var hojaDeVida = MapearHojaDeVida(HojaDeVidaNewInput);
            hojaDeVida.HojaDeVidaId=HojaDeVidaNewInput.HojaDeVidaId;
            var response = hojaDeVidaService.Modificar(hojaDeVida);
            if (!response.Error)
            {
                var informacionHojaDeVidaViewModel = new InformacionHojaDeVidaViewModel(hojaDeVida);
                return Ok(informacionHojaDeVidaViewModel);
            }
            return BadRequest(response.Mensaje);
        }








        [HttpGet("{Correo}")]
        public ActionResult<HojaDeVidaViewModel> GetHojaDeVidaId(string Correo)
        {
            var response = hojaDeVidaService.BuscarHojaDeVidaPorCorreoAspirante(Correo);
            if (!response.Error)
            {
                var informacionHojaDeVidaViewModel = new HojaDeVidaViewModel(response.HojaDeVida);
                return Ok(informacionHojaDeVidaViewModel);
            }
            return BadRequest(response.Mensaje);
        }
















        [HttpGet]
        public ActionResult<IEnumerable<InformacionHojaDeVidaViewModel>> GetHojaDeVida()
        {
            var response = hojaDeVidaService.Consultar();
            if (!response.Error)
            {
                var informacionHojaDeVidaViewModels = response.HojasDeVida.Select(p => new InformacionHojaDeVidaViewModel(p));
                return Ok(informacionHojaDeVidaViewModels);
            }
            return BadRequest(response.Mensaje);
        }






        private HojaDeVida MapearHojaDeVida(HojaDeVidaInputModel hojaDeVidaInput)
        {
            var hojaDeVida = new HojaDeVida()
            {
            Nombre=hojaDeVidaInput.Nombre,
            DescripcionPerfilLaboral=hojaDeVidaInput.DescripcionPerfilLaboral,
            };
            return hojaDeVida;
        }
    }
}
