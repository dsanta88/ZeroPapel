using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class DiaFestivo
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string FechaStr { get; set; }
    }
}
