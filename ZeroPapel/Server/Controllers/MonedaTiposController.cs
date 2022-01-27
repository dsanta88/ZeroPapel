using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Data;
using ZeroPapel.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaTiposController : ControllerBase
    {
        MonedaTiposDA datos = new MonedaTiposDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}")]
        public IActionResult Get(int empresaId, int id)
        {
            Response response = new Response();
            try
            {
                List<MonedaTipo> list = datos.MonedaTiposObtener(empresaId, id);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

    }
}
