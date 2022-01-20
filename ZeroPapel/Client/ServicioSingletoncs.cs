using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroPapel.Client
{
    public class ServicioSingleton
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        public string Email { get; set; }

        public string Rol { get; set; }

        public bool IsLogueado { get; set; }

        public int EmpresaId { get; set; }

        public string EmpresaNombre { get; set; }

        public string EmpresaLogo { get; set; }

        public ServicioSingleton()
        {
            UsuarioId = 0;
            NombreUsuario = "";
            Email = "";
            Rol = "";
        }
    }
}

