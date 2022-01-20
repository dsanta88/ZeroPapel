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
    public class CargosController : ControllerBase
    {
        CargosDA datos = new CargosDA();

        [HttpGet("{empresaId}/{id}")]
        public IActionResult Get(int empresaId, int id)
        {
            Response response = new Response();
            try
            {
                List<Cargo> list = datos.CargosObtener(empresaId, -1);
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
        public IActionResult Add(Cargo model)
        {
            Response response = new Response();
            try
            {
                if (datos.CargosIngresar(model))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Error al gurdar el cargo. Por favor comuniquese con el área de soporte.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult Edit(Cargo model)
        {
            Response response = new Response();
            try
            {
                if (datos.CargosEditar(model))
                {
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Error al editar el cargo. Por favor comuniquese con el área de soporte.";
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
                datos.CargosEliminar(id);
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
