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
    public class DocumentosSeguimientoController : ControllerBase
    {
        DocumentosSeguimientoDA datos = new DocumentosSeguimientoDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();


        [HttpGet("{documentoId}")]
        public IActionResult Get(int documentoId)
        {
            Response response = new Response();
            try
            {
                List<DocumentoSeguimiento> list = datos.DocumentoSeguimientoObtener(documentoId).ToList();
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


        [HttpPost]
        public IActionResult Add(DocumentoSeguimiento model)
        {
            Response response = new Response();
            try
            {
                if (datos.DocumentoSeguimientoIngresar(model))
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
    }
}
