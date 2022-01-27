using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class MonedaTipo
    {
        public int  Id { get; set; }
        public string Moneda { get; set; }
        public bool Estado { get; set; }

        public string EstadoDescripcion { get; set; }
    }
}
