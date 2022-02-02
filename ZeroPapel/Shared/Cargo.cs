using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class Cargo
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool ApruebaValorDocumento { get; set; }
        public string ApruebaValorDocumentoDescripcion { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }

        public bool Estado { get; set; }
        public string EstadoDescripcion { get; set; }

        public string ValorMinimoStr { get; set; }
        public string ValorMaximoStr { get; set; }
    }
}
