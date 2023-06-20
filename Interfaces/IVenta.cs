using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Interfaces
{
  public  interface IVenta
    {
        int Agregar(Venta venta, List<DetalleVenta> detalleVentas, List<ProductoVitrina> productoVitrinas, Movimiento movimiento, List<Salida> salidas);
        Venta Correlativo();
        DataTable ImprimirVenta(int idvent);
        DataTable BuscarVentaFechas(DateTime desde, DateTime hasta);
        DataTable BuscarVentaApellidos(string apellido);
        DataTable DetalleVenta(int idventa);

    }
}
