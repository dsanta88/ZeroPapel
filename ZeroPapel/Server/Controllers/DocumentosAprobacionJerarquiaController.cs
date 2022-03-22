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
    public class DocumentosAprobacionJerarquiaController : ControllerBase
    {
        DocumentosAprobacionJerarquiaDA datos = new DocumentosAprobacionJerarquiaDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}/{documentoTipoId}")]
        public IActionResult Get(int empresaId, int id, int documentoTipoId)
        {
            Response response = new Response();
            try
            {
                List<DocumentoAprobacionJerarquia> list = datos.DocumentosAprobacionJerarquiaObtener(empresaId, id, documentoTipoId);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(DocumentoAprobacionJerarquia model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosAprobacionJerarquiaIngresar(model))
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

        [HttpPost("[action]")]
        public IActionResult Edit(DocumentoAprobacionJerarquia model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosAprobacionJerarquiaEditar(model))
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
                if (datos.DocumentosAprobacionJerarquiaEliminar(id))
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


        [HttpGet("[action]/{empresaId}/{documentoTipoId}/{jeraquiaOrden}")]
        public IActionResult DocumentosAprobacionJerarquiaValidarOrden(int empresaId,int documentoTipoId, int jeraquiaOrden)
        {
            Response response = new Response();
            try
            {
                Validacion valid = datos.DocumentosAprobacionJerarquiaValidarOrden(empresaId, documentoTipoId, jeraquiaOrden);
                response.IsSuccessful = true;
                response.Data = valid;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
