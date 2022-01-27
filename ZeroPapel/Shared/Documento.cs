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
        public int DocumentoTipoId { get; set; }
        public int MonedaId { get; set; }
        public string ProvedorNit { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Decimal Valor { get; set; }
        public string ArchivoRuta { get; set; }
        public int UsuarioRegistroId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observacion { get; set; }


    }
}
