using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;
using System.Data;

namespace Interfaces
{
  public  interface IProductoVitrina
    {
        DataTable ListarVitrinas();
        int ActualizaStockSalida(ProductoVitrina productoVitrina, ref MySqlConnection con, ref MySqlTransaction transaction);
        int ActualizaStockEntrada(ProductoVitrina productoVitrinaa, ref MySqlConnection con, ref MySqlTransaction transaction);

    }
}
