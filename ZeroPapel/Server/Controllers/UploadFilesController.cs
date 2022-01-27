using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        private readonly IWebHostEnvironment enviroment;

        public UploadFilesController(IWebHostEnvironment enviroment)
        {
            this.enviroment = enviroment;
        }



        [HttpPost()]
        public IActionResult ProcesarArchivo(Archivo model)
        {

            string archivo = model.Base64;


            //Valida
            if (model.Base64.IndexOf("data:image/jpeg;base64,") == 0)
            {
                model.Base64 = model.Base64.Replace("data:image/jpeg;base64,", "");
            }

            //Convierte a Bites
            var bytesss = Convert.FromBase64String(model.Base64);

            //Guarda en Disco
            string path = Path.Combine(enviroment.ContentRootPath, "upload", model.Nombre);
            //string ruta = @"D:\SELENE SOFTWARE\Proyectos2022\ZeroPapel\ZeroPapel\Server\Controllers\upload\ejemplo.pdf";
            using (var imageFile = new FileStream(path, FileMode.Create))
            {
                imageFile.Write(bytesss, 0, bytesss.Length);
                imageFile.Flush();
            }

            return Ok();
        }

        //[HttpPost]
        //public async Task Post()
        //{
        //    if (HttpContext.Request.Form.Files.Any())
        //    {
        //        foreach (var file in HttpContext.Request.Form.Files)
        //        {
        //            var path = Path.Combine(enviroment.ContentRootPath, "upload", file.Name);

        //            using (var stream=new FileStream(path, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //        }

        //    }
        //}

    }
}
