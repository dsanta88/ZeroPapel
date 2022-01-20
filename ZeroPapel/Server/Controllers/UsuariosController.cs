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
    public class UsuariosController : ControllerBase
    {
        UsuariosDA datos = new UsuariosDA();

        [HttpGet("[action]/{empresaId}")]
        public IActionResult GetUsuarios(int empresaId)
        {
            Response response = new Response();
            try
            {
                List<Usuario> list = datos.UsuariosObtener(empresaId, -1);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            Response response = new Response();
            try
            {
                Usuario obj = datos.UsuariosObtener(-1, id).ToList().FirstOrDefault();
                response.IsSuccessful = true;
                response.Data = obj;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(Usuario model)
        {
            Response response = new Response();
            try
            {
                datos.UsuariosIngresar(model);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult Edit(Usuario model)
        {
            Response response = new Response();
            try
            {
                datos.UsuariosEditar(model);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                datos.UsuariosEliminar(id);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
