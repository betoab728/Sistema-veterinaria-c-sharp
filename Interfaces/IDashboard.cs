using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IDashboard
    {
        int ContarNumClientes();
        int ContarNumProveedores();
        int ContarNumProductos();
        DataTable TopProd(DashBoard dashBoard);
        DataTable Stock();

    }
}
