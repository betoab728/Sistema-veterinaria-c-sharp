using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;


namespace Interfaces
{
  public  interface IBoleta
    {
        int Agregar( Boleta boleta, List<DetalleBoleta> detalleBoletas);
        Boleta Correlativo();
        DataTable ImprimiBoleta(int idboleta);
        DataTable BuscarBoletaFechas(DateTime desde, DateTime hasta);
        DataTable BuscarBoletaApellidos(string apellido);
        DataTable DetalleBoleta(int idboleta);
    }
}
