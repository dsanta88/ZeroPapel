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
    public class EmpresasController : ControllerBase
    {
        EmpresasDA datos = new EmpresasDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();



        [HttpGet("{id}")]
        public IActionResult Get( int id)
        {
            Response response = new Response();
            try
            {
                List<Empresa> list = datos.EmpresasObtener();
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
