using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;

namespace Interfaces
{
  public  interface IMascota
    {
        int Agregar(Mascota mascota,ref MySqlConnection con,ref MySqlTransaction transaction);
    }
}
