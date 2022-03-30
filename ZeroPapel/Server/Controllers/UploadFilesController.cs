using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ZeroPapel.Shared;
using ZeroPapel.Server.Data;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {

        LogEventosDA logDA = new LogEventosDA();
        ParametrosDA parametrosDA = new ParametrosDA();
        private readonly IWebHostEnvironment enviroment;

        public UploadFilesController(IWebHostEnvironment enviroment)
        {
            this.enviroment = enviroment;
        }



        [HttpPost()]
        public IActionResult Post(Archivo model)
        {

            Response response = new Response();
            try
            {
                string archivo = model.Base64;


                //Valida
                if (model.Base64.IndexOf("data:image/jpeg;base64,") == 0)
                {
                    model.Base64 = model.Base64.Replace("data:image/jpeg;base64,", "");
                }

                //Convierte a Bites
                var bytesss = Convert.FromBase64String(model.Base64);

                string documentoRuta = parametrosDA.ParametrosObtener(model.EmpresaId, -1, "DocumentoRuta").FirstOrDefault().Valor.Trim();
              

                 string path = documentoRuta+@"/" + model.Nombre;
                using (var imageFile = new FileStream(path, FileMode.Create))
                {
                    imageFile.Write(bytesss, 0, bytesss.Length);
                    imageFile.Flush();
                }
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccessful = false;
                logDA.LogEventoIngresar(ex);
            }

            return Ok(response);
        }

    }
}
