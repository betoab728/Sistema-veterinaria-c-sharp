using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;

namespace Interfaces
{
    public interface IDetallePedido
    {
        int Agregar(DetallePedido detallePedido, ref MySqlConnection con, ref MySqlTransaction transaction);
    }
}
