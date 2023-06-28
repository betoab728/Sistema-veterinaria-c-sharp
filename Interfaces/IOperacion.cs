using System;
using System.Collections.Generic;
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
    }
}
