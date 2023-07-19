using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class SubmenuSistema
    {
        public int idsubmenu { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idmenu { get; set; }
        public string permiso_submenu { get; set; }
    }
}
