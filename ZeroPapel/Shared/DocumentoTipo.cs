using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class DocumentoTipo
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int AreaTrabajoId { get; set; }

        public string Nombre { get; set; }
        public string AreaTrabajoNombre { get; set; }

        
        public bool Estado { get; set; }
        public string EstadoDescripcion { get; set; }
    }
}
