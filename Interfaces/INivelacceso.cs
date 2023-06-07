using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface INivelacceso
    {

        int Agregar(NivelAcceso nivelacceso);
        int Editar(NivelAcceso nivelacceso);
        DataTable Listar();


    }
}
