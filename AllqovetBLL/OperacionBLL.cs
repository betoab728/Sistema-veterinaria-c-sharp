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
   public class OperacionBLL : IOperacion,IDisposable
    {
        OperacionDAO db = new OperacionDAO();
        public int Agregar(Operacion operacion)
        {
            throw new NotImplementedException();
        }

        public int AgregarPagoVenta(Operacion operacion)
        {
           return db.AgregarPagoVenta(operacion);
        }
        public int AgregarMovimiento(Operacion operacion)
        {
            return db.AgregarMovimiento(operacion);
        }

        public DataTable BuscarMovCajaFechas(DateTime desde, DateTime hasta, int idmediopago, int idtipoOperacion)
        {
            return db.BuscarMovCajaFechas(desde ,hasta ,idmediopago, idtipoOperacion);
        }
        public DataTable BuscarMovCajaActual(int idcajachica, int idmediopago, int idTipoOperacion)
        {
            return db.BuscarMovCajaActual(idcajachica, idmediopago, idTipoOperacion);
        }
        public int Anular(int Idoperacion)
        {
            return db.Anular(Idoperacion);
        }

        public Operacion MostrarRegistro(int idopereacion)
        {
            return db.MostrarRegistro(idopereacion);
        }

        public int ActualizarMovimientoCaja(Operacion operacion)
        {
            return db.ActualizarMovimientoCaja(operacion);
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
        // ~OperacionBLL() {
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
