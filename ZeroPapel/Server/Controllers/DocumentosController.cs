using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Data;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {

        private readonly IWebHostEnvironment enviroment;
        DocumentosDA datos = new DocumentosDA();
        Mensajes mensajes = new Mensajes();
        LogEventosDA logDA = new LogEventosDA();

        public DocumentosController(IWebHostEnvironment enviroment)
        {
            this.enviroment = enviroment;
        }


        [HttpGet("{empresaId}/{id}/{usuarioId}")]
        public IActionResult Get(int empresaId, int id, int usuarioId)
         {
            Response response = new Response();
            try
            {
                List<Documento> list = datos.DocumentosObtener(empresaId, id, usuarioId);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }


        [HttpPost("[action]")]
        public IActionResult guardar(Documento model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosIngresar(model))
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
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult Edit(Documento model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosEditar(model))
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
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentosEliminar(id))
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
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }
    }
}
