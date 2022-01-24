using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class ProcesoLog
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int ProcesoCodigo { get; set; }
        public string ProcesoNombre { get; set; }

        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }

        public string Campo5 { get; set; }
        public string Campo6 { get; set; }

        public string Campo7 { get; set; }
        public string Campo8 { get; set; }

        public string Campo9 { get; set; }
        public string Campo10 { get; set; }

        public int Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public int UsuarioRegistroId { get; set; }
        public string UsuarioRegistroNombre { get; set; }
        public DateTime FechaRegistro { get; set; }


    }
}
