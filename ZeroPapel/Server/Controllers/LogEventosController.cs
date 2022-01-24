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
    public class LogEventosController : ControllerBase
    {

        LogEventosDA datos = new LogEventosDA();


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Response response = new Response();
            try
            {
                List<LogEvento> list = datos.LogEventosObtener(id);
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
