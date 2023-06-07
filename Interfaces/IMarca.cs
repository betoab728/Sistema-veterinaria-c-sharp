using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
    public interface IMarca
    {
        int Agregar(Marca marca);
        int Editar(Marca marca);
        DataTable Buscar(Marca marca);
        DataTable Listar();
    }
}
