using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
  public  interface IOperacion
    {
        int Agregar(Operacion operacion);
        int AgregarPagoVenta(Operacion operacion);
        int AgregarMovimiento(Operacion operacion);
        DataTable BuscarMovCajaFechas(DateTime desde, DateTime hasta, int idmediopago, int idtipoOperacion);
        DataTable BuscarMovCajaActual(int idcajachica, int idmediopago, int idTipoOperacion);
    }
}
