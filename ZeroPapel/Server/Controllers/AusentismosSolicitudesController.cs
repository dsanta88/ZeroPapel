using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Data;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AusentismosSolicitudesController : ControllerBase
    {
        AusentismosSolicitudesDA datos = new AusentismosSolicitudesDA();

        [HttpGet("[action]/{id}/{usuarioId}")]
        public IActionResult GetAusentismosSolicitudes(int id, int usuarioId)
        {
            Response response = new Response();
            try
            {
                List<AusentismoSolicitud> list = datos.AusentismosSolicitudesObtener(id, usuarioId);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            Response response = new Response();
            try
            {
                AusentismoSolicitud obj = datos.AusentismosSolicitudesObtener(-1, id).ToList().FirstOrDefault();
                response.IsSuccessful = true;
                response.Data = obj;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(AusentismoSolicitud model)
        {
            Response response = new Response();
            try
            {
               if( datos.AusentismosSolicitudesIngresar(model))
                {
                    response.IsSuccessful = true;
                }
               else
                {
                    response.IsSuccessful = false;
                    response.Message = "Error al registrar la solicitud del ausentismo. Por favor comuniquese con el área de soporte.";
                }
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(AusentismoSolicitud model)
        {
            Response response = new Response();
            try
            {
                datos.AusentismosSolicitudesEditar(model);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                datos.AusentismosSolicitudesEliminar(id);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
