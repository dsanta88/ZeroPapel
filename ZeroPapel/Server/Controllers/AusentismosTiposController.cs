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
    public class AusentismosTiposController : ControllerBase
    {
        AusentismosTiposDA datos = new AusentismosTiposDA();

        [HttpGet("[action]/{empresaId}")]
        public IActionResult GetAusentismosTipos(int empresaId)
        {
            Response response = new Response();
            try
            {
                List<AusentismoTipo> list = datos.AusentismosTiposObtener(empresaId, -1);
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
                AusentismoTipo obj = datos.AusentismosTiposObtener(-1, id).ToList().FirstOrDefault();
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
        public IActionResult Add(AusentismoTipo model)
        {
            Response response = new Response();
            try
            {
                if (datos.AusentismosTiposIngresar(model))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Error al guardar el tipo de ausentismo. Por favor comuniquese con el área de soporte.";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult Edit(AusentismoTipo model)
        {
            Response response = new Response();
            try
            {
                if (datos.AusentismosTiposEditar(model))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Error al editar el tipo de ausentismo. Por favor comuniquese con el área de soporte.";
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
                datos.AusentismosTiposEliminar(id);
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
