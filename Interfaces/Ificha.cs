using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
  public  interface Ificha
    {
        int Agregar( Ficha ficha, List<DetalleFicha> detalleFichas);
        int Editar(Ficha ficha, List<DetalleFicha> detalleFichas);
        DataTable Buscar(Ficha ficha);
        DataTable Listar();
        string CorrelativoFicha();
        DataTable Imprimir(int idficha);
        DataTable BuscarFichaApellido(string apellido);
        DataTable BuscarFichaDNI(string dni);
        DataTable BuscarFichaFechas(DateTime desde, DateTime hasta);
        DataTable BuscarFichaID(int idficha);

    }
}
