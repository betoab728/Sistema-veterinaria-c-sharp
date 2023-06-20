using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using MySql.Data.MySqlClient;
using Entidades;

namespace AllqovetDAO
{
    public class ProductoVitrinaDAO : IProductoVitrina,IDisposable
    {
        public int ActualizaStockEntrada()
        {
            throw new NotImplementedException();
        }

        public int ActualizaStockSalida(ProductoVitrina productoVitrina, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_ActualizaStockSalida", con, transaction))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdproducto", productoVitrina.Idproducto);
             
                cmd.Parameters.AddWithValue("pCantidad", productoVitrina.Stock);

                return cmd.ExecuteNonQuery();

            }
        }

        public int ActualizaStockEntrada(ProductoVitrina productoVitrina, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_ActualizaStockSalida", con, transaction))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdproducto", productoVitrina.Idproducto);
                cmd.Parameters.AddWithValue("pIdvitrina", productoVitrina.Idvitrina);
                cmd.Parameters.AddWithValue("pCantidad", productoVitrina.Stock);

                return cmd.ExecuteNonQuery();

            }
        }

        public DataTable ListarVitrinas()
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
        // ~ProductoVitrinaDAO() {
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
