using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;

namespace AllqovetDAO
{
    class DetalleVEntaDAO : IDetalleVenta, IDisposable
    {
        public int Agregar(DetalleVenta detalleVenta, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarDetalleVenta", con, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdventa", detalleVenta.Idventa);
                cmd.Parameters.AddWithValue("pIdproducto", detalleVenta.Idproducto);
                cmd.Parameters.AddWithValue("pDescripcion", detalleVenta.Descripcion);
                cmd.Parameters.AddWithValue("pCantidad", detalleVenta.Cantidad);
                cmd.Parameters.AddWithValue("pPrecio", detalleVenta.Precio);
                cmd.Parameters.AddWithValue("pCosto", detalleVenta.Costo);

                return cmd.ExecuteNonQuery();
            }
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
        // ~DetalleVEntaDAO() {
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
