using Microsoft.AspNetCore.Http;
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
    public class DocumentosEstadosCargosController : ControllerBase
    {
        DocumentosEstadosCargoDA datos = new DocumentosEstadosCargoDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{documentoEstadoId}")]
        public IActionResult Get(int documentoEstadoId)
        {
            Response response = new Response();
            try
            {
                List<DocumentoEstadoCargo> list = datos.DocumentosEstadosCargoObtener(documentoEstadoId);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(DocumentoEstadoCargo model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosEstadosCargoIngresar(model))
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
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosEstadosCargosEliminar(id))
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
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }

    }
}

