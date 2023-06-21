using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using AllqovetDAO;
using System.Data;

namespace AllqovetBLL
{
    public class FacturaBLL : IFactura,IDisposable
    {
        FacturaDAO db = new FacturaDAO();

        public int Agregar(Factura factura, List<DetalleFactura> detalleFacturas)
        {
           return db.Agregar(factura, detalleFacturas);
        }

        public DataTable BuscarFacturaFechas(DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarFacturaRazon(string apellido)
        {
            throw new NotImplementedException();
        }

        public Factura Correlativo()
        {
           return db.Correlativo();
        }

        public DataTable DetalleFactura(int idfactura)
        {
            throw new NotImplementedException();
        }

        public DataTable ImprimiFactura(int idfactura)
        {
            throw new NotImplementedException();
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
        // ~FacturaBLL() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
