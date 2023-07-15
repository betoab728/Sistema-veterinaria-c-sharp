using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IProducto
    {
        int Agregar(Producto producto, ProductoVitrina productoVitrina);
        int AgregarServicio(Producto producto);
        int Editar(Producto producto);
        DataTable Buscar(Producto producto);
        DataTable Listar();
        DataTable BuscarProductoCodigo(string codigo);
        DataTable ReporteStock(int idmarca, int idcategoria, int idvitrina, int stock);
        DataTable ReporteCaducidad(DateTime Fecha);

    }
}
