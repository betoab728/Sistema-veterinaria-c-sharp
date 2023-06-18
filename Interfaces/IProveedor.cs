using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IProveedor
    {
        int Agregar(Proveedor proveedor);
        int Editar(Proveedor proveedor);
        DataTable BuscarRazonSocial(Proveedor proveedor);
        DataTable BuscarRuc(Proveedor proveedor);
        DataTable Listar();
        int ContarNumProveedores(Proveedor proveedor);
    }
}
