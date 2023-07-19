using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
   public interface IPermiso
    {
        int ActualizarPermisoMenu(PermisoMenu permiso, PermisoSubMenu permisoSub);
        int ActualizarPermisoSubMenu(PermisoMenu permiso);
         DataTable LeerPermisos(Usuario usuario);
    }
}
