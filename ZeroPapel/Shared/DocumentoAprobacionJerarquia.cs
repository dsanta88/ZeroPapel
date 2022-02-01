using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class DocumentoAprobacionJerarquia
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int DocumentoTipoId { get; set; }
        public int RolId { get; set; }
        public int JeraquiaOrden { get; set; }
        public bool Estado { get; set; }
        public string EstadoDescripcion { get; set; }
    }
}
