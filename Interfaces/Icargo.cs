using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
   public interface Icargo
    {
        int Agregar(Cargo cargo);
        int Editar(Cargo cargo);
        DataTable Buscar(Cargo cargo);
        DataTable Listar();
    }
}
