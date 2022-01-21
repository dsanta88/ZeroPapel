using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroPapel.Server.Controllers
{
    public class Mensajes
    {
        public string msgErrorGuardar()
        {
            return "Error al guardar la información. Por favor comuniquese con el area de soporte.";
        }
        public string msgErrorEditar()
        {
            return "Error al editar la información. Por favor comuniquese con el area de soporte.";
        }
        public string msgErrorEliminar()
        {
            return "Error al guardar el registro. Por favor comuniquese con el area de soporte.";
        }
    }
}
