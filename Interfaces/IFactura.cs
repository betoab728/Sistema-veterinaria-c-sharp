using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Interfaces
{
   public interface IFactura
    {
        int Agregar(Factura factura, List<DetalleFactura> detalleFacturas);
        Factura Correlativo();
        DataTable ImprimiFactura(int idfactura);
        DataTable BuscarFacturaFechas(DateTime desde, DateTime hasta);
        DataTable BuscarFacturaRazon(string apellido);
        DataTable DetalleFactura(int idfactura);
    }
}
