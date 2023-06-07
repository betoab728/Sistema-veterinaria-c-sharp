using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
  public  interface IUsuario
    {

        int Agregar(Usuario usuario);
        int Editar();
        DataTable Listar();
        DataTable Login(Usuario usuario);


    }
}
