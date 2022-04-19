using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class AreaTrabajoAprobacionJerarquia
    {
        public int Id { get; set; }
        public int JerarquiaOrden { get; set; }
        public int EmpresaId { get; set; }
        public int AreaTrabajoId { get; set; }
        public string AreaTrabajoNombre { get; set; }
        public int CargoId { get; set; }
        public string CargoNombre { get; set; }
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
