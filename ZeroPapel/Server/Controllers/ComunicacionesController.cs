using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Helper;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunicacionesController : ControllerBase
    {


        [HttpPost]
        public IActionResult Add(Email model)
        {
            Response response = new Response();
            try
            {
                EmailHelper emailHelper = new EmailHelper();
                emailHelper.EnviarEmail(model.Asunto, model.Mensaje);

            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
