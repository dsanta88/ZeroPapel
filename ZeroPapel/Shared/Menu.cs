using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
   public class Menu
    {

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int PadreId { get; set; }
        public string PadreNombre { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }

        public string Link { get; set; }
        public bool Estado { get; set; }
        public string Icono { get; set; }
        public int UsuarioRegistroId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
