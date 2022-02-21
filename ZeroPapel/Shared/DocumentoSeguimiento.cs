using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class DocumentoSeguimiento
    {

        public int Id { get; set; }
        public int DocumentoId { get; set; }

        public int DocumentoEstadoId { get; set; }
        public int JerarquiaOrden { get; set; }
        public string Comentario { get; set; }

        public string Observacion { get; set; }
        public int UsuarioRegistroId { get; set; }

        public string UsuarioNombre { get; set; }

        public string EstadoDescripcion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string FechaRegistroStr { get; set; }

    }
}
