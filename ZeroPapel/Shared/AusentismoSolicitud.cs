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
        public int JefeUsuarioId { get; set; }
        public int AusentismoTipoId  { get; set; }
        public string AusentismoTipoNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaInicioStr { get; set; }
        public string FechaFinStr { get; set; }

    
        public string Descripcion { get; set; }
        public string ArchivoRuta { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string FechaSolicitudStr { get; set; }
        public string JefeEstado { get; set; }
        public string JefeEstadoDescripcion { get; set; }

        public DateTime?  JefeFecha { get; set; }
        public int JefeUsuarioRegistroId { get; set; }
        public string JefeObservacion { get; set; }


        public string GhEstado { get; set; }
        public string GhEstadoDescripcion { get; set; }

        public DateTime? GhFecha { get; set; }
        public string GhObservacion { get; set; }
        public int GhUsuarioRegistroId { get; set; }

       



    }
}

