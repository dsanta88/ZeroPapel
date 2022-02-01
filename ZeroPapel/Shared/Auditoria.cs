using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class Auditoria
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Accion { get; set; }
        public string Mensaje { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public string Tabla { get; set; }
        public string Usuario { get; set; }
        public string UsuarioNombre { get; set; }
        public int UsuarioRegistroId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
