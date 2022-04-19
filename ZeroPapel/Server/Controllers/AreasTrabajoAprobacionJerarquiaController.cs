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
    public class AreasTrabajoAprobacionJerarquiaController : ControllerBase
    {
        AreasTrabajoAprobacionJerarquiaDA datos = new AreasTrabajoAprobacionJerarquiaDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}/{areaTrabajoId}")]
        public IActionResult Get(int empresaId, int id, int areaTrabajoId)
        {
            Response response = new Response();
            try
            {
                List<AreaTrabajoAprobacionJerarquia> list = datos.AreasTrabajoAprobacionJerarquiaObtener(empresaId, id, areaTrabajoId);
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
        public IActionResult Add(AreaTrabajoAprobacionJerarquia model)
        {
            Response response = new Response();
            try
            {
                if (datos.AreasTrabajoAprobacionJerarquiaIngresar(model))
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
        public IActionResult Edit(AreaTrabajoAprobacionJerarquia model)
        {
            Response response = new Response();
            try
            {
                if (datos.AreasTrabajoAprobacionJerarquiaEditar(model))
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
                if (datos.AreasTrabajoAprobacionJerarquiaEliminar(id))
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


        [HttpGet("[action]/{empresaId}/{areaTrabajoId}/{jeraquiaOrden}")]
        public IActionResult AreasTrabajoAprobacionJerarquiaValidarOrden(int empresaId,int areaTrabajoId, int jeraquiaOrden)
        {
            Response response = new Response();
            try
            {
                Validacion valid = datos.AreasTrabajoAprobacionJerarquiaValidarOrden(empresaId, areaTrabajoId, jeraquiaOrden);
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
