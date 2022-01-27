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
    public class ProveedoresController : ControllerBase
    {
        ProveedoresDA datos = new ProveedoresDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet()]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                List<Proveedor> list = datos.ProveedoresObtener();
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
