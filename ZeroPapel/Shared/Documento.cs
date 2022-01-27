using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class Documento
    {

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string CentroCostoId { get; set; }
        public string CentroCostoNombre { get; set; }
        public int DocumentoTipoId { get; set; }
        public string DocumentoTipoNombre { get; set; }
        public int MonedaId { get; set; }
        public string MonedaNombre { get; set; }
        public string ProveedorNit { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string FechaRecepcionStr { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string FechaExpedicionStr { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string FechaVencimientoStr { get; set; }
        public Decimal Valor { get; set; }
        public string ArchivoRuta { get; set; }
        public int UsuarioRegistroId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroStr { get; set; }
        public string Observacion { get; set; }

        public string ArchivoNombre { get; set; }


    }
}
