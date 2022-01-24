using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class LogEvento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string Fuente { get; set; }
        public string Seguimiento { get; set; }
        public bool Estado { get; set; }
    }
}
