using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class DocumentoEstadoCargo
    {
        public int Id { get; set; }
        public int DocumentoEstadoId { get; set; }

        public string DocumentoEstadoNombre { get; set; }


        public int CargoId { get; set; }

        public string CargoNombre { get; set; }

    }
}
