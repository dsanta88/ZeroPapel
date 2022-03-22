using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
  public  class RolMenuPermiso
    {
        public int RolId { get; set; }
        public int MenuId { get; set; }
        public string MenuPadre { get; set; }

        public string MenuHijo { get; set; }

        public bool RolPermiso { get; set; }

        public string ArrayMenuIds { get; set; }
    }
}
