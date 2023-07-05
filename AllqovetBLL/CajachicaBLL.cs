using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using AllqovetDAO;
using Entidades;
using System.Data;

namespace AllqovetBLL
{
    public class CajachicaBLL : ICajachica,IDisposable
    {
        CajachicaDAO db = new CajachicaDAO();
        public int Agregar(CajaChica caja)
        {
            return db.Agregar(caja);
        }

        public int BuscarCajaActiva()
        {
            return db.BuscarCajaActiva();
        }

        public DataTable VentasCierre(int idcaja)
        {
            return db.VentasCierre(idcaja);
        }

        public DataTable ResumenVentasMedioPago(int idcaja)
        {
            return db.ResumenVentasMedioPago(idcaja);
        }
        public DataTable EgresosCierre(int idcaja)
        {
            return db.EgresosCierre(idcaja);
        }
        public DataTable ResumenEgresosMEdioPago(int idcaja)
        {
            return db.ResumenEgresosMEdioPago(idcaja);
        }

        public int CerrarCaja(CajaChica caja)
        {
            return db.CerrarCaja(caja);
        }

        public DataTable CobrosCierre(int idcaja)
        {
            return db.CobrosCierre(idcaja);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~CajachicaBLL() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
