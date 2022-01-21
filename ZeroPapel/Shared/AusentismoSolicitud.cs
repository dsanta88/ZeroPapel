using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class AusentismoSolicitud
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int AusentismoTipoId  { get; set; }
        public string AusentismoTipoNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaInicioStr { get; set; }
        public string FechaFinStr { get; set; }

    
        public string Descripcion { get; set; }
        public string ArchivoRuta { get; set; }
        public string Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public int UsuarioRegistroId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroStr { get; set; }
    }
}

