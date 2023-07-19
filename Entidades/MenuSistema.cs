using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class MenuSistema
    {
        public int idmenu { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string permiso_menu { get; set; }
        public List<SubmenuSistema> SubMenus { get; set; }
    }
}
