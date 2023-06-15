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
  public  interface IMascota
    {
        int Agregar(Mascota mascota,ref MySqlConnection con,ref MySqlTransaction transaction);
        DataTable BuscarMascotaFicha(int idccliente);
    }
}
