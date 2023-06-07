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
        int Agregar(Producto producto);
        int Editar(Producto producto);
        DataTable Buscar(Producto producto);
        DataTable Listar();
    }
}
