using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace Interfaces
{
    public interface ICajachica
    {
        int Agregar(CajaChica caja);
        int BuscarCajaActiva();
        DataTable VentasCierre(int idcaja);
        DataTable ResumenVentasMedioPago(int idcaja);
        DataTable EgresosCierre(int idcaja);
        DataTable ResumenEgresosMEdioPago(int idcaja);
        DataTable CobrosCierre(int idcaja);
        int AperturaActual();

        int CerrarCaja(CajaChica caja);
    }
}
