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
    public class RolMenuPermisosController : ControllerBase
    {
        RolMenuPermisoDA datos = new RolMenuPermisoDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();


        [HttpGet("{rolId}")]
        public IActionResult Get(int rolId)
        {
            Response response = new Response();
            try
            {
                List<RolMenuPermiso> list = datos.Obtenet(rolId);
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




        [HttpPost("[action]")]
        public IActionResult Edit(RolMenuPermiso model)
        {
            Response response = new Response();
            try
            {
                if (datos.Editar(model))
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
