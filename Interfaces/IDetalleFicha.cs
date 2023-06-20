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
   public interface IDetalleFicha
    {
        int Agregar(DetalleFicha detalleFicha, ref MySqlConnection con, ref MySqlTransaction transaction);
        DataTable BuscarDetallea(int idficha);
    }
}
