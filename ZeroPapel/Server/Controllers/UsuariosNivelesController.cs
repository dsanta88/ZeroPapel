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
    public class UsuariosNivelesController : ControllerBase
    {
        UsuariosNivelesDA datos = new UsuariosNivelesDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}")]
        public IActionResult Get(int empresaId, int id)
        {
            Response response = new Response();
            try
            {
                List<UsuarioNivel> list = datos.UsuariosNivelesObtener(empresaId, id);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(UsuarioNivel model)
        {
            Response response = new Response();
            try
            {
                if (datos.UsuariosNivelesIngresar(model))
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
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult Edit(UsuarioNivel model)
        {
            Response response = new Response();
            try
            {
                if (datos.UsuariosNivelesEditar(model))
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
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                if (datos.UsuariosNivelesEliminar(id))
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
            }

            return Ok(response);
        }
    }
}
