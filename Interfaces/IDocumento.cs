using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;


namespace Interfaces
{
  public interface IDocumento
    {
        int Agregar(Documento documento);
        DataTable Listar();
    }
}
