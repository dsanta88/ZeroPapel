using ZeroPapel.Server.Data;
using ZeroPapel.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        MenuDA datos = new MenuDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}")]
        public IActionResult Get(int empresaId, int id)
        {
            Response response = new Response();
            try
            {
                List<Menu> list = datos.MenuObtener(empresaId, id);
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
