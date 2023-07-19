using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public class Permiso
    {
        public int idpermiso { get; set; }
        public int idnivel { get; set; }
        public string permiso_menu { get; set; }
        public int idsubmenu { get; set; }
        public int idmenu { get; set; }
        public string permiso_submenu { get; set; }

    }
}
