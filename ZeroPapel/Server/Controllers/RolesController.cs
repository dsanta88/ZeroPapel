﻿using ZeroPapel.Server.Data;
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
    public class RolesController : ControllerBase
    {
        RolesDA datos = new RolesDA();
        LogEventosDA logDA = new LogEventosDA();
        Mensajes mensajes = new Mensajes();

        [HttpGet("{empresaId}/{id}")]
        public IActionResult Get(int empresaId, int id)
        {
            Response response = new Response();
            try
            {
                List<Rol> list = datos.RolesObtener(empresaId, id);
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
        public IActionResult Add(Rol model)
        {
            Response response = new Response();
            try
            {
                if (datos.RolesIngresar(model))
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
        public IActionResult Edit(Rol model)
        {
            Response response = new Response();
            try
            {
                if (datos.RolesEditar(model))
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
                if (datos.RolesEliminar(id))
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
