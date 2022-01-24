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
        Mensajes mensajes = new Mensajes();

        [HttpGet("{id}/{usuarioId}/{jefeUsuarioId}")]
        public IActionResult Get(int id, int usuarioId, int jefeUsuarioId)
        {
            Response response = new Response();
            try
            {
                List<AusentismoSolicitud> list = datos.AusentismosSolicitudesObtener(id, usuarioId,jefeUsuarioId);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost()]
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
                    response.Message = mensajes.msgErrorGuardar();
                }
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        //[HttpPost]
        //public IActionResult Edit(AusentismoSolicitud model)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        if (datos.AusentismosSolicitudesEditar(model))
        //        {
        //            response.IsSuccessful = true;
        //        }
        //        else
        //        {
        //            response.IsSuccessful = false;
        //            response.Message = mensajes.msgErrorEditar();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }

        //    return Ok(response);
        //}


        [HttpPost("[action]")]
        public IActionResult EditJefe(AusentismoSolicitud model)
        {
            Response response = new Response();
            try
            {
                if (datos.AusentismosSolicitudesJefeEditar(model))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = mensajes.msgErrorEditar();
                }
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
                if (datos.AusentismosSolicitudesEliminar(id))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = mensajes.msgErrorEliminar();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
