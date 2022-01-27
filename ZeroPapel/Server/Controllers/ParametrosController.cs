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
    public class ParametrosController : ControllerBase
    {
        ParametrosDA datos = new ParametrosDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("[action]/{empresaId}")]
        public IActionResult GetParametros(int empresaId)
        {
            Response response = new Response();
            try
            {
                List<Parametro> list = datos.ParametrosObtener(empresaId, -1, "-1");
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


        [HttpGet("{id}/{nombre}")]
        public IActionResult Get(int id, string nombre)
        {
            Response response = new Response();
            try
            {
                Parametro obj = datos.ParametrosObtener(-1, id, nombre).ToList().FirstOrDefault();
                response.IsSuccessful = true;
                response.Data = obj;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }




        [HttpPost("[action]")]
        public IActionResult Edit(Parametro model)
        {
            Response response = new Response();
            try
            {
                if (datos.ParametrosEditar(model))
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


    }
}
